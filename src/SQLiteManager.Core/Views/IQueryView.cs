//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using SQLiteManager.Core.Models;

namespace SQLiteManager.Core.Views
{
	public interface IQueryView : IView
	{
		Query2 Query { get; set; }
	}
}
