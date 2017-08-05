using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Excel_Arbeitsmappen_erweitern
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Für die wiederholte Ausführung der Demo die Datei zunächst aus einem
			// Original umkopieren
			if (File.Exists(Path.Combine(Application.StartupPath, "Einkommensberechnung.xls")))
				File.Delete(Path.Combine(Application.StartupPath, "Einkommensberechnung.xls"));
			File.Copy(Path.Combine(Application.StartupPath, "Einkommensberechnung_Orig.xls"),
				Path.Combine(Application.StartupPath, "Einkommensberechnung.xls"));
			
			// Excel-Instanz erzeugen und sichtbar schalten
			Excel.Application excel = new Excel.ApplicationClass();
			excel.Visible = true;

			// Arbeitsmappe öffnen
			object missing = Missing.Value;
			string fileName = Path.Combine(Application.StartupPath, "Einkommensberechnung.xls");
			Excel.Workbook workbook = excel.Workbooks.Open(fileName, missing, missing, missing,
				missing, missing, missing, missing, missing, missing, missing, missing, missing, 
				missing, missing);

			// Arbeitsblatt 'Einkommensberechnung' referenzieren
			Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets["Einkommensberechnung"];

			// Suchen der ersten Zeile, die in der ersten Spalte keine Daten mehr enthält
			int row = 0;
			Excel.Range range = null;
			do
			{
				row++;
				range = (Excel.Range)worksheet.Cells[row, 1];
				if (range.Value2 == null)
					break;
			} while (true);

			// Die erste Zelle der letzten Datenzeile referenzieren
			range = (Excel.Range)worksheet.Cells[row - 1, 1];

			// Alternative: Ausgehend von der Zelle A1 die letzte Zelle suchen, die noch Daten enthält
			// Excel.Range range = worksheet.get_Range("A1", missing).get_End(Excel.XlDirection.xlDown);
			
			// Eine Zeile einfügen
			range.EntireRow.Insert(missing, missing);

			// Die erste Zelle in der aktuellen Zeile referenzieren (zur Sicherheit)
			range = (Excel.Range)range.EntireRow.Cells[1, 1];

			// Die Daten der aktuellen Zeile in die neue oben kopieren
			range.get_Offset(-1, 0).Value2 = range.Value2;
			range.get_Offset(-1, 1).Value2 = range.get_Offset(0, 1).Value2;

			// Daten in die aktuelle Zeile einfügen
			range.Value2 = 2004;
			range = range.get_Offset(0, 1);
			range.Value2 = 185000;

			// Eine weitere Zeile einfügen, Daten kopieren und neue Daten einfügen
			range.EntireRow.Insert(missing, missing);
			range = (Excel.Range)range.EntireRow.Cells[1, 1];
			range.get_Offset(-1, 0).Value2 = range.Value2;
			range.get_Offset(-1, 1).Value2 = range.get_Offset(0, 1).Value2;
			range.Value2 = 2005;
			range = range.get_Offset(0, 1);
			range.Value2 = 221000;

			// Arbeitsmappe speichern 
			workbook.Save();

			// Excel beenden
			excel.Quit();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
