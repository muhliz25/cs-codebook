using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Addison_Wesley.Codebook.Security
{
	/* Aufz�hlung f�r die unterst�tzten Algorithmen */
	public enum HashAlgorithmEnum
	{
		SHA160,
		SHA256,
		SHA384,
		SHA512,
		MD5,
		HMACSHA1,
		MACTripleDES
	}

	/* Klasse f�r verschiedene Hash-Algorithmen */
	public class Hasher
	{
		/* Eigenschaft zur Speicherung des Hash-Objekts */
		private HashAlgorithm hashObject;

		/* Konstruktor */
		public Hasher(HashAlgorithmEnum algorithm)
		{
			switch (algorithm)
			{
				case HashAlgorithmEnum.SHA160:
					this.hashObject = new SHA1Managed();
					break;
				case HashAlgorithmEnum.SHA256:
					this.hashObject = new SHA256Managed();
					break;
				case HashAlgorithmEnum.SHA384:
					this.hashObject = new SHA384Managed();
					break;
				case HashAlgorithmEnum.SHA512:
					this.hashObject = new SHA512Managed();
					break;
				case HashAlgorithmEnum.MD5:
					this.hashObject = new MD5CryptoServiceProvider();
					break;
				case HashAlgorithmEnum.HMACSHA1:
					this.hashObject = new HMACSHA1();
					break;
				case HashAlgorithmEnum.MACTripleDES:
					this.hashObject = new MACTripleDES();
					break;
			}
		}

		/* Eigenschaft f�r den Schl�ssel der Algorithmen, die einen solchen
		 * verwenden */
		public string Key
		{
			get
			{
				// �berpr�fen, ob der Algorithmus einen Schl�ssel erlaubt,
				// und Speichern des Schl�ssel
				KeyedHashAlgorithm kha = this.hashObject as KeyedHashAlgorithm;
				if (kha != null)
					// Schl�ssel in einen String umwandeln und zur�ckgeben
					return Encoding.GetEncoding("ISO-8859-1").GetString(kha.Key);
				else
					throw new NotSupportedException("Der aktuell verwendete " +
						"Hash-Algorithmus unterst�tzt keine Schl�ssel");
			}

			set
			{
				// Auf Unicode-Zeichen gr��er 0x00FF �berpr�fen
				for (int i = 0; i < value.Length; i++)
				{
					if ((int)value[i] > 255)
						throw new CryptographicException("Der �bergebene " +
							"Schl�ssel enth�lt mindestens ein Unicode-Zeichen, " +
							"das gr��er ist als 0x00FF (255): " + value[i] + " (" + 
							(int)value[i] + "). Unterst�tzt werden lediglich " +
							"8-Bit-Unicode-Zeichen");
				}

				// �berpr�fen, ob der Algorithmus einen Schl�ssel erlaubt,
				// und Speichern des Schl�ssel
				KeyedHashAlgorithm kha = this.hashObject as KeyedHashAlgorithm;
				if (kha != null)
					// Schl�ssel in einen String umwandeln und zur�ckgeben
					kha.Key = Encoding.GetEncoding("ISO-8859-1").GetBytes(value);
				else
					throw new NotSupportedException("Der aktuell verwendete " +
						"Hash-Algorithmus unterst�tzt keine Schl�ssel");
			}
		}

		/* Methoden zum Erzeugen eines Hash aus einem Byte-Array */
		public string ComputeHash(byte[] data)
		{
			return Encoding.GetEncoding("ISO-8859-1").GetString(
				this.hashObject.ComputeHash(data));
		}

		public string ComputeHash(byte[] data, int offset, int count)
		{
			return Encoding.GetEncoding("ISO-8859-1").GetString(
				this.hashObject.ComputeHash(data, offset, count));
		}

		/* Methode zum Erzeugen eines Hash aus einem Stream */
		public string ComputeHash(Stream inputStream)
		{
			return Encoding.GetEncoding("ISO-8859-1").GetString(
				this.hashObject.ComputeHash(inputStream));
		}

		/* Methode zum Erzeugen eines Hash aus einem String */
		public string ComputeHash(string inputString)
		{
			// Byte-Array aus dem String erzeugen und damit den Hashcode erzeugen
			byte[] buffer = Encoding.Unicode.GetBytes(inputString);
			return Encoding.GetEncoding("ISO-8859-1").GetString(
				this.hashObject.ComputeHash(buffer));
		}
	}
}
