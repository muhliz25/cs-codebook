using System;
using System.Security.Cryptography;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Methode zur Generierung eines Zufalls-String */ 
		public static string RandomString(int count)
		{
			string randomString = "";

			// Echte Zufallszahlen im Bereich von 1 bis 255 erzeugen
			RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
			byte[] numbers = new byte[count];
			rngCSP.GetNonZeroBytes(numbers);

			// Die Zahlen so umrechnen, dass Werte zwischen 97 und 122 herauskommen
			// und die daraus resultierenden Zeichen an den Ergebnisstring
			// anhängen
			for (int i = 0; i < count; i++)
			{
				numbers[i] = (byte)(numbers[i] / 9.81 + 97);
				randomString += (char)numbers[i];
			}
			
			return randomString;
		}
	}
}
