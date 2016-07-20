//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System.Data.SQLite;

namespace SQLiteManager.Core
{
	public static class ConnectionFactory
	{
		private const string ConnectionString = "Data Source={0};Version=3;";
		private const string ConnectionStringWithPassword = "Data Source={0};Version=3;Password={1};";
	
		public static SQLiteConnection GetConnection(Database database)
		{
			var connection = new SQLiteConnection();
			
			if (database.PasswordProtected) {
				connection.ConnectionString = string.Format(ConnectionStringWithPassword, database.FileName, database.Password);
			} else {
				connection.ConnectionString = string.Format(ConnectionString, database.FileName);
			}
			connection.Open();
			return connection;
		}
	}
}
