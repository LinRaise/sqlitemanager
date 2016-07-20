//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

namespace SQLiteManager.Gui
{
	partial class QueryAndResultPane
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
			this.queryAndResultsSplitContainer = new System.Windows.Forms.SplitContainer();
			this.queryTextEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
			this.resultsTabControl = new System.Windows.Forms.TabControl();
			this.queryAndResultStatusStrip = new System.Windows.Forms.StatusStrip();
			this.currentDatabaseToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.placeHolderToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.rowCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.queryAndResultsSplitContainer.Panel1.SuspendLayout();
			this.queryAndResultsSplitContainer.Panel2.SuspendLayout();
			this.queryAndResultsSplitContainer.SuspendLayout();
			this.queryAndResultStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// queryAndResultsSplitContainer
			// 
			this.queryAndResultsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.queryAndResultsSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.queryAndResultsSplitContainer.Name = "queryAndResultsSplitContainer";
			this.queryAndResultsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// queryAndResultsSplitContainer.Panel1
			// 
			this.queryAndResultsSplitContainer.Panel1.Controls.Add(this.queryTextEditorControl);
			// 
			// queryAndResultsSplitContainer.Panel2
			// 
			this.queryAndResultsSplitContainer.Panel2.Controls.Add(this.resultsTabControl);
			this.queryAndResultsSplitContainer.Size = new System.Drawing.Size(441, 307);
			this.queryAndResultsSplitContainer.SplitterDistance = 137;
			this.queryAndResultsSplitContainer.TabIndex = 0;
			// 
			// queryTextEditorControl
			// 
			this.queryTextEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.queryTextEditorControl.IsReadOnly = false;
			this.queryTextEditorControl.Location = new System.Drawing.Point(0, 0);
			this.queryTextEditorControl.Name = "queryTextEditorControl";
			this.queryTextEditorControl.Size = new System.Drawing.Size(441, 137);
			this.queryTextEditorControl.TabIndex = 0;
			// 
			// resultsTabControl
			// 
			this.resultsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsTabControl.Location = new System.Drawing.Point(0, 0);
			this.resultsTabControl.Name = "resultsTabControl";
			this.resultsTabControl.SelectedIndex = 0;
			this.resultsTabControl.Size = new System.Drawing.Size(441, 166);
			this.resultsTabControl.TabIndex = 2;
			// 
			// queryAndResultStatusStrip
			// 
			this.queryAndResultStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.currentDatabaseToolStripStatusLabel,
									this.placeHolderToolStripStatusLabel,
									this.rowCountToolStripStatusLabel});
			this.queryAndResultStatusStrip.Location = new System.Drawing.Point(0, 307);
			this.queryAndResultStatusStrip.Name = "queryAndResultStatusStrip";
			this.queryAndResultStatusStrip.Size = new System.Drawing.Size(441, 22);
			this.queryAndResultStatusStrip.SizingGrip = false;
			this.queryAndResultStatusStrip.TabIndex = 2;
			// 
			// currentDatabaseToolStripStatusLabel
			// 
			this.currentDatabaseToolStripStatusLabel.Name = "currentDatabaseToolStripStatusLabel";
			this.currentDatabaseToolStripStatusLabel.Size = new System.Drawing.Size(103, 17);
			this.currentDatabaseToolStripStatusLabel.Text = "{CurrentDataBase}";
			// 
			// placeHolderToolStripStatusLabel
			// 
			this.placeHolderToolStripStatusLabel.Name = "placeHolderToolStripStatusLabel";
			this.placeHolderToolStripStatusLabel.Size = new System.Drawing.Size(255, 17);
			this.placeHolderToolStripStatusLabel.Spring = true;
			// 
			// rowCountToolStripStatusLabel
			// 
			this.rowCountToolStripStatusLabel.Name = "rowCountToolStripStatusLabel";
			this.rowCountToolStripStatusLabel.Size = new System.Drawing.Size(68, 17);
			this.rowCountToolStripStatusLabel.Text = "{rowCount}";
			// 
			// QueryAndResultPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.queryAndResultsSplitContainer);
			this.Controls.Add(this.queryAndResultStatusStrip);
			this.Name = "QueryAndResultPane";
			this.Size = new System.Drawing.Size(441, 329);
			this.queryAndResultsSplitContainer.Panel1.ResumeLayout(false);
			this.queryAndResultsSplitContainer.Panel2.ResumeLayout(false);
			this.queryAndResultsSplitContainer.ResumeLayout(false);
			this.queryAndResultStatusStrip.ResumeLayout(false);
			this.queryAndResultStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SplitContainer queryAndResultsSplitContainer;
		private System.Windows.Forms.TabControl resultsTabControl;
		private System.Windows.Forms.ToolStripStatusLabel rowCountToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel placeHolderToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel currentDatabaseToolStripStatusLabel;
		private System.Windows.Forms.StatusStrip queryAndResultStatusStrip;
		private ICSharpCode.TextEditor.TextEditorControl queryTextEditorControl;
	}
}
