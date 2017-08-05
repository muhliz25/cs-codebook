using System;
using System.IO;
using ICSharpCode.SharpZipLib;
using Addison_Wesley.Codebook.Filesystem;

namespace Archiv_entpacken
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string zipFileName = "c:\\demo.zip";
			string folderName = "c:\\temp";

			// Zip-Archiv mit einer Blockgröße von 1 MB 
			// mit Überschreib-Nachfrage entpacken
			Console.WriteLine("Extrahiere {0} nach {1} ... ", zipFileName, folderName);
			try
			{
				Zip.ExtractToFolder(zipFileName, folderName, 1048576, false);

				Console.WriteLine("Fertig");
			}
			catch (ZipException ex1)
			{
				Console.WriteLine("Fehler bei der Archivoperation: {0}", ex1.Message); 
			}
			catch (IOException ex2)
			{
				Console.WriteLine("Fehler bei der Dateioperation: {0}", ex2.Message); 
			}
			catch (Exception ex3)
			{
				Console.WriteLine("Allgemeiner Fehler: {0}", ex3.Message); 
			}
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
