namespace SQLiteManager.Gui
{
    partial class ViewerIndexPane
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIndex = new System.Windows.Forms.TabPage();
            this.columnsList = new SQLiteManager.Gui.ColumnsList();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.textEditorControlScript = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabControl1.SuspendLayout();
            this.tabIndex.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIndex);
            this.tabControl1.Controls.Add(this.tabScript);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 353);
            this.tabControl1.TabIndex = 0;
            // 
            // tabIndex
            // 
            this.tabIndex.Controls.Add(this.columnsList);
            this.tabIndex.Location = new System.Drawing.Point(4, 22);
            this.tabIndex.Name = "tabIndex";
            this.tabIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndex.Size = new System.Drawing.Size(339, 327);
            this.tabIndex.TabIndex = 0;
            this.tabIndex.Text = "Columns";
            this.tabIndex.UseVisualStyleBackColor = true;
            // 
            // columnsList
            // 
            this.columnsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnsList.Location = new System.Drawing.Point(3, 3);
            this.columnsList.Name = "columnsList";
            this.columnsList.Size = new System.Drawing.Size(333, 321);
            this.columnsList.TabIndex = 13;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.textEditorControlScript);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(339, 327);
            this.tabScript.TabIndex = 1;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // textEditorControlScript
            // 
            this.textEditorControlScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControlScript.IsReadOnly = false;
            this.textEditorControlScript.Location = new System.Drawing.Point(3, 3);
            this.textEditorControlScript.Name = "textEditorControlScript";
            this.textEditorControlScript.Size = new System.Drawing.Size(333, 321);
            this.textEditorControlScript.TabIndex = 1;
            // 
            // ViewerIndexPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ViewerIndexPane";
            this.Size = new System.Drawing.Size(347, 353);
            this.tabControl1.ResumeLayout(false);
            this.tabIndex.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIndex;
        private ColumnsList columnsList;
        private System.Windows.Forms.TabPage tabScript;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControlScript;


    }
}
