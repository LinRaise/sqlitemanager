//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;

using ICSharpCode.TextEditor.Document;
using SQLiteManager.Core;
using SQLiteManager.Gui.SqlSyntaxHighlighting;

namespace SQLiteManager.Gui
{
	public partial class QueryAndResultPane : BaseDatabaseDependentControl
	{
		public event EventHandler QueryChanged;
		private string fileName = string.Empty;
		
		static QueryAndResultPane()
		{
			HighlightingManager.Manager.AddSyntaxModeFileProvider(
				new AppSyntaxModeProvider()
			);
		}
		
		public QueryAndResultPane(string databaseId)
		{
			InitializeComponent();
			
			queryAndResultsSplitContainer.Panel2Collapsed = true;
			
			DatabaseId = databaseId;
			
			rowCountToolStripStatusLabel.Text = string.Empty;
//			this.queryTextEditorControl.Font = new Font("Lucida Console", 8);
			queryTextEditorControl.SetHighlighting("SQL");
			queryTextEditorControl.TextChanged += delegate { OnQueryChanged(null); };
			resultsTabControl2.SelectedIndexChanged += delegate {
				OnResultsTabControlSelectedIndexChanged();
			};
		}
		
		public QueryAndResultPane(string databaseId, string fileName) : this(databaseId)
		{
			this.fileName = fileName;
			ReadFile();
		}
		
		public string FileName {
			get { return fileName; }
			set { fileName = value; }
		}
		
		public void Save()
		{
			queryTextEditorControl.SaveFile(fileName);
		}
		
		public void ExecuteCurrentQuery()
		{
			string query;

			if (queryTextEditorControl.ActiveTextAreaControl.SelectionManager.HasSomethingSelected) {
				query = queryTextEditorControl.ActiveTextAreaControl.SelectionManager.SelectedText;
			} else {
				int currPos = queryTextEditorControl.Document.PositionToOffset(queryTextEditorControl.ActiveTextAreaControl.Caret.Position);
				query = GetQueryInSelection(currPos, currPos);
			}

			ExecuteQuery(query);
		}
		
		public void ExecuteAllQueries()
		{
			ExecuteQuery(queryTextEditorControl.Text);
		}
		
		protected virtual void OnQueryChanged(EventArgs e)
		{
			if (QueryChanged != null) {
				QueryChanged(this, e);
			}
		}
		
		protected override void OnDatabaseChanged(Database database)
		{
			if (database != null) {
				currentDatabaseToolStripStatusLabel.Text = database.FileName;
			} else {
				currentDatabaseToolStripStatusLabel.Text = @"No database selected";
			}
		}
		
		void ReadFile()
		{
			queryTextEditorControl.LoadFile(fileName);
		}
		
		string GetQueryInSelection(int searchForBeginingFrom, int searchForEndFrom)
		{
			var editorTextLength = queryTextEditorControl.Text.Length;
			
			while (searchForBeginingFrom > 0) {
				searchForBeginingFrom--;
				
				if (queryTextEditorControl.Text[searchForBeginingFrom].Equals(Query.StatementSplitter)) {
					break;
				}
			}
			
			while (searchForEndFrom < (editorTextLength - 1)) {
				searchForEndFrom++;

				if (queryTextEditorControl.Text[searchForEndFrom].Equals(Query.StatementSplitter)) {
					break;
				}
			}
			
			if (searchForBeginingFrom > 0) {
				searchForBeginingFrom++;
			}
			
			return queryTextEditorControl.Text.Substring(searchForBeginingFrom, searchForEndFrom - searchForBeginingFrom);
		}
		
		// FIXME: Add this from design time. #D 4 is giving me annoying errors on design. Don't have VS2010 at work.
		readonly ResultsTabControl resultsTabControl2 = new ResultsTabControl();

		void ExecuteQuery(string query)
		{
			if (DatabaseId != null) {
				resultsTabControl2.Visible = false;
				var results = DatabaseManager.Instance.ExecuteMultiQuery(this.DatabaseId, query);
				resultsTabControl2.Results = results;
				
				resultsTabControl2.Visible = true;
				resultsTabControl2.Dock = DockStyle.Fill;
				queryAndResultsSplitContainer.Panel2.Controls.Clear();
				queryAndResultsSplitContainer.Panel2.Controls.Add(resultsTabControl2);
				
				OnResultsTabControlSelectedIndexChanged();
				
				if (queryAndResultsSplitContainer.Panel2Collapsed) {
					queryAndResultsSplitContainer.Panel2Collapsed = false;
				}
			}
		}
		
		void OnResultsTabControlSelectedIndexChanged()
		{
			if (resultsTabControl2.SelectedTab != null) {
				if (resultsTabControl2.SelectedTab.Tag != null) {
					rowCountToolStripStatusLabel.Text = string.Format("{0} rows", resultsTabControl2.SelectedTab.Tag);
				} else {
					rowCountToolStripStatusLabel.Text = string.Empty;
				}
			}
		}
	}
}
