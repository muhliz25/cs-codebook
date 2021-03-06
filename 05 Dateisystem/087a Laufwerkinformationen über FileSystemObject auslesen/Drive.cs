using System;

namespace Addison_Wesley.Codebook.Filesystem
{
	/* Klasse, die ein Laufwerk repr�sentiert */
	public class Drive
	{
		/* Aufz�hlung f�r den Laufwerktyp */
		public enum DriveType
		{
			CDRom = Scripting.DriveTypeConst.CDRom,
			Fixed = Scripting.DriveTypeConst.Fixed,
			RamDisk = Scripting.DriveTypeConst.RamDisk,
			Remote = Scripting.DriveTypeConst.Remote,
			Removable = Scripting.DriveTypeConst.Removable,
			UnknownType = Scripting.DriveTypeConst.UnknownType
		}

		/* Eigenschaften */
		public string DriveLetter;
		public DriveType Type;
		public long TotalSize;
		public long AvailableSpace;
		public long FreeSpace;
		public bool IsReady;

		/* Statische Methode zum Auslesen aller Laufwerke des Systems */
		public static Drive[] GetLocalDrives()
		{
			// Instanz der Klasse FileSystemObject erzeugen
			Scripting.FileSystemObject fso = new Scripting.FileSystemObjectClass();

			// Ergebnis-Array erzeugen
			Drive[] drives = new Drive[fso.Drives.Count];

			// Alle Laufwerke �ber die Drives-Auflistung durchgehen, deren Typ, Gr��e
			// und freien Platz ermitteln und als Drive-Objekt im Array speichern
			int index = 0;
			foreach (Scripting.Drive drive in fso.Drives)
			{
				drives[index] = new Drive();
				drives[index].DriveLetter = drive.DriveLetter;
				drives[index].Type = (DriveType)drive.DriveType;
				drives[index].IsReady = drive.IsReady;

				// Voreinstellung f�r die Gr��enangaben
				drives[index].AvailableSpace = -1;
				drives[index].FreeSpace = -1;
				drives[index].TotalSize = -1;

				if (drive.IsReady)
				{
					// Die als COM-Variant angegebenen Gr��enangaben in einen Long-Wert
					// umwandeln
					try
					{
						drives[index].AvailableSpace =
							Convert.ToInt64(drive.AvailableSpace);
						drives[index].FreeSpace = Convert.ToInt64(drive.FreeSpace);
						drives[index].TotalSize = Convert.ToInt64(drive.TotalSize);
					}
					catch {}
				}
				index++;
			}

			// Ergebnis-Array zur�ckgeben
			return drives;
		}
	}
}
