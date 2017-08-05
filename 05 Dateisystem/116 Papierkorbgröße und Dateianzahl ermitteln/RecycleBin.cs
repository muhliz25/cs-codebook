using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class RecycleBin
	{
		/* Klasse für die Rückgabe der GetRecycleBinInfo-Methode */
		public class RecycleBinInfo
		{
			public long Size = 0;
			public long Count = 0;
		}

		/* Struktur, in der SHQueryRecycleBin die gelesenen Daten zurückgibt */
		[StructLayout(LayoutKind.Sequential, Pack=1)]
			private struct SHQUERYRBINFO
		{
			public int cbSize;
			public long i64Size;
			public long i64NumItems;
		}

		/* Deklaration der benötigten API-Funktionen und -Konstanten */
		[DllImport("shell32.dll", CharSet=CharSet.Auto)]
		static extern int SHQueryRecycleBin(string rootPath, 
			ref SHQUERYRBINFO shQueryRBInfo);

		[DllImport("Kernel32.dll")]
		private static extern uint GetDriveType(string lpRootPathName);

		private const uint DRIVE_FIXED = 3; 

		/* Methode zum Auslesen der Anzahl und der Größe der Dateien 
		 * im Papierkorb */
		public static RecycleBinInfo GetRecycleBinInfo(string rootPath)
		{
			// Die auszulesenden Laufwerke bestimmen
			ArrayList drives = new ArrayList();
			if (rootPath != null && rootPath != "")
			{
				drives.Add(rootPath);
			}
			else
			{
				// Alle Festplattenpartitionen ermitteln
				string[] logicalDrives = Environment.GetLogicalDrives();
				for (int i = 0; i < logicalDrives.Length; i++)
					if (GetDriveType(logicalDrives[i]) == DRIVE_FIXED)
						drives.Add(logicalDrives[i]);
			}

			// RecycleBinInfo-Instanz für das Ergebnis und SHQUERYRBINFO-Struktur
			// erzeugen
			RecycleBinInfo rbi = new RecycleBinInfo();
			SHQUERYRBINFO shQueryRBInfo = new SHQUERYRBINFO();

			// Größe der Struktur definieren, damit die API-Funktion diese beim
			// Schreiben kennt
			shQueryRBInfo.cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO));
   
			// Alle ermittelten Laufwerke durchgehen
			for (int i = 0; i < drives.Count; i++)
			{
				// SHQueryRecycleBin aufrufen und eventuelle Fehler auswerten
				int result = SHQueryRecycleBin(drives[i] + "\x0", 
					ref shQueryRBInfo);
				if (result == 0)
				{
					// Kein Fehler: Die gelesene Daten mit dem Ergebnis addieren
					rbi.Size += shQueryRBInfo.i64Size;
					rbi.Count += shQueryRBInfo.i64NumItems;
				}
				else
				{
					// Fehler beim Lesen: Ausnahme erzeugen
					throw new Exception(String.Format(
						"Fehler 0x{0:X} beim Lesen des Papierkorbs", result));
				}
			}
    
			return rbi;
		}
	}
}
