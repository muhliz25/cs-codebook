using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace XML_Dateien_�ber_ein_DataSet_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Die Dateinamen
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");
			string xmlSchemaFileName = Path.Combine(Application.StartupPath, "Persons.xsd");

			// DataSet erzeugen
			DataSet dataSet = new DataSet();

			// XML-Schema und -Daten einlesen
			try
			{
				dataSet.ReadXmlSchema(xmlSchemaFileName);
				dataSet.ReadXml(xmlFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Einlesen der XML-Datei '" + xmlFileName + "': " +
					ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// Die Personen durchgehen
			DataTable dataTable = dataSet.Tables["person"];
			if (dataTable != null)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Console.WriteLine(dataTable.Rows[i]["id"]);
					Console.WriteLine(dataTable.Rows[i]["firstName"]);
					Console.WriteLine(dataTable.Rows[i]["lastName"]);
					Console.WriteLine(dataTable.Rows[i]["vehicleId"]);
					Console.WriteLine();
				}
			}
			else
			{
				Console.WriteLine("Keine Personen gespeichert"); 
			}

			// Die Fahrzeuge durchgehen
			dataTable = dataSet.Tables["vehicle"];
			if (dataTable != null)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Console.WriteLine(dataTable.Rows[i]["id"]);
					Console.WriteLine(dataTable.Rows[i]["type"]);
					Console.WriteLine();
				}
			}
			else
			{
				Console.WriteLine("Keine Fahrzeuge gespeichert"); 
			}

			Console.WriteLine();
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
