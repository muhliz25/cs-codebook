using System;
using Addison_Wesley.Codebook.Filesystem.DemoLib;

namespace Dateiname_einer_Klassenbibliothek_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Instanz der Demo-Klasse in der Klasenbibliothek
			// erzeugen
			Demo d = new Demo();

			// Dateiname der Klassenbibliothek ermitteln
			Console.WriteLine("Ordnername der Klassenbibliothek:\r\n{0}", 
				d.GetFolderName());

			Console.ReadLine();
		}
	}
}
