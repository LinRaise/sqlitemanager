//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;

namespace SQLiteManager.Core
{
	public class DatabaseEventArgs : EventArgs
	{
	    public Database Database { get; set; }

	    public DatabaseEventArgs(Database database)
		{
			Database = database;
		}
	}
}
