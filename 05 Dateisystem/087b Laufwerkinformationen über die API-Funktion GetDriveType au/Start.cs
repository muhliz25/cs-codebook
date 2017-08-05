using System;
using System.Runtime.InteropServices;
using Addison_Wesley.Codebook.Filesystem;

namespace Laufwerkinformationen_ber_die_API_Funktion_GetDriveType_auslesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Alle Laufwerke des Systems auslesen
			Drive[] drives = Drive.GetLocalDrives();

			// Das zurckgegebene Array durchgehen
			// und den Laufwerk-Typ ermitteln
			for (int i = 0; i < drives.Length; i++)
			{
				// Laufwerk-Buchstabe auslesen
				Console.Write(drives[i].DriveLetter + ": "); 

				// Typ des Laufwerks auslesen
				switch (drives[i].Type)
				{
					case Drive.DriveType.CDRom: 
						Console.WriteLine("CD-ROM");
						break;

					case Drive.DriveType.Fixed:  
						Console.WriteLine("Festplatten-Partition");
						break;
					
					case Drive.DriveType.RamDisk:
						Console.WriteLine("Ram-Disk");
						break;
					
					case Drive.DriveType.Remote:
						Console.WriteLine("Netzwerklaufwerk");
						break;
					
					case Drive.DriveType.Removable:
						Console.WriteLine("Entfernbares Laufwerk");
						break;
					
					case Drive.DriveType.UnknownType:
						Console.WriteLine("Unbekannter Typ");
						break;
				}
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
