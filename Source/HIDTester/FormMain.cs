using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using HID;

namespace HIDTester;

public class FormMain : Form
{
	public class KeyParam
	{
		public static byte[] Data_Send_Buff = new byte[65];

		public static byte KeySet_KeyNum = 0;

		public static byte KeyType_Num = 1;

		public static byte KeyGroupCharNum = 2;

		public static byte KeySet_KeyValNum = 3;

		public static byte Key_Fun_Num = 4;

		public static byte KEY_Char_Num = 5;

		public static byte PageBet_Inte_Cmd = 0;

		public static string[] KeyChar = new string[100];

		public static string[] FunKeyChar = new string[100];

		public static byte FunKEY_Char_Num = 0;

		public static byte ReportID = 0;

		public static byte KEY_Cur_Layer = 1;

		public static byte KEY_Cur_Page = 1;

		public static byte Language_Set = 0;
	}

	private ushort WriteMode = 1;

	private Hid myHid = new Hid();

	private IntPtr myHidPtr;

	private AutoSizeFormClass asc = new AutoSizeFormClass();

	private HidLib myHidLib = new HidLib();

	private byte[] RecDataBuffer = new byte[90];

	private int Display_Dowlaod_Char_TM;

	private readonly Color menuBackColor = Color.FromArgb(200, 200, 169);

	private readonly Color menuMouserOverColor = Color.FromArgb(230, 206, 172);

	private readonly string[] menuStr = new string[6] { "KEY", "Ctrl Shift Alt", "Multimedia", "LED", "Mouse", "" };

	private Dictionary<string, Form> menuDic = new Dictionary<string, Form>();

	private IContainer components;

	private Label stateLabel;

	private ToolStripMenuItem fdToolStripMenuItem;

	private Button Download;

	private Button KEY1;

	private Button KEY2;

	private Button KEY3;

	private Button KEY4;

	private Button K1_Left;

	private Button K1_Centre;

	private Button K1_Right;

	private TextBox SetText;

	private Button Key_Clear;

	private Button KEY8;

	private Button KEY7;

	private Button KEY6;

	private Button KEY5;

	private Button KEY12;

	private Button KEY11;

	private Button KEY10;

	private Button KEY9;

	private Button KEY16;

	private Button KEY15;

	private Button KEY14;

	private Button KEY13;

	private Button K2_Right;

	private Button K2_Centre;

	private Button K2_Left;

	private SplitContainer splitContainer1;

	private FlowLayoutPanel flowLayoutPanel1;

	private TextBox SetFunText;

	private Button K3_Left;

	private Button K3_Centre;

	private Button K3_Right;

	private FlowLayoutPanel flowLayoutPanel_LayerFun;

	private PictureBox pictureBox1;

	private Label label_Dowload_Dsp;

	public FormMain()
	{
		InitializeComponent();
		myHid.DataReceived += myhid_DataReceived;
		myHid.DeviceRemoved += myhid_DeviceRemoved;
		MenuList();
		KEY_Colour_Init();
		Time_Display_Text();
		Hide_Dowload_Text();
		LayerFunList();
		Lanuage_Set_EN();
	}

	private void MenuList()
	{
		for (int i = 0; i < menuStr.Length; i++)
		{
			Button button = new Button();
			button.Text = menuStr[i];
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.MouseOverBackColor = menuMouserOverColor;
			button.FlatAppearance.BorderSize = 0;
			button.Width = flowLayoutPanel1.Width;
			button.Height = 40;
			Padding margin = default(Padding);
			margin.All = 0;
			button.Margin = margin;
			button.MouseClick += Btn_OnClick;
			flowLayoutPanel1.Controls.Add(button);
			flowLayoutPanel1.BackColor = menuBackColor;
		}
		BasicKeys basicKeys = new BasicKeys();
		basicKeys.Parent = splitContainer1.Panel2;
		basicKeys.Dock = DockStyle.Fill;
		basicKeys.Show();
		KeyParam.KEY_Cur_Page = 1;
	}

	private void LayerFunList()
	{
		LayerFun layerFun = new LayerFun();
		flowLayoutPanel_LayerFun.Controls.Add(layerFun);
		layerFun.Show();
	}

	private void Btn_OnClick(object sender, MouseEventArgs e)
	{
		switch ((sender as Button).Text)
		{
		case "KEY":
		{
			splitContainer1.Panel2.Controls.Clear();
			BasicKeys basicKeys = new BasicKeys();
			basicKeys.Parent = splitContainer1.Panel2;
			basicKeys.Dock = DockStyle.Fill;
			basicKeys.Show();
			KeyParam.KEY_Cur_Page = 1;
			break;
		}
		case "Ctrl Shift Alt":
		{
			splitContainer1.Panel2.Controls.Clear();
			FunKey funKey = new FunKey();
			funKey.Parent = splitContainer1.Panel2;
			funKey.Dock = DockStyle.Fill;
			funKey.Show();
			KeyParam.KEY_Cur_Page = 2;
			break;
		}
		case "Multimedia":
		{
			splitContainer1.Panel2.Controls.Clear();
			MULKey mULKey = new MULKey();
			mULKey.Parent = splitContainer1.Panel2;
			mULKey.Dock = DockStyle.Fill;
			mULKey.Show();
			KeyParam.KEY_Cur_Page = 3;
			break;
		}
		case "LED":
		{
			splitContainer1.Panel2.Controls.Clear();
			LEDkey lEDkey = new LEDkey();
			lEDkey.Parent = splitContainer1.Panel2;
			lEDkey.Dock = DockStyle.Fill;
			lEDkey.Show();
			Key_Clear_Fun();
			KeyParam.KEY_Cur_Page = 4;
			break;
		}
		case "Mouse":
		{
			splitContainer1.Panel2.Controls.Clear();
			MouseKey mouseKey = new MouseKey();
			mouseKey.Parent = splitContainer1.Panel2;
			mouseKey.Dock = DockStyle.Fill;
			mouseKey.Show();
			Key_Clear_Fun();
			KeyParam.KEY_Cur_Page = 5;
			break;
		}
		}
	}

	private void Show_Dowload_Text()
	{
		Display_Dowlaod_Char_TM = 20;
		label_Dowload_Dsp.Show();
	}

	private void Hide_Dowload_Text()
	{
		label_Dowload_Dsp.Hide();
	}

	private void AutoCheckUsb()
	{
		if (WriteMode == 0)
		{
			if (!myHid.Opened)
			{
				ushort vID = 4489;
				ushort pID = 34960;
				if ((int)(myHidPtr = myHid.OpenDevice(vID, pID)) != -1)
				{
					KeyBoardVersion_Check();
					stateLabel.Text = "Connected";
					Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Green));
				}
				else
				{
					stateLabel.Text = "Not Connected";
					Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Red));
				}
			}
			else
			{
				stateLabel.Text = "Connected";
				Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Green));
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			if (!myHidLib.Get_Dev_Sta())
			{
				if (myHidLib.Connect_Device())
				{
					KeyBoardVersion_Check();
					stateLabel.Text = "Connected";
					Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Green));
				}
				else
				{
					stateLabel.Text = "Not Connected";
					Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Red));
				}
			}
			else if (myHidLib.Check_Disconnect())
			{
				stateLabel.Text = "Connected";
				Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Green));
			}
			else
			{
				stateLabel.Text = "Not Connected";
				Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Red));
			}
		}
	}

	protected void myhid_DataReceived(object sender, report e)
	{
		RecDataBuffer = e.reportBuff;
		new ASCIIEncoding().GetString(RecDataBuffer);
	}

	protected void myhid_DeviceRemoved(object sender, EventArgs e)
	{
		stateLabel.Text = "设备移除";
		Color color2 = (stateLabel.BackColor = (stateLabel.BackColor = Color.Red));
	}

	private void aboutMenu_Click(object sender, EventArgs e)
	{
		Process.Start("http://www.cnblogs.com/hebaichuanyeah/p/4504855.html");
	}

	private void Time_Display_Text()
	{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		timer.Enabled = true;
		timer.Interval = 30;
		timer.Start();
		timer.Tick += Timer1_Elapsed;
	}


    private void Timer1_Elapsed(object sender, EventArgs e)
	{
		AutoCheckUsb();
		if (KeyParam.PageBet_Inte_Cmd != 0 && KeyParam.PageBet_Inte_Cmd == 1)
		{
			KeyParam.PageBet_Inte_Cmd = 0;
			Key_Clear_Fun();
		}
		if (Display_Dowlaod_Char_TM-- == 0)
		{
			Hide_Dowload_Text();
		}
		if (KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] != 0)
		{
			string text = "";
			string text2 = "";
			text += KeyParam.KeyChar[0];
			text += " ";
			text += KeyParam.KeyChar[2];
			text += " ";
			text += KeyParam.KeyChar[4];
			text += " ";
			text += KeyParam.KeyChar[6];
			text += " ";
			text += KeyParam.KeyChar[8];
			SetText.Text = text;
			text2 += KeyParam.FunKeyChar[0];
			text2 += " ";
			text2 += KeyParam.FunKeyChar[1];
			text2 += " ";
			text2 += KeyParam.FunKeyChar[2];
			text2 += " ";
			text2 += KeyParam.FunKeyChar[3];
			SetFunText.Text = text2;
		}
		else
		{
			string text3 = "";
			string text4 = "";
			SetText.Text = text3;
			SetFunText.Text = text4;
		}
	}

    private void KeyBoardVersion_Check()
	{
		byte[] array = new byte[65];
		KeyParam.ReportID = 0;
		array[0] = 0;
		array[1] = 0;
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				KeyParam.ReportID = 0;
				return;
			}
			KeyParam.ReportID = 2;
			r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				KeyParam.ReportID = 2;
			}
			else
			{
				KeyParam.ReportID = 3;
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			KeyParam.ReportID = 3;
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				KeyParam.ReportID = 3;
				return;
			}
			KeyParam.ReportID = 0;
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				KeyParam.ReportID = 0;
				return;
			}
			KeyParam.ReportID = 2;
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				KeyParam.ReportID = 2;
			}
		}
	}

	private void Send_WriteFlash_Cmd()
	{
		byte[] array = new byte[65];
		array[0] = 170;
		array[1] = 170;
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载成功";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Green));
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载失败";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Red));
				Show_Dowload_Text();
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载成功";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Green));
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载失败";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Red));
				Show_Dowload_Text();
			}
		}
	}

	private void Send_WriteFlashLED_Cmd()
	{
		byte[] array = new byte[65];
		array[0] = 170;
		array[1] = 161;
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			if ((byte)myHid.Write(r) == 0)
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载成功";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Green));
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载失败";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Red));
				Show_Dowload_Text();
			}
		}
		else
		{
			if (WriteMode != 1)
			{
				return;
			}
			if (myHidLib.WriteDevice(KeyParam.ReportID, array))
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download success";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载成功";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Green));
				Show_Dowload_Text();
			}
			else
			{
				if (KeyParam.Language_Set == 0)
				{
					label_Dowload_Dsp.Text = "Download failed";
				}
				else if (KeyParam.Language_Set == 1)
				{
					label_Dowload_Dsp.Text = "下载失败";
				}
				Color color2 = (label_Dowload_Dsp.BackColor = (label_Dowload_Dsp.BackColor = Color.Red));
				Show_Dowload_Text();
			}
		}
	}

	private void Send_SwLayer()
	{
		byte[] array = new byte[65];
		array[0] = 161;
		array[1] = KeyParam.KEY_Cur_Layer;
		if (array[1] == 0)
		{
			array[1] = 1;
		}
		if (WriteMode == 0)
		{
			report r = new report(KeyParam.ReportID, array);
			_ = (byte)myHid.Write(r);
		}
		else if (WriteMode == 1)
		{
			myHidLib.WriteDevice(KeyParam.ReportID, array);
		}
	}

	private void Download_Click(object sender, EventArgs e)
	{
		byte b = 0;
		byte[] array = new byte[65];
		if (!myHidLib.Get_Dev_Sta())
		{
			return;
		}
		array[0] = KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum];
		if (array[0] == 0)
		{
			return;
		}
		if (KeyParam.ReportID == 0)
		{
			array[1] = (KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] &= 15);
		}
		else
		{
			Send_SwLayer();
			array[1] = KeyParam.KEY_Cur_Layer;
			array[1] <<= 4;
			array[1] |= KeyParam.Data_Send_Buff[KeyParam.KeyType_Num];
		}
		if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 1)
		{
			array[2] = KeyParam.Data_Send_Buff[KeyParam.KeyGroupCharNum];
			for (b = 0; b <= KeyParam.Data_Send_Buff[KeyParam.KeyGroupCharNum]; b = (byte)(b + 1))
			{
				array[3] = b;
				switch (b)
				{
				case 0:
					array[4] = KeyParam.Data_Send_Buff[4];
					array[5] = 0;
					break;
				case 1:
					array[4] = KeyParam.Data_Send_Buff[4];
					array[5] = KeyParam.Data_Send_Buff[5];
					break;
				case 2:
					array[4] = KeyParam.Data_Send_Buff[6];
					array[5] = KeyParam.Data_Send_Buff[7];
					break;
				case 3:
					array[4] = KeyParam.Data_Send_Buff[8];
					array[5] = KeyParam.Data_Send_Buff[9];
					break;
				case 4:
					array[4] = KeyParam.Data_Send_Buff[10];
					array[5] = KeyParam.Data_Send_Buff[11];
					break;
				case 5:
					array[4] = KeyParam.Data_Send_Buff[12];
					array[5] = KeyParam.Data_Send_Buff[13];
					break;
				}
				if (WriteMode == 0)
				{
					report r = new report(KeyParam.ReportID, array);
					myHid.Write(r);
				}
				else if (WriteMode == 1)
				{
					myHidLib.WriteDevice(KeyParam.ReportID, array);
				}
			}
			Send_WriteFlash_Cmd();
		}
		else if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 2)
		{
			array[2] = KeyParam.Data_Send_Buff[5];
			array[3] = KeyParam.Data_Send_Buff[6];
			if (WriteMode == 0)
			{
				report r = new report(KeyParam.ReportID, array);
				myHid.Write(r);
			}
			else if (WriteMode == 1)
			{
				myHidLib.WriteDevice(KeyParam.ReportID, array);
			}
			Send_WriteFlash_Cmd();
		}
		else if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 8)
		{
			array[2] = KeyParam.Data_Send_Buff[2];
			if (WriteMode == 0)
			{
				report r = new report(KeyParam.ReportID, array);
				myHid.Write(r);
			}
			else if (WriteMode == 1)
			{
				myHidLib.WriteDevice(KeyParam.ReportID, array);
			}
			Send_WriteFlashLED_Cmd();
		}
		else if ((KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] & 0xF) == 3)
		{
			array[2] = KeyParam.Data_Send_Buff[5];
			array[3] = KeyParam.Data_Send_Buff[6];
			array[4] = KeyParam.Data_Send_Buff[7];
			array[5] = KeyParam.Data_Send_Buff[8];
			array[6] = KeyParam.Data_Send_Buff[9];
			if (WriteMode == 0)
			{
				report r = new report(KeyParam.ReportID, array);
				myHid.Write(r);
			}
			else if (WriteMode == 1)
			{
				myHidLib.WriteDevice(KeyParam.ReportID, array);
			}
			Send_WriteFlash_Cmd();
		}
	}

	private void Key_Clear_Click(object sender, EventArgs e)
	{
		Key_Clear_Fun();
	}

	private void Key_Clear_Fun()
	{
		Clear_Key_Char();
		Set_Key_Init();
		KEY_Colour_Init();
		KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 0;
	}

	private void Clear_Key_Char()
	{
		int num = 0;
		for (num = 0; num < 100; num++)
		{
			KeyParam.KeyChar[num] = null;
			KeyParam.FunKeyChar[num] = null;
			KeyParam.FunKEY_Char_Num = 0;
		}
	}

	private void Set_Key_Init()
	{
		KeyParam.KEY_Char_Num = 5;
		KeyParam.Data_Send_Buff[KeyParam.KeyType_Num] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KeyGroupCharNum] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyValNum] = 0;
		KeyParam.Data_Send_Buff[KeyParam.Key_Fun_Num] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 1] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 2] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 3] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 4] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 5] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 6] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 7] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 8] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 9] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 10] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 11] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 12] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 13] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 14] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 15] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 16] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 17] = 0;
		KeyParam.Data_Send_Buff[KeyParam.KEY_Char_Num + 18] = 0;
	}

	private void KEY_Colour_Init()
	{
		int red = 152;
		int green = 251;
		int blue = 152;
		KEY1.BackColor = Color.FromArgb(red, green, blue);
		KEY2.BackColor = Color.FromArgb(red, green, blue);
		KEY3.BackColor = Color.FromArgb(red, green, blue);
		KEY4.BackColor = Color.FromArgb(red, green, blue);
		KEY5.BackColor = Color.FromArgb(red, green, blue);
		KEY6.BackColor = Color.FromArgb(red, green, blue);
		KEY7.BackColor = Color.FromArgb(red, green, blue);
		KEY8.BackColor = Color.FromArgb(red, green, blue);
		KEY9.BackColor = Color.FromArgb(red, green, blue);
		KEY10.BackColor = Color.FromArgb(red, green, blue);
		KEY11.BackColor = Color.FromArgb(red, green, blue);
		KEY12.BackColor = Color.FromArgb(red, green, blue);
		KEY13.BackColor = Color.FromArgb(red, green, blue);
		KEY14.BackColor = Color.FromArgb(red, green, blue);
		KEY15.BackColor = Color.FromArgb(red, green, blue);
		KEY16.BackColor = Color.FromArgb(red, green, blue);
		K1_Left.BackColor = Color.FromArgb(red, green, blue);
		K1_Centre.BackColor = Color.FromArgb(red, green, blue);
		K1_Right.BackColor = Color.FromArgb(red, green, blue);
		K2_Left.BackColor = Color.FromArgb(red, green, blue);
		K2_Centre.BackColor = Color.FromArgb(red, green, blue);
		K2_Right.BackColor = Color.FromArgb(red, green, blue);
		K3_Left.BackColor = Color.FromArgb(red, green, blue);
		K3_Centre.BackColor = Color.FromArgb(red, green, blue);
		K3_Right.BackColor = Color.FromArgb(red, green, blue);
	}

	private void KEY1_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 1;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY1.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY2_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 2;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY2.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY3_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 3;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY3.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY4_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 4;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY4.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY5_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 5;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY5.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY6_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 6;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY6.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY7_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 7;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY7.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY8_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 8;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY8.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY9_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 9;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY9.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY10_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 10;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY10.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY11_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 11;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY11.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void KEY12_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 12;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			KEY12.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K1_Left_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 13;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			K1_Left.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K1_Centre_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 14;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			K1_Centre.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K1_Right_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 15;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			K1_Right.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K2_Left_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 16;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			K2_Left.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K2_Centre_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 17;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			K2_Centre.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void K2_Right_Click(object sender, EventArgs e)
	{
		if (KeyParam.KEY_Cur_Page != 4)
		{
			KeyParam.Data_Send_Buff[KeyParam.KeySet_KeyNum] = 18;
			Set_Key_Init();
			Clear_Key_Char();
			KEY_Colour_Init();
			K2_Right.BackColor = Color.FromArgb(255, 48, 48);
		}
	}

	private void FormMain_Load(object sender, EventArgs e)
	{
		asc.controllInitializeSize(this);
	}

	private void MainPage_SizeChanged(object sender, EventArgs e)
	{
		asc.controlAutoSize(this);
	}

	private void Lanuage_Set_ZH()
	{
		Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
		ApplyResource();
	}

	private void Lanuage_Set_EN()
	{
		Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
		ApplyResource();
	}

	private void ApplyResource()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMain));
		foreach (Control control in base.Controls)
		{
			componentResourceManager.ApplyResources(control, control.Name);
		}
		ResumeLayout(performLayout: false);
		PerformLayout();
		componentResourceManager.ApplyResources(this, "$this");
	}

	private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
	{
	}

	private void SetFunText_TextChanged(object sender, EventArgs e)
	{
	}

	private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HIDTester.FormMain));
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
		this.stateLabel = new System.Windows.Forms.Label();
		this.fdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.Download = new System.Windows.Forms.Button();
		this.KEY1 = new System.Windows.Forms.Button();
		this.KEY2 = new System.Windows.Forms.Button();
		this.KEY3 = new System.Windows.Forms.Button();
		this.KEY4 = new System.Windows.Forms.Button();
		this.K1_Left = new System.Windows.Forms.Button();
		this.K1_Centre = new System.Windows.Forms.Button();
		this.K1_Right = new System.Windows.Forms.Button();
		this.SetText = new System.Windows.Forms.TextBox();
		this.Key_Clear = new System.Windows.Forms.Button();
		this.KEY8 = new System.Windows.Forms.Button();
		this.KEY7 = new System.Windows.Forms.Button();
		this.KEY6 = new System.Windows.Forms.Button();
		this.KEY5 = new System.Windows.Forms.Button();
		this.KEY12 = new System.Windows.Forms.Button();
		this.KEY11 = new System.Windows.Forms.Button();
		this.KEY10 = new System.Windows.Forms.Button();
		this.KEY9 = new System.Windows.Forms.Button();
		this.KEY16 = new System.Windows.Forms.Button();
		this.KEY15 = new System.Windows.Forms.Button();
		this.KEY14 = new System.Windows.Forms.Button();
		this.KEY13 = new System.Windows.Forms.Button();
		this.K2_Right = new System.Windows.Forms.Button();
		this.K2_Centre = new System.Windows.Forms.Button();
		this.K2_Left = new System.Windows.Forms.Button();
		this.SetFunText = new System.Windows.Forms.TextBox();
		this.K3_Left = new System.Windows.Forms.Button();
		this.K3_Centre = new System.Windows.Forms.Button();
		this.K3_Right = new System.Windows.Forms.Button();
		this.flowLayoutPanel_LayerFun = new System.Windows.Forms.FlowLayoutPanel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label_Dowload_Dsp = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.splitContainer1, "splitContainer1");
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(splitContainer1_Panel1_Paint);
		this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(splitContainer1_Panel2_Paint);
		componentResourceManager.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
		this.flowLayoutPanel1.Name = "flowLayoutPanel1";
		componentResourceManager.ApplyResources(this.stateLabel, "stateLabel");
		this.stateLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.stateLabel.Name = "stateLabel";
		this.fdToolStripMenuItem.Name = "fdToolStripMenuItem";
		componentResourceManager.ApplyResources(this.fdToolStripMenuItem, "fdToolStripMenuItem");
		componentResourceManager.ApplyResources(this.Download, "Download");
		this.Download.Name = "Download";
		this.Download.UseVisualStyleBackColor = true;
		this.Download.Click += new System.EventHandler(Download_Click);
		componentResourceManager.ApplyResources(this.KEY1, "KEY1");
		this.KEY1.Name = "KEY1";
		this.KEY1.UseVisualStyleBackColor = true;
		this.KEY1.Click += new System.EventHandler(KEY1_Click);
		componentResourceManager.ApplyResources(this.KEY2, "KEY2");
		this.KEY2.Name = "KEY2";
		this.KEY2.UseVisualStyleBackColor = true;
		this.KEY2.Click += new System.EventHandler(KEY2_Click);
		componentResourceManager.ApplyResources(this.KEY3, "KEY3");
		this.KEY3.Name = "KEY3";
		this.KEY3.UseVisualStyleBackColor = true;
		this.KEY3.Click += new System.EventHandler(KEY3_Click);
		componentResourceManager.ApplyResources(this.KEY4, "KEY4");
		this.KEY4.Name = "KEY4";
		this.KEY4.UseVisualStyleBackColor = true;
		this.KEY4.Click += new System.EventHandler(KEY4_Click);
		componentResourceManager.ApplyResources(this.K1_Left, "K1_Left");
		this.K1_Left.Name = "K1_Left";
		this.K1_Left.UseVisualStyleBackColor = true;
		this.K1_Left.Click += new System.EventHandler(K1_Left_Click);
		componentResourceManager.ApplyResources(this.K1_Centre, "K1_Centre");
		this.K1_Centre.Name = "K1_Centre";
		this.K1_Centre.UseVisualStyleBackColor = true;
		this.K1_Centre.Click += new System.EventHandler(K1_Centre_Click);
		componentResourceManager.ApplyResources(this.K1_Right, "K1_Right");
		this.K1_Right.Name = "K1_Right";
		this.K1_Right.UseVisualStyleBackColor = true;
		this.K1_Right.Click += new System.EventHandler(K1_Right_Click);
		componentResourceManager.ApplyResources(this.SetText, "SetText");
		this.SetText.Name = "SetText";
		componentResourceManager.ApplyResources(this.Key_Clear, "Key_Clear");
		this.Key_Clear.Name = "Key_Clear";
		this.Key_Clear.UseVisualStyleBackColor = true;
		this.Key_Clear.Click += new System.EventHandler(Key_Clear_Click);
		componentResourceManager.ApplyResources(this.KEY8, "KEY8");
		this.KEY8.Name = "KEY8";
		this.KEY8.UseVisualStyleBackColor = true;
		this.KEY8.Click += new System.EventHandler(KEY8_Click);
		componentResourceManager.ApplyResources(this.KEY7, "KEY7");
		this.KEY7.Name = "KEY7";
		this.KEY7.UseVisualStyleBackColor = true;
		this.KEY7.Click += new System.EventHandler(KEY7_Click);
		componentResourceManager.ApplyResources(this.KEY6, "KEY6");
		this.KEY6.Name = "KEY6";
		this.KEY6.UseVisualStyleBackColor = true;
		this.KEY6.Click += new System.EventHandler(KEY6_Click);
		componentResourceManager.ApplyResources(this.KEY5, "KEY5");
		this.KEY5.Name = "KEY5";
		this.KEY5.UseVisualStyleBackColor = true;
		this.KEY5.Click += new System.EventHandler(KEY5_Click);
		componentResourceManager.ApplyResources(this.KEY12, "KEY12");
		this.KEY12.Name = "KEY12";
		this.KEY12.UseVisualStyleBackColor = true;
		this.KEY12.Click += new System.EventHandler(KEY12_Click);
		componentResourceManager.ApplyResources(this.KEY11, "KEY11");
		this.KEY11.Name = "KEY11";
		this.KEY11.UseVisualStyleBackColor = true;
		this.KEY11.Click += new System.EventHandler(KEY11_Click);
		componentResourceManager.ApplyResources(this.KEY10, "KEY10");
		this.KEY10.Name = "KEY10";
		this.KEY10.UseVisualStyleBackColor = true;
		this.KEY10.Click += new System.EventHandler(KEY10_Click);
		componentResourceManager.ApplyResources(this.KEY9, "KEY9");
		this.KEY9.Name = "KEY9";
		this.KEY9.UseVisualStyleBackColor = true;
		this.KEY9.Click += new System.EventHandler(KEY9_Click);
		componentResourceManager.ApplyResources(this.KEY16, "KEY16");
		this.KEY16.Name = "KEY16";
		this.KEY16.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.KEY15, "KEY15");
		this.KEY15.Name = "KEY15";
		this.KEY15.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.KEY14, "KEY14");
		this.KEY14.Name = "KEY14";
		this.KEY14.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.KEY13, "KEY13");
		this.KEY13.Name = "KEY13";
		this.KEY13.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.K2_Right, "K2_Right");
		this.K2_Right.Name = "K2_Right";
		this.K2_Right.UseVisualStyleBackColor = true;
		this.K2_Right.Click += new System.EventHandler(K2_Right_Click);
		componentResourceManager.ApplyResources(this.K2_Centre, "K2_Centre");
		this.K2_Centre.Name = "K2_Centre";
		this.K2_Centre.UseVisualStyleBackColor = true;
		this.K2_Centre.Click += new System.EventHandler(K2_Centre_Click);
		componentResourceManager.ApplyResources(this.K2_Left, "K2_Left");
		this.K2_Left.Name = "K2_Left";
		this.K2_Left.UseVisualStyleBackColor = true;
		this.K2_Left.Click += new System.EventHandler(K2_Left_Click);
		componentResourceManager.ApplyResources(this.SetFunText, "SetFunText");
		this.SetFunText.Name = "SetFunText";
		this.SetFunText.TextChanged += new System.EventHandler(SetFunText_TextChanged);
		componentResourceManager.ApplyResources(this.K3_Left, "K3_Left");
		this.K3_Left.Name = "K3_Left";
		this.K3_Left.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.K3_Centre, "K3_Centre");
		this.K3_Centre.Name = "K3_Centre";
		this.K3_Centre.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.K3_Right, "K3_Right");
		this.K3_Right.Name = "K3_Right";
		this.K3_Right.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this.flowLayoutPanel_LayerFun, "flowLayoutPanel_LayerFun");
		this.flowLayoutPanel_LayerFun.Name = "flowLayoutPanel_LayerFun";
		this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
		componentResourceManager.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(this.label_Dowload_Dsp, "label_Dowload_Dsp");
		this.label_Dowload_Dsp.Name = "label_Dowload_Dsp";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.flowLayoutPanel1);
		base.Controls.Add(this.label_Dowload_Dsp);
		base.Controls.Add(this.flowLayoutPanel_LayerFun);
		base.Controls.Add(this.SetFunText);
		base.Controls.Add(this.K3_Right);
		base.Controls.Add(this.K3_Centre);
		base.Controls.Add(this.K3_Left);
		base.Controls.Add(this.K2_Right);
		base.Controls.Add(this.K2_Centre);
		base.Controls.Add(this.K2_Left);
		base.Controls.Add(this.KEY16);
		base.Controls.Add(this.KEY15);
		base.Controls.Add(this.KEY14);
		base.Controls.Add(this.KEY13);
		base.Controls.Add(this.KEY12);
		base.Controls.Add(this.KEY11);
		base.Controls.Add(this.KEY10);
		base.Controls.Add(this.KEY9);
		base.Controls.Add(this.KEY8);
		base.Controls.Add(this.KEY7);
		base.Controls.Add(this.KEY6);
		base.Controls.Add(this.KEY5);
		base.Controls.Add(this.Key_Clear);
		base.Controls.Add(this.SetText);
		base.Controls.Add(this.K1_Right);
		base.Controls.Add(this.K1_Centre);
		base.Controls.Add(this.K1_Left);
		base.Controls.Add(this.KEY4);
		base.Controls.Add(this.KEY3);
		base.Controls.Add(this.KEY2);
		base.Controls.Add(this.KEY1);
		base.Controls.Add(this.Download);
		base.Controls.Add(this.stateLabel);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.pictureBox1);
		this.Cursor = System.Windows.Forms.Cursors.Default;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		base.Name = "FormMain";
		base.Load += new System.EventHandler(FormMain_Load);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
