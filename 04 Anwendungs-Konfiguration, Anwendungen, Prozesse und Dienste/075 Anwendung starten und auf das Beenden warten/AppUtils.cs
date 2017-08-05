using System;
using System.Diagnostics;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zum Starten einer Anwendung mit optionalem Warten
		 * auf deren Beendigung */
		public static void StartApplication(string exeFileName, string arguments,
			bool maximized, bool waitForExit)
		{
			// ProcessStartInfo-Instanz erzeugen und initialisieren
			ProcessStartInfo psi = new ProcessStartInfo(exeFileName);
			if (arguments != "")
				psi.Arguments = arguments;
			if (maximized)
				psi.WindowStyle = ProcessWindowStyle.Maximized;
			psi.UseShellExecute = true;

			// Prozess starten
			Process process = Process.Start(psi);

			// Auf die Beendigung des Prozesses warten, sofern dies gewünscht ist
			if (waitForExit)
				process.WaitForExit();
		}
	}
}
