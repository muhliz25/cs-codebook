using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Xml;

namespace XML_Dokumente_validieren
{
	class Start
	{
		// Methode zum Validieren
		static void ValidateXmlFile(string xmlFileName, ValidationType validationType,
			string schemaFileName)
		{
			XmlValidator xmlValidator = new XmlValidator();
			XmlValidator.XmlValidatorResult result;
			try
			{
				result = xmlValidator.ValidateXmlFile(xmlFileName, 
					validationType, schemaFileName);
			}
			catch (XmlException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			switch (result)
			{
				case XmlValidator.XmlValidatorResult.Valid: 
					Console.WriteLine("Die XML-Datei ist valide.");
					break;

				case XmlValidator.XmlValidatorResult.WarningsExists: 
					Console.WriteLine("Die XML-Datei ist valide, es wurden aber Warnungen gemeldet:");
					for (int i = 0; i < xmlValidator.Warnings.Count; i++)
					{
						Console.WriteLine("\r\n* " + xmlValidator.Warnings[i].ToString());
					}
					break;

				case XmlValidator.XmlValidatorResult.ErrorsExists: 
					Console.WriteLine("Die XML-Datei ist nicht valide.");
					// Fehler ausgeben
					Console.WriteLine("Die folgenden Fehler wurden gefunden:");
					for (int i = 0; i < xmlValidator.Errors.Count; i++)
					{
						Console.WriteLine("\r\n* " + xmlValidator.Errors[i].ToString());
					}
					// Überprüfen, ob Warnungen vorhanden sind, und diese ebenfalls ausgeben
					if (xmlValidator.Warnings.Count > 0)
					{
						Console.WriteLine("Die folgenden Warnungen wurden gemeldet:");
						for (int i = 0; i < xmlValidator.Warnings.Count; i++)
						{
							Console.WriteLine("\r\n* " + xmlValidator.Warnings[i].ToString());
						}
					}
					break;
			}
		}
		
		[STAThread]
		static void Main(string[] args)
		{
			for (int i = 0; i < 2; i++)
			{
				// Zwei Läufe: der erste mit validen Dateien, der zweite mit invaliden

				// Der Basis-Dateiname
				string xmlBaseFileName;
				if (i == 0) 
				{
					Console.WriteLine("*** Erster Lauf mit validen Dokumenten ***\r\n");
					xmlBaseFileName= Path.Combine(
						Application.StartupPath, "Valid\\Persons");
				}
				else
				{
					Console.WriteLine("\r\n\r\n*** Zweiter Lauf mit invaliden Dokumenten ***\r\n");
					xmlBaseFileName= Path.Combine(
						Application.StartupPath, "Invalid\\Persons");
				}
			
				// XML-Datei nur auf Wohlgeformtheit validieren	
				Console.WriteLine("XML-Datei nur auf Wohgeformtheit validieren");
				ValidateXmlFile(xmlBaseFileName + ".xml", ValidationType.None, null);

				// XML-Datei (mit internem DTD) automatisch validieren (je nach eingebetteten Informationen)
				Console.WriteLine();
				Console.WriteLine("XML-Datei (mit internem DTD) automatisch validieren (je nach eingebetteten Informationen)");
				ValidateXmlFile(xmlBaseFileName + "_Intern_DTD.xml", ValidationType.Auto, null);

				// XML-Datei gegen ein externes Schema validieren	
				Console.WriteLine();
				Console.WriteLine("XML-Datei gegen ein externes Schema validieren");
				ValidateXmlFile(xmlBaseFileName + "_Extern_XSD.xml", ValidationType.Schema, 
					xmlBaseFileName + ".xsd");

				// XML-Datei gegen ein externes DTD validieren (auf das in der XML-Datei verwiesen wird)	
				Console.WriteLine();
				Console.WriteLine("XML-Datei gegen ein externes DTD validieren");
				ValidateXmlFile(xmlBaseFileName + "_Extern_DTD.xml", ValidationType.DTD, null);

				// XML-Datei mit internem DTD gegen ein externes Schema validieren	
				Console.WriteLine();
				Console.WriteLine("XML-Datei mit DTD gegen ein externes Schema validieren");
				ValidateXmlFile(xmlBaseFileName + "_Intern_DTD.xml", ValidationType.Schema, xmlBaseFileName + ".xsd");

			}

			// Ein XmlDokument überprüfen
			Console.WriteLine();
			Console.WriteLine("XmlDokument überprüfen");
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" " +
				"standalone=\"yes\"?><persons></persons>");
			XmlNode personNode = xmlDoc.CreateElement("person");
			XmlNode node = xmlDoc.CreateElement("firstname");
			node.InnerText = "Zaphod";
			personNode.AppendChild(node);
			node = xmlDoc.CreateElement("lastname");
			node.InnerText = "Beeblebrox";
			personNode.AppendChild(node);
			node = xmlDoc.CreateElement("type");
			node.InnerText = "Alien";
			personNode.AppendChild(node);
			xmlDoc.DocumentElement.AppendChild(personNode);

			XmlValidator xmlValidator = new XmlValidator();
			XmlValidator.XmlValidatorResult result;

			string schemaFileName = Path.Combine(Application.StartupPath, "Persons.xsd");

			try
			{
				result = xmlValidator.ValidateXmlDocument(xmlDoc, 
					ValidationType.Schema, schemaFileName);
			}
			catch (XmlException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			switch (result)
			{
				case XmlValidator.XmlValidatorResult.Valid: 
					Console.WriteLine("Das XML-Dokument ist valide.");
					break;

				case XmlValidator.XmlValidatorResult.WarningsExists: 
					Console.WriteLine("Das XML-Dokument ist valide, es wurden aber Warnungen gemeldet:");
					for (int i = 0; i < xmlValidator.Warnings.Count; i++)
					{
						Console.WriteLine("\r\n* " + xmlValidator.Warnings[i].ToString());
					}
					break;

				case XmlValidator.XmlValidatorResult.ErrorsExists: 
					Console.WriteLine("Das XML-Dokument ist nicht valide.");
					// Fehler ausgeben
					Console.WriteLine("Die folgenden Fehler wurden gefunden:");
					for (int i = 0; i < xmlValidator.Errors.Count; i++)
					{
						Console.WriteLine("\r\n* " + xmlValidator.Errors[i].ToString());
					}
					// Überprüfen ob Warnungen vorhanden sind und diese ebenfalls ausgeben
					if (xmlValidator.Warnings.Count > 0)
					{
						Console.WriteLine("Die folgenden Warnungen wurden gemeldet:");
						for (int i = 0; i < xmlValidator.Warnings.Count; i++)
						{
							Console.WriteLine("\r\n* " + xmlValidator.Warnings[i].ToString());
						}
					}
					break;
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
