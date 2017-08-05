using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Laufwerkgr��e_und_freien_Speicherplatz_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Variablen f�r die Aufnahme der Gr��eninformationen
			ulong totalSize = 0, totalSpace = 0, userSpace = 0;

			try
			{
				// Gr��e und freien Speicherplatz des Laufwerks C: ermitteln
				DriveUtils.GetDriveSpace("c:", ref totalSize, ref totalSpace, ref userSpace);

				// Ergebnis ausgeben
				Console.WriteLine("Gr��e: {0} Byte", totalSize);
				Console.WriteLine("Gesamter freier Platz: {0} Byte", totalSpace);
				Console.WriteLine("Benutzerspezifischer freier Platz: {0} Byte", userSpace);
			}
			catch (IOException ex)
			{
				// Fehlerauswertung
				Console.WriteLine("Fehler beim Lesen der Greninformationen " +
					"von Laufwerk c: {0}.", ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
