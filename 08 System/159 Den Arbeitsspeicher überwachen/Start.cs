using System;
using System.Threading;
using System.Diagnostics;

namespace RAM_Auslastung
{
	class Start
	{
		/* Thread-Methode f�r die �berwachung des Arbeitsspeichers */
		public static void GetRAMUsage()
		{
			// PerformanceCounter-Instanz f�r den Leistungsindikator 
			// 'Verf�gbare Bytes' der Kategorie 'Speicher' erzeugen (in englischer
			// Sprache um das Programm auch auf Systemen ausf�hren zu k�nnen, die eine
			// andere Sprache als Deutsch verwenden)
			PerformanceCounter pc = new PerformanceCounter("Memory", 
				"Available Bytes");
			do
			{
				// den n�chsten Wert auslesen und ausgeben
				float byteCount = pc.NextValue();
				Console.WriteLine("{0:0} Bytes verf�gbar", byteCount);

				// Alarmmeldung ausgeben, wenn der Minimalwert unterschritten wird
				if (byteCount < 1048576)
				{
					Console.WriteLine("ALARM: Der verf�gbare Speicher " +
						"ist unter 1 MB gesunken");
				}

				// Thread eine Sekunde anhalten
				Thread.Sleep(1000);

			} while (true);
		}

		/* Main-Methode */
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Beenden mit Return");

			// Thread starten
			Thread ramUsageThread = new Thread(new ThreadStart(GetRAMUsage));
			ramUsageThread.IsBackground = true;
			ramUsageThread.Start();

			// Auf Return warten
			Console.ReadLine();
   
			// Thread beenden
			ramUsageThread.Abort();
		}
	}
}
