//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Windows.Forms;
using NUnit.Framework;
using SQLiteManager.Core.Controllers;

namespace SQLiteManager.Tests.Controllers
{
	[TestFixture]
	public class DatabaseControllerTests
	{
		DatabaseController controller;
		
		[SetUp]
		public void Setup()
		{
			Application.EnableVisualStyles();
			SQLiteManager.Gui.MainForm f = new SQLiteManager.Gui.MainForm();
			WorkbenchSingleton.Attach(f);
			controller = new DatabaseController(f);
		}
		
		[Test]
		[STAThread]
		public void TestMethod()
		{
			(controller.List() as Form).ShowDialog();
		}
	}
}
