using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace XML_Dateien_lesen
{
	/* Klasse zur Speicherung der Daten einer Person */
	class Person
	{
		public string Id;
		public string FirstName;
		public string LastName;
		public string Type;
	}

	/* Start-Klasse */
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Der Dateiname
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");

			// XmlTextReader erzeugen
			XmlTextReader xmlReader = null;
			try
			{
				xmlReader = new XmlTextReader(xmlFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Einlesen der XML-Datei '" + xmlFileName + 
					"': " + ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// Auflistung für die Personen erzeugen
			ArrayList persons = new ArrayList();

			// Die einzelnen Knoten einlesen und durchgehen
			Person person = null;
			try
			{
				while (xmlReader.Read())
				{
					// Überprüfen, ob es sich beim aktuellen Knoten um einen Start-Tag
					// handelt
					if (xmlReader.NodeType == XmlNodeType.Element)
					{
						// Überprüfen, ob es sich um ein person-Element handelt
						if (xmlReader.Name == "person")
						{
							// Neue Person: Neues Person-Objekt erzeugen ...
							person = new Person();

							// ... und in der Auflistung ablegen
							persons.Add(person);
            
							// Das Attribut 'id' einlesen
							person.Id = xmlReader.GetAttribute("id");
						}
						else
						{
							// Überprüfen, um welches Element es sich handelt
							if (xmlReader.Name == "firstname")
							{
								// Zum Inhalt wechseln und den Text einlesen
								if (xmlReader.MoveToContent() != XmlNodeType.None)
									person.FirstName = xmlReader.ReadString();
							}
							else if (xmlReader.Name == "lastname")
							{
								// Zum Inhalt wechseln und den Text einlesen
								if (xmlReader.MoveToContent() != XmlNodeType.None)
									person.LastName = xmlReader.ReadString();
							}
							else if (xmlReader.Name == "type")
							{
								// Zum Inhalt wechseln und den Text einlesen
								if (xmlReader.MoveToContent() != XmlNodeType.None)
									person.Type = xmlReader.ReadString();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Einlesen der XML-Datei '" +
					xmlFileName + "': " + ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				xmlReader.Close(); 
				return;
			}

			// XmlTextReader schließen
			xmlReader.Close();

			// Alle eingelesenen Personen durchgehen und an der Konsole ausgeben
			foreach (Person p in persons)
			{
				Console.WriteLine("Person {0}", p.Id);
				Console.WriteLine("Vorname: {0}", p.FirstName);
				Console.WriteLine("Nachname: {0}", p.LastName);
				Console.WriteLine("Typ: {0}", p.Type);
				Console.WriteLine();
			}
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}

