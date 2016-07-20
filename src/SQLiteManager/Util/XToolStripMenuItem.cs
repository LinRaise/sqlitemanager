//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Drawing;
using System.Windows.Forms;

using SQLiteManager.Core;

namespace SQLiteManager.Util
{
	public class XToolStripMenuItem : ToolStripMenuItem
	{
	    readonly ICommand command;
		
		public XToolStripMenuItem()
		{
		}
		
		public XToolStripMenuItem(string text)
		{
			this.Text = text;
		}
		
		public XToolStripMenuItem(string text, ToolStripItem[] items)
		{
			this.Text = text;
			DropDownItems.AddRange(items);
		}
		
		public XToolStripMenuItem(string text, ICommand command)
		{
			this.Text = text;
			this.command = command;
		}
		
		public XToolStripMenuItem(string text, ICommand command, Image image)
		{
			this.Text = text;
			this.command = command;
			this.Image = image;
		}
		
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (command != null) {
				command.Run();
			}
		}
	}
}
