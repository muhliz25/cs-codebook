using System;
using System.Diagnostics;

namespace Prozess_RAM
{
	class Start
	{
		/* Main-Methode */
		[STAThread]
		static void Main(string[] args)
		{
			// PerformanceCounter-Instanzen für die zu überwachenden
			// Leistungsindikatoren der Kategorie 'Prozess' erzeugen
			PerformanceCounter pc1 = new PerformanceCounter("Process", 
				"% Processor Time");
			PerformanceCounter pc2 = new PerformanceCounter("Process", "Working Set");
			PerformanceCounter pc3 = new PerformanceCounter("Process", "Thread Count");

			// Instanzname auf den Namen des aktuellen Prozesses festlegen
			pc1.InstanceName = Process.GetCurrentProcess().ProcessName;
			pc2.InstanceName = Process.GetCurrentProcess().ProcessName;
			pc3.InstanceName = Process.GetCurrentProcess().ProcessName;

			// Die jeweils nächsten Werte auslesen und ausgeben
			Console.WriteLine("Prozessorzeit: {0:0} %", pc1.NextValue());
			Console.WriteLine("Speicherauslastung: {0:0} KB", pc2.NextValue() / 1024);
			Console.WriteLine("Threadanzahl: {0:0}", pc3.NextValue());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}
	}
}
