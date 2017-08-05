using System;
using Microsoft.VisualBasic;

namespace Datumsdifferenz
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			
			// Zwei DateTime-Objekte erzeugen
			// DateTime birthDate = new DateTime(2000, 1, 2);
			DateTime birthDate =  new DateTime(2002, 12, 31);
			// DateTime now = DateTime.Now;
			DateTime now = new DateTime(2003, 1, 7);


			// Berechnen der Differenz
			long weeks = DateAndTime.DateDiff(DateInterval.Weekday, birthDate,
				now, FirstDayOfWeek.System, FirstWeekOfYear.System);
			long months = DateAndTime.DateDiff(DateInterval.Month, birthDate,
				now, FirstDayOfWeek.System, FirstWeekOfYear.System);
			long quarters = DateAndTime.DateDiff(DateInterval.Quarter,
				birthDate, now, FirstDayOfWeek.System, FirstWeekOfYear.System);
			long years = DateAndTime.DateDiff(DateInterval.Year, birthDate, now,
				FirstDayOfWeek.System, FirstWeekOfYear.System);

			// Ausgeben der berechneten Werte
			Console.WriteLine("Differenz zwischen dem {0}\r\nund dem {1}:",
				birthDate.ToString(), now.ToString());
			Console.WriteLine("Wochen: {0}", weeks);
			Console.WriteLine("Monate: {0}", months);
			Console.WriteLine("Quartale: {0}", quarters);
			Console.WriteLine("Jahre: {0}", years);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
