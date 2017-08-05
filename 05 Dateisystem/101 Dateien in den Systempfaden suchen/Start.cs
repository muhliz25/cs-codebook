using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Dateien_in_den_Systempfaden_suchen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Suchen der Datei notepad.exe
			string fileName = FileUtil.FindFileInSystemPaths("notepad.exe");
			if (fileName != null)
				Console.WriteLine("Gefunden: {0}", fileName);
			else
				Console.WriteLine("Nicht gefunden");

			// Suchen der Datei java.exe
			fileName = FileUtil.FindFileInSystemPaths("java.exe");
			if (fileName != null)
				Console.WriteLine("Gefunden: {0}", fileName);
			else
				Console.WriteLine("Nicht gefunden");

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
