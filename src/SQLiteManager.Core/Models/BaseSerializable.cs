//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SQLiteManager.Core.Utilities
{
	public class BaseSerializable<T>
	{
		public BaseSerializable()
		{
		}
		
		public static T Deserialize(string file)
		{
			return Deserialize(new StreamReader(file));
		}
		
		public static T Deserialize(TextReader reader)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			T t = (T)serializer.Deserialize(reader);
			reader.Close();
			return t;
		}
		
		public string Serialize()
		{
			XmlSerializer serializer = new XmlSerializer(this.GetType());
			StringWriter writer = new StringWriter();
			serializer.Serialize(writer, this, CreateNamespace());
			return writer.ToString();
		}
		
		public void Serialize(string file)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			XmlTextWriter writer = new XmlTextWriter(file, Encoding.Unicode);
			writer.Formatting = Formatting.Indented;
			serializer.Serialize(writer, this, CreateNamespace());
			writer.Flush();
			writer.Close();
		}
		
		XmlSerializerNamespaces CreateNamespace()
		{
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add(string.Empty, string.Empty);
			return ns;
		}
	}
}
