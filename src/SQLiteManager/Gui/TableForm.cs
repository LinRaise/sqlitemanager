//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using SQLiteManager.Core.Utilities;
using SQLiteManager.Core;

namespace SQLiteManager.Gui
{
	public partial class TableForm : BaseForm
	{
		Table table;

		public Table Table {
			get {
				return table;
			}
			
			set {
				table = value;
				textBoxName.Text = table.Name;
				RefreshColumns();
			}
		}

		public TableForm() : this(new Table())
		{
		}

		public TableForm(Table table)
		{
			InitializeComponent();
			table.ColumnAdded += TableColumnAdded;
			Table = table;
		}

		void TableColumnAdded(object sender, EventArgs e)
		{
			RefreshColumns();
		}

		void RefreshColumns()
		{
			columnsList.Items.Clear();
			foreach (Column c in table.Columns) {
				ListViewItem li = columnsList.Items.Add(c.Name);
				li.SubItems.Add(c.Type);
				li.SubItems.Add(c.Default != null ? c.Default.ToString() : "{null}");
			}
		}

		void ButtonAddColumnClick(object sender, EventArgs e)
		{
			using (var f = new ColumnForm()) {
//				if (WorkbenchSingleton.MainForm.AddDialog(f) == DialogResult.OK) {
				if (WorkbenchSingleton.ShowDialogView(f) == DialogResult.OK) {
					table.AddColumn(f.Column);
				}
			}
		}

		void ButtonDropColumnClick(object sender, EventArgs e)
		{
			for (int i = 0; i < columnsList.SelectedItems.Count; i++) {
				ListViewItem selectedItem = columnsList.SelectedItems[i];
				if (table.Columns.Remove(table.Columns.First(n => n.Name.Equals(selectedItem.Text)))) {
					columnsList.Items.Remove(selectedItem);
					i = 0;
				}
			}
			RefreshColumns();
		}

        private void buttonOk_Click(object sender, EventArgs e)
        {
            table.Name = textBoxName.Text;

            TableValidator tblValidator = new TableValidator();

            ICollection<IValidationResult> results;
            if (!tblValidator.Validate(table, out results))
            {
                string message = string.Empty;

                foreach (IValidationResult result in results) {
                    message += result.Message + Environment.NewLine;
                }
                
                MessageService.ShowError(message);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
	}
}
