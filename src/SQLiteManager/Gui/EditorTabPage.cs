//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using SQLiteManager.Util;

namespace SQLiteManager.Gui
{
	public class EditorTabPage : TabPage, IDatabaseDepedentControl
	{
		public string DatabaseId {
			get { return queryAndResult.DatabaseId; }
			set { queryAndResult.DatabaseId = value; }
		}
		
		public string TableName {
			get { return queryAndResult.TableName; }
		}

		private static int count = 1;
		private readonly QueryAndResultPane queryAndResult;

		public bool IsDirty { get; private set; }

		public bool HasFile {
			get { return !string.IsNullOrEmpty(queryAndResult.FileName); }
		}
		
		public string FileName {
			get {
				if (HasFile) {
					return Path.GetFileName(queryAndResult.FileName);
				}
				return Text.Replace("*", string.Empty);
			}
		}

		public EditorTabPage(string databaseId)
		{
			queryAndResult = new QueryAndResultPane(databaseId);
			this.Text = @"Edit Untitled " + count++;
			InitializeComponent();
		}
		
		public EditorTabPage(string databaseId, string fileName)
		{
			queryAndResult = new QueryAndResultPane(databaseId, fileName);
			this.Text = Path.GetFileName(fileName);
			InitializeComponent();
		}
		
		public void ExecuteAllQueries()
		{
			queryAndResult.ExecuteAllQueries();
		}
		
		public void ExecuteCurrentQuery()
		{
			queryAndResult.ExecuteCurrentQuery();
		}
		
		public void Save()
		{
			if (IsDirty) {
				SaveToExistingFile();
			}
		}
		
		public void SaveToFile(string fileName)
		{
			queryAndResult.FileName = fileName;
			SaveToExistingFile();
		}
		
		void InitializeComponent()
		{
			queryAndResult.Dock = DockStyle.Fill;
			Controls.Add(queryAndResult);
			
			queryAndResult.QueryChanged += QueryAndResultQueryChanged;
		}
		
		void QueryAndResultQueryChanged(object sender, EventArgs e)
		{
			if (!IsDirty) {
				IsDirty = true;
				Text = Text + @"*";
			}
		}
		
		void SaveToExistingFile()
		{
			queryAndResult.Save();
			IsDirty = false;
			Text = Path.GetFileName(queryAndResult.FileName);
		}
	}
}
