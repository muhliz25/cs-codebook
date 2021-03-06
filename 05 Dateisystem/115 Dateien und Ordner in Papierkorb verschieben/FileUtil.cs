using System;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Deklaration ben�tiger API-Funktionen,- Konstanten und -Strukturen */
		[DllImport("shell32.dll", CharSet=CharSet.Auto)]
		static extern int SHFileOperation(ref SHFILEOPSTRUCT fileOp);

		private const int FO_DELETE = 0x0003;          // Datei/Ordner l�schen 
		private const int FOF_ALLOWUNDO  = 0x0040;     // Undo erm�glichen
		private const int FOF_NOCONFIRMATION = 0x0010; // keine Nachfrage

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

		/* Methode zum Verschieben einer Datei in den Papierkorb */
		public static bool MoveToRecycleBin(string path)
		{
			// Struktur f�r die Dateiinformationen erzeugen
			SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT();

			// Quelle definieren. Dabei m�ssen mehrere Datei- oder
			// Ordnerangaben �ber 0-Zeichen getrennt werden.
			// Am Ende muss ein zus�tzliches 0-Zeichen stehen
			fileOp.pFrom = path + "\x0\x0";

			// Flags setzen, sodass ein R�ckg�ngigmachen m�glich ist und
			// keine Nachfrage beim Anwender erfolgt
			fileOp.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;

			// (Unter-)Funktion definieren
			fileOp.wFunc = FO_DELETE;

			// ShFileOperation unter �bergabe der Struktur aufrufen
			int result = SHFileOperation(ref fileOp);

			// Erfolg oder Fehler zur�ckmelden. SHFileOperation liefert 0
			// zur�ck, wenn kein Fehler aufgetreten ist
			return (result == 0);
		}
	}
}
