using System;
using System.IO;
using MSjogren.Samples.ShellLink;

namespace Verknpfungen_anlegen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Name der zu erzeugenden Verknüpfungs-Datei
			string linkFileName = "c:\\eula.lnk";

			// Pfad zu notepad.exe zusammenstellen
			string path = Path.Combine(Environment.SystemDirectory, "notepad.exe");

			// Argumente für den Aufruf
			string arguments = Path.Combine(Environment.SystemDirectory, "eula.txt");

			// Instanz der Klasse ShellShortcut erzeugen
			ShellShortcut ssh = new ShellShortcut(linkFileName);

			// ShellShortcut-Objekt initialisieren
			ssh.Description = "Test-Verknpfung"; // Beschreibung
			ssh.WorkingDirectory = "c:\\";        // Arbeitsverzeichnis
			ssh.Path = path;                      // Pfad zur Datei / zum Ordner
			ssh.Arguments = arguments;            // Aufruf-Argumente 
			ssh.IconPath = linkFileName;          // Pfad zur Icon-Datei 
			ssh.IconIndex = 0;                    // Index des Icons 

			try
			{
				// Verknpfung speichern
				ssh.Save();

				Console.WriteLine("Fertig");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Anlegen der Verknpfung: {0}",
					ex.Message);
			}

			Console.ReadLine();
		}
	}
}
