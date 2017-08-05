using System;
using System.IO;
using Addison_Wesley.Codebook.Filesystem;

namespace Kurzer_Dateiname
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateinamen der Lizenz-Textdatei des .NET-Framework-SDK ermitteln 
			string fileName = Path.Combine(Environment.GetFolderPath(
				Environment.SpecialFolder.ProgramFiles), 
				@"Microsoft Visual Studio .NET\FrameworkSDK\license.txt");

			try
			{
				// Ermitteln des kurzen Dateinamens
				string shortName = FileUtil.GetShortName(fileName);

				Console.WriteLine("Der kurze Dateiname von\r\n{0}\r\nist\r\n{1}", fileName, shortName);			
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Ermitteln des kurzen Namens: {0}",
					ex.Message);
			}

			Console.ReadLine();
		}
	}
}
