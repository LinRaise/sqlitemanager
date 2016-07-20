//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System.Drawing;
using System.Reflection;
using System.Resources;

namespace SQLiteManager.Util
{
	/// <summary>
	/// Description of ResourceUtility.
	/// </summary>
	public static class ResourceUtility
	{
		static readonly ResourceManager Manager = new ResourceManager("SQLiteManager.ApplicationResource", Assembly.GetExecutingAssembly());
		
		public static string GetString(string key)
		{
			return Manager.GetString(key);
		}
		
		public static Image GetImage(string key)
		{
			return (Bitmap)Manager.GetObject(key);
		}
	}
}
