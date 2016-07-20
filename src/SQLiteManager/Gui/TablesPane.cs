//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//      <author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLiteManager.Core;
using SQLiteManager.Core.Utilities;
using SQLiteManager.Gui.TreeNodes;

namespace SQLiteManager.Gui
{
	public partial class TablesPane : BaseUserControl
	{
		public event EventHandler<TableSelectedEventArgs> TableSelected;

		public event EventHandler<IndexSelectedEventArgs> IndexSelected;
		
		private readonly IDictionary<string, DatabaseTreeNode> openedDatabases = new Dictionary<string, DatabaseTreeNode>();
		
		public TablesPane()
		{
			InitializeComponent();
			WireDatabaseManagerEvents();
		}
		
		public override void UnwireEvents()
		{
			base.UnwireEvents();
			UnwireDatabaseManagerEvents();
		}
		
		private static DatabaseTreeNode BuildDatabaseTreeNode(Database database)
		{
			var databaseTreeNode = new DatabaseTreeNode(database, (int)DatabasesTreeViewImageIndex.Database, (int)DatabasesTreeViewImageIndex.Database);
			databaseTreeNode.ExpandAll();
			var tablesObjectNode = new DbObjectTreeNode(DbObjectTreeNode.STR_TABLES_DB_OBJECT_NAME, database.Tables.Count(), (int)DatabasesTreeViewImageIndex.Folder, (int)DatabasesTreeViewImageIndex.Folder, DbObjectTreeNode.NodeType.Tables, database.Id);
			var indexesObjectNode = new DbObjectTreeNode(DbObjectTreeNode.STR_INDEXES_DB_OBJECT_NAME, database.Indexes.Count(), (int)DatabasesTreeViewImageIndex.Index, (int)DatabasesTreeViewImageIndex.Index, DbObjectTreeNode.NodeType.Indexes, database.Id);
			databaseTreeNode.Nodes.Add(tablesObjectNode);
			databaseTreeNode.Nodes.Add(indexesObjectNode);
			tablesObjectNode.ExpandAll();
			foreach	(var table in database.Tables) {
				var tableTreeNode = new TableTreeNode(table.Name, database.Id, (int)DatabasesTreeViewImageIndex.Table, (int)DatabasesTreeViewImageIndex.Table);
				tablesObjectNode.Nodes.Add(tableTreeNode);
				
				foreach (var column in table.Columns) {
					int imageIndex = column.PrimaryKey ? (int)DatabasesTreeViewImageIndex.Key : (int)DatabasesTreeViewImageIndex.Column;
					int selectedImageIndex = imageIndex;
					
					var columnTreeNode = new ColumnTreeNode(column, imageIndex, selectedImageIndex);
					tableTreeNode.Nodes.Add(columnTreeNode);
				}
			}

			foreach (var index in database.Indexes) {
				var indexTreeNode = new IndexTreeNode(index.Name, database.Id, (int)DatabasesTreeViewImageIndex.Index, (int)DatabasesTreeViewImageIndex.Index);
				indexesObjectNode.Nodes.Add(indexTreeNode);
				foreach (Column column in index.Columns) {
					var columnTreeNode = new ColumnTreeNode(column, (int)DatabasesTreeViewImageIndex.Column, (int)DatabasesTreeViewImageIndex.Column);
					indexTreeNode.Nodes.Add(columnTreeNode);
				}
			}
			
			return databaseTreeNode;
		}

		private void WireDatabaseManagerEvents()
		{
			DatabaseManager.Instance.DatabaseOpened += DatabaseManagerInstanceDatabaseOpened;
			DatabaseManager.Instance.DatabaseClosed += DatabaseManagerInstanceDatabaseClosed;
			DatabaseManager.Instance.DatabaseRefreshed += DatabaseManagerInstanceDatabaseRefreshed;
		}
		
		private void UnwireDatabaseManagerEvents()
		{
			DatabaseManager.Instance.DatabaseOpened -= DatabaseManagerInstanceDatabaseOpened;
			DatabaseManager.Instance.DatabaseClosed -= DatabaseManagerInstanceDatabaseClosed;
			DatabaseManager.Instance.DatabaseRefreshed -= DatabaseManagerInstanceDatabaseRefreshed;
		}
		
		private void DatabaseManagerInstanceDatabaseRefreshed(object sender, DatabaseEventArgs e)
		{
			var databaseTreeNode = BuildDatabaseTreeNode(e.Database);
			
			if (openedDatabases.ContainsKey(e.Database.Id)) {
				var originalDatabaseTreeNode = openedDatabases[e.Database.Id];
				originalDatabaseTreeNode.Nodes.Clear();
				foreach (TreeNode node in databaseTreeNode.Nodes) {
					originalDatabaseTreeNode.Nodes.Add(node);
				}
			} else {
				openedDatabases.Add(e.Database.Id, databaseTreeNode);
				databasesTreeView.Nodes.Add(databaseTreeNode);
			}
		}
		
		private void DatabaseManagerInstanceDatabaseOpened(object sender, DatabaseEventArgs e)
		{
			if (!openedDatabases.ContainsKey(e.Database.Id)) {
				var databaseTreeNode = BuildDatabaseTreeNode(e.Database);
				openedDatabases.Add(e.Database.Id, databaseTreeNode);
				databasesTreeView.Nodes.Add(databaseTreeNode);
			}
		}
		
		private void DatabaseManagerInstanceDatabaseClosed(object sender, DatabaseEventArgs e)
		{
			if (openedDatabases.ContainsKey(e.Database.Id)) {
				databasesTreeView.Nodes.Remove(openedDatabases[e.Database.Id]);
			}
		}
		
		private void DatabasesTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			SetAccessToButtons(e.Node);
			toolStripButtonRefresh.Enabled = (e.Node is DatabaseTreeNode);
			
			if (e.Node is TableTreeNode) {
				var tableTreeNode = (e.Node as TableTreeNode);
				var table = DatabaseManager.Instance.FindTable(tableTreeNode.DatabaseId, tableTreeNode.TableName);

				if (table != null) {
					selectedTableStructureListView.Items.Clear();
					foreach (Column column in table.Columns) {
						var listViewItem = selectedTableStructureListView.Items.Add(column.Name);
						listViewItem.ImageIndex = column.PrimaryKey ? (int)DatabasesTreeViewImageIndex.Key : (int)DatabasesTreeViewImageIndex.Column;
						listViewItem.SubItems.Add(column.Type);
					}
					selectedTableStructureListView.KeyUp += new KeyEventHandler(selectedTableStructureListView_KeyUp);
				}
				
				if (TableSelected != null) {
					TableSelected(this, new TableSelectedEventArgs(tableTreeNode.DatabaseId, tableTreeNode.TableName));
				}
			}

			if (e.Node is IndexTreeNode) {
				var indextTreeNode = (e.Node as IndexTreeNode);
				var index = DatabaseManager.Instance.FindDatabase(indextTreeNode.DatabaseId).Indexes.Where(
					n => n.Name == indextTreeNode.IndexName).First();
				if (index != null)
				{
					selectedTableStructureListView.Items.Clear();
					foreach (var column in index.Columns) {
						var listViewItem = selectedTableStructureListView.Items.Add(column.Name);
						listViewItem.ImageIndex = column.PrimaryKey ? (int)DatabasesTreeViewImageIndex.Key : (int)DatabasesTreeViewImageIndex.Column;
						listViewItem.SubItems.Add(column.Type);
					}
					selectedTableStructureListView.KeyUp += new KeyEventHandler(selectedTableStructureListView_KeyUp);
				}
				if (IndexSelected != null) {
					IndexSelected(this, new IndexSelectedEventArgs(indextTreeNode.DatabaseId, indextTreeNode.IndexName));
				}
			}
		}

		void selectedTableStructureListView_KeyUp(object sender, KeyEventArgs e)
		{
			if (sender != selectedTableStructureListView) {
				return;
			}
			if (e.Control && e.KeyCode == Keys.C) {
				CopySelectedColumnToClipboard();
			}
		}
		
		void CopySelectedColumnToClipboard()
		{
			var s = new StringBuilder();
			foreach (ListViewItem li in selectedTableStructureListView.SelectedItems) {
				s.AppendLine(li.SubItems[0].Text);
			}
			Clipboard.SetText(s.ToString());
		}

		private void SetAccessToIndexButtons(TreeNode node)
		{
			var enabled = (node is IndexTreeNode);
			toolStripButtonAddIndex.Visible = enabled;
			toolStripButtonEditIndex.Visible = enabled;
			toolStripButtonDeleteIndex.Visible = enabled;

			toolStripButtonAddIndex.Enabled = enabled;
			toolStripButtonEditIndex.Enabled = enabled;
			toolStripButtonDeleteIndex.Enabled = enabled;
		}

		private void SetAccessToButtons(TreeNode node)
		{
			SetAccessToTableButtons(node);
			SetAccessToIndexButtons(node);
			SetAccessToButtonsToParentNodes(node);
		}

		private void SetAccessToButtonsToParentNodes(TreeNode node)
		{
			var parentNode = node as DbObjectTreeNode;
			if (parentNode == null) {
				return;
			}
			switch (parentNode.Type) {
				case DbObjectTreeNode.NodeType.Indexes:
					{
						toolStripButtonAddIndex.Enabled = true;
						toolStripButtonAddIndex.Visible = true;
						break;
					}
				case DbObjectTreeNode.NodeType.Tables:
					{
						toolStripButtonAdd.Enabled = true;
						toolStripButtonAdd.Visible = true;
						break;
					}
				default:
					{
						toolStripButtonAddIndex.Enabled = false;
						toolStripButtonAddIndex.Visible = false;
						toolStripButtonAdd.Enabled = false;
						toolStripButtonAdd.Visible = false;
						break;
					}
			}
		}

		private void SetAccessToTableButtons(TreeNode node)
		{
			var enabled = (node is TableTreeNode);
			toolStripButtonAdd.Visible = enabled;
			toolStripButtonDelete.Visible = enabled;
			toolStripButtonEdit.Visible = enabled;
			toolStripButtonAdd.Enabled = enabled;
			toolStripButtonDelete.Enabled = enabled;
			toolStripButtonEdit.Enabled = enabled;
		}

		private void ToolStripButtonAddClick(object sender, EventArgs e)
		{
			string databaseId = string.Empty;
			if (databasesTreeView.SelectedNode is TableTreeNode) {
				databaseId = (databasesTreeView.SelectedNode as TableTreeNode).DatabaseId;
			}
			if (databasesTreeView.SelectedNode is DbObjectTreeNode) {
				databaseId = (databasesTreeView.SelectedNode as DbObjectTreeNode).DatabaseId;
			}
			if (string.IsNullOrEmpty(databaseId)) {
				return;
			}

			using (var f = new TableForm()) {
//				if (WorkbenchSingleton.MainForm.AddDialog(f) == DialogResult.OK) {
				if (WorkbenchSingleton.ShowDialogView(f) == DialogResult.OK) {
					DatabaseManager.Instance.CreateTable(databaseId, f.Table);
				}
			}
		}
		
		private void ToolStripButtonRefreshClick(object sender, EventArgs e)
		{
			DatabaseManager.Instance.RefreshDatabase(((DatabaseTreeNode) databasesTreeView.SelectedNode).DatabaseId);
		}
		
		private void ToolStripButtonDeleteClick(object sender, EventArgs e)
		{
			var tableTreeNode = (databasesTreeView.SelectedNode as TableTreeNode);
			if (tableTreeNode == null) {
				return;
			}
			
			if (MessageBox.Show("Are you sure you want to delete \"" + tableTreeNode.TableName + "\"?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				DatabaseManager.Instance.DropTable(tableTreeNode.DatabaseId, tableTreeNode.TableName);
			}
		}
		
		private enum DatabasesTreeViewImageIndex
		{
			Database = 0,
			Folder = 1,
			Table = 2,
			Key = 3,
			Column = 4,
			Index = 5
		}

		private void ToolStripButtonEditClick(object sender, EventArgs e)
		{
			var tableTreeNode = databasesTreeView.SelectedNode as TableTreeNode;
			if (tableTreeNode == null) {
				return;
			}

			var table = DatabaseManager.Instance.FindTable(tableTreeNode.DatabaseId, tableTreeNode.TableName);
			
			if (table == null) {
				return;
			}

			var originalTable = (Table)table.Clone();
			
			//copy columns collection
			var originalColumns = new Column[table.Columns.Count];
			table.Columns.CopyTo(originalColumns, 0);
			originalTable.Columns = originalColumns;
			
			using (var f = new TableForm(table))
			{
				f.Text = string.Format("Alter Table {0}", table.Name);
//				if (WorkbenchSingleton.MainForm.AddDialog(f) == DialogResult.OK) {
				if (WorkbenchSingleton.ShowDialogView(f) == DialogResult.OK) {
					if (DatabaseManager.Instance.FindTable(table.Database.Id, f.Table.Name) != null) {
						MessageService.ShowError(string.Format("Table with name \"{0}\" already exists.", f.Table.Name));
						return;
					}
					DatabaseManager.Instance.AlterTable(originalTable, f.Table);
				}
			}
		}

		private void ToolStripButtonAddIndexClick(object sender, EventArgs e) {
			var databaseId = string.Empty;
			if (databasesTreeView.SelectedNode is IndexTreeNode) {
				databaseId = (databasesTreeView.SelectedNode as IndexTreeNode).DatabaseId;
			}
			if (databasesTreeView.SelectedNode is DbObjectTreeNode) {
				databaseId = (databasesTreeView.SelectedNode as DbObjectTreeNode).DatabaseId;
			}
			if (string.IsNullOrEmpty(databaseId)) {
				return;
			}
			using (var indexForm = new IndexForm(databaseId)) {
				indexForm.Text = @"Create Index";
//				if (WorkbenchSingleton.MainForm.AddDialog(indexForm) == DialogResult.OK) {
				if (WorkbenchSingleton.ShowDialogView(indexForm) == DialogResult.OK) {
					var result = DatabaseManager.Instance.CreateIndex(databaseId, indexForm.Index);
					if (result.Status != ResultStatus.DMLSucceded) {
						MessageService.ShowError(result.Message);
					}
				}
			}
		}

		private void ToolStripButtonEditIndexClick(object sender, EventArgs e)
		{
			if (databasesTreeView.SelectedNode is IndexTreeNode)
			{
				var selectedIndexNode = databasesTreeView.SelectedNode as IndexTreeNode;
				var index = DatabaseManager.Instance.FindIndex(selectedIndexNode.DatabaseId, selectedIndexNode.IndexName);
				if (index == null) {
					return;
				}
				using (var indexForm = new IndexForm(index)) {
					indexForm.Text = @"Edit Index " + index.Name;
//					if (WorkbenchSingleton.MainForm.AddDialog(indexForm) == DialogResult.OK) {
					if (WorkbenchSingleton.ShowDialogView(indexForm) == DialogResult.OK) {
						DatabaseManager.Instance.DropIndex(selectedIndexNode.DatabaseId, index.Name);
						DatabaseManager.Instance.CreateIndex(selectedIndexNode.DatabaseId, indexForm.Index);
					}
				}
			}
		}

		private void ToolStripButtonDeleteIndexClick(object sender, EventArgs e) {
			var indexTreeNode = (databasesTreeView.SelectedNode as IndexTreeNode);
			if (indexTreeNode == null) {
				return;
			}
			if (MessageBox.Show("Are you sure you want to delete \"" + indexTreeNode.IndexName + "\"?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				DatabaseManager.Instance.DropIndex(indexTreeNode.DatabaseId, indexTreeNode.IndexName);
			}
		}
	}
}
