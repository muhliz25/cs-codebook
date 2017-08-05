using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode, die �berpr�ft, ob ein String mit einer Zahl beginnt 
		 * und die die Zeichenl�nge der Zahl zur�ckgibt */
		public static int NumberAtStart(string source)
		{
			// Match-Instanz erzeugen und �berpr�fen, ob ein Treffer erzielt wurde
			Match match = Regex.Match(source, @"^\d{1,}");
			if (match.Success)
				// Die L�nge des gefundenen Teilstrings zur�ckgeben
				return match.Length;
			else
				return 0;
		}
	}
}
