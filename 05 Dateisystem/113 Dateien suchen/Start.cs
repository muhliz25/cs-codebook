using System;
using Addison_Wesley.Codebook.Filesystem;
using System.Collections.Specialized;

namespace Dateien_suchen
{
	class Start
	{
		/* Methode für den Fortschritts-Delegate */
		private static void FindProgressHandler(string folderName)
		{
			Console.WriteLine("Durchsuche {0} ...", folderName);
		}
		
		[STAThread]
		static void Main(string[] args)
		{

			/* Im Inetpub-Ordner rekursiv nach Textdateien suchen */
			StringCollection files = FileUtil.FindFiles("c:\\inetpub", "*.txt", true,
				new FileUtil.FindProgress(FindProgressHandler));

			if (files.Count > 0)
			{
				Console.WriteLine("\r\nGefundene Dateien:");
				for (int i = 0; i < files.Count; i++)
					Console.WriteLine(files[i]);
			}
			else
			{
				Console.WriteLine("Keine Dateien gefunden");
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
