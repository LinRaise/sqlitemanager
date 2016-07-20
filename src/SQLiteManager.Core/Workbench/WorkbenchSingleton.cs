//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using SQLiteManager.Core.Views;

namespace SQLiteManager.Core.Workbench
{
//	public class WorkbenchSingleton
//	{
//		static IWorkbench workbench;
//		
//		public static void Attach(IWorkbench workbench)
//		{
//			WorkbenchSingleton.workbench = workbench;
//		}
//	}
	
	public interface IWorkbench
	{
		string CurrentDatabaseId { get; }
		
		void OpenSqlFileInEditor();
		
		void SaveCurrentEditor();
		
		void SaveCurrentEditorAs();
		
		void ShowView(IView view);
		
		void CloseAllWindows();
		
		void CloseWindow();
	}
	
	public interface IWorkbenchLayout
	{
		IWorkbench Workbench { get; set; }
	}
	
	public interface IWorkbenchWindow
	{
		IView View { get; set; }
	}
}
