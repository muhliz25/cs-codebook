using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Files;

namespace XML_Dateien_erzeugen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// Der Dateiname der XML-Datei
				string xmlFileName = Path.Combine(Application.StartupPath, "contacts.xml");

				// Neues XML-Dokument erzeugen
				ContactHandler ch = new ContactHandler(xmlFileName, true, Encoding.UTF8);

				// Kontakt hinzufügen
				ch.AddContact(1000, "Zap", "BBrox", "01234-12345");
				ch.AddContact(1001, "Ford", "Prefect", "01234-12346");

				// Dokument speichern
				ch.Save();

				// Dokument einlesen
				ch = new ContactHandler(xmlFileName, false, null);

				// Kontakt hinzufügen
				ch.AddContact(1002, "Tricia", "McMillan", "01234-12347");

				// Kontakt ändern
				ch.ChangeContact(1000, "Zaphod", "Beeblebrox", "042-42");

				// Kontakt löschen
				ch.RemoveContact(1001);

				// Kontakt auslesen
				string firstName, lastName, phone;
				ch.ReadContact(1000, out firstName, out lastName, out phone);
				Console.WriteLine("Kontakt 1000:");
				Console.WriteLine(firstName);
				Console.WriteLine(lastName);
				Console.WriteLine(phone);

				// Dokument speichern
				ch.Save();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Fertig");
			Console.ReadLine();
		}
	}
}

