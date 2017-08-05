using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Datei_löschen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei löschen
			if (FileUtil.DeleteFile(@"c:\autoexec.bat.copy"))
				Console.WriteLine("Datei erfolgreich gelöscht");
			else
				Console.WriteLine("Datei nicht erfolgreich gelöscht");

			Console.ReadLine();
		}

	}
}
