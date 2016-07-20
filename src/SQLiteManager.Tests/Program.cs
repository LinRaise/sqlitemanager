/*
 * Created by SharpDevelop.
 * User: ie185004
 * Date: 2/1/2011
 * Time: 9:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using SQLiteManager.Core;

namespace SQLiteManager.Tests
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
//			WorkbenchSingleton.Attach(new MainForm(new DialogWorkbenchLayout()));
//			Application.Run(WorkbenchSingleton.MainForm);
		}
	}
}
