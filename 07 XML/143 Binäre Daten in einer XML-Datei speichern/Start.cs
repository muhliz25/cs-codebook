using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace Bin�re_XML_Daten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Der Dateiname
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");

			// Neues XML-Dokument erzeugen
			XmlDocument xmlDoc = new XmlDocument();  
			xmlDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" " +
				"standalone=\"yes\"?><persons></persons>");

			// Ein person-Element erzeugen
			XmlNode personNode = xmlDoc.CreateElement("person");
			xmlDoc.DocumentElement.AppendChild(personNode);

			// Vor- und Nachname schreiben
			XmlNode subNode = xmlDoc.CreateElement("firstname"); 
			subNode.InnerText = "Zaphod";
			personNode.AppendChild(subNode);
			subNode = xmlDoc.CreateElement("lastname"); 
			subNode.InnerText = "Beeblebrox";
			personNode.AppendChild(subNode);

			// Das Bild einlesen 
			string imageFileName = Path.Combine(Application.StartupPath, "Zaphod.jpg");
			FileInfo fi = new FileInfo(imageFileName);
			byte[] buffer = new byte[fi.Length];
			FileStream fs = new FileStream(imageFileName, FileMode.Open,  FileAccess.Read);
			fs.Read(buffer, 0, buffer.Length);

			// Bild Base64-codieren ...
			string codedFile = Convert.ToBase64String(buffer, 0, buffer.Length);

			// ... und im XML-Dokument speichern
			subNode = xmlDoc.CreateElement("image"); 
			subNode.InnerText = codedFile;
			personNode.AppendChild(subNode);

			// XML-Datei speichern
			xmlDoc.Save(xmlFileName);

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
