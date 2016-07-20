//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SQLiteManager.Core;
using SQLiteManager.Core.Utilities;
using SQLiteManager.Core.Views;
using SQLiteManager.Core.Workbench;
using SQLiteManager.Gui;
using SQLiteManager.Util;

namespace SQLiteManager
{
	[Obsolete()]
	public partial class MainForm : BaseForm, IDatabaseListView, IWorkbench
	{
		private XToolStripDatabasesComboBox databasesComboBox;
		private DataTabPage dataTabPage;
		private IndexTabPage indexTabPage;
		
		List<Database> databases = new List<Database>();
		
		public List<Database> Databases {
			get { return databases; }
			set { databases = value; }
		}

		public MainForm()
		{
			InitializeComponent();
			ConfigureMenu();
			this.Text = ApplicationUtility.ProductNameAndVersion;
		}

		public string CurrentDatabaseId {
			get {
				return databasesComboBox.CurrentDatabaseId;
			}
		}

		public void CloseWindow()
		{
			if (tabControlDocuments.SelectedTab != null) {
				tabControlDocuments.TabPages.Remove(tabControlDocuments.SelectedTab);
			}
		}

		public void CloseAllWindows()
		{
			tabControlDocuments.TabPages.Clear();
		}

		public void OpenBlankEditor()
		{
			var editorTabPage = new EditorTabPage(databasesComboBox.CurrentDatabaseId);
			tabControlDocuments.TabPages.Add(editorTabPage);
		}
		
		public void OpenSqlFileInEditor()
		{
			var dr = editorOpenFileDialog.ShowDialog(this);
			if (dr == DialogResult.OK) {
				var editorTabPage = new EditorTabPage(databasesComboBox.CurrentDatabaseId, editorOpenFileDialog.FileName);
				tabControlDocuments.TabPages.Add(editorTabPage);
			}
		}

		public void ExecuteCurrentQuery()
		{
			if (tabControlDocuments.SelectedTab != null && tabControlDocuments.SelectedTab is EditorTabPage
			    && CurrentDatabaseId != null) {
				(tabControlDocuments.SelectedTab as EditorTabPage).ExecuteCurrentQuery();
			}
		}

		public void ExecuteAllQueries()
		{
			if (tabControlDocuments.SelectedTab != null && tabControlDocuments.SelectedTab is EditorTabPage
			    && CurrentDatabaseId != null) {
				(tabControlDocuments.SelectedTab as EditorTabPage).ExecuteAllQueries();
			}
		}
		
		public void SaveCurrentEditor()
		{
			if (tabControlDocuments.SelectedTab != null && tabControlDocuments.SelectedTab is EditorTabPage) {
				var editorTabPage = tabControlDocuments.SelectedTab as EditorTabPage;
				if (editorTabPage.HasFile) {
					editorTabPage.Save();
				} else {
					SaveToFile(editorTabPage);
				}
			}
		}
		
		public void SaveCurrentEditorAs()
		{
			if (tabControlDocuments.SelectedTab != null && tabControlDocuments.SelectedTab is EditorTabPage) {
				SaveToFile(tabControlDocuments.SelectedTab as EditorTabPage);
			}
		}

		[Obsolete()]
		public DialogResult AddDialog(Form form)
		{
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterParent;
			form.MaximizeBox = form.MinimizeBox = form.ShowInTaskbar = false;
			return form.ShowDialog();
		}

		protected override void WireForm()
		{
			base.WireForm();

			tabControlDocuments.SelectedIndexChanged += MainFormSelectedIndexChanged;
			tablesPane.TableSelected += MainFormTableSelected;
			tablesPane.IndexSelected += TablesPaneIndexSelected;
			DatabaseManager.Instance.DatabaseClosed += DatabaseManagerDatabaseClosed;
		}

		protected override void UnwireForm()
		{
			base.UnwireForm();

			tabControlDocuments.SelectedIndexChanged -= MainFormSelectedIndexChanged;
			tablesPane.TableSelected -= MainFormTableSelected;
			databasesComboBox.DatabaseChanged -= MainFormDatabaseChanged;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			SaveEditorsOnClose();
			base.OnClosing(e);
		}

		void TablesPaneIndexSelected(object sender, IndexSelectedEventArgs e)
		{
			if (dataTabPage != null)
			{
				tabControlDocuments.TabPages.Remove(dataTabPage);
				dataTabPage = null;
			}
			if (indexTabPage == null) {
				indexTabPage = new IndexTabPage();
				tabControlDocuments.TabPages.Insert(0, indexTabPage);
			}

			indexTabPage.Text = @"Index Viewer " + e.IndexName;
			indexTabPage.ViewIndex(e.DatabaseId, e.IndexName);
		}

		void DatabaseManagerDatabaseClosed(object sender, DatabaseEventArgs e)
		{
			var tabsForClose = tabControlDocuments.TabPages.OfType<EditorTabPage>().Where(tab => tab.DatabaseId.Equals(e.Database.Id));

			foreach (var editorTabPage in tabsForClose) {
				if (editorTabPage.IsDirty) {
					SaveToFile(editorTabPage);
				}
				tabControlDocuments.TabPages.Remove(editorTabPage);
			}
		}

		private void ConfigreControlsToUnwire()
		{
			controlsToUnwire.Add(tablesPane);
			controlsToUnwire.Add(databasesComboBox);
		}

		private void ConfigureMenu()
		{
			var defaultMenu = new DefaultMenu();
			mainMenuStrip.Items.AddRange(defaultMenu.MenuItems);
			commandsToolStrip.Items.AddRange(defaultMenu.ToolStripButtons);

			foreach (ToolStripItem item in commandsToolStrip.Items) {
				if (item is XToolStripDatabasesComboBox) {
					databasesComboBox = item as XToolStripDatabasesComboBox;
					databasesComboBox.DatabaseChanged += MainFormDatabaseChanged;
					break;
				}
			}
		}
		
		private void SaveToFile(EditorTabPage editorTabPage)
		{
			string fileName = editorTabPage.FileName;

			editorSaveFileDialog.Title = string.Format("Save {0}", fileName);
			editorSaveFileDialog.FileName = fileName;

			DialogResult dr = editorSaveFileDialog.ShowDialog(this);

			if (dr == DialogResult.OK) {
				editorTabPage.SaveToFile(editorSaveFileDialog.FileName);
			}
		}

		private void MainFormTableSelected(object sender, TableSelectedEventArgs e)
		{
			if (indexTabPage != null)
			{
				tabControlDocuments.TabPages.Remove(indexTabPage);
				indexTabPage = null;
			}
			if (dataTabPage == null) {
				dataTabPage = new DataTabPage();
				tabControlDocuments.TabPages.Insert(0, dataTabPage);
			}

			dataTabPage.Text = @"Table Viewer " + e.TableName;
			dataTabPage.ViewTable(e.DatabaseId, e.TableName);
		}

		private void MainFormSelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControlDocuments.SelectedTab == null) {
				return;
			}
			if (tabControlDocuments.SelectedTab is EditorTabPage) {
				databasesComboBox.CurrentDatabaseId = (tabControlDocuments.SelectedTab as IDatabaseDepedentControl).DatabaseId;
			}
			databasesComboBox.Enabled = !(tabControlDocuments.SelectedTab is DataTabPage);
		}

		private void MainFormDatabaseChanged(object sender, DatabaseChangedEventArgs e)
		{
			if (CurrentDatabaseId != null
			    && tabControlDocuments.SelectedTab != null
			    && tabControlDocuments.SelectedTab is EditorTabPage) {
				(tabControlDocuments.SelectedTab as EditorTabPage).DatabaseId = e.DatabaseId;
			}
		}

		private void SaveEditorsOnClose()
		{
			foreach (var tabPage in tabControlDocuments.TabPages.OfType<EditorTabPage>()) {
				{
					var editorTabPage = tabPage;
					if (editorTabPage != null && editorTabPage.IsDirty) {
						SaveToFile(editorTabPage);
					}
				}
			}
		}
		
		public void AddQuery(string file)
		{
			throw new NotImplementedException();
		}
		
		public void ShowView(IView view)
		{
			throw new NotImplementedException();
		}
		
		public void AddDatabase(string file)
		{
			throw new NotImplementedException();
		}
		
		public Database SelectedDatabase {
			get {
				throw new NotImplementedException();
			}
		}
		
		public void RemoveDatabase(Database database)
		{
			throw new NotImplementedException();
		}
	}
}
