//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System.Collections.Generic;

namespace SQLiteManager.Core
{
	public interface ITableDao
	{
		void Create(Table table, Database database);
		void Drop(Table table);
		IList<Table> FindAll(Database database);
//		DataTable GetResult(Table table);
	}
}
