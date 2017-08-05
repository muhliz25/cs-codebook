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
			// FileInfo-Objekt f�r die Datei erzeugen, die die ausf�hrende
			// Assembly speichert
			FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);

			// Den Pfad des Verzeichnisses der Datei zur�ckgeben
			return fi.DirectoryName;
		}
	}
}
