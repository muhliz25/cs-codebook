using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class DriveUtils
	{
		/* Deklaration der verwendeten API-Funktionen und Konstanten */
		[DllImport ("Kernel32.dll", SetLastError=true)]
		private static extern int GetDiskFreeSpaceEx(string lpDirectoryName,
			ref ulong lpFreeBytesAvailable, ref ulong lpTotalNumberOfBytes,
			ref ulong lpTotalNumberOfFreeBytes);

		[DllImport("Kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, string lpSource, 
			int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize,
			string [] Arguments);

		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000; 

		/* Methode zur Ermittlung der Größe und des freien Speicherplatzes eines
		 * Laufwerks */
		public static void GetDriveSpace(string drive, ref ulong totalSize, 
			ref ulong totalSpace, ref ulong userSpace)
		{
			// GetDiskFreeSpaceEx aufrufen
			if (GetDiskFreeSpaceEx(drive, ref userSpace, ref totalSize, 
				ref totalSpace) == 0)
			{
				// Fehler bei der Ausführung: API-Fehler ermitteln, dessen Beschreibung
				// auslesen und eine Ausnahme werfen 
				int apiError = Marshal.GetLastWin32Error();
				StringBuilder errorMessage = new StringBuilder(1024);
				FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, null, apiError, 0, 
					errorMessage, 1024, null);
				throw new IOException(errorMessage.ToString());
			}
		}
	}
}
