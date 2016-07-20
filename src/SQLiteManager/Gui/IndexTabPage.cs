using System.Windows.Forms;
using SQLiteManager.Util;

namespace SQLiteManager.Gui
{
    class IndexTabPage : TabPage, IDatabaseDepedentControl
    {
        public string DatabaseId {
			get {
				return viewerIndexPane.DatabaseId;
			}
		}
		public string TableName {
			get {
				return viewerIndexPane.TableName;
			}
		}

        private readonly ViewerIndexPane viewerIndexPane = new ViewerIndexPane();

        public IndexTabPage()
		{
			this.Text = @"Index Viewer";
			viewerIndexPane.Dock = DockStyle.Fill;
			Controls.Add(viewerIndexPane);
		}
		
		public void ViewIndex(string databaseId, string indexName)
		{
			viewerIndexPane.ViewIndex(databaseId, indexName);
		}
    }
}
