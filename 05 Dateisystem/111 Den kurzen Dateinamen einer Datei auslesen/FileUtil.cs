using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Deklaration der benötigten API-Funktionen und –Konstanten */
		[DllImport("kernel32.dll", SetLastError=true)]
		private static extern int GetShortPathName(string lpszLongPath,
			StringBuilder lpszShortPath, int cchBuffer);

		[DllImport("Kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, string lpSource, 
			int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize,
			string [] Arguments);

		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000; 
		private const int MAX_PATH = 260;
   
		/* Methode zur Ermittlung des kurzen Dateinamens einer Datei */
		public static string GetShortName(string fileName)
		{
			// GetShortPathName mit einem ausreichend großen StringBuilder-Objekt
			// aufrufen 
			StringBuilder shortName = new StringBuilder(MAX_PATH + 1);
			if (GetShortPathName(fileName, shortName, MAX_PATH + 1) > 0)
				return shortName.ToString();
			else
			{
				// Fehler bei der Ausführung: API-Fehler ermitteln, diesen in eine
				// Fehlerbeschreibung umwandeln und damit eine Ausnahme werfen
				System.Text.StringBuilder errorMessage = new StringBuilder(1024);
				FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, null, 
					Marshal.GetLastWin32Error(), 0, errorMessage, 1024, null);
				throw new IOException(errorMessage.ToString());
			}
		}
	}
}
