using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Deklaration der benötigten API-Funktionen */
		[DllImport("user32", SetLastError=true)]
		private static extern int FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32", SetLastError=true)]
		public static extern int SetForegroundWindow(IntPtr hwnd);

		[DllImport("user32", SetLastError=true)]
		public static extern int IsIconic(IntPtr hwnd);

		[DllImport("user32", SetLastError=true)]
		public static extern int OpenIcon(IntPtr hwnd);

		[DllImport("user32", SetLastError=true)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName,
			int nMaxCount);

		/* Methode zum Aktivieren einer Anwendung */
		public static void ActivateApplication(string mainWindowClassName, 
			string mainWindowTitle)
		{
			// Fenster mit dem übergebenen Klassennamen und Titel suchen
			int windowHandle = FindWindow(mainWindowClassName, mainWindowTitle);

			if (windowHandle != 0)
			{
				// Fenster gefunden: Überprüfen, ob das Fenster verkleinert ist
				if (IsIconic((IntPtr)windowHandle) != 0) 
				{
					// Fenster wiederherstellen
					if (OpenIcon((IntPtr)windowHandle) == 0) 
					{
						throw new Exception("Windows-Fehler " + 
							Marshal.GetLastWin32Error() + " beim Wiederherstellen " +
							"des Fensters mit dem Titel '" + mainWindowTitle + 
							"' aus dem minimierten Zustand.");
					}
				}

				// Fenster in den Vordergrund holen
				if (SetForegroundWindow((IntPtr)windowHandle) == 0) 
				{
					throw new Exception("Windows-Fehler " + 
						Marshal.GetLastWin32Error() + " beim Nach-Vorne-Holen " +
						"des Fensters mit dem Titel '" + mainWindowTitle + "'");
				}
			}
			else
			{
				throw new Exception("Fenster mit Titel '" + mainWindowTitle + 
					"' nicht gefunden");
			}
		}

		/* Hilfs-Methode zum Auslesen des Klassennamens eines Fensters */
		public static string GetWindowClassName(string windowTitle)
		{
			int windowHandle = FindWindow(null, windowTitle);
			if (windowHandle != 0)
			{
				StringBuilder className = new StringBuilder(255);
				if (GetClassName((IntPtr)windowHandle, className, 255) > 0)
				{
					return className.ToString();
				}
				else
				{
					throw new Exception("Windows-Fehler " + 
						Marshal.GetLastWin32Error() + "beim Ermitteln des " +
						" Klassennamens des Fensters mit dem Titel '" + 
						windowTitle + "'");
				}
			}
			else
			{
				throw new Exception("Fenster mit dem Titel '" + windowTitle + 
					"' nicht gefunden");
			}
		}
	}
}