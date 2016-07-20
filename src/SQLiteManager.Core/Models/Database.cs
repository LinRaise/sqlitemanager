//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace SQLiteManager.Core
{
	[Serializable()]
	public class Database : IEquatable<Database>
	{
//		private string id = string.Empty;
//		private string name = string.Empty;
//		private string fileName = string.Empty;
//		public SQLiteConnection Connection { get; set; }

//	    private string password = string.Empty;
				
		private IList<Table> tables = new List<Table>();

        private IList<Index> indexes = new List<Index>();
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Password { get; set; }
        
        public Database()
        {
        }
        
        public Database(string file)
        {
        	this.FileName = file;
        	this.Name = Path.GetFileNameWithoutExtension(file);
        }
		
//		public string Id {
//			get { return id; }
//			set { id = value; }
//		}
		
//		public string Name {
//			get { return name; }
//			set { name = value; }
//		}
		
//		public string FileName {
//			get { return fileName; }
//			set { fileName = value; }
//		}

	    public bool PasswordProtected { get; set; }

//	    public string Password {
//			get { return password; }
//			set { password = value; }
//		}
		
		public IList<Table> Tables {
			get { return tables; }
			set { tables = value; }
		}

	    public IList<Index> Indexes {
	        get { return indexes; }
            set { indexes = value; }
	    }
		
	    [Obsolete()]
		public void LoadTableStructure()
		{
			tables = new TableDao().FindAll(this);
		}

		[Obsolete()]
        public void LoadIndexes()
        {
            indexes = new TableDao().FindIndexes(this);
        }

		public bool Equals(Database other)
		{
			return Id.Equals(other.Id, StringComparison.CurrentCultureIgnoreCase);
		}
		
		public SQLiteConnection CreateConnection()
		{
			string str = !PasswordProtected ? string.Format("Data Source={0};Version=3;", FileName) : string.Format("Data Source={0};Version=3;Password={1};", FileName, Password);
			return new SQLiteConnection(str);
		}
		
		public override string ToString()
		{
			var s = new StringBuilder();
			foreach (var t in tables) {
				s.Append(t.Script);
				s.Append(";");
				s.Append(Environment.NewLine);
				s.Append(Environment.NewLine);
			}
			return s.ToString();
		}
		
		public event EventHandler DatabaseRefresh;
		
		protected virtual void OnDatabaseRefresh(EventArgs e)
		{
			if (DatabaseRefresh != null) {
				DatabaseRefresh(this, e);
			}
		}
		
		public void Refresh()
		{
			Tables = Table.Load(this);
			OnDatabaseRefresh(null);
		}
		
		public static Database Load(string file)
		{
			Database d = new Database(file);
			d.Tables = Table.Load(d);
			return d;
		}
	}
}
