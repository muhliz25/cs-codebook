using System;

namespace Laufwerke
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Namen der logischen Laufwerke des Systems ermitteln
			string[] driveNames = Environment.GetLogicalDrives();

			// Alle logischen Laufwerke durchgehen
			for (int i = 0; i < driveNames.Length; i++)
				Console.WriteLine(driveNames[i]);

			Console.ReadLine();
		}
	}
}
