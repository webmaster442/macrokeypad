using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HIDTester;

public class MULKey : UserControl
{
	private IContainer components;

	private Button KEY_Play;

	private Button KEY_VolumeAdd;

	private Button KEY_VolumeSub;

	private Button KEY_PreSong;

	private Button KEY_NextSong;

	private Button KEY_Mute;

	public MULKey()
	{
		InitializeComponent();
	}

	private void MULGeneral_Char_Set()
	{
		FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KeyType_Num] |= 2;
	}

	private void KEY_Play_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 64;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Play.Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 4;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Play.Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 205;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Play.Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_PreSong_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 128;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_PreSong.Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 11;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_PreSong.Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 182;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_PreSong.Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_NextSong_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 1;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_NextSong.Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 10;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_NextSong.Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 181;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_NextSong.Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_Mute_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 4;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Mute.Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num + 1] = 1;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Mute.Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 226;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_Mute.Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_VolumeAdd_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 2;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_VolumeAdd.Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 64;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_VolumeAdd.Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 233;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_VolumeAdd.Text;
			MULGeneral_Char_Set();
		}
	}

	private void KEY_VolumeSub_Click(object sender, EventArgs e)
	{
		if (FormMain.KeyParam.ReportID == 0)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 1;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_VolumeSub.Text;
			MULGeneral_Char_Set();
		}
		else if (FormMain.KeyParam.ReportID == 2)
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 128;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_VolumeSub.Text;
			MULGeneral_Char_Set();
		}
		else
		{
			FormMain.KeyParam.Data_Send_Buff[FormMain.KeyParam.KEY_Char_Num] = 234;
			FormMain.KeyParam.KeyChar[FormMain.KeyParam.KEY_Char_Num - 5] = KEY_VolumeSub.Text;
			MULGeneral_Char_Set();
		}
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HIDTester.MULKey));
		this.KEY_Play = new System.Windows.Forms.Button();
		this.KEY_VolumeAdd = new System.Windows.Forms.Button();
		this.KEY_VolumeSub = new System.Windows.Forms.Button();
		this.KEY_PreSong = new System.Windows.Forms.Button();
		this.KEY_NextSong = new System.Windows.Forms.Button();
		this.KEY_Mute = new System.Windows.Forms.Button();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.KEY_Play, "KEY_Play");
		this.KEY_Play.Name = "KEY_Play";
		this.KEY_Play.UseVisualStyleBackColor = true;
		this.KEY_Play.Click += new System.EventHandler(KEY_Play_Click);
		componentResourceManager.ApplyResources(this.KEY_VolumeAdd, "KEY_VolumeAdd");
		this.KEY_VolumeAdd.Name = "KEY_VolumeAdd";
		this.KEY_VolumeAdd.UseVisualStyleBackColor = true;
		this.KEY_VolumeAdd.Click += new System.EventHandler(KEY_VolumeAdd_Click);
		componentResourceManager.ApplyResources(this.KEY_VolumeSub, "KEY_VolumeSub");
		this.KEY_VolumeSub.Name = "KEY_VolumeSub";
		this.KEY_VolumeSub.UseVisualStyleBackColor = true;
		this.KEY_VolumeSub.Click += new System.EventHandler(KEY_VolumeSub_Click);
		componentResourceManager.ApplyResources(this.KEY_PreSong, "KEY_PreSong");
		this.KEY_PreSong.Name = "KEY_PreSong";
		this.KEY_PreSong.UseVisualStyleBackColor = true;
		this.KEY_PreSong.Click += new System.EventHandler(KEY_PreSong_Click);
		componentResourceManager.ApplyResources(this.KEY_NextSong, "KEY_NextSong");
		this.KEY_NextSong.Name = "KEY_NextSong";
		this.KEY_NextSong.UseVisualStyleBackColor = true;
		this.KEY_NextSong.Click += new System.EventHandler(KEY_NextSong_Click);
		componentResourceManager.ApplyResources(this.KEY_Mute, "KEY_Mute");
		this.KEY_Mute.Name = "KEY_Mute";
		this.KEY_Mute.UseVisualStyleBackColor = true;
		this.KEY_Mute.Click += new System.EventHandler(KEY_Mute_Click);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.KEY_Mute);
		base.Controls.Add(this.KEY_NextSong);
		base.Controls.Add(this.KEY_PreSong);
		base.Controls.Add(this.KEY_VolumeSub);
		base.Controls.Add(this.KEY_VolumeAdd);
		base.Controls.Add(this.KEY_Play);
		base.Name = "MULKey";
		base.ResumeLayout(false);
	}
}
