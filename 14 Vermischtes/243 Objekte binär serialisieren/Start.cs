using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Objects;
using System.Data;
using System.Data.SqlClient;

namespace Objekte_serialisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Person-Objekt erzeugen
			Person person = new Person();
			person.FirstName = "Zaphod";
			person.LastName = "Beeblebrox";
			person.BirthDate = new DateTime(1900, 1, 1);

			// Objekt in eine Datei serialisieren
			string fileName = Path.Combine(Application.StartupPath, "Person.dat");
			Serializer.SerializeToFile(person, fileName);

			// Objekt aus einer Datei deserialisieren
			person = (Person)Serializer.DeserializeFromFile(fileName);

			Console.WriteLine("{0}\r\n{1}\r\n{2}", person.FirstName, person.LastName,
				person.BirthDate.ToShortDateString());
			Console.WriteLine();

			// Objekt in ein Byte-Array serialisieren
			byte[] data = Serializer.SerializeToByteArray(person);

			// Objekt aus dem Byte-Array deserialisieren
			person = (Person)Serializer.DeserializeFromByteArray(data);

			Console.WriteLine("{0}\r\n{1}\r\n{2}", person.FirstName, person.LastName,
				person.BirthDate.ToShortDateString());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
