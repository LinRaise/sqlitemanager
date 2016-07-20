//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//		<author name="Brandon Hawker" email="bhawker@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using SQLiteManager.Core;
using SQLiteManager.Core.Utilities;

namespace SQLiteManager.Gui
{
	public partial class ColumnForm : BaseForm
	{
		Column col;
		
		public Column Column {
			get { 				
				return col; 
			}
			set { 
				col = value;
				textBoxName.Text = col.Name;
                cbColumnType.Text = col.Type;
				checkBoxNotNull.Checked = col.NotNull;
				checkBoxPrimaryKey.Checked = col.PrimaryKey;
			}
		}
		
		public ColumnForm() : this(new Column())
		{
		}
		
		public ColumnForm(Column column)
		{
			InitializeComponent();
			Column = column;
		}

        private void buttonOk_Click(object sender, EventArgs e)
        {
            col.Name = textBoxName.Text;
            col.Type = cbColumnType.Text;
            col.NotNull = checkBoxNotNull.Checked;
            col.PrimaryKey = checkBoxPrimaryKey.Checked;

            ColumnValidator colValidator = new ColumnValidator();

            ICollection<IValidationResult> results;
            if (!colValidator.Validate(col, out results))
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
