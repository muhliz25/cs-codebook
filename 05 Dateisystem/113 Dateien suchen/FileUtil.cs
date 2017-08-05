using System;
using System.IO;
using System.Collections.Specialized;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Delegate für eine Fortschrittsmeldung */
		public delegate void FindProgress(string folderName);

		/* Methode zum Suchen von Dateien in einem Ordner */
		public static StringCollection FindFiles(string folderName,
			string searchPattern, bool recurse, FindProgress findProgress)
		{
			// StringCollection-Objekt für die Rückgabe erzeugen
			StringCollection resultFiles =  new StringCollection();
    
			// DirectoryInfo-Objekt für den Ordner erzeugen
			DirectoryInfo folder = new DirectoryInfo(folderName);

			// Die rekursive Methode zum Suchen in einem Ordner aufrufen
			FindFilesInFolder(searchPattern, folder, recurse, resultFiles, 
				findProgress);

			// StringCollection zurückgeben
			return resultFiles;
		}

		/* Rekursive Methode zum Suchen von Dateien */
		private static void FindFilesInFolder(string searchPattern, 
			DirectoryInfo folder, bool recurse, StringCollection resultFiles,
			FindProgress findProgress)
		{
			// Delegate aufrufen, falls dieser übergeben wurde
			if (findProgress != null)
				findProgress(folder.FullName); 

			// Zunächst für alle Unterordner FindFilesInFolder rekursiv aufrufen, 
			// wenn dies gewünscht ist
			if (recurse)
			{
				DirectoryInfo[] subFolders = folder.GetDirectories();
				for (int i = 0; i < subFolders.Length; i++)
					FindFilesInFolder(searchPattern, subFolders[i], true, resultFiles,
						findProgress);
			}

			// Alle Dateien ermitteln, die dem übergebenen Suchmuster entsprechen 
			FileInfo[] files = folder.GetFiles(searchPattern);

			// Die gefundenen Dateien durchgehen und deren vollen Namen an die
			// StringCollection anhängen
			for (int i = 0; i < files.Length; i++)
				resultFiles.Add(files[i].FullName);
		}
	}
}
