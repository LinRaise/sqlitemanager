//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

namespace SQLiteManager.Util
{
	public interface IDatabaseDepedentControl
	{
		string DatabaseId { get; }
		string TableName { get; }
	}
}
