using System;
using System.Linq;
using System.Collections.Generic;
using SQLiteManager.Core;
using SQLiteManager.Core.Utilities;

namespace SQLiteManager.Gui
{
	public partial class IndexForm : BaseForm
	{
		private readonly string databaseId;
		
		private readonly Index index;
		
		public Index Index {
			get {
				var index = new Index(txIndexName.Text.Trim(), SelectedTable) {
					Unique = cbUnique.Checked,
				};
				foreach (var checkedItem in chLstBoxColumns.CheckedItems) {
					index.AddColumn(checkedItem.ToString());
				}
				return index;
			}
		}

		private Table SelectedTable {
			get {
				return DatabaseManager.Instance.FindTable(databaseId, cbTables.SelectedItem.ToString());
			}
		}

		public IndexForm(Index index) {
			InitializeComponent();
			cbTables.Enabled = false;
            cbTables.Text = index.Table.Name;
			this.index = index;
			Init(index);
		}

		public IndexForm(string databaseId)
		{
			InitializeComponent();
			this.databaseId = databaseId;
			GetTables(databaseId);
			index = new Index();
		}

		private void Init(Index index)
		{
			txIndexName.Text = index.Name;
			cbUnique.Checked = index.Unique;
			CheckColumns(index.Table);
		}

		private void CheckColumns(Table table)
		{
			chLstBoxColumns.Items.Clear();
			if (table != null) {
				foreach (Column column in table.Columns) {
					bool columnChecked = index.Columns.Any(n => n.Name.Equals(column.Name));
					chLstBoxColumns.Items.Add(column.Name, columnChecked);
				}
			}
		}

		private void GetTables(string databaseId)
		{
			var database = DatabaseManager.Instance.FindDatabase(databaseId);
			foreach (var table in database.Tables) {
				cbTables.Items.Add(table.Name);
			}
		}

		private void CbTablesSelectedIndexChanged(object sender, EventArgs e) {
			CheckColumns(SelectedTable);
		}

        private void btOk_Click(object sender, EventArgs e)
        {
            IndexValidator idxValidator = new IndexValidator();

            ICollection<IValidationResult> results;
            if (!idxValidator.Validate(this.Index, out results))
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
