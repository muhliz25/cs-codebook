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
			string sourceFolderName = @"C:\Codebook";
			string destFolderName = @"G:\Backup\Codebook";

			Console.WriteLine("Kopiere '" + sourceFolderName + "' nach '" +
				destFolderName + "' ...");

			// CopyFaults-Auflistung erzeugen
			CopyFaults copyFaults = new CopyFaults();  

			// Ordner kopieren
			try
			{
				if (FolderUtil.ExtCopy(sourceFolderName, destFolderName,
					copyFaults))
				{
					Console.WriteLine("Fertig");
				}
				else
				{
					// Beim Kopieren sind Fehler aufgetreten: Alle Fehler
					// durchgehen und ausgeben
					for (int i = 0; i < copyFaults.Count; i++)
					{
						if (copyFaults[i].IsFile)
						{
							// es handelt sich um eine Datei
							Console.WriteLine("Fehler beim Kopieren der " +
								"Datei '{0}' nach '{1}': {2}",
								copyFaults[i].Source, copyFaults[i].Destination,
								copyFaults[i].Error); 
						}
						else
						{
							// es handelt sich um einen Ordner
							Console.WriteLine("Fehler beim Kopieren des " +
								"Ordners '{0}' nach '{1}': {2}",
								copyFaults[i].Source, copyFaults[i].Destination,
								copyFaults[i].Error); 
						}
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Kopieren des Ordners: {0}", 
					ex.Message);
			}

			Console.ReadLine();
		}
	}
}
