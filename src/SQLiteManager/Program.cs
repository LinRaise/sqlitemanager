//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Windows.Forms;

namespace SQLiteManager
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
//			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				
				WorkbenchSingleton.Attach(new MainForm());
				Application.Run(WorkbenchSingleton.MainForm);
//			} catch (Exception ex) {
//				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
		}
	}
}
