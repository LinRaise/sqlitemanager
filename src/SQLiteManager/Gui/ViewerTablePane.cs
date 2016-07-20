//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ICSharpCode.TextEditor.Document;
using SQLiteManager.Core;
using SQLiteManager.Gui.SqlSyntaxHighlighting;

namespace SQLiteManager.Gui
{
	public partial class ViewerTablePane : BaseDatabaseDependentControl
	{
		readonly SQLiteDataAdapter da = new SQLiteDataAdapter();
		DataTable ds;

		static ViewerTablePane()
		{
			HighlightingManager.Manager.AddSyntaxModeFileProvider(new AppSyntaxModeProvider());
		}
		
		public ViewerTablePane()
		{
			InitializeComponent();
			
			textEditorControlScript.Font = new Font("Lucida Console", 8);
			textEditorControlScript.SetHighlighting("SQL");
			textEditorControlScript.IsReadOnly = true;
		}
		
		public void ViewTable(string databaseId, string tableName)
		{
			DatabaseId = databaseId;
			TableName = tableName;
			
			Table table = DatabaseManager.Instance.FindTable(databaseId, tableName);
			
			listViewColumns.Items.Clear();
			foreach (Column column in table.Columns) {
				ListViewItem li = listViewColumns.Items.Add(column.Name);
				li.ImageIndex = column.PrimaryKey ? 1 : -1;
				li.SubItems.Add(column.Type);
				if (column.Default != null) {
					li.SubItems.Add(column.Default.ToString());
				} else {
					li.SubItems.Add("{null}");
				}
			}
			LoadTableData();
		}
		
		private void ToolStripButtonSaveChangesClick(object sender, EventArgs e)
		{
			// I do not know why this is necessary, but without it does not work update :-)
			new SQLiteCommandBuilder {
				DataAdapter = da
			};
			da.Update(ds);
			LoadTableData();
		}
		
		private void ToolStripButtonRefreshClick(object sender, EventArgs e)
		{
			LoadTableData();
		}
		
		private void LoadTableData()
		{
			var result = DatabaseManager.Instance.GetAllData(DatabaseId, TableName);

			if (result.Status == ResultStatus.QuerySucceded)
			{
				dataGridData.DataSource = result.DataTable;
				FillDataSet(result);
			}

			textEditorControlScript.Text = DatabaseManager.Instance.FindTable(DatabaseId, TableName).Script;
		}

		private void FillDataSet(Result result)
		{
			var set = new DataSet();
			da.SelectCommand = GetSelectCommand();
			set.Tables.Add(result.DataTable);
			da.Fill(set);
			ds = result.DataTable;
		}

		private SQLiteCommand GetSelectCommand()
		{
			var table = DatabaseManager.Instance.FindTable(DatabaseId, TableName);
			var connection = ConnectionFactory.GetConnection(DatabaseManager.Instance.Databases.Where(db => db.Id == DatabaseId).First());
			return new SQLiteCommand(table.SelectQuery, connection);
		}
	}
}
