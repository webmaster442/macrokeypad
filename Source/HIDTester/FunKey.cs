using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class FunKey : UserControl
{
	private IContainer components;

	private Button KEY_Ctrl_left;

	private Button KEY_Shift_left;

	private Button KEY_ALT_Left;

	private Button KEY_ALT_Right;

	private Button KEY_Shift_right;

	private Button KEY_Ctrl_Right;

	private Button KEY_Win_left;

	private Button KEY_Win_Right;

	private Button KEY_ctrl_alt;

	private Button KEY_Ctrl_Shift;

	private Button KEY_Alt_Shift;

	private Button KEY_Ctrl_Shift_Alt;

	private Button KEY_Ctrl_Alt_Win;

	private Button KEY_Shift_Win;

	private Button KEY_Ctrl_Alt_Shift_Win;

	private Button KEY_Shift_And_1;

	private Button KEY_Shift_And_2;

	private Button KEY_Shift_And_3;

	private Button KEY_Shift_And_4;

	private Button KEY_Shift_And_5;

	private Button KEY_Shift_And_6;

	private Button KEY_Shift_And_7;

	private Button KEY_Shift_And_8;

	private Button KEY_Shift_And_9;

	private Button KEY_Shift_And_10;

	private Button KEY_Shift_And_11;

	private Button KEY_Shift_And_12;

	private Button KEY_Shift_And_13;

	private Button KEY_Shift_And_14;

	private Button KEY_Shift_And_15;

	private Button KEY_Shift_And_16;

	private Button KEY_Shift_And_17;

	private Button KEY_Shift_And_18;

	private Button KEY_Shift_And_19;

	private Button KEY_Shift_And_20;

	private Button KEY_Shift_And_21;

	public FunKey()
	{
		InitializeComponent();
	}

	private void FunGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void KEY_Ctrl_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
	}

	private void KEY_Shift_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_ALT_Left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Win_left_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 16;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
	}

	private void KEY_Shift_right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 32;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_ALT_Right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 64;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Win_Right_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 128;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_ctrl_alt_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Shift_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_Alt_Shift_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
	}

	private void KEY_Shift_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Shift_Alt_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Alt_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void KEY_Ctrl_Alt_Shift_Win_Click(object sender, EventArgs e)
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 1;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Ctrl";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 4;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Alt";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Shift";
		FunGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 8;
		FormMain.KeyParam.FunKeyChar[FormMain.KeyParam.FunKEY_Char_Num] = "Win";
		FunGeneral_Char_Set();
	}

	private void ShiftGeneral_Char_Set()
	{
		if (FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] != 0)
		{
			FormMain.KeyParam.KEY_Char_Num += 2;
		}
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num - 1] |= 2;
	}

	private void ShiftGeneral_Char_Set2()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 1;
		FormMain.KeyParam.KEY_Char_Num += 2;
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyGroupCharNum]++;
		FormMain.KeyParam.FunKEY_Char_Num++;
	}

	private void KEY_Shift_And_1_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 53;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_1.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_2_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 30;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_2.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_3_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 31;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_3.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_4_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 32;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_4.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_5_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 33;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_5.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_6_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 34;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_6.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_7_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 35;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_7.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_8_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 36;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_8.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_9_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 37;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_9.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_10_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 38;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_10.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_11_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 39;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_11.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_12_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 45;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_12.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_13_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 46;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_13.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_14_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 47;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_14.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_15_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 48;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_15.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_16_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 49;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_16.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_17_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 51;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_17.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_18_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 52;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_18.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_19_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 54;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_19.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_20_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 55;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_20.Text;
		ShiftGeneral_Char_Set2();
	}

	private void KEY_Shift_And_21_Click(object sender, EventArgs e)
	{
		ShiftGeneral_Char_Set();
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 56;
		FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Shift_And_21.Text;
		ShiftGeneral_Char_Set2();
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
		this.KEY_Ctrl_left = new System.Windows.Forms.Button();
		this.KEY_Shift_left = new System.Windows.Forms.Button();
		this.KEY_ALT_Left = new System.Windows.Forms.Button();
		this.KEY_ALT_Right = new System.Windows.Forms.Button();
		this.KEY_Shift_right = new System.Windows.Forms.Button();
		this.KEY_Ctrl_Right = new System.Windows.Forms.Button();
		this.KEY_Win_left = new System.Windows.Forms.Button();
		this.KEY_Win_Right = new System.Windows.Forms.Button();
		this.KEY_ctrl_alt = new System.Windows.Forms.Button();
		this.KEY_Ctrl_Shift = new System.Windows.Forms.Button();
		this.KEY_Alt_Shift = new System.Windows.Forms.Button();
		this.KEY_Ctrl_Shift_Alt = new System.Windows.Forms.Button();
		this.KEY_Ctrl_Alt_Win = new System.Windows.Forms.Button();
		this.KEY_Shift_Win = new System.Windows.Forms.Button();
		this.KEY_Ctrl_Alt_Shift_Win = new System.Windows.Forms.Button();
		this.KEY_Shift_And_1 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_2 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_3 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_4 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_5 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_6 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_7 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_8 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_9 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_10 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_11 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_12 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_13 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_14 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_15 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_16 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_17 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_18 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_19 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_20 = new System.Windows.Forms.Button();
		this.KEY_Shift_And_21 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.KEY_Ctrl_left.Location = new System.Drawing.Point(3, 3);
		this.KEY_Ctrl_left.Name = "KEY_Ctrl_left";
		this.KEY_Ctrl_left.Size = new System.Drawing.Size(94, 23);
		this.KEY_Ctrl_left.TabIndex = 69;
		this.KEY_Ctrl_left.Text = "Ctrl+";
		this.KEY_Ctrl_left.UseVisualStyleBackColor = true;
		this.KEY_Ctrl_left.Click += new System.EventHandler(KEY_Ctrl_left_Click);
		this.KEY_Shift_left.Location = new System.Drawing.Point(206, 3);
		this.KEY_Shift_left.Name = "KEY_Shift_left";
		this.KEY_Shift_left.Size = new System.Drawing.Size(97, 23);
		this.KEY_Shift_left.TabIndex = 70;
		this.KEY_Shift_left.Text = "Shift+";
		this.KEY_Shift_left.UseVisualStyleBackColor = true;
		this.KEY_Shift_left.Click += new System.EventHandler(KEY_Shift_left_Click);
		this.KEY_ALT_Left.Location = new System.Drawing.Point(103, 3);
		this.KEY_ALT_Left.Name = "KEY_ALT_Left";
		this.KEY_ALT_Left.Size = new System.Drawing.Size(97, 23);
		this.KEY_ALT_Left.TabIndex = 71;
		this.KEY_ALT_Left.Text = "Alt+";
		this.KEY_ALT_Left.UseVisualStyleBackColor = true;
		this.KEY_ALT_Left.Click += new System.EventHandler(KEY_ALT_Left_Click);
		this.KEY_ALT_Right.Location = new System.Drawing.Point(103, 32);
		this.KEY_ALT_Right.Name = "KEY_ALT_Right";
		this.KEY_ALT_Right.Size = new System.Drawing.Size(97, 23);
		this.KEY_ALT_Right.TabIndex = 72;
		this.KEY_ALT_Right.Text = "Right Alt+";
		this.KEY_ALT_Right.UseVisualStyleBackColor = true;
		this.KEY_ALT_Right.Click += new System.EventHandler(KEY_ALT_Right_Click);
		this.KEY_Shift_right.Location = new System.Drawing.Point(206, 32);
		this.KEY_Shift_right.Name = "KEY_Shift_right";
		this.KEY_Shift_right.Size = new System.Drawing.Size(97, 23);
		this.KEY_Shift_right.TabIndex = 73;
		this.KEY_Shift_right.Text = "Right Shift+";
		this.KEY_Shift_right.UseVisualStyleBackColor = true;
		this.KEY_Shift_right.Click += new System.EventHandler(KEY_Shift_right_Click);
		this.KEY_Ctrl_Right.Location = new System.Drawing.Point(3, 32);
		this.KEY_Ctrl_Right.Name = "KEY_Ctrl_Right";
		this.KEY_Ctrl_Right.Size = new System.Drawing.Size(94, 23);
		this.KEY_Ctrl_Right.TabIndex = 74;
		this.KEY_Ctrl_Right.Text = "Right  Ctrl+";
		this.KEY_Ctrl_Right.UseVisualStyleBackColor = true;
		this.KEY_Ctrl_Right.Click += new System.EventHandler(KEY_Ctrl_Right_Click);
		this.KEY_Win_left.Location = new System.Drawing.Point(309, 3);
		this.KEY_Win_left.Name = "KEY_Win_left";
		this.KEY_Win_left.Size = new System.Drawing.Size(88, 23);
		this.KEY_Win_left.TabIndex = 75;
		this.KEY_Win_left.Text = "Win+";
		this.KEY_Win_left.UseVisualStyleBackColor = true;
		this.KEY_Win_left.Click += new System.EventHandler(KEY_Win_left_Click);
		this.KEY_Win_Right.Location = new System.Drawing.Point(309, 32);
		this.KEY_Win_Right.Name = "KEY_Win_Right";
		this.KEY_Win_Right.Size = new System.Drawing.Size(88, 23);
		this.KEY_Win_Right.TabIndex = 76;
		this.KEY_Win_Right.Text = "Right Win+";
		this.KEY_Win_Right.UseVisualStyleBackColor = true;
		this.KEY_Win_Right.Click += new System.EventHandler(KEY_Win_Right_Click);
		this.KEY_ctrl_alt.Location = new System.Drawing.Point(3, 61);
		this.KEY_ctrl_alt.Name = "KEY_ctrl_alt";
		this.KEY_ctrl_alt.Size = new System.Drawing.Size(94, 23);
		this.KEY_ctrl_alt.TabIndex = 77;
		this.KEY_ctrl_alt.Text = "Ctrl+Alt+";
		this.KEY_ctrl_alt.UseVisualStyleBackColor = true;
		this.KEY_ctrl_alt.Click += new System.EventHandler(KEY_ctrl_alt_Click);
		this.KEY_Ctrl_Shift.Location = new System.Drawing.Point(106, 61);
		this.KEY_Ctrl_Shift.Name = "KEY_Ctrl_Shift";
		this.KEY_Ctrl_Shift.Size = new System.Drawing.Size(94, 23);
		this.KEY_Ctrl_Shift.TabIndex = 78;
		this.KEY_Ctrl_Shift.Text = "Ctrl+Shift+";
		this.KEY_Ctrl_Shift.UseVisualStyleBackColor = true;
		this.KEY_Ctrl_Shift.Click += new System.EventHandler(KEY_Ctrl_Shift_Click);
		this.KEY_Alt_Shift.Location = new System.Drawing.Point(206, 61);
		this.KEY_Alt_Shift.Name = "KEY_Alt_Shift";
		this.KEY_Alt_Shift.Size = new System.Drawing.Size(97, 23);
		this.KEY_Alt_Shift.TabIndex = 79;
		this.KEY_Alt_Shift.Text = "Alt+Shift+";
		this.KEY_Alt_Shift.UseVisualStyleBackColor = true;
		this.KEY_Alt_Shift.Click += new System.EventHandler(KEY_Alt_Shift_Click);
		this.KEY_Ctrl_Shift_Alt.Location = new System.Drawing.Point(3, 90);
		this.KEY_Ctrl_Shift_Alt.Name = "KEY_Ctrl_Shift_Alt";
		this.KEY_Ctrl_Shift_Alt.Size = new System.Drawing.Size(197, 23);
		this.KEY_Ctrl_Shift_Alt.TabIndex = 80;
		this.KEY_Ctrl_Shift_Alt.Text = "Ctrl+Shift+Alt+";
		this.KEY_Ctrl_Shift_Alt.UseVisualStyleBackColor = true;
		this.KEY_Ctrl_Shift_Alt.Click += new System.EventHandler(KEY_Ctrl_Shift_Alt_Click);
		this.KEY_Ctrl_Alt_Win.Location = new System.Drawing.Point(206, 90);
		this.KEY_Ctrl_Alt_Win.Name = "KEY_Ctrl_Alt_Win";
		this.KEY_Ctrl_Alt_Win.Size = new System.Drawing.Size(191, 23);
		this.KEY_Ctrl_Alt_Win.TabIndex = 81;
		this.KEY_Ctrl_Alt_Win.Text = "Ctrl+Alt+Win+";
		this.KEY_Ctrl_Alt_Win.UseVisualStyleBackColor = true;
		this.KEY_Ctrl_Alt_Win.Click += new System.EventHandler(KEY_Ctrl_Alt_Win_Click);
		this.KEY_Shift_Win.Location = new System.Drawing.Point(309, 61);
		this.KEY_Shift_Win.Name = "KEY_Shift_Win";
		this.KEY_Shift_Win.Size = new System.Drawing.Size(88, 23);
		this.KEY_Shift_Win.TabIndex = 82;
		this.KEY_Shift_Win.Text = "Shift+Win+";
		this.KEY_Shift_Win.UseVisualStyleBackColor = true;
		this.KEY_Shift_Win.Click += new System.EventHandler(KEY_Shift_Win_Click);
		this.KEY_Ctrl_Alt_Shift_Win.Location = new System.Drawing.Point(3, 119);
		this.KEY_Ctrl_Alt_Shift_Win.Name = "KEY_Ctrl_Alt_Shift_Win";
		this.KEY_Ctrl_Alt_Shift_Win.Size = new System.Drawing.Size(394, 23);
		this.KEY_Ctrl_Alt_Shift_Win.TabIndex = 83;
		this.KEY_Ctrl_Alt_Shift_Win.Text = "Ctrl+Alt+Shift+Win+";
		this.KEY_Ctrl_Alt_Shift_Win.UseVisualStyleBackColor = true;
		this.KEY_Ctrl_Alt_Shift_Win.Click += new System.EventHandler(KEY_Ctrl_Alt_Shift_Win_Click);
		this.KEY_Shift_And_1.Location = new System.Drawing.Point(423, 3);
		this.KEY_Shift_And_1.Name = "KEY_Shift_And_1";
		this.KEY_Shift_And_1.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_1.TabIndex = 84;
		this.KEY_Shift_And_1.Text = "～";
		this.KEY_Shift_And_1.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_1.Click += new System.EventHandler(KEY_Shift_And_1_Click);
		this.KEY_Shift_And_2.Location = new System.Drawing.Point(470, 3);
		this.KEY_Shift_And_2.Name = "KEY_Shift_And_2";
		this.KEY_Shift_And_2.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_2.TabIndex = 85;
		this.KEY_Shift_And_2.Text = "！";
		this.KEY_Shift_And_2.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_2.Click += new System.EventHandler(KEY_Shift_And_2_Click);
		this.KEY_Shift_And_3.Location = new System.Drawing.Point(517, 3);
		this.KEY_Shift_And_3.Name = "KEY_Shift_And_3";
		this.KEY_Shift_And_3.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_3.TabIndex = 86;
		this.KEY_Shift_And_3.Text = "@";
		this.KEY_Shift_And_3.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_3.Click += new System.EventHandler(KEY_Shift_And_3_Click);
		this.KEY_Shift_And_4.Location = new System.Drawing.Point(564, 3);
		this.KEY_Shift_And_4.Name = "KEY_Shift_And_4";
		this.KEY_Shift_And_4.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_4.TabIndex = 87;
		this.KEY_Shift_And_4.Text = "#";
		this.KEY_Shift_And_4.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_4.Click += new System.EventHandler(KEY_Shift_And_4_Click);
		this.KEY_Shift_And_5.Location = new System.Drawing.Point(611, 3);
		this.KEY_Shift_And_5.Name = "KEY_Shift_And_5";
		this.KEY_Shift_And_5.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_5.TabIndex = 88;
		this.KEY_Shift_And_5.Text = "$";
		this.KEY_Shift_And_5.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_5.Click += new System.EventHandler(KEY_Shift_And_5_Click);
		this.KEY_Shift_And_6.Location = new System.Drawing.Point(423, 32);
		this.KEY_Shift_And_6.Name = "KEY_Shift_And_6";
		this.KEY_Shift_And_6.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_6.TabIndex = 89;
		this.KEY_Shift_And_6.Text = "%";
		this.KEY_Shift_And_6.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_6.Click += new System.EventHandler(KEY_Shift_And_6_Click);
		this.KEY_Shift_And_7.Location = new System.Drawing.Point(470, 32);
		this.KEY_Shift_And_7.Name = "KEY_Shift_And_7";
		this.KEY_Shift_And_7.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_7.TabIndex = 90;
		this.KEY_Shift_And_7.Text = "∧";
		this.KEY_Shift_And_7.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_7.Click += new System.EventHandler(KEY_Shift_And_7_Click);
		this.KEY_Shift_And_8.Location = new System.Drawing.Point(517, 32);
		this.KEY_Shift_And_8.Name = "KEY_Shift_And_8";
		this.KEY_Shift_And_8.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_8.TabIndex = 91;
		this.KEY_Shift_And_8.Text = "＆";
		this.KEY_Shift_And_8.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_8.Click += new System.EventHandler(KEY_Shift_And_8_Click);
		this.KEY_Shift_And_9.Location = new System.Drawing.Point(564, 32);
		this.KEY_Shift_And_9.Name = "KEY_Shift_And_9";
		this.KEY_Shift_And_9.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_9.TabIndex = 92;
		this.KEY_Shift_And_9.Text = "*";
		this.KEY_Shift_And_9.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_9.Click += new System.EventHandler(KEY_Shift_And_9_Click);
		this.KEY_Shift_And_10.Location = new System.Drawing.Point(611, 32);
		this.KEY_Shift_And_10.Name = "KEY_Shift_And_10";
		this.KEY_Shift_And_10.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_10.TabIndex = 93;
		this.KEY_Shift_And_10.Text = "(";
		this.KEY_Shift_And_10.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_10.Click += new System.EventHandler(KEY_Shift_And_10_Click);
		this.KEY_Shift_And_11.Location = new System.Drawing.Point(423, 61);
		this.KEY_Shift_And_11.Name = "KEY_Shift_And_11";
		this.KEY_Shift_And_11.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_11.TabIndex = 94;
		this.KEY_Shift_And_11.Text = ")";
		this.KEY_Shift_And_11.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_11.Click += new System.EventHandler(KEY_Shift_And_11_Click);
		this.KEY_Shift_And_12.Location = new System.Drawing.Point(470, 61);
		this.KEY_Shift_And_12.Name = "KEY_Shift_And_12";
		this.KEY_Shift_And_12.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_12.TabIndex = 95;
		this.KEY_Shift_And_12.Text = "\uffe3";
		this.KEY_Shift_And_12.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_12.Click += new System.EventHandler(KEY_Shift_And_12_Click);
		this.KEY_Shift_And_13.Location = new System.Drawing.Point(517, 61);
		this.KEY_Shift_And_13.Name = "KEY_Shift_And_13";
		this.KEY_Shift_And_13.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_13.TabIndex = 96;
		this.KEY_Shift_And_13.Text = "＋";
		this.KEY_Shift_And_13.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_13.Click += new System.EventHandler(KEY_Shift_And_13_Click);
		this.KEY_Shift_And_14.Location = new System.Drawing.Point(564, 61);
		this.KEY_Shift_And_14.Name = "KEY_Shift_And_14";
		this.KEY_Shift_And_14.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_14.TabIndex = 97;
		this.KEY_Shift_And_14.Text = "{";
		this.KEY_Shift_And_14.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_14.Click += new System.EventHandler(KEY_Shift_And_14_Click);
		this.KEY_Shift_And_15.Location = new System.Drawing.Point(611, 61);
		this.KEY_Shift_And_15.Name = "KEY_Shift_And_15";
		this.KEY_Shift_And_15.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_15.TabIndex = 98;
		this.KEY_Shift_And_15.Text = "}";
		this.KEY_Shift_And_15.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_15.Click += new System.EventHandler(KEY_Shift_And_15_Click);
		this.KEY_Shift_And_16.Location = new System.Drawing.Point(423, 90);
		this.KEY_Shift_And_16.Name = "KEY_Shift_And_16";
		this.KEY_Shift_And_16.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_16.TabIndex = 99;
		this.KEY_Shift_And_16.Text = "|";
		this.KEY_Shift_And_16.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_16.Click += new System.EventHandler(KEY_Shift_And_16_Click);
		this.KEY_Shift_And_17.Location = new System.Drawing.Point(470, 90);
		this.KEY_Shift_And_17.Name = "KEY_Shift_And_17";
		this.KEY_Shift_And_17.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_17.TabIndex = 100;
		this.KEY_Shift_And_17.Text = "：";
		this.KEY_Shift_And_17.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_17.Click += new System.EventHandler(KEY_Shift_And_17_Click);
		this.KEY_Shift_And_18.Location = new System.Drawing.Point(517, 90);
		this.KEY_Shift_And_18.Name = "KEY_Shift_And_18";
		this.KEY_Shift_And_18.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_18.TabIndex = 101;
		this.KEY_Shift_And_18.Text = "＂";
		this.KEY_Shift_And_18.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_18.Click += new System.EventHandler(KEY_Shift_And_18_Click);
		this.KEY_Shift_And_19.Location = new System.Drawing.Point(564, 90);
		this.KEY_Shift_And_19.Name = "KEY_Shift_And_19";
		this.KEY_Shift_And_19.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_19.TabIndex = 102;
		this.KEY_Shift_And_19.Text = "＜";
		this.KEY_Shift_And_19.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_19.Click += new System.EventHandler(KEY_Shift_And_19_Click);
		this.KEY_Shift_And_20.Location = new System.Drawing.Point(611, 90);
		this.KEY_Shift_And_20.Name = "KEY_Shift_And_20";
		this.KEY_Shift_And_20.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_20.TabIndex = 103;
		this.KEY_Shift_And_20.Text = "＞";
		this.KEY_Shift_And_20.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_20.Click += new System.EventHandler(KEY_Shift_And_20_Click);
		this.KEY_Shift_And_21.Location = new System.Drawing.Point(423, 119);
		this.KEY_Shift_And_21.Name = "KEY_Shift_And_21";
		this.KEY_Shift_And_21.Size = new System.Drawing.Size(41, 23);
		this.KEY_Shift_And_21.TabIndex = 104;
		this.KEY_Shift_And_21.Text = "？";
		this.KEY_Shift_And_21.UseVisualStyleBackColor = true;
		this.KEY_Shift_And_21.Click += new System.EventHandler(KEY_Shift_And_21_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.KEY_Shift_And_21);
		base.Controls.Add(this.KEY_Shift_And_20);
		base.Controls.Add(this.KEY_Shift_And_19);
		base.Controls.Add(this.KEY_Shift_And_18);
		base.Controls.Add(this.KEY_Shift_And_17);
		base.Controls.Add(this.KEY_Shift_And_16);
		base.Controls.Add(this.KEY_Shift_And_15);
		base.Controls.Add(this.KEY_Shift_And_14);
		base.Controls.Add(this.KEY_Shift_And_13);
		base.Controls.Add(this.KEY_Shift_And_12);
		base.Controls.Add(this.KEY_Shift_And_11);
		base.Controls.Add(this.KEY_Shift_And_10);
		base.Controls.Add(this.KEY_Shift_And_9);
		base.Controls.Add(this.KEY_Shift_And_8);
		base.Controls.Add(this.KEY_Shift_And_7);
		base.Controls.Add(this.KEY_Shift_And_6);
		base.Controls.Add(this.KEY_Shift_And_5);
		base.Controls.Add(this.KEY_Shift_And_4);
		base.Controls.Add(this.KEY_Shift_And_3);
		base.Controls.Add(this.KEY_Shift_And_2);
		base.Controls.Add(this.KEY_Shift_And_1);
		base.Controls.Add(this.KEY_Ctrl_Alt_Shift_Win);
		base.Controls.Add(this.KEY_Shift_Win);
		base.Controls.Add(this.KEY_Ctrl_Alt_Win);
		base.Controls.Add(this.KEY_Ctrl_Shift_Alt);
		base.Controls.Add(this.KEY_Alt_Shift);
		base.Controls.Add(this.KEY_Ctrl_Shift);
		base.Controls.Add(this.KEY_ctrl_alt);
		base.Controls.Add(this.KEY_Win_Right);
		base.Controls.Add(this.KEY_Win_left);
		base.Controls.Add(this.KEY_Ctrl_Right);
		base.Controls.Add(this.KEY_Shift_right);
		base.Controls.Add(this.KEY_ALT_Right);
		base.Controls.Add(this.KEY_ALT_Left);
		base.Controls.Add(this.KEY_Shift_left);
		base.Controls.Add(this.KEY_Ctrl_left);
		base.Name = "FunKey";
		base.Size = new System.Drawing.Size(858, 443);
		base.ResumeLayout(false);
	}
}
