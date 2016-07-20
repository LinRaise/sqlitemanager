//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using SQLiteManager.Core;
using SQLiteManager.Core.Views;
using SQLiteManager.Gui.SqlSyntaxHighlighting;

namespace SQLiteManager.Gui
{
	public partial class TablePane : UserControl, ITableView
	{
		Table table;
		
		public Table Table {
			get { return table; }
			set {
				table = value;
				Text = string.Format("Viewer Table {0}", table.FullName);
				listViewColumns.Items.Clear();
				foreach (var c in table.Columns) {
					ListViewItem li = listViewColumns.Items.Add(c.Name);
					li.ImageIndex = c.PrimaryKey ? 1 : -1;
					li.SubItems.Add(c.Type);
//					li.SubItems.Add(c.Default.ToString());
				}
				textEditorControlScript.Text = table.Script;
				dataGridData.DataSource = table.LoadData();
			}
		}
		
		static TablePane()
		{
			HighlightingManager.Manager.AddSyntaxModeFileProvider(
				new AppSyntaxModeProvider()
			);
		}
		
		public TablePane() : this(new Table())
		{
		}
		
		public TablePane(Table table)
		{
			InitializeComponent();
			textEditorControlScript.SetHighlighting("SQL");
			this.Table = table;
		}
	}
}
