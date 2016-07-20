using System.Windows.Forms;

namespace SQLiteManager.Gui
{
    public partial class ColumnsList : UserControl
    {
        public ColumnsList() {
            InitializeComponent();
        }

        public ListView.ListViewItemCollection Items
        {
            get { return listViewColumns.Items; }
        }

        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get { return listViewColumns.SelectedItems; }
        }
    }
}
