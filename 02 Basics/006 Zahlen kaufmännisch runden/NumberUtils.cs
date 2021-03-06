using System;

namespace Addison_Wesley.Codebook.Basics
{
	public class NumberUtils
	{
		/* Methode zum kaufm�nnischen Runden einer double-Zahl */
		public static double RoundCommercial(double number, int decimals)
		{
			// Faktor f�r die Kommaverschiebung berechnen
			double decimalFactor = (double)Math.Pow(10, decimals);

			// Zahl runden
			return Math.Floor((number * decimalFactor + 
				(0.5F * Math.Sign(number)))) / decimalFactor;
		}

		/* Methode zum kaufm�nnischen Runden einer decimal-Zahl */
		public static decimal RoundCommercial(decimal number, int decimals)
		{
			// Faktor f�r die Kommaverschiebung berechnen
			decimal decimalFactor = (decimal)Math.Pow(10, decimals);

			// Zahl runden
			return Decimal.Truncate((number * decimalFactor + 
				(0.5M * Math.Sign(number)))) / decimalFactor;
		}
	}
}
