using System;

namespace SQLiteManager.Gui
{
    public class IndexSelectedEventArgs : EventArgs
    {
        private readonly string databaseId = string.Empty;
        private readonly string indexName = string.Empty;

        public string DatabaseId
        {
            get { return databaseId; }
        }
        public string IndexName
        {
            get { return indexName; }
        }

        public IndexSelectedEventArgs(string databaseId, string indexName)
        {
            this.databaseId = databaseId;
            this.indexName = indexName;
        }
    }
}
