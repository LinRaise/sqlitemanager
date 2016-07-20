//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Drawing;
using System.IO;

namespace SQLiteManager.Util
{
	public static class ImageUtility
	{
		public static byte[] ToByteArray(Image image)
		{
			if (image == null) {
				return null;
			}
			var ms = new MemoryStream();
			image.Save(ms, image.RawFormat);
			byte[] arr = ms.GetBuffer();
			return arr;
		}
		
		public static Image ToImage(object sourceObject)
		{
			return sourceObject is DBNull ? null : ToImage((byte[])sourceObject);
		}
		
		static Image ToImage(byte[] arr)
		{
			if (arr == null) {
				return null;
			}
			if (arr.Length == 0) {
				return null;
			}
			var ms = new MemoryStream(arr);
			var image = Image.FromStream(ms);
			return image;
		}
	}
}
