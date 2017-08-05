using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode zum Ersetzen eines Teilstrings am Anfang eines Strings */
		public static string ReplaceLeadingString(string source, string find,
			string replacement, bool ignoreCase)
		{
			// Muster für die Suche zusammenstellen, dabei den Sonderzeichen im 
			// Suchstring einen Backslash voranstellen
			string pattern = "^" + Regex.Escape(find);

			// Muster ersetzen
			if (ignoreCase)
				return Regex.Replace(source, pattern, replacement,
					RegexOptions.IgnoreCase);
			else
				return Regex.Replace(source, pattern, replacement);
		}
	}
}
