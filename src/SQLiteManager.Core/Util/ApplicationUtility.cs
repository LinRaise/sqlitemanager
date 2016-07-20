//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Windows.Forms;

namespace SQLiteManager.Core.Utilities
{
	public static class ApplicationUtility
	{
		public static string ProductName {
			get { return Application.ProductName; }
		}
		
		public static string ProductNameAndVersion {
			get { return ProductName + " " + ProductVersion; }
		}
		
		public static string ProductVersion {
			get { 
				var v = new Version(Application.ProductVersion);
				return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
			}
		}
	}
}
