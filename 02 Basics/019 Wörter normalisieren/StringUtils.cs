using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode für den MatchEvaluator-Delegate der Regex-Instanz */
		private static string NormalizeWordMatchEvaluator(Match match)
		{
			int length = match.Value.Length;
			if (length > 1)
				return match.Value.Substring(0, 1).ToUpper() + 
					match.Value.Substring(1, length - 1).ToLower();
			else
				return match.Value.ToUpper();
		}

		/* Methode zur Normalisierung aller Wörter in einem String */
		public static string NormalizeWords(string source)
		{
			// Regex-Objekt mit einem Muster erzeugen, das alle Wörter 
			// im String ermittelt
			Regex re = new Regex(@"\w{1,}");
   
			// Die Fundstellen durch die Rückgabe der MatchEvaluator-Methode
			// ersetzen
			return re.Replace(source, 
				new MatchEvaluator(NormalizeWordMatchEvaluator));
		}
	}
}

