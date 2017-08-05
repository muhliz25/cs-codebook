using System;
using System.IO;
using Addison_Wesley.Codebook.Application;

namespace Anwendung_starten_und_auf_das_Beenden_warten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateinamen zusammensetzen
			string exeFileName = Path.Combine(Environment.SystemDirectory, "notepad.exe");
			string arguments = Path.Combine(Environment.SystemDirectory, "eula.txt");

			// Anwendung starten und warten, bis diese beendet ist
			Console.WriteLine("Starte '{0}' und warte auf die Beendigung ... ", exeFileName);
			AppUtils.StartApplication(exeFileName, arguments, false, true);
			Console.WriteLine("Anwendung wurde beendet");
			Console.ReadLine();
		}
	}
}
