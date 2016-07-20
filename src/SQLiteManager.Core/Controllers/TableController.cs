//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using SQLiteManager.Core.Views;

namespace SQLiteManager.Core.Controllers
{
	public class TableController : Controller
	{
		ITableView view;
		
		public TableController(ITableView view)
		{
			this.view = view;
		}
		
		public IView Add()
		{
			return view;
		}
	}
}
