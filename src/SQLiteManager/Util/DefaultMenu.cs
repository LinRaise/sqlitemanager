//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Windows.Forms;
using SQLiteManager.Commands;

namespace SQLiteManager.Util
{
	[Obsolete()]
	public class DefaultMenu
	{
		public ToolStripItem[] ToolStripButtons {
			get {
				return new ToolStripItem[] {
					new XToolStripButton("Open Database", new OpenDatabase(), ResourceUtility.GetImage("folder_database")),
					new XToolStripDatabasesComboBox(),
					new XToolStripButton("Close Database", new CloseDatabase(), ResourceUtility.GetImage("close_database")),
					new ToolStripSeparator(),
					new XToolStripButton("Execute All Query", new ExecuteAllQuery(), ResourceUtility.GetImage("resultset_next"))
				};
			}
		}
		
		public ToolStripItem[] MenuItems {
			get {
				return new ToolStripItem[] {
					new XToolStripMenuItem(
						"File",
						new ToolStripItem[] {
							new XToolStripMenuItem("Open", new OpenFile()),
							new XToolStripMenuItem("Save", new SaveFile()) { ShortcutKeys = Keys.Control | Keys.S},
							new XToolStripMenuItem("Save As...", new SaveFileAs()),
							new ToolStripSeparator(),
							new XToolStripMenuItem("Exit", new ExitCommand())
						}
					),
					new XToolStripMenuItem(
						"Database",
						new ToolStripItem[] {
							new XToolStripMenuItem("Create Database", new CreateDatabase()),
							new ToolStripSeparator(),
							new XToolStripMenuItem("Open Database", new OpenDatabase(), ResourceUtility.GetImage("folder_database")),
							new XToolStripMenuItem("Close Database", new CloseDatabase()),
							new ToolStripSeparator(),
							new XToolStripMenuItem("Export Database", new ExportDatabase())
						}
					),
					new XToolStripMenuItem(
						"Query",
						new ToolStripItem[] {
							new XToolStripMenuItem("Add Query", new AddQuery()),
							new XToolStripMenuItem("Execute Query", new ExecuteQuery()) { ShortcutKeys = Keys.F8 },
							new XToolStripMenuItem("Execute All Query", new ExecuteAllQuery(), ResourceUtility.GetImage("resultset_next")) { ShortcutKeys = Keys.F5 }
						}
					),
					new XToolStripMenuItem(
						"Window",
						new ToolStripItem[] {
							new XToolStripMenuItem("Close", new CloseWindow()),
							new XToolStripMenuItem("Close All", new CloseAllWindow())
						}
					),
					new XToolStripMenuItem(
						"?",
						new ToolStripItem[] {
							new XToolStripMenuItem("About...", new ShowAbout())
						}
					)
				};
			}
		}
	}
}
