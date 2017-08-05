using System;
using Addison_Wesley.Codebook.Application;

namespace Anwendung_beenden
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Alle laufenden Notepad-Prozesse beenden
			int count = AppUtils.CloseApplication("Notepad", null, 0);

			Console.WriteLine("{0} Prozesse beendet", count);

			Console.ReadLine();
		}
	}
}
