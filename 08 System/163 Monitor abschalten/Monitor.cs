using System;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.System
{
	public class Monitor
	{
		// Deklaration der API-Funktion SendMessage
		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr handle, int msg, int
			wparam, int lparam);

		// Deklaration der benötigten Konstanten
		private const int WM_SYSCOMMAND = 0x0112;
		private const int SC_MONITORPOWER = 0xF170;
		private const int HWND_BROADCAST = 0xFFFF;

		// Funktion zum Abschalten des Monitors
		public static void TurnOff()
		{
			SendMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
		}

		// Funktion zum Umschalten des Monitors in den Energiesparmodus
		public static void SwitchToLowPower()
		{
			SendMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 1);
		}

		// Funktion zum Einschalten des Monitors
		public static void TurnOn()
		{
			SendMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND,
				SC_MONITORPOWER, -1);
		}
	}
}