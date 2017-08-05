using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Anzahl_Kalenderwochen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Die Anzahl der Kalenderwochen der Jahre 1999 bis 2009 berechnen
			for (int year = 1999; year < 2010; year++)
			{
				int weekCount = DateUtils.GetCalendarWeekCount(year);
				Console.WriteLine("Kalenderwochen in {0}: {1}", year, weekCount);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
