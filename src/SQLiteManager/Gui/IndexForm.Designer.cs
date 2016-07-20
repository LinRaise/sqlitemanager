namespace SQLiteManager.Gui
{
    partial class IndexForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.chLstBoxColumns = new System.Windows.Forms.CheckedListBox();
            this.labelIndexName = new System.Windows.Forms.Label();
            this.txIndexName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUnique = new System.Windows.Forms.CheckBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbTable = new System.Windows.Forms.Label();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chLstBoxColumns
            // 
            this.chLstBoxColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chLstBoxColumns.FormattingEnabled = true;
            this.chLstBoxColumns.Location = new System.Drawing.Point(3, 17);
            this.chLstBoxColumns.Name = "chLstBoxColumns";
            this.chLstBoxColumns.Size = new System.Drawing.Size(272, 148);
            this.chLstBoxColumns.TabIndex = 8;
            // 
            // labelIndexName
            // 
            this.labelIndexName.AutoSize = true;
            this.labelIndexName.Location = new System.Drawing.Point(-1, 9);
            this.labelIndexName.Name = "labelIndexName";
            this.labelIndexName.Size = new System.Drawing.Size(38, 13);
            this.labelIndexName.TabIndex = 1;
            this.labelIndexName.Text = "Name:";
            // 
            // txIndexName
            // 
            this.txIndexName.Location = new System.Drawing.Point(43, 6);
            this.txIndexName.Name = "txIndexName";
            this.txIndexName.Size = new System.Drawing.Size(237, 21);
            this.txIndexName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chLstBoxColumns);
            this.groupBox1.Location = new System.Drawing.Point(2, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 177);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Columns";
            // 
            // cbUnique
            // 
            this.cbUnique.AutoSize = true;
            this.cbUnique.Location = new System.Drawing.Point(5, 58);
            this.cbUnique.Name = "cbUnique";
            this.cbUnique.Size = new System.Drawing.Size(59, 17);
            this.cbUnique.TabIndex = 5;
            this.cbUnique.Text = "Unique";
            this.cbUnique.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(124, 264);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 7;
            this.btOk.Text = "&OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(205, 264);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "&Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Location = new System.Drawing.Point(-1, 36);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(37, 13);
            this.lbTable.TabIndex = 3;
            this.lbTable.Text = "Table:";
            // 
            // cbTables
            // 
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(43, 33);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(237, 21);
            this.cbTables.TabIndex = 4;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.CbTablesSelectedIndexChanged);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(292, 299);
            this.Controls.Add(this.cbTables);
            this.Controls.Add(this.lbTable);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.cbUnique);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txIndexName);
            this.Controls.Add(this.labelIndexName);
            this.Name = "IndexForm";
            this.Text = "IndexForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chLstBoxColumns;
        private System.Windows.Forms.Label labelIndexName;
        private System.Windows.Forms.TextBox txIndexName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbUnique;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.ComboBox cbTables;
    }
}