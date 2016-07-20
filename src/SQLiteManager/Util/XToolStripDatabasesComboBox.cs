//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

using SQLiteManager.Core;

namespace SQLiteManager.Util
{
	public class XToolStripDatabasesComboBox : ToolStripComboBox, IUnwireableControl
	{
		public event EventHandler<DatabaseChangedEventArgs> DatabaseChanged;
		
		private readonly BindingList<ComboBoxItem> dataSource = new BindingList<ComboBoxItem>();
		private bool canPublishDatabaseChangedEvent = true;
		
		public XToolStripDatabasesComboBox()
		{
			Width = 400;
			
			ComboBox.DisplayMember = ComboBoxItem.DisplayMemberName;
			ComboBox.ValueMember = ComboBoxItem.ValueMemberName;
			ComboBox.DataSource = dataSource;
			
			WireEvents();
		}
		
		public void UnwireEvents()
		{
			ComboBox.SelectedIndexChanged -= XToolStripDatabasesComboBox_SelectedIndexChanged;
			DatabaseManager.Instance.DatabaseOpened -= DatabaseManager_Instance_DatabaseOpened;
			DatabaseManager.Instance.DatabaseClosed -= DatabaseManager_Instance_DatabaseClosed;
		}

		private void WireEvents()
		{
			ComboBox.SelectedIndexChanged += XToolStripDatabasesComboBox_SelectedIndexChanged;
			DatabaseManager.Instance.DatabaseOpened += DatabaseManager_Instance_DatabaseOpened;
			DatabaseManager.Instance.DatabaseClosed += DatabaseManager_Instance_DatabaseClosed;
		}
		
		private void XToolStripDatabasesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (DatabaseChanged != null && canPublishDatabaseChangedEvent) {
				DatabaseChanged(this, new DatabaseChangedEventArgs(CurrentDatabaseId));
			}
		}

		private void DatabaseManager_Instance_DatabaseClosed(object sender, DatabaseEventArgs e)
		{
			ComboBoxItem comboBoxItem = GetItemByDatbaseId(e.Database.Id);
			if (comboBoxItem != null) {
				dataSource.Remove(comboBoxItem);
			}
		}

		private void DatabaseManager_Instance_DatabaseOpened(object sender, DatabaseEventArgs e)
		{
			int oldSelectedIndex = SelectedIndex;
			
			canPublishDatabaseChangedEvent = false;
			
			dataSource.Add(new ComboBoxItem()
			                {
			                	ItemValue = e.Database.Id,
			                	ItemText = e.Database.Name
			                });
			
			SelectedIndex = oldSelectedIndex;
			canPublishDatabaseChangedEvent = true;
		}
		
		public string CurrentDatabaseId {
			get {
				if (dataSource.Count == 0) {
					return null;
				}
				if (dataSource.Count > 0 && SelectedItem == null) {
					return (ComboBox.Items[0] as ComboBoxItem).ItemValue;
				}
				return (ComboBox.SelectedItem as ComboBoxItem).ItemValue;
			}
			
			set {
				canPublishDatabaseChangedEvent = false;
				
				if (value == null) {
					SelectedIndex = -1;
				} else {
					ComboBoxItem comboBoxItem = GetItemByDatbaseId(value);
					
					if (comboBoxItem != null) {
						SelectedItem = comboBoxItem;
					}
				}
				canPublishDatabaseChangedEvent = true;
			}
		}
		
		private ComboBoxItem GetItemByDatbaseId(string databaseId)
		{
			return (from cbi in dataSource
			        where cbi.ItemValue.Equals(databaseId)
			        select cbi).FirstOrDefault();
		}
	}
}
