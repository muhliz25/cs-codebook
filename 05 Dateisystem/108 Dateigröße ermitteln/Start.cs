using System;
using System.IO;

namespace Dateigröße_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string fileName = "c:\\pagefile.sys";

			/* Ermitteln der Größe der Datei */
			try
			{
				// Größe ber ein FileInfo-Objekt auslesen
				FileInfo fi = new FileInfo(fileName);
				long fileSize = fi.Length;

				Console.WriteLine("{0}: {1:#,#0} Byte.", fileName, fileSize); 
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Ermitteln der Dateigröße " +
					"der Datei '{0}': {1}.", fileName, ex.Message); 
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
