//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Core;

namespace SQLiteManager.Gui.TreeNodes
{
	/// <summary>
	/// Description of DatabaseTreeNode.
	/// </summary>
	[Serializable]
	public class DatabaseTreeNode : TreeNode
	{
		private readonly string _databaseId = string.Empty;

		public string DatabaseId
		{
			get { return _databaseId; }
		}

		public DatabaseTreeNode(Database database, int imageIndex, int selectedImageIndex)
		{
			ImageIndex = imageIndex;
			SelectedImageIndex = selectedImageIndex;

			if (database != null)
			{
				Text = database.Name;
				_databaseId = database.Id;
			}
		}
	}
	
	public class DatabaseTreeNode2 : TreeNode
	{
		Database database;
		
		public Database Database {
			get { return database; }
			set {
				database = value;
				Text = database.Name;
				database.DatabaseRefresh += new EventHandler(database_DatabaseRefresh);
				database_DatabaseRefresh(this, null);
			}
		}

		void database_DatabaseRefresh(object sender, EventArgs e)
		{
			Nodes.Clear();
			Nodes.Add(new TablesTreeNode(database.Tables, 1, 1));
			Nodes.Add(new IndexesTreeNode(database.Indexes, 5, 5));
			Expand();
		}
		
		public DatabaseTreeNode2(Database database, int imageIndex, int selectedImageIndex)
		{
			this.Database = database;
			this.ImageIndex = imageIndex;
			this.SelectedImageIndex = selectedImageIndex;
		}
	}
}
