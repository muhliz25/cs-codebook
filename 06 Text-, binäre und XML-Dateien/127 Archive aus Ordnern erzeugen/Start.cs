using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Ordner_archivieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Komprimiere c:\\inetpub ...");

			System.IO.File.Delete("c:\\demo2.zip");

			// Ordner c:\inetpub nach c:\demo2.zip mit einer Blockgröße von
			// einem MB, eienr Kompressionsrate von 9 und ohne Kommentar 
			// rekursiv archivieren
			Zip.ZipFolder("c:\\inetpub", "c:\\demo2.zip", 1048576, 9, "");
			
			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
