using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Dateien_und_Ordner_ber_SHFileOperation_verschieben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Ordner verschieben */
			string sourceFolderName = @"c:\DemoFolder";    // Quellordner
			string destFolderName = @"c:\Temp\DemoFolder"; // Zielordner

			// Ordner als Beispiel zum Verschieben anlegen
			System.IO.Directory.CreateDirectory(sourceFolderName);

			// Ordner rekursiv mit Anwender-Nachfrage für das Überschreiben von
			// Ordnern verschieben
			Console.WriteLine("Verschiebe {0} nach {1} ... ", sourceFolderName,
				destFolderName);
			if (FileUtil.APIMove(sourceFolderName, destFolderName, true))
				Console.WriteLine("Ordner erfolgreich verschoben");
			else
				Console.WriteLine("Fehler beim Verschieben des Ordners");

			/* Datei verschieben */
			string sourceFileName = @"c:\Demo for API-Move.txt";    // Quelldatei
			string destFileName = @"c:\Temp\Demo for API-Move.txt"; // Zieldatei

			// (Text-)Datei als Beispiel zum Verschieben erzeugen
			System.IO.StreamWriter sw = System.IO.File.CreateText(sourceFileName);
			sw.WriteLine("Beispieldatei für das Verschieben einer Datei " +
				"über SHFileOperation.");
			sw.Close();

			// Datei mit Anwender-Nachfrage für das Überschreiben von Dateien verschieben
			Console.WriteLine("Verschiebe {0} nach {1} ... ", sourceFileName, destFileName);
			if (FileUtil.APIMove(sourceFileName, destFileName, true))
				Console.WriteLine("Datei erfolgreich verschoben");
			else
				Console.WriteLine("Fehler beim Verschieben der Datei");
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}	
	}
}
