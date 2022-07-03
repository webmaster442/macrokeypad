using System;
using System.Windows.Forms;

namespace HIDTester;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new FormMain());
	}
}
