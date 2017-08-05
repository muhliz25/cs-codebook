using System;
using System.IO;
using System.Reflection;

namespace Anwendungs_Ordner
{
	class Start
	{
		/* Methode zum Auslesen des Ordnernamens einer Anwendung */
		public static string GetApplicationFolderName()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die Eintritts-
			// Assembly speichert */
			System.IO.FileInfo fi = new System.IO.FileInfo(
				System.Reflection.Assembly.GetEntryAssembly().Location);

			// Den Pfad des Verzeichnisses der Datei zurückgeben
			return fi.DirectoryName;
		}
	
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname der Anwendung auslesen
			Console.WriteLine("Ordnername der Anwendung: '{0}'",
				GetApplicationFolderName());
			Console.ReadLine();

		}
	}
}
