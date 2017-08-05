using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FolderUtil
	{
		/* Deklaration der Windows-API-Funktion SHFileOperation */
		[DllImport("shell32.dll", CharSet=CharSet.Auto)]
		static extern int SHFileOperation(ref SHFILEOPSTRUCT fileOp);

		/* Konstanten für SHFileOperation (aus ShellAPI.h) */
		// Datei oder Ordner kopieren
		private const int FO_COPY = 0x0002;
		// Rückgängigmachen erlauben
		private const int FOF_ALLOWUNDO  = 0x0040;
		// keine Nachfrage beim Anwender
		private const int FOF_NOCONFIRMATION = 0x0010;

		/* Struktur zur Definition der Dateioperation */
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			public struct SHFILEOPSTRUCT
		{
			public IntPtr hwnd; 
			public int wFunc;
			public string pFrom;
			public string pTo;
			public short fFlags; 
			[MarshalAs(UnmanagedType.Bool)]    
			public bool fAnyOperationsAborted; 
			public IntPtr hNameMappings; 
			public string lpszProgressTitle; 
		}

		/* Methode zum Kopieren. Übergeben werden der Quell- und der 
		 * Zielordnername und ein boolescher Wert, der festlegt, ob der Anwender
		 * vor dem Überschreiben vorhandener Ordner gefragt werden soll, ob diese
		 * überschrieben werden sollen */
		public static bool APICopy(string sourceFolderName, 
			string destFolderName, bool confirmOverwrites)
		{
			// Überprüfen, ob der dem Zielordner übergeordnete Ordner existiert, 
			// um zum einen das Problem zu vermeiden, dass SHFileOperation beim 
			// Kopieren auf ein nicht existierendes Laufwerk ohne Fehler 
			// ausgeführt wird und zum anderen den Fehler zu vermeiden, den
			// SHFileOperation meldet, wenn dieser Ordner nicht existiert.
			int i = destFolderName.LastIndexOf("\\");
			string destParentFolder = null;
			if (i > 0)
			{
				destParentFolder = destFolderName.Substring(0, i);
				if (Directory.Exists(destParentFolder) == false)
					// Ziel-Parent-Ordner existiert nicht: Ausnahme werfen
					throw new IOException("Der Ziel-Ordner " + destParentFolder +
						" existiert nicht");
			}

			// Überprüfen, ob der Quellordner existiert
			if (Directory.Exists(sourceFolderName) == false)
				throw new IOException("Der Quell-Ordner " + sourceFolderName +
					" existiert nicht");
         
			// Struktur für die Dateiinformationen erzeugen
			SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT();

			// (Unter-)Funktion definieren (ShFileOperation kann auch Dateien und
			// Ordner löschen, verschieben oder umbenennen)
			fileOp.wFunc = FO_COPY;
    
			// Quelle und Ziel definieren. Dabei müssen mehrere Datei- oder
			// Ordnerangaben über 0-Zeichen getrennt werden. Am Ende muss ein
			// zusätzliches 0-Zeichen stehen
			fileOp.pFrom = sourceFolderName + "\x0\x0";
			fileOp.pTo = destFolderName + "\x0\x0";
    
			// Flags setzen, sodass ein Rückgängigmachen möglich ist und 
			// dass - je nach Argument confirmOverwrites - keine Nachfrage 
			// beim Überschreiben von Ordnern beim Anwender erfolgt
			if (confirmOverwrites) 
				fileOp.fFlags = FOF_ALLOWUNDO;
			else
				fileOp.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;

			// ShFileOperation unter Übergabe der Struktur aufrufen
			int result = SHFileOperation(ref fileOp);

			// Erfolg oder Misserfolg zurückgeben. SHFileOperation liefert
			// 0 zurück, wenn kein Fehler aufgetreten ist, ansonsten einen
			// Wert ungleich 0
			return (result == 0);
		}
	}
}
