//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;

namespace SQLiteManager.Core.Views
{
	public interface IDatabaseView : IView
	{
		Database Database { get; set; }
	}
	
	public interface IDatabaseListView : IView
	{
		List<Database> Databases { get; set; }
		
		Database SelectedDatabase { get; }
		
		void RemoveDatabase(Database database);
		
		void AddQuery(string file);
		
		void OpenBlankEditor();
		
		void AddDatabase(string file);
		
		void ExecuteAllQueries();
		
		void ExecuteCurrentQuery();
	}
}
