using System;
using System.Threading;
using System.Globalization;

namespace Addison_Wesley.Codebook.Basics
{
	public class NumberUtils
	{
		/* Methoden zur Überprüfung eines Strings auf einen allgemeinen Zahlwert */
		public static bool IsNumber(string value, IFormatProvider provider)
		{
			try
			{
				Double.Parse(value, provider);
				return true;
			}
			catch 
			{
				return false;
			}
		}

		public static bool IsNumber(string value)
		{
			return IsNumber(value, Thread.CurrentThread.CurrentCulture);
		}

		/* Methoden zur Überprüfung eines String auf einen long-Wert */
		public static bool IsLong(string value, IFormatProvider provider)
		{
			try
			{
				Int64.Parse(value, provider);
				return true;
			}
			catch 
			{
				return false;
			}
		}

		public static bool IsLong(string value)
		{
			return IsLong(value, Thread.CurrentThread.CurrentCulture);
		}

		/* Methoden zur Überprüfung eines Strings auf einen double-Wert */
		public static bool IsDouble(string value, IFormatProvider provider)
		{
			double dummy;
			return Double.TryParse(value, NumberStyles.Float, provider, out dummy);
		}

		public static bool IsDouble(string value)
		{
			return IsDouble(value, Thread.CurrentThread.CurrentCulture);
		}


	}
}
