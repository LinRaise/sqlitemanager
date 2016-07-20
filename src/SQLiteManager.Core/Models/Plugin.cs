//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using SQLiteManager.Core.Utilities;

namespace SQLiteManager.Core
{
	[XmlRoot("Plugin")]
	public class Plugin : BaseSerializable<Plugin>
	{
		[XmlElement("Menu")] public PluginMenu Menu { get; set; }
		[XmlElement("ToolBar")] public PluginToolBar ToolBar { get; set; }
		
		public Plugin()
		{
		}
		
		public static Plugin Load(TextReader reader)
		{
			return Deserialize(reader);
		}
		
		public static Plugin Load(string file)
		{
			return Deserialize(file);
		}
		
		public MenuStrip CreateMenu()
		{
			return Menu.Create();
		}
		
		public ToolStrip CreateToolBar()
		{
			return ToolBar.Create();
		}
	}
	
	public class PluginToolBar
	{
		[XmlElement("ToolBarButton")] public PluginToolBarButton[] Buttons { get; set; }
		
		public PluginToolBar()
		{
		}
		
		public ToolStrip Create()
		{
			ToolStrip strip = new ToolStrip();
			foreach (PluginToolBarButton b in Buttons) {
				strip.Items.Add(b.Create());
			}
			return strip;
		}
	}
	
	public class PluginToolBarButton : PluginControl
	{
		public ToolStripButton Create()
		{
			return new XToolStripButton(Text, CreateCommand());
		}
	}
	
	public class PluginMenu
	{
		[XmlElement("MenuItem")] public PluginMenuItem[] MenuItems { get; set; }
		
		public PluginMenu()
		{
		}
		
		public MenuStrip Create()
		{
			MenuStrip strip = new MenuStrip();
			foreach (PluginMenuItem m in MenuItems) {
				ToolStripItem i = m.Create();
				if (m.HasItems) {
					AddItem(i, m.Items);
				}
				strip.Items.Add(i);
			}
			return strip;
		}
		
		void AddItem(ToolStripItem item, PluginMenuItem[] items)
		{
			foreach (PluginMenuItem m in items) {
				ToolStripItem i = m.Create();
				if (m.HasItems) {
					AddItem(i, m.Items);
				}
				(item as ToolStripMenuItem).DropDownItems.Add(i);
			}
		}
	}
	
	public class PluginMenuItem : PluginControl
	{
		PluginMenuItem[] items;
		
		[XmlElement("MenuItem")] public PluginMenuItem[] Items {
			get {
				if (items == null) {
					return new PluginMenuItem[0];
				}
				return items;
			}
			
			set {
				items = value;
			}
		}
		
		public bool HasItems {
			get { return Items.Length > 0; }
		}
		
		public PluginMenuItem()
		{
		}
		
		public ToolStripItem Create()
		{
			if (Text.Equals("-")) {
				return new ToolStripSeparator();
			}
			return new XToolStripMenuItem(Text, CreateCommand());
		}
	}
	
	public class PluginControl
	{
		[XmlAttribute("Text")] public string Text { get; set; }
		[XmlAttribute("Command")] public string Command { get; set; }
		
		public PluginControl()
		{
		}
		
		public ICommand CreateCommand()
		{
			if (Command != null && !Command.Equals(string.Empty)) {
				Type t = Type.GetType(Command);
				if (t != null) {
					return Activator.CreateInstance(t) as ICommand;
				}
			}
			return null;
		}
	}
	
	public class XToolStripButton : ToolStripButton
	{
		ICommand command;
		
		public XToolStripButton(string text, ICommand command)
		{
			this.Text = text;
			this.command = command;
		}
		
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (command != null) {
				command.Run();
			}
		}
	}
	
	public class XToolStripMenuItem : ToolStripMenuItem
	{
		ICommand command;
		
		public XToolStripMenuItem(string text, ICommand command)
		{
			this.Text = text;
			this.command = command;
		}
		
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (command != null) {
				command.Run();
			}
		}
	}
}
