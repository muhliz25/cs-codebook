using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Ordner_kopieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Ordnernamen festlegen
			string sourceFolderName = @"C:\Codebook";
			string destFolderName = @"G:\Backup\Codebook";

			Console.WriteLine("Kopiere {0} nach {1} ...", sourceFolderName,
				destFolderName);

			// Zielordner erzeugen, falls dieser nicht vorhanden ist
			Directory.CreateDirectory(destFolderName);

			// Ordner rekursiv mit Anwender-Nachfrage für das Überschreiben von
			// Ordnern kopieren
			try
			{
				if (FolderUtil.APICopy(sourceFolderName, destFolderName, true))
					Console.WriteLine("Fertig");
				else
					Console.WriteLine("Fehler beim Kopieren des Ordners");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Kopieren des Ordners: {0}", ex.Message);
			}
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
