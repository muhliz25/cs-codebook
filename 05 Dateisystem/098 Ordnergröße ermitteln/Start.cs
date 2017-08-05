using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Ordnergröße
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Windows-Systemordner ermitteln
			string folderName = Environment.SystemDirectory;

			Console.WriteLine("Ermittle die Größe von {0}", folderName);

			try
			{
				// Ordnergröße ermitteln
				long folderSize = FolderUtil.GetFolderSize(folderName);

				Console.WriteLine("Größe von {0}: {1:#,#0} Byte.", folderName,
					folderSize);
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler: {0}.", ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
