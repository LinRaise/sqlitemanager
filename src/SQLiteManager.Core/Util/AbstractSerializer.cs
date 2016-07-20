//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.IO;

namespace SQLiteManager.Core.Utilities
{
	public abstract class AbstractSerializer
	{
		public abstract string Serialize(object obj);
		
		public void SerializeToFile(object value, string fileName)
		{
			string fileContent = Serialize(value);

			if (!Directory.Exists(Path.GetDirectoryName(fileName))) {
				Directory.CreateDirectory(Path.GetDirectoryName(fileName));
			}

			using (var streamWriter = new StreamWriter(fileName, false)) {
				streamWriter.Write(fileContent);
			}
		}

		public abstract object Deserialize(string content, Type type);

		public TObj Deserialize<TObj>(string content)
		{
			return (TObj)Deserialize(content, typeof(TObj));
		}
		
		public object DeserializeFromFile(string fileName, Type type)
		{
			if (File.Exists(fileName)) {
				string fileContent;
				using (var streamReader = new StreamReader(fileName)) {
					fileContent = streamReader.ReadToEnd();
				}
				if (string.IsNullOrEmpty(fileContent)) {
					return null;
				}
				return Deserialize(fileContent, type);
			}
			return null;
		}

		public TObj DeserializeFromFile<TObj>(string fileName)
		{
			return (TObj)DeserializeFromFile(fileName, typeof(TObj));
		}
	}
}
