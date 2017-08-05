using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Datei_in_Papierkorb_verschieben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei als Beispiel erst kopieren
			File.Copy(@"c:\autoexec.bat", @"c:\autoexec.bat.copy", true);

			// Ordner als Beispiel erst erzeugen
			Directory.CreateDirectory(@"C:\Temp\RecycleBinDemoFolder");

			// Datei in den Papierkorb verschieben
			if (FileUtil.MoveToRecycleBin(@"c:\autoexec.bat.copy"))
				Console.WriteLine("Datei erfolgreich in den Papierkorb verschoben.");
			else
				Console.WriteLine("Datei nicht erfolgreich in den Papierkorb verschoben.");

			// Ordner in den Papierkorb verschieben
			if (FileUtil.MoveToRecycleBin(@"C:\Temp\RecycleBinDemoFolder"))
				Console.WriteLine("Ordner erfolgreich in den Papierkorb verschoben.");
			else
				Console.WriteLine("Ordner nicht erfolgreich in den Papierkorb " +
					"verschoben.");

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
