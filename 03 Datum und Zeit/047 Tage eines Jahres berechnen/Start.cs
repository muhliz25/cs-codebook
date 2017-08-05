using System;
using System.Globalization;

namespace Tage_eines_Jahres
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// GregorianCalendar-Objekt für den aktuellen Kalender erzeugen
			Calendar calendar = CultureInfo.CurrentCulture.Calendar;

			// Anzahl der Tage im aktuellen Jahr berechnen
			DateTime now = DateTime.Now;
			int daysInYear = calendar.GetDaysInYear(now.Year);

			Console.WriteLine("Tage des Jahres {0}: {1}", 
				now.Year, daysInYear);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
