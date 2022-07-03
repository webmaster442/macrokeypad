using System.Collections.Generic;
using System.Linq;
using HidLibrary;

namespace HIDTester;

internal class HidLib
{
	private bool Dev_Sta;

	private List<HidDevice> DeviceList = new List<HidDevice>();

	private HidDevice wDevice;

	public bool Get_Dev_Sta()
	{
		return Dev_Sta;
	}

	public bool Connect_Device()
	{
		wDevice = HidDevices.Enumerate(4489).FirstOrDefault();
		if (wDevice != null)
		{
			foreach (HidDevice item in HidDevices.Enumerate(4489).ToList())
			{
				if (item.DevicePath.IndexOf("mi_01") != -1)
				{
					DeviceList.Add(item);
					wDevice = item;
					wDevice.OpenDevice();
					wDevice.MonitorDeviceEvents = true;
					Dev_Sta = true;
					return true;
				}
			}
		}
		return false;
	}

	public bool Check_Disconnect()
	{
		if (!wDevice.IsConnected)
		{
			wDevice.CloseDevice();
			Dev_Sta = false;
			return false;
		}
		return true;
	}

	public bool WriteDevice(byte id, byte[] arrayBuff)
	{
		HidReport val = wDevice.CreateReport();
		val.ReportId = id;
		val.Data[0] = arrayBuff[0];
		val.Data[1] = arrayBuff[1];
		val.Data[2] = arrayBuff[2];
		val.Data[3] = arrayBuff[3];
		val.Data[4] = arrayBuff[4];
		val.Data[5] = arrayBuff[5];
		val.Data[6] = arrayBuff[6];
		val.Data[7] = arrayBuff[7];
		if (wDevice.WriteReport(val, 500))
		{
			return true;
		}
		return false;
	}
}
