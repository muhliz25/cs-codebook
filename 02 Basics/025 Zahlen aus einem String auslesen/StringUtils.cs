using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode zum Auslesen aller Zahlen aus einem String */
		public static long[] ExtractNumbers(string source)
		{
			// Ganzzahlen über einen regulären Ausdruck extrahieren
			MatchCollection matches = Regex.Matches(source, @"\d{1,}");

			// Das Ergebnis in ein long-Array kopieren
			long[] result = new long[matches.Count];
			for (int i = 0; i < matches.Count; i++)
			{
				result[i] = Convert.ToInt64(matches[i].Value);
			}

			return result;
		}
	}
}
