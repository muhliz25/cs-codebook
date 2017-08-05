using System;
using System.IO;
using System.Reflection;

namespace Anwendungs_Dateiname
{
	class Start
	{
		/* Methode zum Auslesen des Dateinamens einer Anwendung */
		public static string GetApplicationFilename()
		{
			// FileInfo-Objekt für die Datei erzeugen, die die Eintritts-
			// Assembly speichert
			FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);

			// Dateiname auslesen und zurückgeben
			return fi.Name;
		}
	
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname der Anwendung auslesen
			Console.WriteLine("Dateiname der Anwendung: '{0}'",
				GetApplicationFilename());
			Console.ReadLine();
		}
	}
}
