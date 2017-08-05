using System;
using System.IO;
using System.Reflection;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Methode zum Auslesen des Ordnernamens einer Anwendung */
		public static string GetApplicationFolderName()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die Eintritts-Assembly speichert
			FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);

			// Den Pfad des Ordners der Datei zurckgeben
			return fi.DirectoryName;
		}
	}
}
