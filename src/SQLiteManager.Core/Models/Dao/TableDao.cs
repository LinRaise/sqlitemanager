//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SQLiteManager.Core.Utilities;

namespace SQLiteManager.Core
{
	[Obsolete()]
	internal class TableDao : ITableDao
	{
		public void Create(Table table, Database database)
		{
			try
			{
				using (var connection = ConnectionFactory.GetConnection(database))
				{
					using (var transaction = TransactionHelper.NewTransaction())
					{
						using (var cmd = new SQLiteCommand(table.ToString(), connection))
						{
							cmd.ExecuteNonQuery();
							transaction.Complete();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageService.ShowError(ex.Message);
			}
		}

		public void Drop(Table table)
		{
			try {
				using (var connection = ConnectionFactory.GetConnection(table.Database))
				{
					using (var transaction = TransactionHelper.NewTransaction())
					{
						using (var cmd = new SQLiteCommand(string.Format("drop table '{0}'", table.Name), connection))
						{
							cmd.ExecuteNonQuery();
						}
						transaction.Complete();
					}
				}
			} catch (Exception ex) {
				MessageService.ShowError(ex.Message);
			}
		}

		public void DropIndex(string indexName, Database database)
		{
			try {
				using (var connection = ConnectionFactory.GetConnection(database)) {
					using (var cmd = new SQLiteCommand("DROP INDEX '" + indexName + "'", connection)) {
						cmd.ExecuteNonQuery();
					}
				}
			} catch (Exception exception) {
				MessageService.ShowError(exception.Message);
			}
		}

		public IList<Table> FindAll(Database database)
		{
			IList<Table> tables = new List<Table>();
			try
			{
				using (var connection = ConnectionFactory.GetConnection(database))
					using (var transaction = TransactionHelper.NewTransaction())
				{
					using (var cmd = new SQLiteCommand("select * from sqlite_master where type='table' order by tbl_name", connection)) {
						using (var reader = cmd.ExecuteReader()) {
							while (reader.Read()) {
								var table = new Table {
									Database = database,
									Name = reader["tbl_name"].ToString(),
									Script = reader["sql"].ToString()
								};
								tables.Add(table);
							}
						}
					}

					foreach (var table in tables) {
						using (var cmd = new SQLiteCommand("pragma table_info('" + table.Name + "')", connection)) {
							using (var reader = cmd.ExecuteReader()) {
								while (reader.Read()) {
									var column = new Column {
										Table = table,
										Name = reader["name"].ToString(),
										Type = reader["type"].ToString(),
										PrimaryKey = reader["pk"].ToString() == "1",
										Default =
											reader["dflt_value"] is DBNull
											? null
											: reader["dflt_value"]
									};
									table.Columns.Add(column);
								}
							}
						}
					}
					transaction.Complete();
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
			return tables;
		}

		public IList<Index> FindIndexes(Database database)
		{
			IList<Index> indexes = new List<Index>();
			try {
				using (var connection = ConnectionFactory.GetConnection(database)) {
					using (var transaction = TransactionHelper.NewTransaction()) {
						using (var cmd = new SQLiteCommand("select * from sqlite_master where type='index' order by tbl_name", connection)) {
							using (var reader = cmd.ExecuteReader()) {
								while (reader.Read())
								{
									var table = database.Tables.Where(n => n.Name.Equals(reader["tbl_name"].ToString())).First();
									var index = new Index(reader["name"].ToString(), table)
									{
										Script = reader["sql"].ToString()
									};
									indexes.Add(index);
								}
							}
						}

						foreach (var index in indexes) {
							using (var cmd = new SQLiteCommand(string.Format("pragma index_info('{0}')", index.Name), connection)) {
								using (var reader = cmd.ExecuteReader()) {
									while (reader.Read())
									{
										var column = index.Table.Columns.Where(n => n.Name.Equals(reader["name"])).First();
										index.AddColumn(column);
									}
								}
							}

							using (var cmd = new SQLiteCommand(string.Format("pragma index_list('{0}')", index.Table.Name), connection)) {
								using (var reader = cmd.ExecuteReader()) {
									while (reader.Read()) {
										if (reader["name"].ToString().Equals(index.Name)) {
											index.Unique = reader["unique"].ToString().Equals("1");
										}
									}
								}
							}
						}
						transaction.Complete();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return indexes;
		}

		public void AlterTable(Table oldTable, Table newTable)
		{
			if (oldTable == null) {
				throw new ArgumentNullException("oldTable");
			}
			if (newTable == null) {
				throw new ArgumentNullException("newTable");
			}
			try {
				using (var connection = ConnectionFactory.GetConnection(oldTable.Database)) {
					var tempTableName = oldTable.Name + Guid.NewGuid().ToString().Replace("-", "");

					//rename old table, create new table, move data, add missing columns
					var commonColumns = newTable.Columns.Intersect(oldTable.Columns).ToList();
					using (var transaction = TransactionHelper.NewTransaction()) {
						if (!string.Equals(oldTable.Name, newTable.Name)) {
							RenameTable(oldTable, tempTableName, connection);
						}

						var table = new Table {
							Name = newTable.Name,
							Columns = commonColumns,
							Database = newTable.Database
						};

						Create(table, oldTable.Database);
						transaction.Complete();
					}
					using (var transaction = TransactionHelper.NewTransaction()) {
						using (var cmd = new SQLiteCommand(connection)) {
							cmd.CommandText = string.Format(
								" INSERT INTO '{2}' SELECT {0} FROM {1} ;",
								Column.GetColumnsNames(commonColumns),
								tempTableName,
								newTable.Name
							);
							cmd.ExecuteNonQuery();
						}

						Drop(tempTableName, newTable.Database);

						var columns = newTable.Columns.Except(oldTable.Columns);

						//add missing columns
						AddColumnsToTable(newTable, columns, connection);
						transaction.Complete();
					}
				}
			}
			catch (Exception ex)
			{
				MessageService.ShowError(ex.Message);
			}
		}

		/// <summary>
		/// Drop table by name
		/// </summary>
		/// <param name="tableName">Table name</param>
		/// <param name="database">Database</param>
		private static void Drop(string tableName, Database database)
		{
			try
			{
				using (var connection = ConnectionFactory.GetConnection(database))
				{
					using (var transaction = TransactionHelper.NewTransaction())
					{
						var cmd = new SQLiteCommand(string.Format("drop table '{0}'", tableName), connection);
						cmd.ExecuteNonQuery();
						transaction.Complete();
					}
				}
			}
			catch (Exception ex)
			{
				MessageService.ShowError(ex.Message);
			}
		}

		private static void AddColumnsToTable(Table table, IEnumerable<Column> columns, SQLiteConnection connection)
		{
			var stringCommand = new StringBuilder();
			foreach (var column in columns) {
				stringCommand.Append(
					string.Format(
						" ALTER TABLE '{0}' ADD COLUMN {1} {2} {3} ;",
						table.Name,
						column.Name,
						column.Type,
						column.NotNull ? " not null" : string.Empty
					)
				);
			}
			using (var cmd = new SQLiteCommand(stringCommand.ToString(), connection)) {
				cmd.ExecuteNonQuery();
			}
		}

		private static void RenameTable(Table oldTable, string tempTableName, SQLiteConnection connection)
		{
			using (var cmd = new SQLiteCommand((string.Format("ALTER TABLE '{0}' rename TO '{1}' ;", oldTable.Name, tempTableName)), connection)) {
				cmd.ExecuteNonQuery();
			}
		}
	}
}
