//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Drawing;
using System.Windows.Forms;
using SQLiteManager.Core.Views;

namespace SQLiteManager.Core.Workbench
{
	public class SdiWorkbenchLayout : IWorkbenchLayout
	{
		IWorkbench workbench;
		
		public IWorkbench Workbench {
			get { return workbench; }
			set { workbench = value; }
		}
		
		public SdiWorkbenchLayout()
		{
		}
	}
	
	public class SdiWorkbenchWindow : TabPage, IWorkbenchWindow
	{
		public IView View { get; set; }
		
		public SdiWorkbenchWindow(IView view)
		{
			this.View = view;
			Control control = view as Control;
			control.Dock = DockStyle.Fill;
			Size s = control.Size;
			ClientSize = new Size(s.Width, s.Height);
			Controls.Add(control);
			Text = view.Text;
			control.TextChanged += delegate { Text = view.Text; };
		}
	}
}
