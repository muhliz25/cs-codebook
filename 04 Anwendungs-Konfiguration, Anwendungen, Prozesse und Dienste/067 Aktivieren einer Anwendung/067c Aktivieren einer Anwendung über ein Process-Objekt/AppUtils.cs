using System;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Deklaration der benötigten API-Funktionen */
		[DllImport("user32", SetLastError=true)]
		public static extern int SetForegroundWindow(IntPtr hwnd);

		[DllImport("user32", SetLastError=true)]
		public static extern int IsIconic(IntPtr hwnd);

		[DllImport("user32", SetLastError=true)]
		public static extern int OpenIcon(IntPtr hwnd);

		/* Methode zum Aktivieren einer Anwendung über ein Process-Objekt */
		public static void ActivateApplication(Process process)
		{
			if ((int)process.MainWindowHandle != 0)
			{
				if (IsIconic((IntPtr)process.MainWindowHandle) != 0) 
				{
					// Hauptfenster nach vorne holen
					if (OpenIcon(process.MainWindowHandle) == 0) 
					{
						throw new Exception("Windows-Fehler " + 
							Marshal.GetLastWin32Error() + " beim Wiederherstellen " +
							"des Fensters für den Prozess " + process.ProcessName + 
							"' aus dem minimierten Zustand.");
					}
				}

				// Fenster in den Vordergrund holen
				if (SetForegroundWindow(process.MainWindowHandle) == 0) 
				{
					throw new Exception("Windows-Fehler " + 
						Marshal.GetLastWin32Error() + " beim Nach-Vorne-Holen " +
						"des Hauptfensters des Prozesses '" + process.ProcessName +
						"'");
				}
			}
			else
			{
				throw new Exception("Der Prozess '" + process.ProcessName + 
					" besitzt kein Hauptfenster");
			}
		}
	}
}
