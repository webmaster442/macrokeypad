using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class MouseKey : UserControl
{
	private IContainer components;

	private Button KEY_Mouse_Left;

	private Button KEY_Mouse_Right;

	private Button KEY_Mouse_Centre;

	private Button KEY_MOUSE_WHEEL_ADD;

	private Button KEY_MOUSE_WHEEL_SUB;

	private Button Ctrl_Mouse_wheel_Up;

	private Button Ctrl_Mouse_wheel_Down;

	private Button Shift_Mouse_wheel_Up;

	private Button Shift_Mouse_wheel_Down;

	private Button Alt_Mouse_wheel_Up;

	private Button Alt_Mouse_wheel_Down;

	public MouseKey()
	{
		InitializeComponent();
	}

	private void KEY_Colour_Init()
	{
		int red = 152;
		int green = 251;
		int blue = 152;
		KEY_Mouse_Left.BackColor = Color.FromArgb(red, green, blue);
		KEY_Mouse_Centre.BackColor = Color.FromArgb(red, green, blue);
		KEY_Mouse_Right.BackColor = Color.FromArgb(red, green, blue);
		KEY_MOUSE_WHEEL_ADD.BackColor = Color.FromArgb(red, green, blue);
		KEY_MOUSE_WHEEL_SUB.BackColor = Color.FromArgb(red, green, blue);
	}

	private void MouseGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 3;
	}

	private void KEY_Mouse_Left_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Mouse_Left.Text;
	}

	private void KEY_Mouse_Centre_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 4;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Mouse_Centre.Text;
	}

	private void KEY_Mouse_Right_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 2;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 0;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Mouse_Right.Text;
	}

	private void KEY_MOUSE_WHEEL_ADD_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_MOUSE_WHEEL_ADD.Text;
	}

	private void KEY_MOUSE_WHEEL_SUB_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_MOUSE_WHEEL_SUB.Text;
	}

	private void Ctrl_Mouse_wheel_Up_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = Ctrl_Mouse_wheel_Up.Text;
	}

	private void Ctrl_Mouse_wheel_Down_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 1;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = Ctrl_Mouse_wheel_Down.Text;
	}

	private void Shift_Mouse_wheel_Up_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 2;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = Shift_Mouse_wheel_Up.Text;
	}

	private void Shift_Mouse_wheel_Down_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 2;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = Shift_Mouse_wheel_Down.Text;
	}

	private void Alt_Mouse_wheel_Up_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = 1;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 4;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = Alt_Mouse_wheel_Up.Text;
	}

	private void Alt_Mouse_wheel_Down_Click(object sender, EventArgs e)
	{
		MouseGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 2] = 0;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 3] = byte.MaxValue;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 4] = 4;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = Alt_Mouse_wheel_Down.Text;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HIDTester.MouseKey));
		this.KEY_Mouse_Left = new System.Windows.Forms.Button();
		this.KEY_Mouse_Right = new System.Windows.Forms.Button();
		this.KEY_Mouse_Centre = new System.Windows.Forms.Button();
		this.KEY_MOUSE_WHEEL_ADD = new System.Windows.Forms.Button();
		this.KEY_MOUSE_WHEEL_SUB = new System.Windows.Forms.Button();
		this.Ctrl_Mouse_wheel_Up = new System.Windows.Forms.Button();
		this.Ctrl_Mouse_wheel_Down = new System.Windows.Forms.Button();
		this.Shift_Mouse_wheel_Up = new System.Windows.Forms.Button();
		this.Shift_Mouse_wheel_Down = new System.Windows.Forms.Button();
		this.Alt_Mouse_wheel_Up = new System.Windows.Forms.Button();
		this.Alt_Mouse_wheel_Down = new System.Windows.Forms.Button();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.KEY_Mouse_Left, "KEY_Mouse_Left");
		this.KEY_Mouse_Left.Name = "KEY_Mouse_Left";
		this.KEY_Mouse_Left.UseVisualStyleBackColor = true;
		this.KEY_Mouse_Left.Click += new System.EventHandler(KEY_Mouse_Left_Click);
		componentResourceManager.ApplyResources(this.KEY_Mouse_Right, "KEY_Mouse_Right");
		this.KEY_Mouse_Right.Name = "KEY_Mouse_Right";
		this.KEY_Mouse_Right.UseVisualStyleBackColor = true;
		this.KEY_Mouse_Right.Click += new System.EventHandler(KEY_Mouse_Right_Click);
		componentResourceManager.ApplyResources(this.KEY_Mouse_Centre, "KEY_Mouse_Centre");
		this.KEY_Mouse_Centre.Name = "KEY_Mouse_Centre";
		this.KEY_Mouse_Centre.UseVisualStyleBackColor = true;
		this.KEY_Mouse_Centre.Click += new System.EventHandler(KEY_Mouse_Centre_Click);
		componentResourceManager.ApplyResources(this.KEY_MOUSE_WHEEL_ADD, "KEY_MOUSE_WHEEL_ADD");
		this.KEY_MOUSE_WHEEL_ADD.Name = "KEY_MOUSE_WHEEL_ADD";
		this.KEY_MOUSE_WHEEL_ADD.UseVisualStyleBackColor = true;
		this.KEY_MOUSE_WHEEL_ADD.Click += new System.EventHandler(KEY_MOUSE_WHEEL_ADD_Click);
		componentResourceManager.ApplyResources(this.KEY_MOUSE_WHEEL_SUB, "KEY_MOUSE_WHEEL_SUB");
		this.KEY_MOUSE_WHEEL_SUB.Name = "KEY_MOUSE_WHEEL_SUB";
		this.KEY_MOUSE_WHEEL_SUB.UseVisualStyleBackColor = true;
		this.KEY_MOUSE_WHEEL_SUB.Click += new System.EventHandler(KEY_MOUSE_WHEEL_SUB_Click);
		componentResourceManager.ApplyResources(this.Ctrl_Mouse_wheel_Up, "Ctrl_Mouse_wheel_Up");
		this.Ctrl_Mouse_wheel_Up.Name = "Ctrl_Mouse_wheel_Up";
		this.Ctrl_Mouse_wheel_Up.Click += new System.EventHandler(Ctrl_Mouse_wheel_Up_Click);
		componentResourceManager.ApplyResources(this.Ctrl_Mouse_wheel_Down, "Ctrl_Mouse_wheel_Down");
		this.Ctrl_Mouse_wheel_Down.Name = "Ctrl_Mouse_wheel_Down";
		this.Ctrl_Mouse_wheel_Down.Click += new System.EventHandler(Ctrl_Mouse_wheel_Down_Click);
		componentResourceManager.ApplyResources(this.Shift_Mouse_wheel_Up, "Shift_Mouse_wheel_Up");
		this.Shift_Mouse_wheel_Up.Name = "Shift_Mouse_wheel_Up";
		this.Shift_Mouse_wheel_Up.Click += new System.EventHandler(Shift_Mouse_wheel_Up_Click);
		componentResourceManager.ApplyResources(this.Shift_Mouse_wheel_Down, "Shift_Mouse_wheel_Down");
		this.Shift_Mouse_wheel_Down.Name = "Shift_Mouse_wheel_Down";
		this.Shift_Mouse_wheel_Down.Click += new System.EventHandler(Shift_Mouse_wheel_Down_Click);
		componentResourceManager.ApplyResources(this.Alt_Mouse_wheel_Up, "Alt_Mouse_wheel_Up");
		this.Alt_Mouse_wheel_Up.Name = "Alt_Mouse_wheel_Up";
		this.Alt_Mouse_wheel_Up.Click += new System.EventHandler(Alt_Mouse_wheel_Up_Click);
		componentResourceManager.ApplyResources(this.Alt_Mouse_wheel_Down, "Alt_Mouse_wheel_Down");
		this.Alt_Mouse_wheel_Down.Name = "Alt_Mouse_wheel_Down";
		this.Alt_Mouse_wheel_Down.Click += new System.EventHandler(Alt_Mouse_wheel_Down_Click);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.Alt_Mouse_wheel_Down);
		base.Controls.Add(this.Alt_Mouse_wheel_Up);
		base.Controls.Add(this.Shift_Mouse_wheel_Down);
		base.Controls.Add(this.Shift_Mouse_wheel_Up);
		base.Controls.Add(this.Ctrl_Mouse_wheel_Down);
		base.Controls.Add(this.Ctrl_Mouse_wheel_Up);
		base.Controls.Add(this.KEY_MOUSE_WHEEL_SUB);
		base.Controls.Add(this.KEY_MOUSE_WHEEL_ADD);
		base.Controls.Add(this.KEY_Mouse_Centre);
		base.Controls.Add(this.KEY_Mouse_Right);
		base.Controls.Add(this.KEY_Mouse_Left);
		base.Name = "MouseKey";
		base.ResumeLayout(false);
	}
}
