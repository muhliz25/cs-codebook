using System;

namespace Prozesse_auflisten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Alle auf dem lokalen Computer laufenden Prozesse ermitteln
			System.Diagnostics.Process[] processes = 
				System.Diagnostics.Process.GetProcesses();

			// Die Prozesse durchgehen und Informationen dazu anzeigen
			for (int i = 0; i < processes.Length; i++)
			{
				Console.WriteLine("Id: {0}", processes[i].Id);
				Console.WriteLine("Name: {0}", processes[i].ProcessName);
				Console.WriteLine("Startzeit: {0}", processes[i].StartTime.ToString());
				Console.WriteLine("Priorität: {0}", processes[i].BasePriority);
				Console.WriteLine("Hauptfenster-Titel: {0}", processes[i].MainWindowTitle);
				Console.WriteLine("Prozess reagiert: {0}", processes[i].Responding);
				Console.WriteLine("Anzahl Threads: {0}", processes[i].Threads.Count);
				Console.WriteLine("Prozessor-Zeit: {0}", processes[i].TotalProcessorTime);
				Console.WriteLine("Virtuelle Speichergröße: {0}", 
					processes[i].VirtualMemorySize);
			}

			Console.ReadLine();
		}
	}
}
