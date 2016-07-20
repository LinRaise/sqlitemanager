//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

namespace SQLiteManager.Gui
{
	partial class TableForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDropColumn = new System.Windows.Forms.Button();
            this.buttonAddColumn = new System.Windows.Forms.Button();
            this.columnsList = new SQLiteManager.Gui.ColumnsList();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(64, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(248, 21);
            this.textBoxName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 4);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(160, 280);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "&OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(240, 280);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonDropColumn
            // 
            this.buttonDropColumn.Location = new System.Drawing.Point(240, 235);
            this.buttonDropColumn.Name = "buttonDropColumn";
            this.buttonDropColumn.Size = new System.Drawing.Size(75, 23);
            this.buttonDropColumn.TabIndex = 4;
            this.buttonDropColumn.Text = "&Drop";
            this.buttonDropColumn.UseVisualStyleBackColor = true;
            this.buttonDropColumn.Click += new System.EventHandler(this.ButtonDropColumnClick);
            // 
            // buttonAddColumn
            // 
            this.buttonAddColumn.Location = new System.Drawing.Point(160, 235);
            this.buttonAddColumn.Name = "buttonAddColumn";
            this.buttonAddColumn.Size = new System.Drawing.Size(75, 23);
            this.buttonAddColumn.TabIndex = 3;
            this.buttonAddColumn.Text = "&Add";
            this.buttonAddColumn.UseVisualStyleBackColor = true;
            this.buttonAddColumn.Click += new System.EventHandler(this.ButtonAddColumnClick);
            // 
            // columnsList
            // 
            this.columnsList.Location = new System.Drawing.Point(8, 42);
            this.columnsList.Name = "columnsList";
            this.columnsList.Size = new System.Drawing.Size(307, 184);
            this.columnsList.TabIndex = 8;
            // 
            // TableForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(321, 314);
            this.Controls.Add(this.columnsList);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDropColumn);
            this.Controls.Add(this.buttonAddColumn);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "TableForm";
            this.Text = "New Table";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDropColumn;
        private System.Windows.Forms.Button buttonAddColumn;
        private ColumnsList columnsList;
	}
}
