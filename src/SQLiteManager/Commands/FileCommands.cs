//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Core;
using SQLiteManager.Core.Views;

namespace SQLiteManager.Commands
{
	[Obsolete()]
	public class OpenFile : AbstractCommand
	{
		public override void Run()
		{			
//			WorkbenchSingleton.MainForm.OpenSqlFileInEditor();
			WorkbenchSingleton.Workbench.OpenSqlFileInEditor();
		}
	}
	
	public class OpenFile2 : AbstractCommand
	{
		public override void Run()
		{
			using (OpenFileDialog d =  new OpenFileDialog()) {
				d.Title = "Open SQL Script...";
				d.Filter = "SQL Scripts (*.sql)|*.sql|All Files (*.*)|*.*";
				if (d.ShowDialog() == DialogResult.OK) {
					(WorkbenchSingleton.Workbench as IDatabaseListView).AddQuery(d.FileName);
				}
			}
		}
	}
	
	[Obsolete()]
	public class SaveFile : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.SaveCurrentEditor();
			WorkbenchSingleton.Workbench.SaveCurrentEditor();
		}
	}
	
	public class SaveFile2 : AbstractCommand
	{
		public override void Run()
		{
//			(WorkbenchSingleton.Workbench as IDatabaseListView).Save();
		}
	}
	
	[Obsolete()]
	public class SaveFileAs : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.SaveCurrentEditorAs();
			WorkbenchSingleton.Workbench.SaveCurrentEditorAs();
		}
	}
	
	public class SaveFileAs2 : AbstractCommand
	{
		public override void Run()
		{
//			(WorkbenchSingleton.Workbench as IDatabaseListView).SaveFileAs();
		}
	}
	
	public class ExitCommand : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.Close();
			(WorkbenchSingleton.Workbench as Form).Close();
		}
	}
}
