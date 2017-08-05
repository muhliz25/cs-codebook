using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Addison_Wesley.Codebook.Security
{
	/* Aufzählung für die unterstützten symmetrischen Verschlüsselungen */
	public enum SymmetricEncryptAlgorithm
	{
		DES,
		TrippleDES,
		RC2,
		Rijndael
	} 
	
	/* Klasse zum Ver- und Entschlüseln von Daten */
	public class SymmetricEncryptor
	{
		/* Eigenschaften zur Speicherung der Verschlüsselungs-Instanz
		 * und des gewählten Algorithmus */
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

		/* Eigenschaft für den Chiffrier-Modus */
		public CipherMode CipherMode
		{
			get {return this.encryptor.Mode;}
			set {this.encryptor.Mode = value;}
		}

		/* Eigenschaft für die Blockgröße */
		public int BlockSize
		{
			get {return this.encryptor.BlockSize;}
			set {this.encryptor.BlockSize = value;}
		}

		/* Eigenschaft für das Padding */
		public PaddingMode PaddingMode
		{
			get {return this.encryptor.Padding;}
			set {this.encryptor.Padding = value;}
		}

		/* Eigenschaft für den Schlüssel */
		public string Key
		{
			get 
			{
				return Encoding.GetEncoding("ISO-8859-1").GetString(
					this.encryptor.Key);
			}

			set
			{
				// Den übergebenen Schlüssel überprüfen
				if (this.encryptor.ValidKeySize(value.Length * 8) == false) 
				{
					// Ungültiger Schlüssel: Ausnahme mit erweiterten Informationen
					// werfen
					string allowedKeySizes = null;
					for (int i = 0; i < this.encryptor.LegalKeySizes.Length; i++)
					{
						if (allowedKeySizes != null) allowedKeySizes += ", ";
						allowedKeySizes += this.encryptor.LegalKeySizes[i].MinSize +
							", " + this.encryptor.LegalKeySizes[i].MaxSize;
					}
					throw new CryptographicException("Der übergebene Schlüssel " +
						"ist mit " + (value.Length * 8) + " Bit für den " + 
						this.algorithmName + "-Algorithmus ungültig. Erlaubt " +
						"sind die folgenden Größen: " + allowedKeySizes + ".");
				}

				// Auf Unicode-Zeichen größer 0x00FF überprüfen
				for (int i = 0; i < value.Length; i++)
				{
					if ((int)value[i] > 255)
						throw new CryptographicException("Der übergebene " +
							"Schlüssel enthält mindestens ein Unicode-Zeichen, " +
							"das größer ist als 0x00FF (255): " + value[i] + " (" + 
							(int)value[i] + "). Unterstützt werden lediglich " +
							"8-Bit-Unicode-Zeichen");
				}

				// Den Schlüssel setzen
				this.encryptor.Key = Encoding.GetEncoding(
					"ISO-8859-1").GetBytes(value);
			}
		}

		/* Eigenschaft für den Initialisierungsvektor */
		public string IV
		{
			get 
			{
				return Encoding.GetEncoding("ISO-8859-1").GetString(
					this.encryptor.IV);
			}
			set
			{
				// Den übergebenen Initialisierungsvektor überprüfen
				if ((value.Length * 8) != this.encryptor.BlockSize) 
				{
					// Ungültiger Initialisierungsvektor: Ausnahme mit erweiterten
					// Informationen werfen
					throw new CryptographicException("Der übergebene " +
						"Initialisierungsvektor ist mit " + (value.Length * 8) + 
						" Bit für den " + this.algorithmName + "-Algorithmus " +
						"ungültig. Die Länge des Initialisierungsvektors muss " +
						"der Blockgröße (aktuell " + this.encryptor.BlockSize + 
						") entsprechen");
				}

				// Auf Unicode-Zeichen größer 0x00FF überprüfen
				for (int i = 0; i < value.Length; i++)
				{
					if ((int)value[i] > 255)
						throw new CryptographicException("Der übergebene " +
							"Initialisierungsvektor enthält mindestens ein " +
							"Unicode-Zeichen, das größer ist als 0x00FF (255): " + 
							value[i] + " (" + (int)value[i] + "). Unterstützt " +
							"werden lediglich 8-Bit-Unicode-Zeichen");
				}

				// Den Initialisierungsvektor setzen
				this.encryptor.IV = Encoding.GetEncoding(
					"ISO-8859-1").GetBytes(value);
			}
		}

		/* Methode zur Erzeugung eines zufälligen Schlüssels */
		public void GenerateKey()
		{
			this.encryptor.GenerateKey();
		}

		/* Methode zur Erzeugung eines zufälligen Initialisierungsvektors */
		public void GenerateIV()
		{
			this.encryptor.GenerateIV();
		}

		/* Methode zum Verschlüsseln von Daten aus einem Stream */
		public void Encrypt(Stream source, Stream dest)
		{
			// CryptoStream zum Verschlüsseln erzeugen. Als Transformations-
			// Objekt wird das Verschlüssel-Objekt der aktuellen 
			// SymmetricAlgorithm-Instanz übergeben
			CryptoStream cryptoStream = new CryptoStream(dest,
				this.encryptor.CreateEncryptor(), CryptoStreamMode.Write);

			// Die Rohdaten blockweise in den CryptoStream schreiben (der diese
			// verschlüsselt in den Ziel-Stream schreibt)
			int bytesRead = 0;
			byte[] buffer = new byte[1024];
			do
			{
				bytesRead = source.Read(buffer, 0, 1024);
				cryptoStream.Write(buffer, 0, bytesRead);
			} while (bytesRead > 0);

			// Den Zielstream aktualisieren und den Puffer löschen 
			cryptoStream.FlushFinalBlock();
         
			// Der CryptoStream darf hier nicht geschlossen werden, da
			// dieser den Ziel-Stream ansonsten auch schließt
		}

		/* Methode zum Entschlüsseln von Daten aus einem Stream */
		public void Decrypt(Stream source, Stream dest)
		{
			// CryptoStream zum Entschlüsseln erzeugen. Als Transformations-
			// Objekt wird das Entschlüssel-Objekt der aktuellen
			// SymmetricAlgorithm-Instanz übergeben
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
			// dieser den Quell-Stream ansonsten auch schließt
		}

		/* Methode zum Verschlüsseln von Strings */
		public string Encrypt(string source)
		{
			// MemoryStreams für die Daten erzeugen
			MemoryStream sourceStream = 
				new MemoryStream(Encoding.Unicode.GetBytes(source));
			MemoryStream destStream = new MemoryStream();

			// Daten verschlüsseln
			Encrypt(sourceStream, destStream);

			// Ergebnis auslesen
			destStream.Seek(0, SeekOrigin.Begin);
			byte[] encryptedBytes = destStream.ToArray();

			// Streams schließen
			sourceStream.Close();
			destStream.Close();

			// String zurückgeben
			return Encoding.Unicode.GetString(encryptedBytes);
		}
      
		/* Methode zum Entschlüsseln von Strings */
		public string Decrypt(string source)
		{
			// MemoryStreams für die Daten erzeugen
			MemoryStream sourceStream = 
				new MemoryStream(Encoding.Unicode.GetBytes(source));
			MemoryStream destStream = new MemoryStream();

			// Daten entschlüsseln
			Decrypt(sourceStream, destStream);

			// Ergebnis auslesen
			destStream.Seek(0, SeekOrigin.Begin);
			byte[] encryptedBytes = destStream.ToArray();

			// Streams schließen
			sourceStream.Close();
			destStream.Close();

			// String zurückgeben
			return Encoding.Unicode.GetString(encryptedBytes);
		}
	}
}
