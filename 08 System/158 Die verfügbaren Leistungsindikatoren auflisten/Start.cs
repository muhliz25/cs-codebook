using System;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms;
using Addison_Wesley.Codebook.System;

namespace Performance_Counter_Liste
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Working ...");
			
			// Auslesen der verfügbaren Leistungsindikatoren in die Datei
			// C:\PerformanceCounterDE.txt in deutscher Sprache
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de"); 
			SystemUtils.WritePerformanceCounterNames("C:\\PerformanceCounterDE.txt");

			// Auslesen der verfügbaren Leistungsindikatoren in die Datei
			// C:\PerformanceCounterDE.txt in englischer Sprache
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en"); 
			SystemUtils.WritePerformanceCounterNames("C:\\PerformanceCounterEN.txt");

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
