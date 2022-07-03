using System.Collections.Generic;
using System.Windows.Forms;

namespace HIDTester;

internal class AutoSizeFormClass
{
	public struct controlRect
	{
		public int Left;

		public int Top;

		public int Width;

		public int Height;
	}

	public List<controlRect> oldCtrl = new List<controlRect>();

	private int ctrlNo;

	public void controllInitializeSize(Control mForm)
	{
		controlRect item = default(controlRect);
		item.Left = mForm.Left;
		item.Top = mForm.Top;
		item.Width = mForm.Width;
		item.Height = mForm.Height;
		oldCtrl.Add(item);
		AddControl(mForm);
	}

	private void AddControl(Control ctl)
	{
		controlRect item = default(controlRect);
		foreach (Control control in ctl.Controls)
		{
			item.Left = control.Left;
			item.Top = control.Top;
			item.Width = control.Width;
			item.Height = control.Height;
			oldCtrl.Add(item);
			if (control.Controls.Count > 0)
			{
				AddControl(control);
			}
		}
	}

	public void controlAutoSize(Control mForm)
	{
		if (ctrlNo == 0)
		{
			controlRect item = default(controlRect);
			item.Left = 0;
			item.Top = 0;
			item.Width = mForm.PreferredSize.Width;
			item.Height = mForm.PreferredSize.Height;
			oldCtrl.Add(item);
			AddControl(mForm);
		}
		float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;
		float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;
		ctrlNo = 1;
		AutoScaleControl(mForm, wScale, hScale);
	}

	private void AutoScaleControl(Control ctl, float wScale, float hScale)
	{
		foreach (Control control in ctl.Controls)
		{
			int left = oldCtrl[ctrlNo].Left;
			int top = oldCtrl[ctrlNo].Top;
			int width = oldCtrl[ctrlNo].Width;
			int height = oldCtrl[ctrlNo].Height;
			control.Left = (int)((float)left * wScale);
			control.Top = (int)((float)top * hScale);
			control.Width = (int)((float)width * wScale);
			control.Height = (int)((float)height * hScale);
			ctrlNo++;
			if (control.Controls.Count > 0)
			{
				AutoScaleControl(control, wScale, hScale);
			}
			if (ctl is DataGridView)
			{
				DataGridView dataGridView = ctl as DataGridView;
				Cursor.Current = Cursors.WaitCursor;
				int num = 0;
				for (int i = 0; i < dataGridView.Columns.Count; i++)
				{
					dataGridView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
					num += dataGridView.Columns[i].Width;
				}
				if (num >= ctl.Size.Width)
				{
					dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				}
				else
				{
					dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				}
				Cursor.Current = Cursors.Default;
			}
		}
	}
}
