using System;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode zum Extrahieren eines linken Teilstrings */
		public static string Left(string source, int count)
		{
			if (source.Length >= count)
				return source.Substring(0, count);
			else
				return source;
		}

		/* Methode zum Extrahieren eines rechten Teilstrings */
		public static string Right(string source, int count)
		{
			int length = source.Length;
			if (length >= count)
				return source.Substring(length - count, count);
			else
				return source;
		}
	}
}
