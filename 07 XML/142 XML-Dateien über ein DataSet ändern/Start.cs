using System;
using System.Data;
using System.IO;
using System.Windows.Forms; 

namespace XML_Dateien_verändern
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Der Dateiname der XML-Datei
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");

			// DataSet erzeugen und XML-Datei mit Schema einlesen
			DataSet dataSet = new DataSet();
			try
			{
				dataSet.ReadXml(xmlFileName, XmlReadMode.ReadSchema);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Lesen der XML-Datei: " + ex.Message,
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// DataTable referenzieren
			DataTable personTable = dataSet.Tables["person"];

			if (personTable == null)
			{
				MessageBox.Show("Das XML-Dokument enthält keine person-Elemente", 
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Zeile anfügen
			personTable.Rows.Add(new Object[] {1004, "Marvin", "", "Robot"});

			// Zeile suchen und löschen
			DataRow[] rows = personTable.Select("id = 1003");
			for (int i = 0; i < rows.Length; i++)
				rows[i].Delete();

			// Zeile suchen und aktualisieren
			rows = personTable.Select("id = 1001");
			if (rows.Length == 1)
			{
				rows[0]["type"] = "Traveller";
			}
			else
			{
				if (rows.Length == 0)
					Console.WriteLine("Person mit der Id 1001 nicht gefunden");
				else
					Console.WriteLine("Mehrere Personen mit der Id 1001 gefunden");
			}

			// XML-Datei mit Schema (unter einem anderen Namen) schreiben
			try
			{
				xmlFileName = xmlFileName.Replace("Persons", "Persons_New");
				dataSet.WriteXml(xmlFileName, XmlWriteMode.WriteSchema); 
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Schreiben der XML-Datei: " + ex.Message,
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
