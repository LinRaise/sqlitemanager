//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//      <author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;

namespace SQLiteManager.Core
{
	public class TableEventArgs : EventArgs
	{
		public Table Table { get; set; }
		
		public TableEventArgs(Table table)
		{
			this.Table = table;
		}
	}
	
	public class Table : ICloneable, IValidatable
	{
		public string Name { get; set; }
		public string Script { get; set; }
		IList<Column> columns = new List<Column>();
		public Database Database { get; set; }
        public bool IsValid { get; set; }
        public ICollection<IValidationResult> ValidationResults { get; set; }
		
		public string FullName {
			get { return string.Format("{0}.{1}", Database != null ? Database.Name : "None", Name); }
		}
		
		public IList<Column> Columns {
			get { return columns; }
			set { columns = value; }
		}
		
		public Table()
		{
            IsValid = true;
            ValidationResults = new Collection<IValidationResult>();
		}
		
		public Table(string name) : this()
		{
			Name = name;
		}
		
		public void AddColumn(Column column)
		{
			column.Table = this;
			columns.Add(column);
			OnColumnAdd(null);
		}
		
		public event EventHandler ColumnAdded;
		
		public DataTable LoadData()
		{
			DataTable dt = new DataTable();
			if (Database != null) {
				SQLiteDataAdapter da = new SQLiteDataAdapter(string.Format("select * from {0}", Name), Database.CreateConnection());
				da.Fill(dt);
			}
			return dt;
		}
		
		public static IList<Table> Load(Database database)
		{
			IList<Table> tables = new List<Table>();
			using (var conn = database.CreateConnection()) {
				conn.Open();
				using (var trans = conn.BeginTransaction()) {
					using (var cmd = new SQLiteCommand("select * from sqlite_master where type='table' order by tbl_name", conn)) {
						using (var reader = cmd.ExecuteReader()) {
							while (reader.Read()) {
								tables.Add(
									new Table {
										Database = database,
										Name = reader["tbl_name"].ToString(),
										Script = reader["sql"].ToString()
									}
								);
							}
						}
					}
					foreach (var table in tables) {
						using (var cmd = new SQLiteCommand("pragma table_info('" + table.Name + "')", conn)) {
							using (var reader = cmd.ExecuteReader()) {
								while (reader.Read()) {
									table.Columns.Add(
										new Column {
											Table = table,
											Name = reader["name"].ToString(),
											Type = reader["type"].ToString(),
											PrimaryKey = reader["pk"].ToString() == "1",
											Default = reader["dflt_value"] is DBNull ? null : reader["dflt_value"]
										}
									);
								}
							}
						}
					}
					trans.Commit();
				}
			}
			return tables;
		}

		public string SelectQuery
		{
			get
			{
				const string selectQuery = "select {0} {2}from {1}";
				var columnList = string.Empty;
				
				for (int i = 0; i < columns.Count; i++) {
					columnList += string.Format("{0}{1}", columns[i].Name, (i == columns.Count - 1 ? string.Empty : ","));
				}
				
				return string.Format(selectQuery, columnList, Name, Environment.NewLine);
			}
		}
		
		public override string ToString()
		{
			string cols = "";
			int i = 0;
			foreach (var c in columns) {
				cols += c.Name + " " + c.Type;
				cols += c.NotNull ? " not null" : "";
				cols += c.PrimaryKey ? " primary key" : "";
				cols += i++ < columns.Count - 1 ? ", " : "";
			}
			return string.Format("create table '{0}'({1});", Name, cols);
		}

		public object Clone()
		{
			var table = new Table
			{
				Columns = Columns,
				Database = Database,
				Name = Name,
				Script = Script,
                IsValid = IsValid,
                ValidationResults = ValidationResults
			};
			return table;
		}
		
		protected virtual void OnColumnAdd(EventArgs e)
		{
			if (ColumnAdded != null) {
				ColumnAdded(this, e);
			}
		}
	}    
}
