using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class Zip
	{
		/* Methode zum Archivieren von einzelnen Dateien */
		public static void ZipFiles(string[] sourceFileNames, string zipFileName, 
			int blockSize, int zipLevel, bool includePaths, string comment)
		{
			// Datei-Stream als Basis-Stream erzeugen
			Stream zipFileStream = File.Open(zipFileName, FileMode.CreateNew);

			// ZipOutputStream zum Schreiben der Zip-Datei erzeugen
			ZipOutputStream zipOutputStream = new ZipOutputStream(zipFileStream);

			// Kompressionsrate definieren (0 bis 9)
			zipOutputStream.SetLevel(zipLevel);

			// Kommentar zum Archiv definieren
			zipOutputStream.SetComment(comment);

			// Alle im Array sourceFileNames übergebenen Dateien 
			// durchgehen und in das Archiv schreiben
			for (int i = 0; i < sourceFileNames.Length; i++)
			{
				// ZipEntry-Objekt für die neue Datei erzeugen. Der im Konstruktor 
				// übergebene Name wird als Dateiname beim Extrahieren verwendet. 
				// Sie können hier auch (relative) Pfadangaben mit angeben. 
				// Das Programm speichert den Pfad (ohne Laufwerkangabe) mit, 
				// wenn das Argument includePaths true ist         
				string fileNameForZip;
				FileInfo fi = new FileInfo(sourceFileNames[i]);
				if (includePaths) 
				{
					// Dateiname ohne Laufwerkbuchstabe ermitteln
					int pos = fi.FullName.IndexOf('\\');
					if (pos > -1)
						fileNameForZip = fi.FullName.Substring(pos, 
							fi.FullName.Length - pos);
					else
						fileNameForZip = fi.FullName;
				}
				else
				{
					// Nur den Dateinamen speichern
					fileNameForZip = fi.Name;
				}
				ZipEntry zipEntry = new ZipEntry(fileNameForZip);

				// ZipEntry-Objekt dem ZipOutputStream hinzufügen
				zipOutputStream.PutNextEntry(zipEntry);

				// Zu archivierende Datei in einem FileStream öffnen
				FileStream fileStream = new FileStream(sourceFileNames[i],
					FileMode.Open, FileAccess.Read);

				// Quellstream blockweise in ein Byte-Array lesen und in den
				// ZipOutputStream schreiben
				byte[] buffer = new byte[blockSize];
				int bytesWritten = 0;
				do
				{
					int size = fileStream.Read(buffer, 0, buffer.Length);
					zipOutputStream.Write(buffer, 0, size);
					bytesWritten += size;

				} while (bytesWritten < fileStream.Length); 

				// FileStream schließen
				fileStream.Close();
			}

			// ZipOutputStream abschließen und schließen
			zipOutputStream.Finish();
			zipOutputStream.Close();
		}
	}
}
