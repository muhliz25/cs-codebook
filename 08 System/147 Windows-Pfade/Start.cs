using System;
using System.Text;
using System.Runtime.InteropServices; 

namespace Windows_Pfade
{
	class Start
	{
		/* Deklaration der API-Funktion GetWindowsDirectory */
		[DllImport("kernel32.dll")]
		private static extern uint GetWindowsDirectory(StringBuilder lpBuffer,
			uint uSize);
		
		[STAThread]
		static void Main(string[] args)
		{
			// Windows-Systempfad auslesen
			string windowsSystemPath = System.Environment.SystemDirectory;

			// Windows-Pfad auslesen
			const int MAX_PATH = 260;
			StringBuilder buffer = new StringBuilder(MAX_PATH + 1);
			string windowsPath = null;
			if (GetWindowsDirectory(buffer, MAX_PATH + 1) > 0)
				windowsPath = buffer.ToString();

			// Spezielle Systemordner ermitteln
			string programPath = Environment.GetFolderPath(
				Environment.SpecialFolder.ProgramFiles);
			string desktopPath = Environment.GetFolderPath(
				Environment.SpecialFolder.DesktopDirectory);
			string applicationDataPath = Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData);
			string recentPath = Environment.GetFolderPath(
				Environment.SpecialFolder.Recent);

			Console.WriteLine("Windows-Pfad: {0}", windowsPath);
			Console.WriteLine("Windows-System-Pfad: {0}", windowsSystemPath);
			Console.WriteLine("Programmordner: {0}", programPath);
			Console.WriteLine("Desktop: {0}", desktopPath);
			Console.WriteLine("Anwendungsdaten: {0}", applicationDataPath);
			Console.WriteLine("Zuletzt ge�ffnete Dokumente: {0}", recentPath);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
