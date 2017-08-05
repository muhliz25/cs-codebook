using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Dateien_archivieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname der Zip-Datei
			string zipFileName = "c:\\demo.zip";

			// Dateien, die archiviert werden sollen
			string[] sourceFiles = {@"c:\inetpub\wwwroot\winxp.gif", 
									   @"c:\inetpub\wwwroot\pagerror.gif", 
									   @"c:\inetpub\wwwroot\warning.gif", @"c:\config.sys"};

			try
			{
				// Dateien mit einer Blockgröße von 1 MB und einer
				// Kompressionsrate von 9 archivieren. 
				// Pfade sollen mit eingeschlossen werden
				Zip.ZipFiles(sourceFiles, zipFileName, 1048576, 
					9, true, "Demo fr die Verwendung von #ziplib");

				Console.WriteLine("Fertig");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Archivieren: {0}", ex.Message);
			}
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
