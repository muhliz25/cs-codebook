using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Anwendungs_Ordner
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname der Anwendung auslesen
			Console.WriteLine("Ordnername der Anwendung: '{0}'",
				FileUtil.GetApplicationFolderName());
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}
	}
}
