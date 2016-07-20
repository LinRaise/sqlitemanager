//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using SQLiteManager.Core.Views;

namespace SQLiteManager.Core.Controllers
{
	public class DatabaseController : Controller
	{
		IDatabaseListView listView;
		
		public DatabaseController(IDatabaseListView listView)
		{
			this.listView = listView;
		}
		
		public IView List()
		{
			return listView;
		}
	}
}
