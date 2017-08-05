using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtil
	{
		/* Delegate für Folder.GetSubFolderSizes */
		public delegate void FolderProgress(string currentFolderName);

		/* Klasse für die Speicherung von Ordner-Größen */
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

		/* Spezialisierte Collection für FolderSize-Objekte */
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

		/* Methode zur Ermittlung der Gesamtgröße aller einem Ordner direkt 
		 * untergeordneten Unterordner */
		public static FolderSizes GetSubFolderSizes(string folderName, 
			FolderProgress progress)
		{
			// FolderSizes-Objekt für die Speicherung der Ordnergrößen erzeugen
			FolderSizes fs = new FolderSizes();

			// DirectoryInfo-Objekt für den Ordner erzeugen
			DirectoryInfo folder = new DirectoryInfo(folderName);

			// Fortschritts-Delegate aufrufen
			if (progress != null)
				progress(folder.Name);

			// Gesamtgröße der Dateien des Ordners ermitteln
			FileInfo[] files = folder.GetFiles(); 
			long folderSize = 0;
			for (int i = 0; i < files.Length; i++)
				folderSize += files[i].Length; 

			// Ordnername und Größe als erstes Element in der Auflistung ablegen
			fs.Add(new FolderSize(folderName, folderSize));

			// Unterordner ermitteln
			DirectoryInfo[] subFolders = folder.GetDirectories();

			// Unterordner durchgehen
			for (int i = 0; i < subFolders.Length; i++)
			{
				// Fortschritts-Delegate aufrufen
				if (progress != null)
					progress(subFolders[i].Name);

				// Die jeweilige Größe ermitteln
				folderSize = SumFolderSize(subFolders[i]);

				// Ordnername und Größe in der Auflistung ablegen
				fs.Add(new FolderSize(subFolders[i].FullName, folderSize));
			}

			// Referenz auf die Auflistung zurückgeben
			return fs;
		}

		/* Methode zur Ermittlung der Gesamtgröße der in einem Ordner und dessen
		 * Unterordnern enthaltenen Dateien */
		public static long GetFolderSize(string folderName)
		{
			// DirectoryInfo-Objekt für den Ordner erzeugen
			DirectoryInfo di = new DirectoryInfo(folderName);

			// Die rekursive Methode zur Ermittlung der Größe eines Ordners aufrufen
			return SumFolderSize(di);
		}

		/* Methode zum rekursiven Durchgehen eines Ordners und zur Ermittlung der 
		 * Gesamtgröße der in einem Ordner und dessen Unterordnern enthaltenen 
		 * Dateien. */
		private static long SumFolderSize(DirectoryInfo folder)
		{
			// Variable zur Speicherung der jeweils ermittelten Dateigrößen-Summe 
			// eines (Unter-)Ordners
			long folderSize = 0;

			// Summe der Größen der Dateien im Ordner ermitteln
			FileInfo[] files = folder.GetFiles();
			for (int i = 0; i < files.Length; i++)
				folderSize += files[i].Length; 

			// Unterordner ermitteln und die Methode rekursiv für jeden Unterordner 
			// aufrufen und dabei die Variable folderSize hochzählen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
				folderSize += SumFolderSize(subFolders[i]);

			// Die ermittelte Ordnergröße zurückgeben
			return folderSize;
		}
	}
}
