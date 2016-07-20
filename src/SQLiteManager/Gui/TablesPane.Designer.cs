//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

namespace SQLiteManager.Gui
{
	partial class TablesPane
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablesPane));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.databasesTreeView = new System.Windows.Forms.TreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.treePaneToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddIndex = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditIndex = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteIndex = new System.Windows.Forms.ToolStripButton();
            this.selectedTableStructureListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.treePaneToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.databasesTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.treePaneToolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectedTableStructureListView);
            this.splitContainer1.Size = new System.Drawing.Size(150, 372);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // databasesTreeView
            // 
            this.databasesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasesTreeView.HideSelection = false;
            this.databasesTreeView.ImageIndex = 0;
            this.databasesTreeView.ImageList = this.treeViewImageList;
            this.databasesTreeView.Location = new System.Drawing.Point(0, 25);
            this.databasesTreeView.Name = "databasesTreeView";
            this.databasesTreeView.SelectedImageIndex = 0;
            this.databasesTreeView.Size = new System.Drawing.Size(150, 237);
            this.databasesTreeView.TabIndex = 1;
            this.databasesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DatabasesTreeViewAfterSelect);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.treeViewImageList.Images.SetKeyName(0, "DatabaseServer.bmp");
            this.treeViewImageList.Images.SetKeyName(1, "VSFolder_closed.bmp");
            this.treeViewImageList.Images.SetKeyName(2, "Table.bmp");
            this.treeViewImageList.Images.SetKeyName(3, "key.png");
            this.treeViewImageList.Images.SetKeyName(4, "List_BulletsHS.png");
            this.treeViewImageList.Images.SetKeyName(5, "index.png");
            // 
            // treePaneToolStrip
            // 
            this.treePaneToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripButtonAddIndex,
            this.toolStripButtonEditIndex,
            this.toolStripButtonDeleteIndex});
            this.treePaneToolStrip.Location = new System.Drawing.Point(0, 0);
            this.treePaneToolStrip.Name = "treePaneToolStrip";
            this.treePaneToolStrip.Size = new System.Drawing.Size(150, 25);
            this.treePaneToolStrip.TabIndex = 0;
            this.treePaneToolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Enabled = false;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh database";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.ToolStripButtonRefreshClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Enabled = false;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "Create Table";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.ToolStripButtonAddClick);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Enabled = false;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEdit.Text = "Alter Table";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.ToolStripButtonEditClick);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "Drop Table";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.ToolStripButtonDeleteClick);
            // 
            // toolStripButtonAddIndex
            // 
            this.toolStripButtonAddIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddIndex.Enabled = false;
            this.toolStripButtonAddIndex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddIndex.Image")));
            this.toolStripButtonAddIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddIndex.Name = "toolStripButtonAddIndex";
            this.toolStripButtonAddIndex.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddIndex.Text = "Create index";
            this.toolStripButtonAddIndex.Visible = false;
            this.toolStripButtonAddIndex.Click += new System.EventHandler(this.ToolStripButtonAddIndexClick);
            // 
            // toolStripButtonEditIndex
            // 
            this.toolStripButtonEditIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditIndex.Enabled = false;
            this.toolStripButtonEditIndex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditIndex.Image")));
            this.toolStripButtonEditIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditIndex.Name = "toolStripButtonEditIndex";
            this.toolStripButtonEditIndex.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonEditIndex.Text = "Edit index";
            this.toolStripButtonEditIndex.Visible = false;
            this.toolStripButtonEditIndex.Click += new System.EventHandler(this.ToolStripButtonEditIndexClick);
            // 
            // toolStripButtonDeleteIndex
            // 
            this.toolStripButtonDeleteIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteIndex.Enabled = false;
            this.toolStripButtonDeleteIndex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteIndex.Image")));
            this.toolStripButtonDeleteIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteIndex.Name = "toolStripButtonDeleteIndex";
            this.toolStripButtonDeleteIndex.Size = new System.Drawing.Size(23, 20);
            this.toolStripButtonDeleteIndex.Text = "Drop index";
            this.toolStripButtonDeleteIndex.Visible = false;
            this.toolStripButtonDeleteIndex.Click += new System.EventHandler(this.ToolStripButtonDeleteIndexClick);
            // 
            // selectedTableStructureListView
            // 
            this.selectedTableStructureListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.selectedTableStructureListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedTableStructureListView.FullRowSelect = true;
            this.selectedTableStructureListView.GridLines = true;
            this.selectedTableStructureListView.Location = new System.Drawing.Point(0, 0);
            this.selectedTableStructureListView.Name = "selectedTableStructureListView";
            this.selectedTableStructureListView.Size = new System.Drawing.Size(150, 106);
            this.selectedTableStructureListView.SmallImageList = this.treeViewImageList;
            this.selectedTableStructureListView.TabIndex = 0;
            this.selectedTableStructureListView.UseCompatibleStateImageBehavior = false;
            this.selectedTableStructureListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            // 
            // TablesPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TablesPane";
            this.Size = new System.Drawing.Size(150, 372);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.treePaneToolStrip.ResumeLayout(false);
            this.treePaneToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.TreeView databasesTreeView;
		private System.Windows.Forms.ImageList treeViewImageList;
		private System.Windows.Forms.ToolStrip treePaneToolStrip;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
		private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
		private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ListView selectedTableStructureListView;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddIndex;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditIndex;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteIndex;
	}
}
