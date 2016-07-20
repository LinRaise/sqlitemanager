//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SQLiteManager.Core;
using SQLiteManager.Gui.TreeNodes;

namespace SQLiteManager.Gui
{
	public partial class DatabaseListPane : UserControl
	{
		IList<Database> databases = new List<Database>();
		Table selectedTable = null;
		Database selectedDatabase = null;
		
		public Database SelectedDatabase {
			get { return selectedDatabase; }
		}
		
		public Table SelectedTable {
			get { return selectedTable; }
		}
		
		public IList<Database> Databases {
			get { return databases; }
			set {
				databases = value;
				foreach (var d in databases) {
					treeViewDatabases.Nodes.Add(new DatabaseTreeNode2(d, 0, 0));
				}
			}
		}
		
		public DatabaseListPane()
		{
			InitializeComponent();
		}
		
		public event EventHandler<TableEventArgs> TableSelected;
		
		public event EventHandler<TableEventArgs> TableDelete;
		
		protected virtual void OnTableDelete(TableEventArgs e)
		{
			if (TableDelete != null) {
				TableDelete(this, e);
			}
		}
		
		public event EventHandler<DatabaseEventArgs> DatabaseSelected;
		
		protected virtual void OnDatabaseSelected(DatabaseEventArgs e)
		{
			if (DatabaseSelected != null) {
				DatabaseSelected(this, e);
			}
		}
		
		protected virtual void OnTableSelected(TableEventArgs e)
		{
			if (TableSelected != null) {
				TableSelected(this, e);
			}
		}
		
		void ToolStripButtonEditIndexClick(object sender, EventArgs e)
		{
			OnIndexEdit(e);
		}
		
		public void AddDatabase(Database database)
		{
			databases.Add(database);
			treeViewDatabases.Nodes.Add(new DatabaseTreeNode2(database, 0, 0));
		}
		
		public event EventHandler IndexEdit;
		
		protected virtual void OnIndexEdit(EventArgs e)
		{
			if (IndexEdit != null) {
				IndexEdit(this, e);
			}
		}
		
		void ToolStripButtonRefreshClick(object sender, EventArgs e)
		{
			OnDatabaseRefresh(new DatabaseEventArgs(SelectedDatabase));
		}
		
		public event EventHandler<DatabaseEventArgs> DatabaseRefresh;
		
		protected virtual void OnDatabaseRefresh(DatabaseEventArgs e)
		{
			if (DatabaseRefresh != null) {
				DatabaseRefresh(this, e);
			}
		}
		
		void DatabasesTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			toolStripButtonRefresh.Enabled = toolStripButtonAddTable.Enabled = toolStripButtonEditTable.Enabled = toolStripButtonDeleteTable.Enabled = false;
			if (e.Node is DatabaseTreeNode2) {
				selectedDatabase = (e.Node as DatabaseTreeNode2).Database;
				toolStripButtonRefresh.Enabled = true;
				OnDatabaseSelected(new DatabaseEventArgs((e.Node as DatabaseTreeNode2).Database));
			} else if (e.Node is TablesTreeNode) {
				toolStripButtonAddTable.Enabled = true;
			} else if (e.Node is TableTreeNode2) {
				selectedTable = (e.Node as TableTreeNode2).Table;
				toolStripButtonEditTable.Enabled = toolStripButtonDeleteTable.Enabled = true;
				listViewTableStructure.Items.Clear();
				foreach (var c in selectedTable.Columns) {
					ListViewItem li = listViewTableStructure.Items.Add(c.Name);
					li.ImageIndex = c.PrimaryKey ? 3 : 4;
					li.SubItems.Add(c.Type);
				}
				OnTableSelected(new TableEventArgs(selectedTable));
			}
		}

		private void toolStripButtonDeleteTable_Click(object sender, EventArgs e)
		{
			OnTableDelete(new TableEventArgs(SelectedTable));
		}
	}
}
