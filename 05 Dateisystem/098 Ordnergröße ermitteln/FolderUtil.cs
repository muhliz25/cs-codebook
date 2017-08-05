using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtil
	{
		/* Methode zur Ermittlung der Gesamtgr��e der in einem Ordner und dessen
		 * Unterordnern enthaltenen Dateien */
		public static long GetFolderSize(string folderName)
		{
			// Die rekursive Methode zur Ermittlung der Gr��e eines Ordners aufrufen
			return SumFolderSize(new DirectoryInfo(folderName));
		}

		/* Methode zum rekursiven Durchgehen eines Ordners und zur Ermittlung der
		 * Gesamtgr��e der in einem Ordner und dessen Unterordnern 
		 * enthaltenen Dateien */
		private static long SumFolderSize(DirectoryInfo folder)
		{
			// Variable zur Speicherung der jeweils ermittelten Dateigr��en-Summe 
			// eines (Unter-)Ordners
			long folderSize = 0;

			// Summe der Gr��en der Dateien im Ordner ermitteln
			FileInfo[] files = folder.GetFiles();
			for (int i = 0; i < files.Length; i++)
				folderSize += files[i].Length; 

			// Unterordner ermitteln und die Methode rekursiv f�r jeden Unterordner 
			// aufrufen und dabei die Variable folderSize hochz�hlen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
				folderSize += SumFolderSize(subFolders[i]);

			// Die ermittelte Ordnergr��e zur�ckgeben
			return folderSize;
		}
	}
}
