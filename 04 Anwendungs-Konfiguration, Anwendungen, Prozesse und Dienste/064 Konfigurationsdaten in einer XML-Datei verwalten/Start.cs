using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Configuration;

namespace XML_Config
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Config-Instanz erzeugen
			Config config = new Config(Path.Combine(Application.StartupPath,
				"Config.xml"));

			// Konfigurations-Sektionen und Einstellungen definieren
			config.Sections.Add("System");
			config.Sections.Add("Database");
			config.Sections["System"].Settings.Add("LastAccess", "00:00");
			config.Sections["Database"].Settings.Add("Server", "(local)");

			// Datei einlesen
			config.Load();

			// Ein Datum lesen und ausgeben
			Setting setting = config.Sections["System"].Settings["LastAccess"];
			if (setting.WasInFile == false)
				Console.WriteLine("Einstellung System/LastAccess nicht gefunden");
			Console.WriteLine("LastAccess: {0}", setting.Value);

			// Den Wert Datum ändern
			setting.Value = DateTime.Now.ToString();

			// Datei speichern
			config.Save();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
