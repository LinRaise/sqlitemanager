//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

namespace SQLiteManager.Core
{
	public interface ICommand
	{
		void Run();
	}
	
	public abstract class AbstractCommand : ICommand
	{
		public abstract void Run();
	}
}
