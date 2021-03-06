using System;
using System.Globalization;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class DateUtil
	{
		/* Methode zur �berpr�fung der G�ltigkeit eines als String angegebenen Datums */
		public static bool IsDate(string dateString) 
		{
			// Versuch, den String in ein Datum zu konvertieren
			try
			{
				System.DateTime.Parse(dateString);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/* Methode zur �berpr�fung der G�ltigkeit eines als String angegebenen Datums 
		 * unter Ber�cksichtigung einer speziellen Kultur */
		public static bool IsDate(string dateString, CultureInfo culture) 
		{
			// Versuch, den String in ein Datum zu konvertieren
			try
			{
				System.DateTime.Parse(dateString, culture);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
