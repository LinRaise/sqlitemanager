//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;

namespace SQLiteManager.Gui
{
	public class TableSelectedEventArgs : EventArgs
	{
		private readonly string databaseId = string.Empty;
		private readonly string tableName = string.Empty;
		
		public string DatabaseId {
			get { return databaseId; }
		}
		
		public string TableName {
			get { return tableName; }
		}
		
		public TableSelectedEventArgs(string databaseId, string tableName)
		{
			this.databaseId = databaseId;
			this.tableName = tableName;
		}
	}
}
