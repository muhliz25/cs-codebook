using System;
using System.Threading;
using System.Globalization;

namespace Kultur_umstellen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// CultureInfo-Objekt für die US-englische Kultur erzeugen
			// und dem aktuellen Thread zuweisen
			Thread.CurrentThread.CurrentCulture = 
				CultureInfo.CreateSpecificCulture("en-US");

			// Als Beispiel einige Zahlen und Datumswerte formatiert ausgeben
			double number = 1234.5678; 
			Console.WriteLine("{0:#,#0.00}", number);

			DateTime now = DateTime.Now;
			Console.WriteLine(now.ToString());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
