using System;
using Addison_Wesley.Codebook.Application;

namespace Anwendung_prüfen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Überprüfen, ob Outlook läuft
			if (AppUtils.ApplicationRunning("Outlook", "Microsoft Outlook"))
				Console.WriteLine("Outlook läuft");
			else
				Console.WriteLine("Outlook läuft nicht");

			Console.ReadLine();
		}
	}
}
