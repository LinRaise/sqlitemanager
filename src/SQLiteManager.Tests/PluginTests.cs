//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using NUnit.Framework;
using SQLiteManager.Core;

namespace SQLiteManager.Tests
{
	[TestFixture]
	public class PluginTests
	{
		[Test]
		public void TestMethod()
		{
			Plugin p = Plugin.Load(new StringReader(@"<Plugin>
	<Menu>
		<MenuItem Text='File'>
			<MenuItem Text='Exit' Command='SQLiteManager.Command.ExitCommand, sqlitemanager'/>
		</MenuItem>
	</Menu>
</Plugin>"));
			Assert.AreEqual(p.Menu.MenuItems.Length, 1);
		}
	}
}
