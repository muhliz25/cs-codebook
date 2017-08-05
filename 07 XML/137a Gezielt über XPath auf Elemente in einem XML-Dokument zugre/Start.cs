using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace XPath_Abfrage	
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Der Dateiname
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");

			// XmlDocument-Instanz erzeugen
			XmlDocument xmlDoc = new XmlDocument();

			// XML-Datei laden
			try
			{
				xmlDoc.Load(xmlFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Einlesen der XML-Datei '" + xmlFileName + "': " +
					ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// Einlesen aller Vornamen
			XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/persons/person/firstname");
			if (xmlNodeList != null)
			{
				for (int i = 0; i < xmlNodeList.Count; i++)
					Console.WriteLine(xmlNodeList[i].InnerText);
			}

			// Die Person mit der Id 1001 suchen
			XmlNode xmlNode = xmlDoc.SelectSingleNode("/persons/person[attribute::id='1001']");
			if (xmlNode != null)
			{
				// Der passende person-Knoten wurde gefunden
				// Das Attribut id einlesen
				XmlAttribute xmlAttribute = xmlNode.Attributes["id"];
				string id = null;
				if (xmlAttribute != null)
					id = xmlAttribute.InnerText; 

				// firstname-Element suchen
				XmlNode xmlSubNode = xmlNode.SelectSingleNode("firstname");
				string firstName = null;
				if (xmlSubNode != null)
					firstName = xmlSubNode.InnerText;

				// lastname-Element suchen
				xmlSubNode = xmlNode.SelectSingleNode("lastname");
				string lastName = null;
				if (xmlSubNode != null)
					lastName = xmlSubNode.InnerText;
      
				// type-Element suchen
				string type = null;
				xmlSubNode = xmlNode.SelectSingleNode("type");
				if (xmlSubNode != null)
					type = xmlSubNode.InnerText;

				// Daten der Person ausgeben
				Console.WriteLine();
				Console.WriteLine("Person {0}", id);
				Console.WriteLine("Vorname: {0}", firstName);
				Console.WriteLine("Nachname: {0}", lastName);
				Console.WriteLine("Typ: {0}", type);
			}
			else
			{
				MessageBox.Show("Person mit der Id 1001 nicht gefunden.", 
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			// Personen mit Typ = Alien suchen
			xmlNodeList = xmlDoc.SelectNodes("/persons/person[type='Alien']");
			if (xmlNodeList != null)
			{
				// Passende person-Knoten wurden gefunden: Alle gefundenen Personen durchgehen
				for (int i = 0; i < xmlNodeList.Count; i++)
				{
					// Das Attribut id einlesen
					XmlAttribute xmlAttribute = xmlNodeList[i].Attributes["id"];
					string id = null;
					if (xmlAttribute != null)
						id = xmlAttribute.InnerText; 

					// firstname-Element suchen
					XmlNode xmlSubNode = 
						xmlNodeList[i].SelectSingleNode("firstname");
					string firstName = null;
					if (xmlSubNode != null)
						firstName = xmlSubNode.InnerText;

					// lastname-Element suchen
					xmlSubNode = xmlNodeList[i].SelectSingleNode("lastname");
					string lastName = null;
					if (xmlSubNode != null)
						lastName = xmlSubNode.InnerText;
      
					// type-Element suchen
					string type = null;
					xmlSubNode = xmlNodeList[i].SelectSingleNode("type");
					if (xmlSubNode != null)
						type = xmlSubNode.InnerText;

					// Daten der Person ausgeben
					Console.WriteLine();
					Console.WriteLine("Person {0}", id);
					Console.WriteLine("Vorname: {0}", firstName);
					Console.WriteLine("Nachname: {0}", lastName);
					Console.WriteLine("Typ: {0}", type);
				}
			}
			else
			{
				MessageBox.Show("Keine Aliens gefunden.", Application.ProductName,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			Console.WriteLine();
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
