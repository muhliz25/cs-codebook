using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Windows_Ordner_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string windowsDirectory = FolderUtil.GetWindowsDirectoryName();
			string systemDirectory = FolderUtil.GetSystemDirectoryName();
			string programDirectory = FolderUtil.GetProgramDirectoryName();
			string desktopDirectory = FolderUtil.GetDesktopDirectoryName();
			string favoritesDirectory = FolderUtil.GetFavoritesDirectoryName();
			string recentDirectory = FolderUtil.GetRecentDirectoryName();

			Console.WriteLine("Windows-Ordner:\r\n{0}", windowsDirectory);
			Console.WriteLine("\r\nWindows-SystemOrdner:\r\n{0}", systemDirectory);
			Console.WriteLine("\r\nProgrammmordner:\r\n{0}", programDirectory);
			Console.WriteLine("\r\nDesktop-Ordner:\r\n{0}", desktopDirectory);
			Console.WriteLine("\r\nFavoriten-Ordner:\r\n{0}", favoritesDirectory);
			Console.WriteLine("\r\nOrdner der zuletzt geöffneten Dokumente:\r\n{0}",
				recentDirectory);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}

