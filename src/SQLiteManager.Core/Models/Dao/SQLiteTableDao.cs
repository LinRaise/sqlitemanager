//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLiteManager.Core.Models.Dao
{
	public class SQLiteTableDao : ITableDao
	{
		public SQLiteTableDao()
		{
		}
		
		public void Create(Table table, Database database)
		{
		}
		
		public void Drop(Table table)
		{
//			using (SQLiteConnection con = Database.CreateConnection()) {
//				using (SQLiteCommand cmd = con.CreateCommand()) {
//					cmd.CommandText = string.Format();
//				}
//			}
		}
		
		public IList<Table> FindAll(Database database)
		{
			IList<Table> tables = new List<Table>();
//			using (SQLiteConnection con = database.CreateConnection()) {
//				
//			}
			return tables;
		}
	}
}
