using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip; 

namespace Addison_Wesley.Codebook.Filesystem
{
	public class Zip
	{
		public static void ZipFolder(string folderName, string zipFileName, 
			int blockSize, int zipLevel, string comment)
		{
			// Datei-Stream als Basis-Stream erzeugen
			Stream zipFileStream = File.Open(zipFileName, FileMode.CreateNew);

			// ZipOutputStream zum Schreiben der Zip-Datei erzeugen
			ZipOutputStream zipOutputStream = new ZipOutputStream(zipFileStream);

			// Kompressionsrate definieren (0 bis 9)
			zipOutputStream.SetLevel(zipLevel);

			// Kommentar zum Archiv definieren
			zipOutputStream.SetComment(comment);

			// Ordner rekursiv archivieren
			AddFilesFromFolder(folderName, folderName, zipOutputStream, blockSize);

			// ZipOutputStream abschließen und schließen
			zipOutputStream.Finish();
			zipOutputStream.Close();
		}

		/* Rekursive Methode zum Hinzufügen aller Dateien eines Ordners */
		private static void AddFilesFromFolder(string baseFolderName, 
			string folderName, ZipOutputStream zipOutputStream, int blockSize)
		{
			// Alle Dateien des Ordners durchgehen und in das Archiv schreiben
			DirectoryInfo folder = new DirectoryInfo(folderName);
			FileInfo[] files = folder.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				// Relativen Pfad des aktuellen Ordners über das Entfernen des
				// Basisordnernamens ermitteln
				string relativePath = folderName.Replace(baseFolderName, ""); 
				if (relativePath != null)
				{
					if (relativePath.StartsWith("\\"))
						relativePath  = relativePath.Remove(0, 1);
					if (relativePath.EndsWith("\\") == false)
						relativePath += "\\";
				}

				// ZipEntry-Objekt für die neue Datei mit dem relativen Pfad
				// erzeugen und dem ZipOutputStream hinzufügen
				zipOutputStream.PutNextEntry(
					new ICSharpCode.SharpZipLib.Zip.ZipEntry(
					relativePath + files[i].Name));

				// Zu archivierende Datei in einem FileStream öffnen und über ein
				// Byte-Array blockweise in den ZipOutputStream schreiben
				FileStream fileStream = files[i].OpenRead();
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

			// Alle Unterordner durchgehen und die Methode rekursiv aufrufen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				AddFilesFromFolder(baseFolderName, subFolders[i].FullName,
					zipOutputStream, blockSize);
			}
		}
	}
}
