using System;
using System.IO;
using System.Diagnostics;

namespace Dateiversion
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Vollen Dateinamen der Datei kernel32.dll ermitteln
			string fileName = Path.Combine(Environment.SystemDirectory,
				"kernel32.dll");

			// Versionsinformationen auslesen
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);

			// Version ausgeben
			Console.WriteLine("Version der Datei {0}", fileName);
			Console.WriteLine("Major: {0}", fileVersionInfo.FileMajorPart);
			Console.WriteLine("Minor: {0}", fileVersionInfo.FileMinorPart);
			Console.WriteLine("Build: {0}", fileVersionInfo.FileBuildPart);
			Console.WriteLine("Revision: {0}", fileVersionInfo.FilePrivatePart);
			Console.WriteLine("Version: {0}", fileVersionInfo.FileVersion); 

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}