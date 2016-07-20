//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Core;

namespace SQLiteManager.Gui
{
	public class ResultTabPage : TabPage
	{
	    readonly DataGridView dataGridView = new DataGridView();
	    
		Result result;
		
		public Result Result {
			get {
				return result;
			}
			
			set {
				result = value;
				dataGridView.DataSource = result.DataTable;
				Tag = result.DataTable.Rows.Count;
			}
		}
		
		public ResultTabPage(Result result, string text)
		{
			dataGridView.Dock = DockStyle.Fill;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.ReadOnly = true;
			Controls.Add(dataGridView);
			Result = result;
			this.Text = text;
		}
	}
}
