//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System.Windows.Forms;

namespace SQLiteManager.Core.Utilities
{
	public static class MessageService
	{
		public static DialogResult ShowYesNo(string text)
		{
			return MessageBox.Show(text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}
		
		public static DialogResult ShowInfo(string text)
		{
			return MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		public static DialogResult ShowError(string text)
		{
			return MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		public static DialogResult ShowWarning(string text)
		{
			return MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
