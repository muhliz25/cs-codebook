using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Laufwerk_Typ
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Festplatten-Partitionen ermitteln ...
			Console.WriteLine("Alle Festplatten-Partitionen:");
			Drive[] drives = Drive.GetLocalDrives(Drive.DriveType.Fixed);

			// ...und durchgehen
			for (int i = 0; i < drives.Length; i++)
				Console.WriteLine(drives[i].DriveLetter);

			// CD-ROM-Laufwerke ermitteln ... 
			Console.WriteLine("\r\nAlle CD-ROM-Laufwerke:");
			drives = Drive.GetLocalDrives(Drive.DriveType.CDRom);

			// ... und durchgehen
			for (int i = 0; i < drives.Length; i++)
				Console.WriteLine(drives[i].DriveLetter);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
