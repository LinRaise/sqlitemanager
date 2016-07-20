//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Util;

namespace SQLiteManager.Gui
{
	public class DataTabPage : TabPage, IDatabaseDepedentControl
	{
		public string DatabaseId {
			get {
				return viewerTablePane.DatabaseId;
			}
		}
		
		public string TableName {
			get {
				return viewerTablePane.TableName;
			}
		}
		
		private readonly ViewerTablePane viewerTablePane = new ViewerTablePane();
		
		public DataTabPage()
		{
			this.Text = @"Table Viewer";
			viewerTablePane.Dock = DockStyle.Fill;
			Controls.Add(viewerTablePane);
		}
		
		public void ViewTable(string databaseId, string tableName)
		{
			viewerTablePane.ViewTable(databaseId, tableName);
		}
	}
}
