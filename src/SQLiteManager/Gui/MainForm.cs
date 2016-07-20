//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SQLiteManager.Core;
using SQLiteManager.Core.Utilities;
using SQLiteManager.Core.Views;
using SQLiteManager.Core.Workbench;

namespace SQLiteManager.Gui
{
	public partial class MainForm : Form, IWorkbench, IDatabaseListView
	{
		List<Database> databases = new List<Database>();
		Database selectedDatabase = null;
		
		public Database SelectedDatabase {
			get { return selectedDatabase; }
		}
		
		public List<Database> Databases {
			get { return databases; }
			set { databases = value; }
		}
		
		public ToolStrip WorkbenchToolBar {
			set {
				Controls.Add(value);
			}
		}
		
		public MenuStrip WorkbenchMenu {
			set {
				Controls.Add(value);
				MainMenuStrip = value;
			}
		}
		
		SdiWorkbenchWindow tableViewerWindow = new SdiWorkbenchWindow(new TablePane());
		
		public MainForm()
		{
			InitializeComponent();
			Text = ApplicationUtility.ProductNameAndVersion;
			
			Plugin p = Plugin.Load(@"..\plugins\Workbench.xml");
			WorkbenchToolBar = p.CreateToolBar();
			WorkbenchMenu = p.CreateMenu();
			
			databaseListPane1.DatabaseRefresh += delegate(object sender, DatabaseEventArgs e) { 
				e.Database.Refresh();
			};
			databaseListPane1.TableSelected += delegate(object sender, TableEventArgs e) {
				(tableViewerWindow.View as ITableView).Table = e.Table;
				if (!tabControl1.TabPages.Contains(tableViewerWindow)) {
					tabControl1.TabPages.Add(tableViewerWindow);
				} else {
					tabControl1.SelectedTab = tableViewerWindow;
				}
			};
		}
		
		public void ShowView(IView view)
		{
			tabControl1.TabPages.Add(new SdiWorkbenchWindow(view));
		}
		
		public void AddQuery(string file)
		{
			tabControl1.TabPages.Add(new SdiWorkbenchWindow(new QueryPane(file)));
		}
		
		public void AddDatabase(string file)
		{
			AddDatabase(Database.Load(file));
		}
		
		public void AddDatabase(Database database)
		{
			databaseListPane1.AddDatabase(database);
		}
		
		public void RemoveDatabase(Database database)
		{
			databases.Remove(database);
		}
		
		[ObsoleteAttribute()]
		public string CurrentDatabaseId {
			get {
				throw new NotImplementedException();
			}
		}
		
		[Obsolete()]
		public void OpenSqlFileInEditor()
		{
			throw new NotImplementedException();
		}
		
		[Obsolete()]
		public void SaveCurrentEditor()
		{
			throw new NotImplementedException();
		}
		
		[Obsolete()]
		public void SaveCurrentEditorAs()
		{
			throw new NotImplementedException();
		}
		
		[Obsolete()]
		public void OpenBlankEditor()
		{
			throw new NotImplementedException();
		}
		
		public void ExecuteAllQueries()
		{
			throw new NotImplementedException();
		}
		
		public void ExecuteCurrentQuery()
		{
			throw new NotImplementedException();
		}
		
		public void CloseAllWindows()
		{
			throw new NotImplementedException();
		}
		
		public void CloseWindow()
		{
			throw new NotImplementedException();
		}
	}
}
