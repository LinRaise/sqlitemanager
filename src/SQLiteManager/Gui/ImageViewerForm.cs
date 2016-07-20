//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System.Drawing;
using System.Windows.Forms;

namespace SQLiteManager.Gui
{
	/// <summary>
	/// Description of ImageViewerForm.
	/// </summary>
	public partial class ImageViewerForm : Form
	{
		public Image Image {
			get { return pictureBox1.Image; }
			set { pictureBox1.Image = value; }
		}
		
		public ImageViewerForm()
		{
			InitializeComponent();
		}
	}
}
