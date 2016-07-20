//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

namespace SQLiteManager
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.commandsToolStrip = new System.Windows.Forms.ToolStrip();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tablesPane = new SQLiteManager.Gui.TablesPane();
			this.tabControlDocuments = new System.Windows.Forms.TabControl();
			this.editorOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.editorSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.mainStatusStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(712, 24);
			this.mainMenuStrip.TabIndex = 0;
			this.mainMenuStrip.Text = "menuStrip1";
			// 
			// commandsToolStrip
			// 
			this.commandsToolStrip.Location = new System.Drawing.Point(0, 24);
			this.commandsToolStrip.Name = "commandsToolStrip";
			this.commandsToolStrip.Size = new System.Drawing.Size(712, 25);
			this.commandsToolStrip.TabIndex = 1;
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 444);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(712, 22);
			this.mainStatusStrip.TabIndex = 2;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 49);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tablesPane);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControlDocuments);
			this.splitContainer1.Size = new System.Drawing.Size(712, 395);
			this.splitContainer1.SplitterDistance = 184;
			this.splitContainer1.TabIndex = 3;
			// 
			// tablesPane
			// 
			this.tablesPane.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablesPane.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tablesPane.Location = new System.Drawing.Point(0, 0);
			this.tablesPane.Name = "tablesPane";
			this.tablesPane.Size = new System.Drawing.Size(184, 395);
			this.tablesPane.TabIndex = 0;
			// 
			// tabControlDocuments
			// 
			this.tabControlDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlDocuments.Location = new System.Drawing.Point(0, 0);
			this.tabControlDocuments.Name = "tabControlDocuments";
			this.tabControlDocuments.SelectedIndex = 0;
			this.tabControlDocuments.Size = new System.Drawing.Size(524, 395);
			this.tabControlDocuments.TabIndex = 0;
			// 
			// editorOpenFileDialog
			// 
			this.editorOpenFileDialog.Filter = "SQL files|*.sql";
			this.editorOpenFileDialog.Title = "Open Query";
			// 
			// editorSaveFileDialog
			// 
			this.editorSaveFileDialog.Filter = "SQL files|*.sql";
			this.editorSaveFileDialog.Title = "Save Query";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(712, 466);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.commandsToolStrip);
			this.Controls.Add(this.mainMenuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenuStrip;
			this.Name = "MainForm";
			this.Text = "SQLiteManager";
			this.commandsToolStrip.ResumeLayout(false);
			this.commandsToolStrip.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog editorSaveFileDialog;
		private System.Windows.Forms.OpenFileDialog editorOpenFileDialog;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStrip commandsToolStrip;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.TabControl tabControlDocuments;
		private SQLiteManager.Gui.TablesPane tablesPane;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}
