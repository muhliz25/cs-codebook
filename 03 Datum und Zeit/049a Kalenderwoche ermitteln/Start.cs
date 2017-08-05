using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Kalenderwoche
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Aktuelles Datum ermitteln
			DateTime now = DateTime.Now;

			// Kalenderwoche ermitteln
			DateUtils.CalendarWeek calendarWeek = DateUtils.GetCalendarWeek2(now);

			Console.WriteLine("Aktuelle Kalenderwoche: {0}/{1}", 
				calendarWeek.Week, calendarWeek.Year);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}

