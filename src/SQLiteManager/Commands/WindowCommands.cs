//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using SQLiteManager.Core;

namespace SQLiteManager.Commands
{
	public class CloseWindow : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.CloseWindow();
			WorkbenchSingleton.Workbench.CloseWindow();
		}
	}
	
	public class CloseAllWindow : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.CloseAllWindow();
			WorkbenchSingleton.Workbench.CloseAllWindows();
		}
	}
}
