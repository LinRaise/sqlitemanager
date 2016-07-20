//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Windows.Forms;
using NUnit.Framework;
using SQLiteManager.Core;
using SQLiteManager.Core.Controllers;
using SQLiteManager.Gui;

namespace SQLiteManager.Tests.Controllers
{
	[TestFixture]
	public class TableControllerTests
	{
		TableController controller;
		
		[SetUp]
		public void Setup()
		{
			controller = new TableController(new TablePane());
		}
		
		[Test]
		public void TestAdd()
		{
		}
	}
}
