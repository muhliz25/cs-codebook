using System;
using System.Diagnostics;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zur Überprüfung, ob eine Anwendung ausgeführt wird */
		public static bool ApplicationRunning(string name, string title)
		{
			// Ermitteln der Prozesse, die den übergebenen Namen tragen
			Process[] processes = Process.GetProcessesByName(name);

			// Überprüfen, ob einer der eventuell gefundenen Prozesse im Titel 
			// des Hauptfensters den übergebenen Titel-String besitzt
			foreach (Process p in processes)
			{
				if (p.MainWindowTitle.ToLower().IndexOf(title.ToLower()) > 0)
					return true;
			}

			// Wenn die Methode hier ankommt, wurde kein Prozess gefunden
			return false;
		}
	}
}
