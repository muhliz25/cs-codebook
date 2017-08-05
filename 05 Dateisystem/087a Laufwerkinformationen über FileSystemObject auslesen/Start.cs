using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Laufwerkinformationen_ber_FileSystemObject_auslesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Alle Laufwerke des Systems auslesen
			Drive[] drives = Drive.GetLocalDrives();

			// Das zurückgegebene Array durchgehen und den Laufwerk-Typ ermitteln
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
						Console.Write("Entfernbares Laufwerk");
						break;
      
					case Drive.DriveType.UnknownType:
						Console.Write("Unbekannter Typ");
						break;
				}
   
				// Größenangaben ausgeben
				Console.WriteLine("Größe: {0} Byte.", drives[i].TotalSize); 
				Console.WriteLine("Freier Platz: {0} Byte.", drives[i].FreeSpace); 
				Console.WriteLine();
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}

}
