//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SQLiteManager.Core;

namespace SQLiteManager.Gui.TreeNodes
{
	[Serializable]
    public class TableTreeNode : TreeNode
	{
		private readonly string databaseId = string.Empty;
		private readonly string tableName = string.Empty;
		
		public string DatabaseId {
			get { return databaseId; }
		}
		public string TableName {
			get { return tableName; }
		}
		
		public TableTreeNode(string tableName, string databaseId, int imageIndex, int selectedImageIndex)
		{
			ImageIndex = imageIndex;
			SelectedImageIndex = selectedImageIndex;
			
			Text = tableName;
			
			this.tableName = tableName;
			this.databaseId = databaseId;
		}
	}
    
    public class TablesTreeNode : TreeNode
    {
    	IList<Table> tables;
    	
		public IList<Table> Tables {
			get { return tables; }
			set {
				tables = value;
				Text = string.Format("Tables ({0})", tables.Count);
				foreach (var t in tables) {
					Nodes.Add(new TableTreeNode2(t, 2, 2));
				}
				Expand();
			}
		}
    	
    	public TablesTreeNode(IList<Table> tables, int imageIndex, int selectedImageIndex)
    	{
    		this.Tables = tables;
    		this.ImageIndex = imageIndex;
    		this.SelectedImageIndex = selectedImageIndex;
    	}
    }
    
    public class TableTreeNode2 : TreeNode
    {
    	Table table;
    	
		public Table Table {
			get { return table; }
			set {
				table = value;
				Text = table.Name;
				foreach (var c in table.Columns) {
					int i = c.PrimaryKey ? 3 : 4;
					Nodes.Add(new ColumnTreeNode(c, i, i));
				}
			}
		}
    	
    	public TableTreeNode2(Table table, int imageIndex, int selectedImageIndex)
    	{
    		this.Table = table;
    		this.ImageIndex = imageIndex;
    		this.SelectedImageIndex = selectedImageIndex;
    	}
    }
}
