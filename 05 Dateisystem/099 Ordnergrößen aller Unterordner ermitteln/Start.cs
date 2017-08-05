using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Unterordner_Größe
{
	class Start
	{
		/* Methode für den Delegate */
		public static void OnProgress(string folderName)
		{
			Console.WriteLine("Durchsuche {0} ...", folderName);
		}
      
		[STAThread]
		static void Main(string[] args)
		{
         
			// Ordner festlegen
			string folderName = "C:\\Inetpub";

			try
			{
				// Rekursives Ermitteln der Größe der im Ordner direkt und in allen
				// Unterordnern gespeicherten Dateien. Übergeben werden der Ordnername
				// und eine neue Instanz des Fortschritts-Delegate
				FolderUtil.FolderSizes fs = FolderUtil.GetSubFolderSizes(
					folderName, new FolderUtil.FolderProgress(OnProgress));

				// Die Auflistung der Ordnergrößen durchgehen
				Console.WriteLine("\r\nErmittelte Größen:");
				for (int i = 0; i < fs.Count; i++)
					Console.WriteLine("{0}: {1:#,#0} Byte",
						fs[i].FolderName, fs[i].Size); 
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler: " + ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
