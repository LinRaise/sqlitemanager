//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

namespace SQLiteManager.Gui
{
	partial class DatabaseListPane
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseListPane));
			this.treeViewDatabases = new System.Windows.Forms.TreeView();
			this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStripButtonAddIndex = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonEditIndex = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonDeleteIndex = new System.Windows.Forms.ToolStripButton();
			this.listViewTableStructure = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.toolStripButtonDeleteTable = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonEditTable = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonAddTable = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treePaneToolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.treePaneToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewDatabases
			// 
			this.treeViewDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewDatabases.HideSelection = false;
			this.treeViewDatabases.ImageIndex = 0;
			this.treeViewDatabases.ImageList = this.treeViewImageList;
			this.treeViewDatabases.Location = new System.Drawing.Point(0, 25);
			this.treeViewDatabases.Name = "treeViewDatabases";
			this.treeViewDatabases.SelectedImageIndex = 0;
			this.treeViewDatabases.Size = new System.Drawing.Size(150, 160);
			this.treeViewDatabases.TabIndex = 1;
			this.treeViewDatabases.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DatabasesTreeViewAfterSelect);
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
			// 
			// listViewTableStructure
			// 
			this.listViewTableStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listViewTableStructure.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewTableStructure.FullRowSelect = true;
			this.listViewTableStructure.GridLines = true;
			this.listViewTableStructure.Location = new System.Drawing.Point(0, 0);
			this.listViewTableStructure.Name = "listViewTableStructure";
			this.listViewTableStructure.Size = new System.Drawing.Size(150, 74);
			this.listViewTableStructure.SmallImageList = this.treeViewImageList;
			this.listViewTableStructure.TabIndex = 0;
			this.listViewTableStructure.UseCompatibleStateImageBehavior = false;
			this.listViewTableStructure.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Column";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			// 
			// toolStripButtonDeleteTable
			// 
			this.toolStripButtonDeleteTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonDeleteTable.Enabled = false;
			this.toolStripButtonDeleteTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteTable.Image")));
			this.toolStripButtonDeleteTable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonDeleteTable.Name = "toolStripButtonDeleteTable";
			this.toolStripButtonDeleteTable.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonDeleteTable.Text = "Drop Table";
			this.toolStripButtonDeleteTable.Click += new System.EventHandler(this.toolStripButtonDeleteTable_Click);
			// 
			// toolStripButtonEditTable
			// 
			this.toolStripButtonEditTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonEditTable.Enabled = false;
			this.toolStripButtonEditTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditTable.Image")));
			this.toolStripButtonEditTable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonEditTable.Name = "toolStripButtonEditTable";
			this.toolStripButtonEditTable.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonEditTable.Text = "Alter Table";
			// 
			// toolStripButtonAddTable
			// 
			this.toolStripButtonAddTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonAddTable.Enabled = false;
			this.toolStripButtonAddTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddTable.Image")));
			this.toolStripButtonAddTable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonAddTable.Name = "toolStripButtonAddTable";
			this.toolStripButtonAddTable.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonAddTable.Text = "Create Table";
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
			this.splitContainer1.Panel1.Controls.Add(this.treeViewDatabases);
			this.splitContainer1.Panel1.Controls.Add(this.treePaneToolStrip);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listViewTableStructure);
			this.splitContainer1.Size = new System.Drawing.Size(150, 263);
			this.splitContainer1.SplitterDistance = 185;
			this.splitContainer1.TabIndex = 1;
			// 
			// treePaneToolStrip
			// 
			this.treePaneToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonAddTable,
            this.toolStripButtonEditTable,
            this.toolStripButtonDeleteTable,
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
			// DatabaseListPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "DatabaseListPane";
			this.Size = new System.Drawing.Size(150, 263);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.treePaneToolStrip.ResumeLayout(false);
			this.treePaneToolStrip.PerformLayout();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.TreeView treeViewDatabases;
		private System.Windows.Forms.ListView listViewTableStructure;
		private System.Windows.Forms.ToolStripButton toolStripButtonDeleteTable;
		private System.Windows.Forms.ToolStripButton toolStripButtonAddTable;
		private System.Windows.Forms.ToolStripButton toolStripButtonEditTable;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
		private System.Windows.Forms.ToolStrip treePaneToolStrip;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ToolStripButton toolStripButtonDeleteIndex;
		private System.Windows.Forms.ToolStripButton toolStripButtonEditIndex;
		private System.Windows.Forms.ToolStripButton toolStripButtonAddIndex;
		private System.Windows.Forms.ImageList treeViewImageList;
	}
}
