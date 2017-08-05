using System;
using System.IO;
using System.Reflection;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Methode zum Auslesen des Dateinamens einer Anwendung */
		public static string GetApplicationFilename()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die Eintritts-
			// Assembly speichert
			FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);

			// Dateiname auslesen und zurckgeben
			return fi.Name;
		}
	}
}
