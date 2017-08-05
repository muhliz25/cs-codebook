using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode zum Extrahieren aller W�rter aus einem String */
		public static string[] GetWords(string source)
		{
			// Alle W�rter abfragen
			MatchCollection matches = Regex.Matches(source, @"\w{1,}");

			// Die MatchCollection in ein String-Array kopieren und zur�ckgeben
			string[] words = new string[matches.Count];
			for (int i = 0; i < matches.Count; i++)
				words[i] = matches[i].Value;
			return words;
		}
	}
}
