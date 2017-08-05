using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Internet
{
	public class InternetUtils
	{
		/* Deklaration der benötigten API-Funktionen */
		[DllImport("wininet.dll", SetLastError=true, CharSet=CharSet.Auto)]
		public static extern int InternetCheckConnection(
			[MarshalAs(UnmanagedType.LPTStr)] string lpszUrl,
			[MarshalAs(UnmanagedType.U4)] int dwFlags,
			[MarshalAs(UnmanagedType.U4)] int dwReserved);		

		[DllImport("Kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, IntPtr lpSource,
			int dwMessageId, int dwLanguageId, System.Text.StringBuilder lpBuffer, 
			int nSize, string [] Arguments);

		/* Konstanten für FormatMessage */
		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

		/* Methode zur Überprüfung, ob eine Verbindung zu einer
		 * Internetadresse möglich ist */
		public static bool CheckConnection(string address, out string error)
		{
			error = null;
			// Verbindung prüfen
			if (InternetCheckConnection(address, 0, 0) != 0)
				return true;
			else
			{
				// Fehler ermitteln und in eine Beschreibung umwandeln
				int apiError = Marshal.GetLastWin32Error();
				StringBuilder message = new StringBuilder(1024);
				if (FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, (IntPtr)0, apiError, 0,
					message, 1024, null) > 0)
					error = message.ToString();
				else
					error = "API-Fehler " + apiError;
				
				return false;
			}
		}
	}
}
