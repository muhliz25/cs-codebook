using System;
using System.IO;

namespace Dateien_verschieben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei zu Demozwecken erst kopieren */
			try
			{
				File.Copy(@"C:\autoexec.bat", @"C:\autoexec.bat.copy");
			}
			catch { /* Fehler ignorieren */ }
			
			string sourceFileName = @"C:\autoexec.bat.copy";
			string destFileName = @"C:\Temp\autoexec.bat.copy";

			try
			{
				// Datei verschieben
				File.Move(sourceFileName, destFileName);

				Console.WriteLine("Datei erfolgreich verschoben");

			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Verschieben der Datei: " + ex.Message);
			}

			Console.ReadLine();
		}
	}
}
