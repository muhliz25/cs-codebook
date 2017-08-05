using System;
using System.Xml;
using System.IO;
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

			// XmlDocument-Instanz erzeugen und XML-Datei laden
			XmlDocument xmlDoc = new XmlDocument();
			try
			{
				xmlDoc.Load(xmlFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Einlesen der XML-Datei '" + xmlFileName + 
					"': " + ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// XmlNamespaceManager erzeugen und mit dem Namensraum initialisieren
			XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
			nsManager.AddNamespace("awcodebook", "http://www.addison-wesley.de/codebook");

			// Die Person mit der Id 1001 suchen
			XmlNode xmlNode = null;
			try
			{
				// XPath-Ausdruck, der das Element person über den im XmlNamespaceManager-
				// Objekt verwalteten Namensraum-Präfix referenziert
				string xpathQuery = "/awcodebook:persons/person[attribute::id='1001']";

				// XPath-Abfrage mit Übergabe des Namensraum-Managers absetzen
				xmlNode = xmlDoc.SelectSingleNode(xpathQuery, nsManager);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Suchen: " + ex.Message);
			}

			if (xmlNode != null)
			{
				// Der passende person-Knoten wurde gefunden: Das Attribut id einlesen
				XmlAttribute xmlAttribute = xmlNode.Attributes["id"];
				if (xmlAttribute != null)
					Console.WriteLine("Person {0}", xmlAttribute.InnerText); 

				// firstname-Element suchen
				XmlNode xmlSubNode = xmlNode.SelectSingleNode("firstname");
				if (xmlSubNode != null)
					Console.WriteLine("Nachname: {0}", xmlSubNode.InnerText);

				// lastname-Element suchen
				xmlSubNode = xmlNode.SelectSingleNode("lastname");
				if (xmlSubNode != null)
					Console.WriteLine("Vorname: {0}", xmlSubNode.InnerText);

				// type-Element suchen
				xmlSubNode = xmlNode.SelectSingleNode("type");
				if (xmlSubNode != null)
					Console.WriteLine("Typ: {0}", xmlSubNode.InnerText);
			}
			else
			{
				MessageBox.Show("Person mit der Id 1001 nicht gefunden.",
					Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}

			Console.WriteLine();
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
