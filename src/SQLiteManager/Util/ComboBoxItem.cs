//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;

namespace SQLiteManager.Util
{
	public class ComboBoxItem
	{
		public const string ValueMemberName = "ItemValue";
		public const string DisplayMemberName = "ItemText";
		
		private string itemValue = string.Empty;
		private string itemText = string.Empty;
		
		public string ItemValue {
			get { return itemValue; }
			set { itemValue = value; }
		}
		public string ItemText {
			get { return itemText; }
			set { itemText = value; }
		}
	}
}
