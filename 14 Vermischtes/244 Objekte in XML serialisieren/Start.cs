using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Objects;

namespace Objekte_in_XML_serialisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Person-Objekt erzeugen
			Person person = new Person(1001, "Zaphod", "Beeblebrox");
			person.BirthDate = new DateTime(1900, 1, 1);

			Console.WriteLine("Originales Objekt:");
			Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n{3}", person.Id, person.FirstName, person.LastName,
				person.BirthDate.ToShortDateString());
			Console.WriteLine();


			// Objekt in eine Datei serialisieren
			string fileName = Path.Combine(Application.StartupPath, "Person.xml");
			Serializer.SerializeToXmlFile(person, fileName, Encoding.GetEncoding("ISO-8859-1"));

			// Objekt aus einer Datei deserialisieren
			person = (Person)Serializer.DeserializeFromXmlFile(fileName, typeof(Person), Encoding.GetEncoding("ISO-8859-1"));

			Console.WriteLine("Aus Datei deserialisiertes Objekt:");
			Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n{3}", person.Id, person.FirstName, person.LastName,
				person.BirthDate.ToShortDateString());
			Console.WriteLine();

			// Objekt in einen XML-String serialisieren
			string xmlString = Serializer.SerializeToXmlString(person, Encoding.GetEncoding("ISO-8859-1"));

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xmlString);
			xmlDoc.Save(fileName);

			// Objekt aus dem XML-String deserialisieren
			person = (Person)Serializer.DeserializeFromXmlString(xmlString, typeof(Person), Encoding.Default);

			Console.WriteLine("Aus String deserialisiertes Objekt:");
			Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n{3}", person.Id, person.FirstName, person.LastName,
				person.BirthDate.ToShortDateString());
			Console.WriteLine();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
