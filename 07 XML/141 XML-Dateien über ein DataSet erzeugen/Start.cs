using System;
using System.Data;
using System.IO;
using System.Windows.Forms; 

namespace XML_Dateien_erzeugen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Der Dateiname der XML-Datei
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");

			// Überprüfen, ob die Datei existiert
			if (File.Exists(xmlFileName))
			{
				if (MessageBox.Show("Die Datei '" + xmlFileName + 
					"' existiert bereits.\r\n\r\nWollen Sie diese Datei überschreiben?",
					Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.No)
					return;
			}

			// DataSet erzeugen und initialisieren
			DataSet dataSet = new DataSet();
			dataSet.DataSetName = "persons";
			dataSet.Namespace = "http://www.addison-wesley.de/codebook/persons";
			dataSet.Prefix = "per";

			// Tabelle erzeugen
			DataTable dataTable = dataSet.Tables.Add("person");

			// Spalten definieren
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("firstname", typeof(string));
			dataTable.Columns.Add("lastname", typeof(string));
			dataTable.Columns.Add("type", typeof(string));

			// Zeilen anfügen
			dataTable.Rows.Add(new Object[] {1000, "Zaphod", "Beeblebrox", "Alien"});
			dataTable.Rows.Add(new Object[] {1001, "Ford", "Prefect", "Alien"});
			dataTable.Rows.Add(new Object[] {1002, "Tricia", "McMillan", "Earthling"});
			dataTable.Rows.Add(new Object[] {1003, "Arthur", "Dent", "Earthling"});

			// XML-Datei mit Schema schreiben
			try
			{
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
