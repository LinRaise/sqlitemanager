//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Core;

namespace SQLiteManager.Gui.TreeNodes
{
	[Serializable]
    public class ColumnTreeNode : TreeNode
	{
		public ColumnTreeNode(Column column, int imageIndex, int selectedImageIndex)
		{
			ImageIndex = imageIndex;
			SelectedImageIndex = selectedImageIndex;
			
			Text = string.Format("{0} {1} ({2})", column.Name, column.Type, column.NotNull ? "Not NULL" : "NULL");
		}
	}
}
