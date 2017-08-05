using System;
using System.Diagnostics;

namespace Programme_auflisten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Alle laufenden Prozesse ermitteln
			Process[] processes = Process.GetProcesses();

			// Die Prozesse durchgehen und die Prozesse mit einem Haupt-Fenster ermitteln
			for (int i = 0; i < processes.Length; i++)
			{
				if ((int)processes[i].MainWindowHandle != 0)
				{
					// Hauptfenster ist vorhanden, der Prozess ist also eine Anwendung:
					// Prozessname und Titel des Hauptfensters auslesen
					Console.WriteLine("Prozessname: {0}\r\nFenstertitel: {1}\r\n", 
						processes[i].ProcessName, processes[i].MainWindowTitle); 
				}
			}

			Console.ReadLine();
		}
	}
}
