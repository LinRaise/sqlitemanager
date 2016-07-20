//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;

namespace SQLiteManager.Gui.TreeNodes
{
	[Serializable]
    public class DbObjectTreeNode : TreeNode
	{
		public const string STR_TABLES_DB_OBJECT_NAME = "Tables";
        public const string STR_INDEXES_DB_OBJECT_NAME = "Indexes";
        
        public NodeType Type { get; private set; }
        public string DatabaseId { get; private set; }
	    public enum NodeType
	    {
	        Indexes,
            Tables
	    }
	    
		public DbObjectTreeNode(string dbObjectName, int dbObjectCount, int imageIndex, int selectedImageIndex, NodeType nodeType, string databaseId)
		{
			ImageIndex = imageIndex;
			SelectedImageIndex = selectedImageIndex;
            Type = nodeType;
		    DatabaseId = databaseId;
			Text = string.Format("{0} ({1})", dbObjectName, dbObjectCount);
		}
	}
}
