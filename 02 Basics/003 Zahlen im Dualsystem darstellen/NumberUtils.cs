using System;

namespace Addison_Wesley.Codebook.Basics
{
	public class NumberUtils
	{
		/* Methode zur Formatierung einer ulong-Zahl in eine Dualzahl */
		public static string DualNumber(ulong number)
		{
			string result = "";

			// Die Bits 0 bis 63 durchgehen
			for (int i = 0; i < 64; i++)
			{
				// �ber ein bitweises Or ermitteln, ob das Bit gesetzt ist, und das 
				// Ergebnis vorne an die Stringvariable anf�gen
				result = (number & 1).ToString() + result;

				// Die Bits um eine Position nach rechts shiften
				number >>= 1;
			}
   
			return "+" + result;
		}

		/* Methode zur Darstellung einer long-Zahl als Dualzahl */
		public static string DualNumber(long number)
		{
			string result = "";

			// Ermitteln, ob die Zahl negativ ist, und in diesem Fall den Absolutwert
			// berechnen
			bool negative = false; 
			if (number < 0)
			{
				negative = true;
				number *= -1;
			}

			// Die Bits 0 bis 64 durchgehen
			for (int i = 0; i < 64; i++)
			{
				// �ber ein bitweises Or ermitteln, ob das Bit gesetzt ist, und das 
				// Ergebnis vorne an die Stringvariable anf�gen
				result = (number & 1).ToString() + result;

				// Die Bits um eine Position nach rechts shiften
				number >>= 1;
			}
   
			// Negative Zahlen auswerten
			if (negative)
				result = "-" + result;
			else
				result = "+" + result;

			return result;
		}

		/* Methode zur Darstellung einer int-Zahl als Dualzahl */
		public static string DualNumber(int number)
		{
			return number < 0 ? 
				"-" + DualNumber((long)number).Substring(33, 32) :
				"+" + DualNumber((long)number).Substring(33, 32);
		}

		/* Methode zur Darstellung einer uint-Zahl als Dualzahl */
		public static string DualNumber(uint number)
		{
			return "+" + DualNumber((ulong)number).Substring(33, 32);
		}

		/* Methode zur Darstellung einer short-Zahl als Dualzahl */
		public static string DualNumber(short number)
		{
			return number < 0 ? 
				"-" + DualNumber((long)number).Substring(49, 16) :
				"+" + DualNumber((long)number).Substring(49, 16);
		}

		/* Methode zur Darstellung einer ushort-Zahl als Dualzahl */
		public static string DualNumber(ushort number)
		{
			return "+" + DualNumber((ulong)number).Substring(49, 16);
		}

		/* Methode zur Darstellung einer byte-Zahl als Dualzahl */
		public static string DualNumber(byte number)
		{
			return "+" + DualNumber((ulong)number).Substring(57, 8);
		}
	}
}
