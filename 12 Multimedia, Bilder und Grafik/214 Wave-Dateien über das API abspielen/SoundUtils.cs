using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Multimedia
{
	public class SoundUtils
	{
		/* Deklaration der benötigten API-Funktionen und -Konstanten */
		[DllImport("winmm.dll", SetLastError=true)]
		private extern static int sndPlaySound(string lpszSound, int fuSound);

		private const int SND_ASYNC = 0x0001; // Asynchron abspielen
		private const int SND_LOOP = 0x0008;   // Das Abspielen wiederholen bis PlaySound erneut aufgerufen wird
		private const int SND_NODEFAULT = 0x0002; // Bei nicht gefundenen oder nicht unterstützten Dateien nicht den Defaultsound abspielen 

		[DllImport("kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, IntPtr lpSource,
			int dwMessageId, int dwLanguageId, System.Text.StringBuilder lpBuffer, 
			int nSize, string [] Arguments);

		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

		/* Methode zum Abspielen einer Wave-Datei */
		public static void PlayWaveFile(string fileName, bool async, bool loop)
		{
			// Überprüfen, ob die Datei existiert
			if (fileName != null && File.Exists(fileName) == false)
				throw new FileNotFoundException("Die Datei '" + fileName + "' existiert nicht", fileName);
	
			// Flags zusammensetzen
			int flags = SND_NODEFAULT;
			if (async) flags |= SND_ASYNC;
			if (loop) flags |= SND_LOOP;

			// Datei abspielen
			if (sndPlaySound(fileName, flags) == 0)
			{
				// Fehler auswerten
				StringBuilder message = new StringBuilder(1024);
				string errorMessage = "Fehler " + Marshal.GetLastWin32Error() +
					" beim Abspielen der Wave-Datei '" + fileName + "'";
				if (FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, (IntPtr)0, Marshal.GetLastWin32Error(), 
					0, message, 1024, null) > 0)
					errorMessage += ": " + message.ToString();
				throw new Exception(errorMessage);
			}
		}
	}
}
