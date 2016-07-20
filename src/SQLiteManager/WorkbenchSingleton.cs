//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Core.Views;
using SQLiteManager.Core.Workbench;

namespace SQLiteManager
{
	public static class WorkbenchSingleton
	{
		static IWorkbench workbench;
		
		public static IWorkbench Workbench {
			get { return workbench; }
		}
		
//		public static MainForm MainForm {
//			get { return workbench as MainForm; }
//		}
		
		public static Form MainForm {
			get { return workbench as Form; }
		}
		
//		public static MainForm MainForm { get; private set; }

//	    public static void Attach(MainForm form)
//		{
//		            MainForm = form;
//		}
		
		public static DialogResult ShowDialogView(Form form)
		{
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterParent;
			form.MaximizeBox = form.MinimizeBox = form.ShowInTaskbar = false;
			return form.ShowDialog();
		}

		public static void Attach(IWorkbench workbench)
		{
			WorkbenchSingleton.workbench = workbench;
		}
		
		public static void ShowView(IView view)
		{
			workbench.ShowView(view);
		}
	}
}
