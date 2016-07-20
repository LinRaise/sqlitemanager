//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using SQLiteManager.Core;
using SQLiteManager.Util;

namespace SQLiteManager
{
	public partial class BaseDatabaseDependentControl : BaseUserControl, IDatabaseDepedentControl
	{
		private string databaseId = string.Empty;
		private string tableName = string.Empty;
		
		public string DatabaseId {
			get {
				return databaseId;
			}
			
			set {
				databaseId = value;
				OnDatabaseChanged(DatabaseManager.Instance.FindDatabase(value));
			}
		}
		
		public string TableName {
			get { return tableName; }
			set { tableName = value; }
		}

		protected virtual void OnDatabaseChanged(Database database)
		{
		}
	}
}
