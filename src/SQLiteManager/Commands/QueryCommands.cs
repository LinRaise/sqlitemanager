//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using SQLiteManager.Core;
using SQLiteManager.Core.Views;
using SQLiteManager.Gui;

namespace SQLiteManager.Commands
{
	[ObsoleteAttribute()]
	public class AddQuery : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.OpenBlankEditor();
			(WorkbenchSingleton.Workbench as IDatabaseListView).OpenBlankEditor();
		}
	}
	
	public class AddQuery2 : AbstractCommand
	{
		public override void Run()
		{
			WorkbenchSingleton.ShowView(new QueryPane());
		}
	}
	
	[Obsolete()]
	public class ExecuteAllQuery : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.ExecuteAllQueries();
			(WorkbenchSingleton.Workbench as IDatabaseListView).ExecuteAllQueries();
		}
	}
	
	public class ExecuteAllQuery2 : AbstractCommand
	{
		public override void Run()
		{
		}
	}
	
	[Obsolete()]
	public class ExecuteQuery : AbstractCommand
	{
		public override void Run()
		{
//			WorkbenchSingleton.MainForm.ExecuteCurrenQuery();
			(WorkbenchSingleton.Workbench as IDatabaseListView).ExecuteCurrentQuery();
		}
	}
	
	public class ExecuteQuery2 : AbstractCommand
	{
		public override void Run()
		{
		}
	}
}
