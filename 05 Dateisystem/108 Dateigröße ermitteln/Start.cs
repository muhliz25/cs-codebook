using System;
using System.IO;

namespace Dateigr��e_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string fileName = "c:\\pagefile.sys";

			/* Ermitteln der Gr��e der Datei */
			try
			{
				// Gr��e ber ein FileInfo-Objekt auslesen
				FileInfo fi = new FileInfo(fileName);
				long fileSize = fi.Length;

				Console.WriteLine("{0}: {1:#,#0} Byte.", fileName, fileSize); 
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Ermitteln der Dateigr��e " +
					"der Datei '{0}': {1}.", fileName, ex.Message); 
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
