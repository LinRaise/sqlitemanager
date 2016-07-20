//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;

namespace SQLiteManager.Util
{
	public class DatabaseChangedEventArgs : EventArgs
	{
		private string databaseId = string.Empty;
		
		public string DatabaseId {
			get { return databaseId; }
			set { databaseId = value; }
		}
		
		public DatabaseChangedEventArgs(string databaseId)
		{
			this.databaseId = databaseId;
		}
	}
}
