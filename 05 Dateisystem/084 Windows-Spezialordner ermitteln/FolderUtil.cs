using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtil
	{
		/* Deklaration der API-Funktion GetWindowsDirectory */
		[DllImport("kernel32.dll", SetLastError=true)]
		private static extern uint GetWindowsDirectory(StringBuilder lpBuffer, 
			uint uSize);

		/* Methode zur Ermittlung des Windows-Ordners */
		public static string GetWindowsDirectoryName()
		{
			const int MAX_PATH = 260;
			StringBuilder buffer = new StringBuilder(MAX_PATH + 1);
			if (GetWindowsDirectory(buffer, MAX_PATH + 1) > 0)
				return buffer.ToString();
			else
				throw new Exception("Windows-Fehler " + Marshal.GetLastWin32Error() + 
					" beim Ermitteln des Windows-Ordners");
		}

		/* Methode zur Ermittlung des Windows-System-Ordners */
		public static string GetSystemDirectoryName()
		{
			return Environment.SystemDirectory;
		}

		/* Methode zur Ermittlung des Programmordners */
		public static string GetProgramDirectoryName()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
		}

		/* Methode zur Ermittlung des Desktop-Ordners */
		public static string GetDesktopDirectoryName()
		{
			return Environment.GetFolderPath(
				Environment.SpecialFolder.DesktopDirectory);
		}

		/* Methode zur Ermittlung des Favoriten-Ordners */
		public static string GetFavoritesDirectoryName()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
		}

		/* Methode zur Ermittlung des Ordners für zuletzt geöffnete Dokumente */
		public static string GetRecentDirectoryName()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Recent);
		}
	}
}
