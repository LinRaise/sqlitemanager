using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SQLiteManager.Core;

namespace SQLiteManager.Gui.TreeNodes
{
    public class IndexTreeNode : TreeNode
    {
        private readonly string databaseId = string.Empty;
		private readonly string indexName = string.Empty;
		
		public string DatabaseId {
			get { return databaseId; }
		}
		public string IndexName {
			get { return indexName; }
		}

        public IndexTreeNode(string indexName, string databaseId, int imageIndex, int selectedImageIndex)
		{
			ImageIndex = imageIndex;
			SelectedImageIndex = selectedImageIndex;
			
			Text = indexName;
			
			this.indexName = indexName;
			this.databaseId = databaseId;
		}
    }
    
    public class IndexesTreeNode : TreeNode
    {
    	IList<Index> indexes;
    	
		public IList<Index> Indexes {
			get { return indexes; }
			set {
				indexes = value;
				Text = string.Format("Indexes ({0})", indexes.Count);
				foreach (var n in indexes) {
					Nodes.Add(new IndexTreeNode2(n, 6, 6));
				}
			}
		}
    	
    	public IndexesTreeNode(IList<Index> indexes, int imageIndex, int selectedImageIndex)
    	{
    		this.Indexes = indexes;
    		this.ImageIndex = imageIndex;
    		this.SelectedImageIndex = selectedImageIndex;
    	}
    }
    
    public class IndexTreeNode2 : TreeNode
    {
    	Index index;
    	
		public Index DatabaseIndex {
			get { return index; }
			set {
				index = value;
				Text = index.Name;
			}
		}
    	
    	public IndexTreeNode2(Index index, int imageIndex, int selectedImageIndex)
    	{
    		this.DatabaseIndex = index;
    		this.ImageIndex = imageIndex;
    		this.SelectedImageIndex = selectedImageIndex;
    	}
    }
}
