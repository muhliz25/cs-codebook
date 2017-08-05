using System;
using System.Runtime.InteropServices; 

namespace Addison_Wesley.Codebook.Filesystem
{
	/* Klasse, die ein Laufwerk repräsentiert */
	public class Drive
	{
		/* Konstanten für GetDriveType */
		private const uint DRIVE_UNKNOWN = 0;     // Typ konnte nicht ermittelt
		// werden
		private const uint DRIVE_NO_ROOT_DIR = 1; // Pfad ist ungültig
		private const uint DRIVE_REMOVABLE = 2;   // Entfernbares LW
		private const uint DRIVE_FIXED = 3;       // Festplatten-LW
		private const uint DRIVE_REMOTE = 4;      // Netzwerklaufwerk
		private const uint DRIVE_CDROM = 5;       // CD-ROM-Laufwerk
		private const uint DRIVE_RAMDISK = 6;     // RAM-Disk

		/* Deklaration der API-Funktion GetDriveType */
		[DllImport("Kernel32.dll")]
		private static extern uint GetDriveType(string lpRootPathName);

		/* Aufzählung für den Laufwerkstyp */
		public enum DriveType: uint
		{
			CDRom = DRIVE_CDROM,
			Fixed = DRIVE_FIXED,
			RamDisk = DRIVE_RAMDISK,
			Remote = DRIVE_REMOTE,
			Removable = DRIVE_REMOVABLE,
			UnknownType = DRIVE_UNKNOWN
		}

		/* Eigenschaften */
		public string DriveLetter;
		public DriveType Type;

		/* Statische Methode zum Auslesen aller Laufwerke des Systems */
		public static Drive[] GetLocalDrives()
		{
			// Alle Laufwerke über Environment.GetLogicalDrives
			string[] logicalDrives = Environment.GetLogicalDrives();

			// Ergebnis-Array erzeugen
			Drive[] drives = new Drive[logicalDrives.Length];

			// Die logischen Laufwerke durchgehen
			for (int i = 0; i < logicalDrives.Length; i++)
			{
				// Drive-Instanz erzeugen
				drives[i] = new Drive();

				// Laufwerk-Wurzelordner ohne Doppelpunkt und Backslash speichern
				drives[i].DriveLetter = logicalDrives[i].Replace(":\\", "");
     
				// Typ des Laufwerks ermitteln und speichern
				drives[i].Type = (DriveType)GetDriveType(logicalDrives[i]);
			}

			// Ergebnis-Array zurückgeben
			return drives;
		}
	}
}

