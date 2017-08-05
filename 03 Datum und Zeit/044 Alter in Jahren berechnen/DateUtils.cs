using System;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class DateUtils
	{
		/* Methode zur Berechnung des Alters einer Person oder eines
		 * Gegenstands in Jahren */
		public static int GetAge(System.DateTime lowerDate, 
			System.DateTime higherDate)
		{
			// Basis-Alter als Differenz zwischen den Jahren ermitteln
			int age = higherDate.Year - lowerDate.Year;

			// Wenn der Monat des größeren Datums kleiner oder wenn der Monat gleich
			// und der Tag kleiner ist, muss ein Jahr abgezogen werden
			if ((higherDate.Month < lowerDate.Month) ||
				(higherDate.Month == lowerDate.Month &&  
				higherDate.Day < lowerDate.Day))   
				age--;

			return age;
		}
	}
}
