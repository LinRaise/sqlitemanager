//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SQLiteManager.Core.Utilities
{
	public static class SerializationUtility
	{
		private static Binary binarySerializer;

		public static Binary BinarySerializer
		{
			get
			{
				if (binarySerializer == null) {
					binarySerializer = new SerializationUtility.Binary();
				}
				return binarySerializer;
			}
			set {
				binarySerializer = value;
			}
		}

		public class Binary : AbstractSerializer
		{
			internal Binary()
			{
			}

			public override string Serialize(object obj)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, obj);
				byte[] bytes = memoryStream.ToArray();
				return Convert.ToBase64String(bytes);
			}

			public override object Deserialize(string content, Type type)
			{
				byte[] bytes = Convert.FromBase64String(content);
				MemoryStream memoryStream = new MemoryStream(bytes);
				memoryStream.Position = 0;
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				object obj = binaryFormatter.Deserialize(memoryStream);
				memoryStream.Close();
				return obj;
			}
		}
	}
}
