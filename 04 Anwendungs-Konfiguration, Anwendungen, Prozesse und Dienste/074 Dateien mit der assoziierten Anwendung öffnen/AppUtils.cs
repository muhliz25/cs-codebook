using System;
using System.Diagnostics;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zum Öffnen einer Datei mit der assoziierten Anwendung */
		public static void OpenFileWithAssociatedApp(string fileName, bool maximized)
		{
			// ProcessStartInfo-Instanz erzeugen und initialisieren
			ProcessStartInfo psi = new ProcessStartInfo(fileName);
			if (maximized)
				psi.WindowStyle = ProcessWindowStyle.Maximized;
			psi.UseShellExecute = true;

			// Prozess starten
			Process.Start(psi);
		}
	}
}
