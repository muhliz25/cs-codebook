using System;
using System.Globalization;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class DateUtils
	{
		// Methode zum Normalisieren eines Datums
		public static System.DateTime NormalizeDate(string dateString)
		{
			// Whitespaces entfernen
			dateString = dateString.Trim();

			// Versuch, das Datum direkt zu konvertieren
			try
			{
				return System.DateTime.Parse(dateString);
			}
			catch {}

			// Das aktuelle Datumstrennzeichen ermitteln
			string dateSeparator = 
				CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

			if (dateString.IndexOf(dateSeparator) == -1)
			{
				// Wenn kein Punkt vorkommt: Versuch ein Datum im Format
				// ddmmyy[yy], ddmm oder d[d] zu erkennen
				if (dateString.Length >= 6 && dateString.Length <= 8)
				{
					// ddmmyy, ddmmyyy oder ddmmyyyy
					dateString = dateString.Substring(0, 2) + "." +
						dateString.Substring(2, 2) + "." + 
						dateString.Substring(4, dateString.Length - 4);
				}
				else if (dateString.Length == 4)
				{
					// ddmm
					dateString = dateString.Substring(0, 2) + "." +
						dateString.Substring(2, 2) + "." + System.DateTime.Now.Year;
				}
				else if (dateString.Length <= 2)
				{
					// d oder dd
					if (dateString.Length == 1) 
						dateString = "0" + dateString;
					dateString = dateString.Substring(0, 2) + "." +
						System.DateTime.Now.Month + "." + System.DateTime.Now.Year;
				}
			}
			else
			{
				// Eingabe des Datums mit Punkten in der Form dd.mm oder 
				// dd. Zunächst einen eventuellen rechten Punkt entfernen
				while (dateString.EndsWith(dateSeparator))
					dateString = dateString.Substring(0, dateString.Length - 1);
         
				// Ein im Format dd oder dd.mm angegebenes Datum um den
				// aktuellen Monat und das aktuelle Jahr ergänzen
				if (dateString.Length <= 2)
				{
					// dd.
					dateString = dateString + "." + System.DateTime.Now.Month + "." + 
						System.DateTime.Now.Year;
				}
				else
				{
					// dd.mm[.]
					dateString = dateString + "." + System.DateTime.Now.Year;
				}
			}

			// Versuch, das ermittelte deutsche Datum zu konvertieren
			return System.DateTime.Parse(dateString,
				CultureInfo.CreateSpecificCulture("de"));
		}
	}
}
