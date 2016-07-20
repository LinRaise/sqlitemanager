//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;

namespace SQLiteManager.Core.Views
{
	public interface ITableView : IView
	{
		Table Table { get; set; }
	}
}
