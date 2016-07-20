//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using SQLiteManager.Core;
using SQLiteManager.Core.Utilities;
using SQLiteManager.Core.Views;

namespace SQLiteManager.Commands
{
	[Obsolete()]
	public class OpenDatabase : AbstractCommand
	{
		public override void Run()
		{
			using (var dialog = new OpenFileDialog()) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					DatabaseManager.Instance.AddDatabase(dialog.FileName);
				}
			}
		}
	}
	
	public class OpenDatabase2 : AbstractCommand
	{
		public override void Run()
		{
			using (OpenFileDialog d = new OpenFileDialog()) {
				d.Title = "Open Database File...";
				d.Filter = "Database Files (*.db;*.sqlite)|*.db;*.sqlite";
				if (d.ShowDialog() == DialogResult .OK) {
					(WorkbenchSingleton.Workbench as IDatabaseListView).AddDatabase(d.FileName);
				}
			}
		}
	}
	
	[Obsolete()]
	public class CloseDatabase : AbstractCommand
	{
		public override void Run()
		{
//			var currentDatabaseId = WorkbenchSingleton.MainForm.CurrentDatabaseId;
			var currentDatabaseId = WorkbenchSingleton.Workbench.CurrentDatabaseId;
			if (!string.IsNullOrEmpty(currentDatabaseId)) {
				var dialogResult = MessageBox.Show(@"Are you sure you want to close this connection?", @"Database connection close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes) {
					DatabaseManager.Instance.RemoveDatabase(currentDatabaseId);
				}
			}
		}
	}
	
	public class CloseDatabase2 : AbstractCommand
	{
		public override void Run()
		{
			IDatabaseListView v = WorkbenchSingleton.Workbench as IDatabaseListView;
			if (v.SelectedDatabase != null) {
				if (MessageService.ShowYesNo("Are you sure you want to close this connection?") == DialogResult.Yes) {
					v.RemoveDatabase(v.SelectedDatabase);
				}
			}
		}
	}
	
	public class ExportDatabase : AbstractCommand
	{
		public override void Run()
		{
//			if (Workbench.MainForm.Database != null) {
//				using (SaveFileDialog d = new SaveFileDialog()) {
//					d.FileName = Path.GetFileNameWithoutExtension(Workbench.MainForm.Database.FileName) + ".sql";
//					if (d.ShowDialog() == DialogResult.OK) {
//						using (StreamWriter w = new StreamWriter(d.FileName)) {
//							w.WriteLine(Workbench.MainForm.Database.ToString());
//						}
//					}
//				}
//			}
		}
	}
	
	[Obsolete()]
	public class CreateDatabase : AbstractCommand
	{
		public override void Run()
		{
			using (var dialog = new SaveFileDialog()) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					DatabaseManager.Instance.AddDatabase(dialog.FileName);
				}
			}
		}
	}
	
	public class CreateDatabase2 : AbstractCommand
	{
		public override void Run()
		{
			using (SaveFileDialog d = new SaveFileDialog()) {
				if (d.ShowDialog() == DialogResult.OK) {
					(WorkbenchSingleton.Workbench as IDatabaseListView).AddDatabase(d.FileName);
				}
			}
		}
	}
}
