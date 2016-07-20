//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

using ICSharpCode.TextEditor.Document;

namespace SQLiteManager.Gui.SqlSyntaxHighlighting
{
	public class AppSyntaxModeProvider : ISyntaxModeFileProvider
	{
	    readonly List<SyntaxMode> syntaxModes;
		
		public ICollection<SyntaxMode> SyntaxModes {
			get {
				return syntaxModes;
			}
		}

        public AppSyntaxModeProvider()
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream syntaxModeStream = assembly.GetManifestResourceStream("SQLiteManager.Gui.SqlSyntaxHighlighting.SyntaxModes.xml");
			if (syntaxModeStream != null) {
				syntaxModes = SyntaxMode.GetSyntaxModes(syntaxModeStream);
			} else {
				syntaxModes = new List<SyntaxMode>();
			}
		}
		
		public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("SQLiteManager.Gui.SqlSyntaxHighlighting." + syntaxMode.FileName);
            return new XmlTextReader(stream);
		}
		
		public void UpdateSyntaxModeList()
		{
			// resources don't change during runtime
		}
	}
}
