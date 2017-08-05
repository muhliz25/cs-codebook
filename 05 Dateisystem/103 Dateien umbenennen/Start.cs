using System;
using System.IO;

namespace Dateien_umbenennen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei zu Demozwecken erst kopieren */
			try
			{
				System.IO.File.Copy(@"C:\autoexec.bat", @"C:\autoexec.bat.copy");
			}
			catch { /* Fehler ignorieren */ }
			
			string sourceFileName = @"C:\autoexec.bat.copy";
			string destFileName = @"C:\autoexec.bat.bak";
			
			try
			{
				// Datei umbenennen
				File.Move(sourceFileName, destFileName);

				Console.WriteLine("Datei erfolgreich umbenannt");
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Umbenennen der Datei: " + ex.Message);
			}

			Console.ReadLine();
		}
	}
}
