using System;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class Zip
	{
		/* Eigenschaften, die f¸r das ‹berschreiben aller Dateien verwendet werden */
		private static bool overwriteAllFiles;
		private static bool alreadyAskedForOverwriteAllFiles;

		/* Methode zum Extrahieren eines Zip-Archivs in einen Ordner */
		public static void ExtractToFolder(string zipFileName, string folderName, 
			int blockSize, bool overwriteWithoutWarning)
		{
			// Eigenschaften voreinstellen
			overwriteAllFiles = false;
			alreadyAskedForOverwriteAllFiles = false;
   
			// ZipInputStream f¸r die Zip-Datei erzeugen 
			ZipInputStream zipInputStream = new ZipInputStream(
				File.Open(zipFileName, FileMode.Open, FileAccess.Read));

			// Alle im Archiv gespeicherten ZipEntry-Objekte durchgehen
			ZipEntry zipEntry;
			while ((zipEntry = zipInputStream.GetNextEntry()) != null)
			{
				// Aus dem (relativen) Dateinamen den Unterordner und den
				// Dateinamen extrahieren
				string subFolderName = Path.GetDirectoryName(zipEntry.Name);
				string fileName = Path.GetFileName(zipEntry.Name);

				// Den vollen Ordnernamen des Zielordners ermitteln
				string destFolderName = Path.Combine(folderName, subFolderName);

				// Unterordner erzeugen, falls notwendig
				if (subFolderName != null)
					Directory.CreateDirectory(destFolderName);

				if (fileName != null)
				{
					bool overwriteFile = true;
         
					if (overwriteWithoutWarning == false && 
						overwriteAllFiles == false)
					{
						// Wenn Dateien nicht ohne Warnung ¸berschrieben werden
						// sollen: ‹berpr¸fen, ob bereits eine gleichnamige Datei
						// existiert
						if (File.Exists(Path.Combine(destFolderName, fileName)))
						{
							// Nachfragen, ob die Datei ¸berschrieben werden soll
							switch (MessageBox.Show("Die Datei '" + fileName + 
								"' existiert bereits im Ordner '" + destFolderName + 
								"'\r\n\r\nSoll diese Datei ¸berschrieben werden?",
								Application.ProductName, 
								MessageBoxButtons.YesNoCancel,
								MessageBoxIcon.Question))
							{
								case DialogResult.Yes:
									overwriteFile = true;
									break;
								case DialogResult.No:
									overwriteFile = false;
									break;
								case DialogResult.Cancel:
									// Stream schlieﬂen und beenden
									zipInputStream.Close();
									return;
							}

							// Nachfragen, ob alle Dateien ¸berschrieben werden
							// sollen, sofern dies noch nicht geschehen ist
							if (overwriteFile == true && 
								alreadyAskedForOverwriteAllFiles == false)
							{
								switch (MessageBox.Show("Sollen alle vorhandenen " +
									"Dateien automatisch ¸berschrieben werden?",
									Application.ProductName,
									MessageBoxButtons.YesNoCancel,
									MessageBoxIcon.Question))
								{
									case DialogResult.Yes:
										overwriteAllFiles = true;
										break;
									case DialogResult.No:
										overwriteAllFiles = false;
										break;
									case DialogResult.Cancel:
										// Stream schlieﬂen und beenden
										zipInputStream.Close();
										return;
								}
								// Definieren, dass nicht noch einmal gefragt wird
								alreadyAskedForOverwriteAllFiles = true;
							}
						}
					}

					if (overwriteFile)
					{
						// FileStream f¸r die Datei erzeugen
						FileStream fileStream = 
							File.Create(Path.Combine(destFolderName, fileName));

						// Datei in Blˆcken von maximal 1 MB in den Stream schreiben
						// um den Speicher nicht mit groﬂen Dateien zu ¸berlasten
						int size;
						byte[] buffer = new byte[1048576];
						do
						{
							// Den n‰chsten Datenblock aus dem ZipInputStream lesen
							size = zipInputStream.Read(buffer, 0, buffer.Length);
							if (size > 0)
								// Wenn Daten gelesen wurden, diese in die Datei
								// schreiben
								fileStream.Write(buffer, 0, size);
						} while (size > 0);

						// FileStream schlieﬂen
						fileStream.Close();
					}
				}
			}

			// ZipInputStream schlieﬂen
			zipInputStream.Close();
		}
	}
}
