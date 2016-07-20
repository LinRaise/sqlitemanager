//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System.Windows.Forms;
using SQLiteManager.Core.Views;
using SQLiteManager.Util;

namespace SQLiteManager
{
	public partial class BaseUserControl : UserControl, IUnwireableControl
	{
		public BaseUserControl()
		{
			InitializeComponent();
		}
		
		public virtual void UnwireEvents()
		{
		}
	}
}
