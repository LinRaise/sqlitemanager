//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System;
using System.Drawing;

namespace SQLiteManager.Gui.FormPositioning
{
	[Serializable]
	public class FormPositionInfo
	{		
		private bool isMaximized;
		private Point location;
		private Size size;
		
		public bool IsMaximized {
			get { return isMaximized; }
			set { isMaximized = value; }
		}
		
		public Point Location {
			get { return location; }
			set { location = value; }
		}

		public Size Size {
			get { return size; }
			set { size = value; }
		}
	}
}
