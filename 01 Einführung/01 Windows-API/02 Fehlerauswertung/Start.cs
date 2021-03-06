using System;
using System.Text;
using System.Runtime.InteropServices;

namespace FormatMessage
{
	
	class Start
	{
		/* Deklaration der ben�tigten API-Funktionen und -Konstanten */
		[DllImport("Kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, IntPtr lpSource,
			int dwMessageId, int dwLanguageId, System.Text.StringBuilder lpBuffer, 
			int nSize, string[] Arguments);

		[DllImport("kernel32.dll")]
		static extern IntPtr GetModuleHandle(string lpFileName);
		
		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
		private const int FORMAT_MESSAGE_FROM_HMODULE = 0x0800;

		/* Deklaration der Funktion InternetGetConnectedState zu Demozwecken */
		[DllImport("wininet.dll")]
		public static extern int InternetGetConnectedState(out int flags, int reserved);

		[STAThread]
		static void Main(string[] args)
		{
			// Den Text des System-Fehlers 1314 ("Der Client besitzt ein erforderliches 
			// Recht nicht") auslesen
			StringBuilder message = new StringBuilder(1024);
			int apiError = 1314;
			if (FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, (IntPtr)0, apiError, 0, message, 1024, null) > 0)
				Console.WriteLine(message.ToString());
			else
				Console.WriteLine("Die Meldung f�r den Fehler {0} konnte nicht ermittelt werden", apiError);

			// Die Funktion InternetGetConnectedState aufrufen, damit die DLL wininet.dll 
			// geladen wird
			int flags;
			InternetGetConnectedState(out flags, 0);

			// Den Text des Fehlers 12002 ("Das Zeitlimit f�r den Vorgang wurde erreicht") 
			// aus der Datei wininet.dll auslesen
			IntPtr hModule = GetModuleHandle("wininet.dll");
			message = new StringBuilder(1024);
			apiError = 12002;
			if (FormatMessage(FORMAT_MESSAGE_FROM_HMODULE, hModule, apiError, 0, message, 1024, null) > 0)
				Console.WriteLine(message.ToString());
			else
				Console.WriteLine("Die Meldung f�r den Fehler {0} konnte nicht ermittelt werden", apiError);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
