using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Addison_Wesley.Codebook.Security
{
	/* Aufz�hlung f�r die unterst�tzten symmetrischen Verschl�sselungen */
	public enum SymmetricEncryptAlgorithm
	{
		DES,
		TrippleDES,
		RC2,
		Rijndael
	} 
	
	/* Klasse zum Ver- und Entschl�seln von Daten */
	public class SymmetricEncryptor
	{
		/* Eigenschaften zur Speicherung der Verschl�sselungs-Instanz
		 * und des gew�hlten Algorithmus */
		private SymmetricAlgorithm encryptor;
		private string algorithmName;

		/* Konstruktor */
		public SymmetricEncryptor(SymmetricEncryptAlgorithm algorithm)
		{
			switch (algorithm)
			{
				case SymmetricEncryptAlgorithm.DES:
					this.encryptor = new DESCryptoServiceProvider();
					this.algorithmName = "DES";
					break;
				case SymmetricEncryptAlgorithm.TrippleDES:
					this.encryptor = new TripleDESCryptoServiceProvider();
					this.algorithmName = "TripleDES";
					break;
				case SymmetricEncryptAlgorithm.RC2:
					this.encryptor = new RC2CryptoServiceProvider();
					this.algorithmName = "RC2";
					break;
				case SymmetricEncryptAlgorithm.Rijndael:
					this.encryptor = new RijndaelManaged();
					this.algorithmName = "Rijndael";
					break;
			}
		}

		/* Eigenschaft f�r den Chiffrier-Modus */
		public CipherMode CipherMode
		{
			get {return this.encryptor.Mode;}
			set {this.encryptor.Mode = value;}
		}

		/* Eigenschaft f�r die Blockgr��e */
		public int BlockSize
		{
			get {return this.encryptor.BlockSize;}
			set {this.encryptor.BlockSize = value;}
		}

		/* Eigenschaft f�r das Padding */
		public PaddingMode PaddingMode
		{
			get {return this.encryptor.Padding;}
			set {this.encryptor.Padding = value;}
		}

		/* Eigenschaft f�r den Schl�ssel */
		public string Key
		{
			get 
			{
				return Encoding.GetEncoding("ISO-8859-1").GetString(
					this.encryptor.Key);
			}

			set
			{
				// Den �bergebenen Schl�ssel �berpr�fen
				if (this.encryptor.ValidKeySize(value.Length * 8) == false) 
				{
					// Ung�ltiger Schl�ssel: Ausnahme mit erweiterten Informationen
					// werfen
					string allowedKeySizes = null;
					for (int i = 0; i < this.encryptor.LegalKeySizes.Length; i++)
					{
						if (allowedKeySizes != null) allowedKeySizes += ", ";
						allowedKeySizes += this.encryptor.LegalKeySizes[i].MinSize +
							", " + this.encryptor.LegalKeySizes[i].MaxSize;
					}
					throw new CryptographicException("Der �bergebene Schl�ssel " +
						"ist mit " + (value.Length * 8) + " Bit f�r den " + 
						this.algorithmName + "-Algorithmus ung�ltig. Erlaubt " +
						"sind die folgenden Gr��en: " + allowedKeySizes + ".");
				}

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

				// Den Schl�ssel setzen
				this.encryptor.Key = Encoding.GetEncoding(
					"ISO-8859-1").GetBytes(value);
			}
		}

		/* Eigenschaft f�r den Initialisierungsvektor */
		public string IV
		{
			get 
			{
				return Encoding.GetEncoding("ISO-8859-1").GetString(
					this.encryptor.IV);
			}
			set
			{
				// Den �bergebenen Initialisierungsvektor �berpr�fen
				if ((value.Length * 8) != this.encryptor.BlockSize) 
				{
					// Ung�ltiger Initialisierungsvektor: Ausnahme mit erweiterten
					// Informationen werfen
					throw new CryptographicException("Der �bergebene " +
						"Initialisierungsvektor ist mit " + (value.Length * 8) + 
						" Bit f�r den " + this.algorithmName + "-Algorithmus " +
						"ung�ltig. Die L�nge des Initialisierungsvektors muss " +
						"der Blockgr��e (aktuell " + this.encryptor.BlockSize + 
						") entsprechen");
				}

				// Auf Unicode-Zeichen gr��er 0x00FF �berpr�fen
				for (int i = 0; i < value.Length; i++)
				{
					if ((int)value[i] > 255)
						throw new CryptographicException("Der �bergebene " +
							"Initialisierungsvektor enth�lt mindestens ein " +
							"Unicode-Zeichen, das gr��er ist als 0x00FF (255): " + 
							value[i] + " (" + (int)value[i] + "). Unterst�tzt " +
							"werden lediglich 8-Bit-Unicode-Zeichen");
				}

				// Den Initialisierungsvektor setzen
				this.encryptor.IV = Encoding.GetEncoding(
					"ISO-8859-1").GetBytes(value);
			}
		}

		/* Methode zur Erzeugung eines zuf�lligen Schl�ssels */
		public void GenerateKey()
		{
			this.encryptor.GenerateKey();
		}

		/* Methode zur Erzeugung eines zuf�lligen Initialisierungsvektors */
		public void GenerateIV()
		{
			this.encryptor.GenerateIV();
		}

		/* Methode zum Verschl�sseln von Daten aus einem Stream */
		public void Encrypt(Stream source, Stream dest)
		{
			// CryptoStream zum Verschl�sseln erzeugen. Als Transformations-
			// Objekt wird das Verschl�ssel-Objekt der aktuellen 
			// SymmetricAlgorithm-Instanz �bergeben
			CryptoStream cryptoStream = new CryptoStream(dest,
				this.encryptor.CreateEncryptor(), CryptoStreamMode.Write);

			// Die Rohdaten blockweise in den CryptoStream schreiben (der diese
			// verschl�sselt in den Ziel-Stream schreibt)
			int bytesRead = 0;
			byte[] buffer = new byte[1024];
			do
			{
				bytesRead = source.Read(buffer, 0, 1024);
				cryptoStream.Write(buffer, 0, bytesRead);
			} while (bytesRead > 0);

			// Den Zielstream aktualisieren und den Puffer l�schen 
			cryptoStream.FlushFinalBlock();
         
			// Der CryptoStream darf hier nicht geschlossen werden, da
			// dieser den Ziel-Stream ansonsten auch schlie�t
		}

		/* Methode zum Entschl�sseln von Daten aus einem Stream */
		public void Decrypt(Stream source, Stream dest)
		{
			// CryptoStream zum Entschl�sseln erzeugen. Als Transformations-
			// Objekt wird das Entschl�ssel-Objekt der aktuellen
			// SymmetricAlgorithm-Instanz �bergeben
			CryptoStream cryptoStream = new CryptoStream(source,
				this.encryptor.CreateDecryptor(), CryptoStreamMode.Read);

			// Daten blockweise einlesen
			int bytesRead = 0;
			byte[] buffer = new Byte[1024];
			do
			{
				bytesRead = cryptoStream.Read(buffer, 0, 1024);
				dest.Write(buffer, 0, bytesRead);
			} while (bytesRead > 0);

			// Der CryptoStream darf hier nicht geschlossen werden, da
			// dieser den Quell-Stream ansonsten auch schlie�t
		}

		/* Methode zum Verschl�sseln von Strings */
		public string Encrypt(string source)
		{
			// MemoryStreams f�r die Daten erzeugen
			MemoryStream sourceStream = 
				new MemoryStream(Encoding.Unicode.GetBytes(source));
			MemoryStream destStream = new MemoryStream();

			// Daten verschl�sseln
			Encrypt(sourceStream, destStream);

			// Ergebnis auslesen
			destStream.Seek(0, SeekOrigin.Begin);
			byte[] encryptedBytes = destStream.ToArray();

			// Streams schlie�en
			sourceStream.Close();
			destStream.Close();

			// String zur�ckgeben
			return Encoding.Unicode.GetString(encryptedBytes);
		}
      
		/* Methode zum Entschl�sseln von Strings */
		public string Decrypt(string source)
		{
			// MemoryStreams f�r die Daten erzeugen
			MemoryStream sourceStream = 
				new MemoryStream(Encoding.Unicode.GetBytes(source));
			MemoryStream destStream = new MemoryStream();

			// Daten entschl�sseln
			Decrypt(sourceStream, destStream);

			// Ergebnis auslesen
			destStream.Seek(0, SeekOrigin.Begin);
			byte[] encryptedBytes = destStream.ToArray();

			// Streams schlie�en
			sourceStream.Close();
			destStream.Close();

			// String zur�ckgeben
			return Encoding.Unicode.GetString(encryptedBytes);
		}
	}
}
