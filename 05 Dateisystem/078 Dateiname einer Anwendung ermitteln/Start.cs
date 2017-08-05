using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Anwendungs_Dateiname
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname der Anwendung auslesen
			Console.WriteLine("Dateiname der Anwendung: '{0}'",
				FileUtil.GetApplicationFilename());
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
