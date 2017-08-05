using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Anwendungen_starten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateinamen zusammensetzen
			string exeFileName = Path.Combine(Environment.SystemDirectory, "notepad.exe");
			string arguments = Path.Combine(Environment.SystemDirectory, "eula.txt");

			// Anwendungs-Prozess mit einem maximierten Fenster starten
			ProcessStartInfo psi = new ProcessStartInfo(exeFileName, arguments);
			psi.WindowStyle = ProcessWindowStyle.Maximized;
			try
			{
				Process.Start(psi);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Starten der Anwendung: " + 
					ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
