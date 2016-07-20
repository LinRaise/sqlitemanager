//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace SQLiteManager.Core
{
	public class DatabaseManager
	{
		public event EventHandler<DatabaseEventArgs> DatabaseOpened;
		public event EventHandler<DatabaseEventArgs> DatabaseClosed;
		public event EventHandler<DatabaseEventArgs> DatabaseRefreshed;
		
		private static readonly DatabaseManager instance = new DatabaseManager();
		
		public static DatabaseManager Instance {
			get { return instance; }
		}

		readonly List<Database> databases = new List<Database>();
		
		public ReadOnlyCollection<Database> Databases {
			get { return databases.AsReadOnly(); }
		}
		
		private DatabaseManager()
		{
		}
		
		public void AddDatabase(string fileName)
		{
			if (!File.Exists(fileName)) {
				throw new FileNotFoundException(fileName);
			}

			string id = Guid.NewGuid().ToString().Replace("-", string.Empty);
			string name = Path.GetFileNameWithoutExtension(fileName);
			
			int countOfDatabasesWithSameName = (from d in databases
			                                    where d.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)
			                                    select d).Count();
			if (countOfDatabasesWithSameName > 0) {
				name = string.Format("{0}_{1}", name, countOfDatabasesWithSameName);
			}
			var database = new Database {
				Id = id,
				FileName = fileName,
				Name = name
			};
			
			database.LoadTableStructure();
			database.LoadIndexes();
			databases.Add(database);
			
			if (DatabaseOpened != null) {
				DatabaseOpened(this, new DatabaseEventArgs(database));
			}
		}
		
		public void RemoveDatabase(string databaseId)
		{
			var database = FindDatabase(databaseId);
			
			if (database != null) {
				databases.Remove(database);
				
				if (DatabaseClosed != null) {
					DatabaseClosed(this, new DatabaseEventArgs(database));
				}
			}
		}
		
		public void RefreshDatabase(string databaseId)
		{
			var database = FindDatabase(databaseId);
			
			if (database != null) {
				database.LoadTableStructure();
				database.LoadIndexes();
				
				if (DatabaseRefreshed != null) {
					DatabaseRefreshed(this, new DatabaseEventArgs(database));
				}
			}
		}
		
		public void CreateTable(string databaseId, Table table)
		{
			var database = FindDatabase(databaseId);
			
			if (database != null) {
				(new TableDao()).Create(table, database);
				RefreshDatabase(databaseId);
			}
		}
		
		public void DropTable(string databaseId, string tableName)
		{
			var table = FindTable(databaseId, tableName);
			
			if (table != null) {
				(new TableDao()).Drop(table);
				RefreshDatabase(databaseId);
			}
		}
		
		public Table FindTable(string databaseId, string tableName)
		{
			Database database = FindDatabase(databaseId);
			
			if (database == null) {
				return null;
			}
			database.LoadTableStructure();
			return (from t in database.Tables
			        where t.Name.Equals(tableName, StringComparison.CurrentCultureIgnoreCase)
			        select t).FirstOrDefault();
		}
		
		public Result GetAllData(string databaseId, string tableName)
		{
			Table table = FindTable(databaseId, tableName);
			return ExecuteSingleQuery(databaseId, table.SelectQuery);
		}
		
		public Result ExecuteSingleQuery(string databaseId, string query)
		{
			var results = ExecuteMultiQuery(databaseId, query);
			
			if (results == null) {
				return null;
			}
			return results.FirstOrDefault();
		}
		
		public ReadOnlyCollection<Result> ExecuteMultiQuery(string databaseId, string query)
		{
			var database = FindDatabase(databaseId);
			if (database == null) {
				throw new ArgumentException("Database not found");
			}
			return (new Query(database, query)).ExecuteQuery();
		}
		
		public Database FindDatabase(string databaseId)
		{
			return (from d in databases
			        where d.Id.Equals(databaseId, StringComparison.CurrentCultureIgnoreCase)
			        select d).FirstOrDefault();
		}

		public void AlterTable(Table oldTable, Table newTable)
		{
			(new TableDao()).AlterTable(oldTable, newTable);
			RefreshDatabase(oldTable.Database.Id);
		}

		public Index FindIndex(string databaseId, string indexName)
		{
			var database = FindDatabase(databaseId);
			var index = database.Indexes.Where(n => n.Name == indexName).FirstOrDefault();
			return index;
		}

		public Result CreateIndex(string databaseId, Index index)
		{
			if (string.IsNullOrEmpty(databaseId)) {
				throw new ArgumentNullException("databaseId");
			}

			if (index == null) {
				throw new ArgumentNullException("index");
			}

			var result = ExecuteSingleQuery(databaseId, index.ToString());

			RefreshDatabase(databaseId);
			return result;
		}

		public void DropIndex(string databaseId, string indexName)
		{
			if (string.IsNullOrEmpty(databaseId)) {
				throw new ArgumentNullException("databaseId");
			}

			if (indexName == null) {
				throw new ArgumentNullException("indexName");
			}
			
			var database = FindDatabase(databaseId);
			new TableDao().DropIndex(indexName, database);
			RefreshDatabase(databaseId);
		}
	}
}
