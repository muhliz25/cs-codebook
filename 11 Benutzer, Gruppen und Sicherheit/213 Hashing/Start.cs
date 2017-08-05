using System;
using System.Text;
using System.Security.Cryptography;
using Addison_Wesley.Codebook.Security;

namespace Hashing
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Hashcode direkt �ber CryptoConfig.CreateFromName erzeugen */
			string source = "Das ist ein Teststring zur Ermittlung eines Hashcodes";
			byte[] buffer = Encoding.Unicode.GetBytes(source);
			string hashCode = Encoding.Unicode.GetString(
				HashAlgorithm.Create("SHA1").ComputeHash(buffer));

			Console.WriteLine("Quellstring: {0}", source);
			Console.WriteLine("Hashcode: {0}", hashCode);
			Console.WriteLine();
			
			/* Hashcode �ber die eigene Klasse erzeugen */
			Hasher hasher = null;
			try
			{
				// Hasher erzeugen und Schl�ssel �bergeben
				hasher = new Hasher(HashAlgorithmEnum.HMACSHA1);
				hasher.Key = "l�ke08325ybnk y973235298�46t �9872598";
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Beenden mit Return");
				Console.ReadLine();
				return;
			}

			// Den Hashcode f�r einen String ermitteln
			source = "Das ist ein Teststring zur Ermittlung eines Hashcodes";
			hashCode = hasher.ComputeHash(source);
			Console.WriteLine("Quellstring: {0}", source);
			Console.WriteLine("Hashcode: {0}", hashCode);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
