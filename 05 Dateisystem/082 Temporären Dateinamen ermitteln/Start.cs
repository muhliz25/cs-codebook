using System;

namespace Temporaeren_Dateinamen_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Neuen Dateinamen f�r eine tempor�re Datei ermitteln
			string tempFileName = System.IO.Path.GetTempFileName();

			Console.WriteLine(tempFileName);

			Console.ReadLine();
		}
	}
}
