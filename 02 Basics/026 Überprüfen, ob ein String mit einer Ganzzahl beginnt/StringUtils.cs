using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode, die überprüft, ob ein String mit einer Zahl beginnt 
		 * und die die Zeichenlänge der Zahl zurückgibt */
		public static int NumberAtStart(string source)
		{
			// Match-Instanz erzeugen und überprüfen, ob ein Treffer erzielt wurde
			Match match = Regex.Match(source, @"^\d{1,}");
			if (match.Success)
				// Die Länge des gefundenen Teilstrings zurückgeben
				return match.Length;
			else
				return 0;
		}
	}
}
