//	<file>
//		<license>lgpl-3.0.txt</license>
//		<author name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SQLiteManager.Gui.FormPositioning;
using SQLiteManager.Util;

namespace SQLiteManager
{
	public partial class BaseForm : Form
	{
		protected bool useSavedPositionSettings = true;
		protected IList<IUnwireableControl> controlsToUnwire = new List<IUnwireableControl>();
		
		public BaseForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			WireForm();
			
			if (useSavedPositionSettings) {
				LoadSavedPositionInfo();
			}
		}
		
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			if (useSavedPositionSettings) {
				SaveFormPositionInfo();
			}
			UnwireControls();
			UnwireForm();
			base.OnClosing(e);
		}
		
		protected virtual void WireForm()
		{
		}
		
		protected virtual void UnwireForm()
		{
		}
		
		private void UnwireControls()
		{
			foreach (var unwireableControl in controlsToUnwire) {
				unwireableControl.UnwireEvents();
			}
		}
		
		private void SaveFormPositionInfo()
		{
			var formPositionInfo = new FormPositionInfo {
				IsMaximized = WindowState == FormWindowState.Maximized,
				Location = Location,
				Size = Size
			};
			ApplicationFormsPositions.FormsPositionCache.SetFormPositionInfo(this, formPositionInfo);
		}
		
		private void LoadSavedPositionInfo()
		{
			var formPositionInfo = ApplicationFormsPositions.FormsPositionCache.GetFormPositionInfo(this);
			if (formPositionInfo != null) {
				StartPosition = FormStartPosition.Manual;
				
				if (formPositionInfo.IsMaximized) {
					WindowState = FormWindowState.Maximized;
				}
				
				Location = formPositionInfo.Location;
				Size = formPositionInfo.Size;
			}
		}
	}
}
