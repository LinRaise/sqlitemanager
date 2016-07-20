//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using SQLiteManager.Core.Models;
using SQLiteManager.Core.Views;
using SQLiteManager.Gui.SqlSyntaxHighlighting;

namespace SQLiteManager.Gui
{
	public partial class QueryPane : UserControl, IQueryView
	{
		Query2 query;
		static int count = 0;
		
		public Query2 Query {
			get {
				return query;
			}
			
			set {
				query = value;
				textEditorControl1.Text = query.Content;
				Text = query.AbsoluteFileName == null ? string.Format("Untitled{0}", count++) : query.AbsoluteFileName;
			}
		}
		
		static QueryPane()
		{
			HighlightingManager.Manager.AddSyntaxModeFileProvider(
				new AppSyntaxModeProvider()
			);
		}
		
		public QueryPane() : this(new Query2())
		{
		}
		
		public QueryPane(string file) : this(Query2.Load(file))
		{
		}
		
		public QueryPane(Query2 query)
		{
			InitializeComponent();
			textEditorControl1.SetHighlighting("SQL");
			
			this.Query = query;
		}
	}
}
