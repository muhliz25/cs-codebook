using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Application;

namespace Dateien_öffnen
{
	class Start
	{

		[STAThread]
		static void Main(string[] args)
		{
			// Der Dateiname
			string fileName = Path.Combine(Application.StartupPath, "dontpanic.bmp");

			// Prozess für die mit der Datei assoziierten Anwendung
			// mit einem maximierten Fenster starten
			Console.WriteLine("Starte {0}", fileName);
			try
			{
				AppUtils.OpenFileWithAssociatedApp(fileName, false);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
         
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
