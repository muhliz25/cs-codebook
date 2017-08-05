using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtil
	{
		/* Methode zum Kopieren eines Ordners */ 
		public static void Copy(string sourceFolderName, string destFolderName)
		{
			// DirectoryInfo-Objekt für den Quellordner erzeugen
			DirectoryInfo sourceFolder = new DirectoryInfo(sourceFolderName);

			// Überprüfen, ob der Zielordner bereits existiert
			if (Directory.Exists(destFolderName))
			{
				// Ausnahme erzeugen
				throw new IOException("Der Zielordner '" + destFolderName + 
					"' existiert bereits");
			}

			// Zielordner anlegen
			Directory.CreateDirectory(destFolderName);

			// Methode zum Kopieren der Unterordner und Dateien aufrufen
			CopySubFoldersAndFiles(sourceFolder, sourceFolderName, destFolderName);
		}

		/* Methode zum rekursiven Kopieren eines Ordners */
		private static void CopySubFoldersAndFiles(DirectoryInfo folder, 
			string sourceFolderName, string destFolderName)
		{
			// Alle Unterordner des übergebenen Ordners durchgehen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				// Pfad für den Ziel-Unterordner ermitteln, indem der Pfad zum
				// Quellordner durch den Pfad zum Zielordner ersetzt wird
				string destSubFolderName = subFolders[i].FullName.Replace(
					sourceFolderName, destFolderName);
  
				// Unterordner im Zielordner erzeugen
				Directory.CreateDirectory(destSubFolderName); 

				// Funktion rekursiv aufrufen um zunächst die weiteren Unterordner 
				// zu erzeugen
				CopySubFoldersAndFiles(subFolders[i], sourceFolderName,
					destFolderName);
			}

			// Die im Ordner enthaltenen Dateien ermitteln
			FileInfo[] files = folder.GetFiles(); 
    
			// Alle Dateien durchgehen
			for (int i = 0; i < files.Length; i++)
			{
				// Ziel-Dateiname ermitteln, indem der Pfad zum Quellordner
				// durch den Pfad zum Zielordner ersetzt wird
				string destFileName = files[i].FullName.Replace(
					sourceFolderName, destFolderName);

				// Datei kopieren
				File.Copy(files[i].FullName, destFileName);  
			} 
		}
	}
}
