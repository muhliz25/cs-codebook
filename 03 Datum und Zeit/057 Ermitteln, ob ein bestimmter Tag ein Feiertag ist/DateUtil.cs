using System;
using System.Collections;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class DateUtils
	{
		/* Methode zur Berechnung des Datums des Ostersonntags.
		 * Nach dem Original von Ronald W. Mallen (www.assa.org.au/edm.html) */
		public static DateTime GetEasterSundayDate(int year)
		{
			// Überprüfen, ob das Jahr für die Osterberechnung gültig ist
			if (year < 1583 || year > 4099)
				throw new Exception("Das Jahr muss zwischen 1583 " +
					"und 4099 liegen");

			int firstDigits, remainding19, temp; // Zwischenergebnisse
			int tA, tB, tC, tD, tE; // Tabellenergebnisse A bis E

			firstDigits = year / 100; // die ersten zwei Ziffern
			remainding19 = year % 19; // Rest von year / 19  

			// PFM-Datum berechnen
			temp = (firstDigits - 15) / 2 + 202 - 11 * remainding19;

			switch (firstDigits)
			{
				case 21:
				case 24:
				case 25:
				case 27:
				case 28:
				case 29:
				case 30:
				case 31:
				case 32:
				case 34:
				case 35:
				case 38:
					temp -= 1;
					break;
				case 33:
				case 36:
				case 37:
				case 39:
				case 40:
					temp -= 2;
					break;
			}
  
			temp = temp % 30;

			tA = temp + 21;
			if (temp == 29) 
				tA = tA - 1;
			if (temp == 28 && remainding19 > 10) 
				tA = tA - 1;

			// Nächsten Sonntag ermitteln
			tB = (tA - 19) % 7;

			tC = (40 - firstDigits) % 4;
			if (tC == 3) 
				tC = tC + 1;
			if (tC > 1)
				tC = tC + 1;

			temp = year % 100;
			tD = (temp + temp / 4) % 7;

			tE = ((20 - tB - tC - tD) % 7) + 1;

			// Das Datum ermitteln und zurückgeben
			int day = tA + tE;
			int month = 0;

			if (day > 31)
			{
				day -= 31;
				month = 4;
			}
			else
				month = 3;

			return new DateTime(year, month, day);
		}

		/* Klasse für einen speziellen deutschen Tag */
		public class GermanSpecialDay: IComparable 
		{
			public string Name;
			public DateTime Date;   
			public bool Nationwide;
			public bool Holiday;
   
			/* Konstruktor */
			public GermanSpecialDay(string name, DateTime date,
				bool nationwide, bool holiday)
			{
				this.Name = name;
				this.Date = date;
				this.Nationwide = nationwide;
				this.Holiday = holiday;
			}

			/* Compare-Methode für das Sortieren */
			public int CompareTo(object o)
			{
				GermanSpecialDay gsd = (GermanSpecialDay)o;
				return this.Date.CompareTo(gsd.Date);
			}
		}

		/* Aufzählung für die besonderen Tage */
		public enum GermanSpecialDaysEnum
		{
			Neujahr,
			HeiligeDreiKönige,
			Valentinstag,
			Maifeiertag,
			MariaHimmelfahrt,
			TagDerDeutschenEinheit,
			Reformationstag,
			Allerheiligen,
			HeiligerAbend,
			ErsterWeihnachtstag,
			ZweiterWeihnachtstag,
			Rosenmontag,
			Aschermittwoch,
			Gründonnerstag,
			Karfreitag,
			Ostersonntag,
			Ostermontag,
			ChristiHimmelfahrt,
			Pfingstsonntag,
			Pfingstmontag,
			Fronleichnam,
			ErsterAdvent,
			ZweiterAdvent,
			DritterAdvent,
			VierterAdvent,
			Totensonntag,
			BußUndBettag
		}

		/* Hashtable für die besonderen Tage */
		public class GermanSpecialDays: DictionaryBase
		{
			/* Implementierung der Add-Methode */
			internal void Add(GermanSpecialDaysEnum key, string name,
				DateTime date, bool nationWide, bool holiday)
			{
				base.Dictionary.Add(key, new GermanSpecialDay(name, date, 
					nationWide, holiday));
			}

			/* Implementierung der Values- und der Keys-Eigenschaft */
			public ICollection Values
			{
				get {return base.Dictionary.Values;}
			}

			/* Implementierung der Values- und der Keys-Eigenschaft */
			public ICollection Keys
			{
				get {return base.Dictionary.Values;}
			}

			/* Implementierung des Indizierers */
			public GermanSpecialDay this[GermanSpecialDaysEnum key]
			{
				get {return (GermanSpecialDay)base.Dictionary[key];}
				set {base.Dictionary[key] = value;}
			}
		}
		
		/* Methode zur Berechnung der besonderen Tage in Deutschland */
		public static GermanSpecialDays GetGermanSpecialDays(int year)
		{
			// GermanSpecialDays-Instanz erzeugen
			GermanSpecialDays gsd = new GermanSpecialDays();

			// Die festen besonderen Tage eintragen
			gsd.Add(GermanSpecialDaysEnum.Neujahr, "Neujahr",
				new DateTime(year, 1, 1), true, true);
			gsd.Add(GermanSpecialDaysEnum.HeiligeDreiKönige, "Heilige Drei Könige",
				new DateTime(year, 1, 6), false, true);
			gsd.Add(GermanSpecialDaysEnum.Valentinstag, "Valentinstag",
				new DateTime(year, 2, 14), true, false);
			gsd.Add(GermanSpecialDaysEnum.Maifeiertag, "Maifeiertag",
				new DateTime(year, 5, 1), true, true);
			gsd.Add(GermanSpecialDaysEnum.MariaHimmelfahrt, "Maria Himmelfahrt", 
				new DateTime(year, 8, 15), false, true);
			gsd.Add(GermanSpecialDaysEnum.TagDerDeutschenEinheit,
				"Tag der Deutschen Einheit", new DateTime(year, 10, 3), true, true);
			gsd.Add(GermanSpecialDaysEnum.Reformationstag, "Reformationstag", 
				new DateTime(year, 10, 31), false, true);
			gsd.Add(GermanSpecialDaysEnum.Allerheiligen, "Allerheiligen", 
				new DateTime(year, 11, 1), false, true);
			gsd.Add(GermanSpecialDaysEnum.HeiligerAbend, "Heiliger Abend", 
				new DateTime(year, 12, 24), true, true);
			gsd.Add(GermanSpecialDaysEnum.ErsterWeihnachtstag, "Erster Weihnachtstag",
				new DateTime(year, 12, 25), true, true);
			gsd.Add(GermanSpecialDaysEnum.ZweiterWeihnachtstag,
				"Zweiter Weihnachtstag", new DateTime(year, 12, 26), true, true);

			// Datum des Ostersonntag berechnen
			DateTime easterSunday = GetEasterSundayDate(year);

			// Die beweglichen besonderen Tage ermitteln, die sich auf Ostern beziehen
			gsd.Add(GermanSpecialDaysEnum.Rosenmontag, "Rosenmontag",
				easterSunday.AddDays(-48), true, false);
			gsd.Add(GermanSpecialDaysEnum.Aschermittwoch, "Aschermittwoch",
				easterSunday.AddDays(-46), true, false);
			gsd.Add(GermanSpecialDaysEnum.Gründonnerstag, "Gründonnerstag",
				easterSunday.AddDays(-3), true, false);
			gsd.Add(GermanSpecialDaysEnum.Karfreitag, "Karfreitag",
				easterSunday.AddDays(-2), true, true);
			gsd.Add(GermanSpecialDaysEnum.Ostermontag, "Ostermontag",
				easterSunday.AddDays(1), true, true);
			gsd.Add(GermanSpecialDaysEnum.Ostersonntag, "Ostersonntag",
				easterSunday, true, true);
			gsd.Add(GermanSpecialDaysEnum.ChristiHimmelfahrt, "Christi Himmelfahrt",
				easterSunday.AddDays(39), true, true);
			gsd.Add(GermanSpecialDaysEnum.Pfingstsonntag, "Pfingstsonntag",
				easterSunday.AddDays(49), true, true);
			gsd.Add(GermanSpecialDaysEnum.Pfingstmontag, "Pfingstmontag",
				easterSunday.AddDays(50), true, true);
			gsd.Add(GermanSpecialDaysEnum.Fronleichnam, "Fronleichnam",
				easterSunday.AddDays(60), false, true);

			// Die beweglichen besonderen Tage ermitteln, die sich auf Weihnachten
			// beziehen
			// Sonntag vor dem 25. Dezember (4. Advent) ermitteln
			DateTime firstXMasDay = new DateTime(year, 12, 25);
			DateTime fourthAdvent;
			int weekday = (int)firstXMasDay.DayOfWeek;
			if (weekday == 0)
				// Sonntag
				fourthAdvent = firstXMasDay.AddDays(-7);
			else
				fourthAdvent = firstXMasDay.AddDays(-weekday);
			gsd.Add(GermanSpecialDaysEnum.VierterAdvent, "Vierter Advent",
				fourthAdvent, true, false);
			gsd.Add(GermanSpecialDaysEnum.DritterAdvent, "Dritter Advent",
				fourthAdvent.AddDays(-7), true, false);
			gsd.Add(GermanSpecialDaysEnum.ZweiterAdvent, "Zweiter Advent",
				fourthAdvent.AddDays(-14), true, false);
			gsd.Add(GermanSpecialDaysEnum.ErsterAdvent, "Erster Advent",
				fourthAdvent.AddDays(-21), true, false);
   
			// Totensonntag ermitteln
			DateTime deadSunday = fourthAdvent.AddDays(-28);
			gsd.Add(GermanSpecialDaysEnum.Totensonntag, "Totensonntag",
				deadSunday, true, false);

			// Den Mittwoch vor dem Totensonntag ermitteln
			weekday = (int)deadSunday.DayOfWeek;
			if (weekday < 4)
				// Sonntag bis Mittwoch
				gsd.Add(GermanSpecialDaysEnum.BußUndBettag, "Buß- und Bettag",
					deadSunday.AddDays(-(weekday + 4)), false, true);
			else 
				// Donnerstag bis Samstag
				gsd.Add(GermanSpecialDaysEnum.BußUndBettag, "Buß- und Bettag",
					deadSunday.AddDays(-(weekday - 3)), false, true);

			// Das Ergebnis zurückgeben
			return gsd;
		}

		/* Methode zur Ermittlung, ob ein bestimmter Tag ein Feiertag ist */
		/* Methode zur Ermittlung, ob ein bestimmter Tag ein Feiertag ist */
		public static bool IsGermanHoliday(DateTime date, out string name,
			out bool nationWide)
		{
			// out-Argumente initialisieren
			name = null;
			nationWide = false;

			// Auflistung der besonderen Tage des angegebenen Jahres erzeugen, 
			// durchgehen und das Datum der Feiertage mit dem angegebenen Datum
			// vergleichen
			foreach (GermanSpecialDay gsd in
				GetGermanSpecialDays(date.Year).Values)
			{
				if (date.Day == gsd.Date.Day && 
					date.Month == gsd.Date.Month)
				{
					// Datum gefunden
					if (gsd.Holiday)
					{
						// Es ist ein Feiertag: Infos definieren und true zurückgeben 
						name = gsd.Name;
						nationWide = gsd.Nationwide;
						return true;
					}
					else
						// Kein Feiertag
						return false;
				}
			}

			// Tag wurde nicht gefunden
			return false;
		}
	}
}
