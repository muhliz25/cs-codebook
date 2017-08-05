using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Datei_kopieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei kopieren
			if (FileUtil.CopyFile(@"C:\autoexec.bat", @"c:\autoexec.bat.copy"))
				Console.WriteLine("Datei erfolgreich kopiert");
			else
				Console.WriteLine("Datei nicht erfolgreich kopiert");

			Console.ReadLine();
		}

	}
}
