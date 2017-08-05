using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtils
	{
		/* Methode zum Vergleich zweier Ordner */
		public static bool CompareFolders(string folderName1, string folderName2, 
			bool compareFileContent)
		{
			// Die übergebenen Ordnernamen angleichen
			if (folderName1.EndsWith("\\") == false) folderName1 += "\\";
			if (folderName2.EndsWith("\\") == false) folderName2 += "\\";

			// Die rekursive Vergleichsmethode mit zwei neuen DirectoryInfo-
			// Objekten für die beiden Ordner aufrufen
			DirectoryInfo folder1 = new DirectoryInfo(folderName1);
			DirectoryInfo folder2 = new DirectoryInfo(folderName2);
			return CompareFolderContent(folder1, folder2, compareFileContent);
		}

		/* Private Methode zum rekursiven Vergleich des Inhalts zweier Ordner */
		private static bool CompareFolderContent(DirectoryInfo folder1,
			DirectoryInfo folder2, bool compareFileContent)
		{
			// Die Anzahl der Dateien im Ordner vergleichen
			FileInfo[] files1 = folder1.GetFiles();
			FileInfo[] files2 = folder2.GetFiles();
			if (files1.Length != files2.Length)
				return false;

			// Die Dateien durchgehen und diese vergleichen
			foreach (FileInfo file1 in files1)
			{
				// Dateiname im zweiten Ordner ermitteln und überprüfen, ob die Datei
				// existiert
				string fileName2 = Path.Combine(folder2.FullName, file1.Name); 
				if (System.IO.File.Exists(fileName2))
				{
					// Dateien vergleichen
					FileUtils.FileCompareMethod compareMethod = 
						compareFileContent ? FileUtils.FileCompareMethod.Content :
						FileUtils.FileCompareMethod.Date;
 
					if (FileUtils.CompareFiles(file1.FullName, fileName2,
						compareMethod) == false)
						return false;
				}
				else
					// Datei existiert nicht, also sind die Ordner nicht identisch
					return false;
			}

			// Die Anzahl der Unterordner vergleichen
			DirectoryInfo[] subFolders1 = folder1.GetDirectories();
			DirectoryInfo[] subFolders2 = folder2.GetDirectories();
			if (subFolders1.Length != subFolders2.Length)
				return false;
   
			// Die Unterordner des ersten Ordners durchgehen um zu vergleichen, ob der
			// zweite Ordner dieselben Unterordner besitzt und um diese rekursiv
			// durchzugehen
			foreach (DirectoryInfo subFolder1 in subFolders1)
			{
				// Ordnername des zweiten Ordners ermitteln und überprüfen, ob der
				// Ordner existiert
				string folderName2 = Path.Combine(folder2.FullName, subFolder1.Name); 
				DirectoryInfo subFolder2 = new DirectoryInfo(folderName2);
				if (subFolder2.Exists == false)
					return false;

				// Rekursiver Aufruf zum Vergleich der beiden Unterordner
				if (CompareFolderContent(subFolder1, subFolder2, 
					compareFileContent) == false)
					return false;
			}

			// Wenn die Methode hier ankommt, enthalten beide (Unter-)Ordner einen
			// identischen Inhalt
			return true;
		}
	}
}
