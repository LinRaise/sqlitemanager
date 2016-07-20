//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

namespace SQLiteManager.Gui
{
	partial class ColumnForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxNotNull = new System.Windows.Forms.CheckBox();
            this.checkBoxPrimaryKey = new System.Windows.Forms.CheckBox();
            this.cbColumnType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Column:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(72, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(171, 21);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(88, 120);
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
            this.buttonCancel.Location = new System.Drawing.Point(168, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotNull
            // 
            this.checkBoxNotNull.Location = new System.Drawing.Point(72, 64);
            this.checkBoxNotNull.Name = "checkBoxNotNull";
            this.checkBoxNotNull.Size = new System.Drawing.Size(104, 24);
            this.checkBoxNotNull.TabIndex = 4;
            this.checkBoxNotNull.Text = "Not NULL";
            this.checkBoxNotNull.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrimaryKey
            // 
            this.checkBoxPrimaryKey.Location = new System.Drawing.Point(72, 88);
            this.checkBoxPrimaryKey.Name = "checkBoxPrimaryKey";
            this.checkBoxPrimaryKey.Size = new System.Drawing.Size(104, 24);
            this.checkBoxPrimaryKey.TabIndex = 5;
            this.checkBoxPrimaryKey.Text = "Primary KEY";
            this.checkBoxPrimaryKey.UseVisualStyleBackColor = true;
            // 
            // cbColumnType
            // 
            this.cbColumnType.FormattingEnabled = true;
            this.cbColumnType.Items.AddRange(new object[] {
            "INTEGER",
            "TEXT",
            "REAL",
            "NUMERIC"});
            this.cbColumnType.Location = new System.Drawing.Point(72, 43);
            this.cbColumnType.Name = "cbColumnType";
            this.cbColumnType.Size = new System.Drawing.Size(171, 21);
            this.cbColumnType.TabIndex = 3;
            // 
            // ColumnForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(251, 153);
            this.Controls.Add(this.cbColumnType);
            this.Controls.Add(this.checkBoxPrimaryKey);
            this.Controls.Add(this.checkBoxNotNull);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "ColumnForm";
            this.Text = "New Column";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.CheckBox checkBoxPrimaryKey;
		private System.Windows.Forms.CheckBox checkBoxNotNull;
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbColumnType;
	}
}
