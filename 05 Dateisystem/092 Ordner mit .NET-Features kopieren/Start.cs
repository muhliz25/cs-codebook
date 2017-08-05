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
			string sourceFolderName = @"C:\Temp";
			string destFolderName = @"C:\Temp.copy";

			// Ordner als Beispiel zum Kopieren anlegen
			System.IO.Directory.CreateDirectory(sourceFolderName);

			Console.WriteLine("Kopiere '" + sourceFolderName + "' nach '" + 
				destFolderName + "' ...");
			try
			{
				// Ordner rekursiv kopieren
				FolderUtil.Copy(sourceFolderName, destFolderName);

				Console.WriteLine("Fertig");
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Kopieren des Ordners: " + ex.Message);
			}
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
