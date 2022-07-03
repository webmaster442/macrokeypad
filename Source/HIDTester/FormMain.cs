using HID;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HIDTester;

public partial class FormMain : Form
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

	private Hid myHid = new Hid();
	private ushort WriteMode = 1;
	private IntPtr myHidPtr;
	private AutoSizeFormClass asc = new AutoSizeFormClass();
	private HidLib myHidLib = new HidLib();
	private byte[] RecDataBuffer = new byte[90];
	private int Display_Dowlaod_Char_TM;
	private readonly Color menuBackColor = Color.FromArgb(200, 200, 169);
	private readonly Color menuMouserOverColor = Color.FromArgb(230, 206, 172);
	private readonly string[] menuStr = new string[6] { "KEY", "Ctrl Shift Alt", "Multimedia", "LED", "Mouse", "" };

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
}
