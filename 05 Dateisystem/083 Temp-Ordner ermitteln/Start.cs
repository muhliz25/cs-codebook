using System;

namespace Temp_Ordner
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Ermitteln des Ordners für temporäre Dateien
			string tempFolder = System.IO.Path.GetTempPath(); 

			Console.WriteLine(tempFolder);

			Console.ReadLine();
		}
	}
}
