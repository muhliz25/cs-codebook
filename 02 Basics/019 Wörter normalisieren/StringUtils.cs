using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode f�r den MatchEvaluator-Delegate der Regex-Instanz */
		private static string NormalizeWordMatchEvaluator(Match match)
		{
			int length = match.Value.Length;
			if (length > 1)
				return match.Value.Substring(0, 1).ToUpper() + 
					match.Value.Substring(1, length - 1).ToLower();
			else
				return match.Value.ToUpper();
		}

		/* Methode zur Normalisierung aller W�rter in einem String */
		public static string NormalizeWords(string source)
		{
			// Regex-Objekt mit einem Muster erzeugen, das alle W�rter 
			// im String ermittelt
			Regex re = new Regex(@"\w{1,}");
   
			// Die Fundstellen durch die R�ckgabe der MatchEvaluator-Methode
			// ersetzen
			return re.Replace(source, 
				new MatchEvaluator(NormalizeWordMatchEvaluator));
		}
	}
}

