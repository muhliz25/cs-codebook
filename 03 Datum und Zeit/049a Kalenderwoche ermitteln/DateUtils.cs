using System;
using System.Globalization;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class DateUtils
	{
		/* Klasse f�r die R�ckgabe der Kalenderwoche */
		public class CalendarWeek
		{
			public int Year;
			public int Week;
			public CalendarWeek(int year,int week)
			{
				this.Year = year;
				this.Week = week;
			}
		}

		/* Methode zur Ermittlung der Kalenderwoche eines Datums nach der
		 * GetWeekOfYear-Methode eines Calendar-Objekts */
		public static CalendarWeek GetCalendarWeek1(DateTime date)
		{
			// Aktuelle Kultur ermitteln
			CultureInfo currentCulture = CultureInfo.CurrentCulture;

			// Aktuellen Kalender ermitteln
			Calendar calendar = currentCulture.Calendar;

			// Kalenderwoche �ber das Calendar-Objekt ermitteln
			int calendarWeek = calendar.GetWeekOfYear(date, 
				currentCulture.DateTimeFormat.CalendarWeekRule,
				currentCulture.DateTimeFormat.FirstDayOfWeek);

			// �berpr�fen, ob eine Kalenderwoche gr��er als 52 ermittelt wurde und ob
			// die Kalenderwoche des Datums in einer Woche 2 ergibt: In diesem Fall hat
			// GetWeekOfYear die Kalenderwoche nicht nach ISO 8601 berechnet (Montag,
			// der 30.12.2003 wird z. B. f�lschlicherweise als KW 53 berechnet). 
			// Die Kalenderwoche wird dann auf 1 gesetzt
			if (calendarWeek > 52)
			{
				date = date.AddDays(7);
				int testCalendarWeek = calendar.GetWeekOfYear(date, 
					currentCulture.DateTimeFormat.CalendarWeekRule,
					currentCulture.DateTimeFormat.FirstDayOfWeek);
				if (testCalendarWeek == 2)
					calendarWeek = 1;
			}

			// Das Jahr der Kalenderwoche ermitteln
			int year = date.Year;
			if (calendarWeek == 1 && date.Month == 12)
				year++;
			if (calendarWeek >= 52 && date.Month == 1)
				year--;

			// Die ermittelte Kalenderwoche zur�ckgeben
			return new CalendarWeek(year, calendarWeek);
		}

		/* Methode zur Berechnung der Kalenderwoche nach dem C++-Algorithmus von 
		 * Ekkehard Hess aus einem Beitrag vom 29.7.1999 in der Newsgroup 
		 * borland.public.cppbuilder.language (freigegeben zur allgemeinen 
		 * Verwendung) */
		public static CalendarWeek GetCalendarWeek2(DateTime date)
		{
			double a = Math.Floor((14 - (date.Month)) / 12);
			double y = date.Year + 4800 - a;
			double m = (date.Month) + (12 * a) - 3;
      
			double jd = date.Day + Math.Floor(((153 * m) + 2) / 5) +
				(365 * y) + Math.Floor(y / 4) - Math.Floor(y / 100) +
				Math.Floor(y / 400) - 32045;
         
			double d4 = (jd + 31741 - (jd % 7)) % 146097 % 36524 %
				1461;
			double L = Math.Floor(d4 / 1460);
			double d1 = ((d4 - L) % 365) + L;

			// Kalenderwoche ermitteln
			int calendarWeek = (int) Math.Floor(d1 / 7) + 1;

			// Das Jahr der Kalenderwoche ermitteln
			int year = date.Year;
			if (calendarWeek == 1 && date.Month == 12)
				year++;
			if (calendarWeek >= 52 && date.Month == 1)
				year--;

			// Die ermittelte Kalenderwoche zur�ckgeben
			return new CalendarWeek(year, calendarWeek);
		}
	}
}
