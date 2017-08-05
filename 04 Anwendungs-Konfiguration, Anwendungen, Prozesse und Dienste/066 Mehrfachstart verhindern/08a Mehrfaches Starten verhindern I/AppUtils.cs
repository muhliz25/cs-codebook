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
			System.Diagnostics.Process[] processes = Process.GetProcessesByName(
				Process.GetCurrentProcess().ProcessName);

			// Alle Prozesse durchgehen und den Fenstertitel vergleichen
			string mainWindowTitle = Process.GetCurrentProcess().MainWindowTitle; 
			for (int i = 0; i < processes.Length; i++)
			{
				// Den aktuellen Prozess ausschlie�en
				if (processes[i].Id != Process.GetCurrentProcess().Id)
				{
					if (processes[i].MainWindowTitle == mainWindowTitle)
					{
						// Prozess gefunden, diesen zur�ckgeben 
						return processes[i];
					}
				}
			}

			// Kein Prozess gefunden, der dem aktuellen entspricht, also null 
			// zur�ckgeben
			return null;
		}
	}
}