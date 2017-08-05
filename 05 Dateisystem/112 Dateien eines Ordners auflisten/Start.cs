using System;
using System.IO;

namespace Ordner_Dateien
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname festlegen
			string folderName = "c:\\";

			try
			{
				// DirectoryInfo-Objekt erzeugen
				DirectoryInfo di = new DirectoryInfo(folderName);

				// Dateien ermitteln
				FileInfo[] files = di.GetFiles();

				// Alle Dateien durchgehen und den Namen ausgeben
				for (int i = 0; i < files.Length; i++)
					Console.WriteLine(files[i].Name);
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Ermitteln der Dateien: {0}.", ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
