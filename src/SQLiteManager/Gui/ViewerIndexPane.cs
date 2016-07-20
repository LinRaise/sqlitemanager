using System;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using SQLiteManager.Core;
using SQLiteManager.Gui.SqlSyntaxHighlighting;

namespace SQLiteManager.Gui
{
    public partial class ViewerIndexPane : BaseDatabaseDependentControl
    {
        public ViewerIndexPane() {
            InitializeComponent();
            HighlightingManager.Manager.AddSyntaxModeFileProvider(new AppSyntaxModeProvider());
            textEditorControlScript.Font = new Font("Lucida Console", 8);
            textEditorControlScript.SetHighlighting("SQL");
            textEditorControlScript.IsReadOnly = true;
        }

        public void ViewIndex(string databaseId, string indexName)
        {
            columnsList.Items.Clear();
            var index = DatabaseManager.Instance.FindIndex(databaseId, indexName);
            if (index == null) {
                throw new ArgumentException("Incorrect database ID or index name");
            }

            foreach (var column in index.Columns) {
                var li = columnsList.Items.Add(column.Name);
                li.SubItems.Add(column.Type);
                li.SubItems.Add(column.Default != null ? column.Default.ToString() : "{null}");
            }
            textEditorControlScript.Text = index.Script;
        }
    }
}
