using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Datei_l�schen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei l�schen
			if (FileUtil.DeleteFile(@"c:\autoexec.bat.copy"))
				Console.WriteLine("Datei erfolgreich gel�scht");
			else
				Console.WriteLine("Datei nicht erfolgreich gel�scht");

			Console.ReadLine();
		}

	}
}
