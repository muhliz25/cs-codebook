using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtils
	{
		/* Aufz�hlung f�r die m�glichen Vergleichstypen */
		public enum FileCompareMethod
		{
			Date,
			Content,
			DateAndContent
		}

		/* Methode zum Vergleichen von zwei Dateien */
		public static bool CompareFiles(string fileName1, string fileName2,
			FileCompareMethod compareMethod)
		{
			// Wenn beide Dateinamen identisch sind true zur�ckgeben
			if (fileName1 == fileName2)
				return true;

			// �ber FileInfo-Objekte das Datum der letzten �nderung vergleichen
			// sofern dies gew�nscht ist
			// Anmerkung: Das Erstelldatum wird nicht verglichen, weil dieses
			// beim Kopieren von Dateien auf das aktuelle Datum gesetzt wird
			if (compareMethod == FileCompareMethod.DateAndContent || 
				compareMethod == FileCompareMethod.Date)
			{
				FileInfo fi1 = new FileInfo(fileName1);
				FileInfo fi2 = new FileInfo(fileName2);
				if (fi1.LastWriteTime != fi2.LastWriteTime)
					return false;
			}

			// Den Inhalt vergleichen sofern dies gew�nscht ist
			if (compareMethod == FileCompareMethod.DateAndContent || 
				compareMethod == FileCompareMethod.Content)
			{
				// FileStream-Objekte f�r den Vergleich erzeugen
				FileStream fs1 = new FileStream(fileName1, FileMode.Open);
				FileStream fs2 = new FileStream(fileName2, FileMode.Open);

				// Die Dateigr��e vergleichen
				if (fs1.Length != fs2.Length)
					return false;

				// Die Dateien Byte f�r Byte vergleichen
				int fileByte1, fileByte2; 
				do
				{
					fileByte1 = fs1.ReadByte();
					fileByte2 = fs2.ReadByte();
				} while (fileByte1 == fileByte2 && fileByte1 != -1);

				// Die Streams schlie�en
				fs1.Close();
				fs2.Close();

				// Das Ergebnis zur�ckgeben: Die Dateien sind gleich wenn an
				// dieser Stelle die zuletzt gelesenen Bytes identisch sind
				return (fileByte1 == fileByte2);
			}

			return true;
		}
	}
}
