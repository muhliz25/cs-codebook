using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Laufwerkgröße_und_freien_Speicherplatz_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Variablen für die Aufnahme der Größeninformationen
			ulong totalSize = 0, totalSpace = 0, userSpace = 0;

			try
			{
				// Größe und freien Speicherplatz des Laufwerks C: ermitteln
				DriveUtils.GetDriveSpace("c:", ref totalSize, ref totalSpace, ref userSpace);

				// Ergebnis ausgeben
				Console.WriteLine("Größe: {0} Byte", totalSize);
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
