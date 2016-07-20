//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using SQLiteManager.Core;
using SQLiteManager.Gui;

namespace SQLiteManager.Commands
{
	public class ShowAbout : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.AddDialog(new AboutForm());
			WorkbenchSingleton.ShowDialogView(new AboutForm());
		}
	}
}
