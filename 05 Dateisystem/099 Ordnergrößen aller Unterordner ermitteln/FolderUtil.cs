using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtil
	{
		/* Delegate f�r Folder.GetSubFolderSizes */
		public delegate void FolderProgress(string currentFolderName);

		/* Klasse f�r die Speicherung von Ordner-Gr��en */
		public class FolderSize
		{
			/* Eigenschaften */
			public string FolderName;
			public long Size;

			/* Konstruktor */
			public FolderSize(string folderName, long size)
			{
				this.FolderName = folderName;
				this.Size = size;
			}
		}

		/* Spezialisierte Collection f�r FolderSize-Objekte */
		public class FolderSizes: System.Collections.CollectionBase 
		{
			/* Implementierung des Indizierers */
			public FolderSize this[int index]
			{
				set {List[index] = value;}
				get {return (FolderSize)List[index];}
			}

			/* Implementierung der Add-Methode */
			public void Add(FolderSize fs)
			{
				this.List.Add(fs);
			}
		}

		/* Methode zur Ermittlung der Gesamtgr��e aller einem Ordner direkt 
		 * untergeordneten Unterordner */
		public static FolderSizes GetSubFolderSizes(string folderName, 
			FolderProgress progress)
		{
			// FolderSizes-Objekt f�r die Speicherung der Ordnergr��en erzeugen
			FolderSizes fs = new FolderSizes();

			// DirectoryInfo-Objekt f�r den Ordner erzeugen
			DirectoryInfo folder = new DirectoryInfo(folderName);

			// Fortschritts-Delegate aufrufen
			if (progress != null)
				progress(folder.Name);

			// Gesamtgr��e der Dateien des Ordners ermitteln
			FileInfo[] files = folder.GetFiles(); 
			long folderSize = 0;
			for (int i = 0; i < files.Length; i++)
				folderSize += files[i].Length; 

			// Ordnername und Gr��e als erstes Element in der Auflistung ablegen
			fs.Add(new FolderSize(folderName, folderSize));

			// Unterordner ermitteln
			DirectoryInfo[] subFolders = folder.GetDirectories();

			// Unterordner durchgehen
			for (int i = 0; i < subFolders.Length; i++)
			{
				// Fortschritts-Delegate aufrufen
				if (progress != null)
					progress(subFolders[i].Name);

				// Die jeweilige Gr��e ermitteln
				folderSize = SumFolderSize(subFolders[i]);

				// Ordnername und Gr��e in der Auflistung ablegen
				fs.Add(new FolderSize(subFolders[i].FullName, folderSize));
			}

			// Referenz auf die Auflistung zur�ckgeben
			return fs;
		}

		/* Methode zur Ermittlung der Gesamtgr��e der in einem Ordner und dessen
		 * Unterordnern enthaltenen Dateien */
		public static long GetFolderSize(string folderName)
		{
			// DirectoryInfo-Objekt f�r den Ordner erzeugen
			DirectoryInfo di = new DirectoryInfo(folderName);

			// Die rekursive Methode zur Ermittlung der Gr��e eines Ordners aufrufen
			return SumFolderSize(di);
		}

		/* Methode zum rekursiven Durchgehen eines Ordners und zur Ermittlung der 
		 * Gesamtgr��e der in einem Ordner und dessen Unterordnern enthaltenen 
		 * Dateien. */
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
