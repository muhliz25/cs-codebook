using System;
using System.IO;
using System.Diagnostics;
using Addison_Wesley.Codebook.System;

namespace Prozess_Performance_Tracing
{
	class Start
	{
		// Eigenschaft für den Performance-Tracer 
		private static PerformanceTracer performanceTracer;
      
		/* Methode, die eine hohe CPU-Auslastung erzeugt */
		public static void Stress()
		{
			// Protokollieren des Eintritts in die Methode
			performanceTracer.TraceRamUsage("Eintritt in Stress");

			// Prozessor- und speicherintensive Schleife
			for (int i = 0; i < 100000; i++)
			{
				// DateTime-Objekt zur Simulation von Speicherauslastung erzeugen
				DateTime d = new DateTime(0);

				Console.Write("{0} ", i);
			}

			// Protokollieren des Austritts aus der Methode
			performanceTracer.TraceRamUsage("Austritt in Stress");
		}
      
		[STAThread]
		static void Main(string[] args)
		{
			// Protokolldatei löschen, falls diese vorhanden ist
			string logfileName = "c:\\trace.log";
			if (File.Exists(logfileName))
				File.Delete(logfileName);
         
			// Trace-Listener zum Schreiben in eine Datei erzeugen und 
			// an die Listeners-Auflistung der Trace-Klasse anfügen
			Trace.Listeners.Clear();
			Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(
				logfileName));
         
			// PerformanceTracer-Instanz erzeugen
			performanceTracer = new PerformanceTracer();

			// CPU-Auslastungs-Thread mit einem 100ms-Intervall starten
			performanceTracer.StartCPUUsageTraceThread(100);

			// Speicher- und prozessorintensive Methode aufrufen
			Stress();

			// CPU-Auslastungs-Thread stoppen
			performanceTracer.StopCPUUsageTraceThread();

			// Trace-Listener schließen
			Trace.Listeners[0].Close();
		}
	}
}
