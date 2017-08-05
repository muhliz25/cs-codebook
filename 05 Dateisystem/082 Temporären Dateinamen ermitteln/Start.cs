using System;

namespace Temporaeren_Dateinamen_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Neuen Dateinamen für eine temporäre Datei ermitteln
			string tempFileName = System.IO.Path.GetTempFileName();

			Console.WriteLine(tempFileName);

			Console.ReadLine();
		}
	}
}
