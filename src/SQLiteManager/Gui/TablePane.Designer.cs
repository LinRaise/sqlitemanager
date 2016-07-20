//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

namespace SQLiteManager.Gui
{
	partial class TablePane
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablePane));
			this.viewerTabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.listViewColumns = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dataGridData = new System.Windows.Forms.DataGrid();
			this.dataManipulationToolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSaveChanges = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textEditorControlScript = new ICSharpCode.TextEditor.TextEditorControl();
			this.viewerTablePaneImageList = new System.Windows.Forms.ImageList(this.components);
			this.viewerTabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridData)).BeginInit();
			this.dataManipulationToolStrip.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// viewerTabControl
			// 
			this.viewerTabControl.Controls.Add(this.tabPage1);
			this.viewerTabControl.Controls.Add(this.tabPage2);
			this.viewerTabControl.Controls.Add(this.tabPage3);
			this.viewerTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewerTabControl.Location = new System.Drawing.Point(0, 0);
			this.viewerTabControl.Name = "viewerTabControl";
			this.viewerTabControl.SelectedIndex = 0;
			this.viewerTabControl.Size = new System.Drawing.Size(355, 264);
			this.viewerTabControl.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.listViewColumns);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(347, 238);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Columns";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// listViewColumns
			// 
			this.listViewColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listViewColumns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewColumns.FullRowSelect = true;
			this.listViewColumns.GridLines = true;
			this.listViewColumns.Location = new System.Drawing.Point(3, 3);
			this.listViewColumns.Name = "listViewColumns";
			this.listViewColumns.Size = new System.Drawing.Size(341, 232);
			this.listViewColumns.SmallImageList = this.viewerTablePaneImageList;
			this.listViewColumns.TabIndex = 0;
			this.listViewColumns.UseCompatibleStateImageBehavior = false;
			this.listViewColumns.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Column";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Default";
			this.columnHeader3.Width = 100;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dataGridData);
			this.tabPage2.Controls.Add(this.dataManipulationToolStrip);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(347, 238);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Data";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dataGridData
			// 
			this.dataGridData.CaptionVisible = false;
			this.dataGridData.DataMember = "";
			this.dataGridData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridData.Location = new System.Drawing.Point(3, 3);
			this.dataGridData.Name = "dataGridData";
			this.dataGridData.Size = new System.Drawing.Size(341, 207);
			this.dataGridData.TabIndex = 4;
			// 
			// dataManipulationToolStrip
			// 
			this.dataManipulationToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataManipulationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButton3,
									this.toolStripButton4,
									this.toolStripButtonSaveChanges,
									this.toolStripButton2,
									this.toolStripSeparator1,
									this.toolStripButtonRefresh});
			this.dataManipulationToolStrip.Location = new System.Drawing.Point(3, 210);
			this.dataManipulationToolStrip.Name = "dataManipulationToolStrip";
			this.dataManipulationToolStrip.Size = new System.Drawing.Size(341, 25);
			this.dataManipulationToolStrip.TabIndex = 3;
			this.dataManipulationToolStrip.Text = "toolStrip1";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Insert record";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Delete record";
			// 
			// toolStripButtonSaveChanges
			// 
			this.toolStripButtonSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveChanges.Image")));
			this.toolStripButtonSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSaveChanges.Name = "toolStripButtonSaveChanges";
			this.toolStripButtonSaveChanges.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSaveChanges.Text = "Save changes";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Cancel changes";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonRefresh
			// 
			this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
			this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
			this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonRefresh.Text = "toolStripButton5";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textEditorControlScript);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(347, 238);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Script";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// textEditorControlScript
			// 
			this.textEditorControlScript.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditorControlScript.IsReadOnly = false;
			this.textEditorControlScript.Location = new System.Drawing.Point(3, 3);
			this.textEditorControlScript.Name = "textEditorControlScript";
			this.textEditorControlScript.Size = new System.Drawing.Size(341, 232);
			this.textEditorControlScript.TabIndex = 0;
			// 
			// viewerTablePaneImageList
			// 
			this.viewerTablePaneImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("viewerTablePaneImageList.ImageStream")));
			this.viewerTablePaneImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.viewerTablePaneImageList.Images.SetKeyName(0, "database.png");
			this.viewerTablePaneImageList.Images.SetKeyName(1, "key.png");
			// 
			// TablePane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.viewerTabControl);
			this.Name = "TablePane";
			this.Size = new System.Drawing.Size(355, 264);
			this.viewerTabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridData)).EndInit();
			this.dataManipulationToolStrip.ResumeLayout(false);
			this.dataManipulationToolStrip.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.TabControl viewerTabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ListView listViewColumns;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGrid dataGridData;
		private System.Windows.Forms.ToolStrip dataManipulationToolStrip;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButtonSaveChanges;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
		private System.Windows.Forms.TabPage tabPage3;
		private ICSharpCode.TextEditor.TextEditorControl textEditorControlScript;
		private System.Windows.Forms.ImageList viewerTablePaneImageList;
	}
}
