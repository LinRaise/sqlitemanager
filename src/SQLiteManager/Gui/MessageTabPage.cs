//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;
using ICSharpCode.TextEditor;

namespace SQLiteManager.Gui
{
	public class MessageTabPage : TabPage
	{
	    readonly TextEditorControl control = new TextEditorControl();
		
		public MessageTabPage(string message)
		{
			this.Text = @"Messages";
			control.Text = message;
			control.Dock = DockStyle.Fill;
			control.IsReadOnly = true;
			Controls.Add(control);
		}
	}
}
