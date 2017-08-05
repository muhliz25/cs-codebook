using System;
using System.IO;
using System.Reflection;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Methode zum Auslesen des Dateinamens einer Klassenbibliothek */
		public static string GetLibraryFilename()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die ausführende
			// Assembly speichert
			FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);

			// Den Dateinamen auslesen und zurückgeben
			return fi.Name;
		}
	}
}
