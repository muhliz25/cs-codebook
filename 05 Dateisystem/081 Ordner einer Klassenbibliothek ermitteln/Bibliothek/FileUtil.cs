using System;
using System.IO;
using System.Reflection;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Methode zum Auslesen des Ordnernamens einer Klassenbibliothek */
		public static string GetLibraryFolderName()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die ausführende
			// Assembly speichert
			FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);

			// Den Pfad des Verzeichnisses der Datei zurückgeben
			return fi.DirectoryName;
		}
	}
}
