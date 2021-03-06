using System;
using System.Diagnostics;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zur Ermittlng eines Prozesses, der eine andere Instanz
		 * der aktuellen Anwendung ist */
		public static Process RunningInstance()
		{
			// Alle Prozesse mit dem Namen des aktuellen Prozesses holen
			System.Diagnostics.Process[] processes = 
				Process.GetProcessesByName(
				Process.GetCurrentProcess().ProcessName);

			// Alle Prozesse durchgehen und den Dateinamen vergleichen
			for (int i = 0; i < processes.Length; i++)
			{
				// Den aktuellen Prozess ausschlie�en
				if (processes[i].Id != Process.GetCurrentProcess().Id)
				{
					// Den Namen der Exe-Datei vergleichen
					if (processes[i].MainModule.FileName == 
						Process.GetCurrentProcess().MainModule.FileName)
						return processes[i];
				}
			}

			// Kein Prozess gefunden, der dem aktuellen entspricht, also null
			// zur�ckgeben
			return null;
		}
	}
}
