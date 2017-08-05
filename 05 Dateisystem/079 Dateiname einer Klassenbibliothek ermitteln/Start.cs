using System;
using Addison_Wesley.Codebook.Filesystem.DemoLib;

namespace Bibliotheks_Dateiname
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Instanz der Demo-Klasse in der Klasenbibliothek erzeugen
			Demo d = new Demo();

			// Dateiname der Klassenbibliothek ermitteln
			Console.WriteLine("Dateiname der Klassenbibliothek:\r\n{0}", 
				d.GetFilename());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
