//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//		<author name="Razvan Goga" email=""/>
//	</file>

using System.Diagnostics;
using System.Windows.Forms;
using SQLiteManager.Core.Utilities;

namespace SQLiteManager.Gui
{
	public partial class AboutForm : BaseForm
	{
		public AboutForm()
		{
			InitializeComponent();
			
			useSavedPositionSettings = false;
			
			labelProductName.Text = ApplicationUtility.ProductName;
			labelProductVersion.Text = @"Version " + ApplicationUtility.ProductVersion;
		}
		
		void LinkLabelLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(((LinkLabel) sender).Text);
		}
	}
}
