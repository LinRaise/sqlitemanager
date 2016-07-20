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
	public class XToolStripButton : ToolStripButton
	{
	    readonly ICommand command;
		
		public XToolStripButton(string text, ICommand command, Image image)
		{
			this.Text = text;
			this.command = command;
			this.Image = image;
			this.DisplayStyle = ToolStripItemDisplayStyle.Image;
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
