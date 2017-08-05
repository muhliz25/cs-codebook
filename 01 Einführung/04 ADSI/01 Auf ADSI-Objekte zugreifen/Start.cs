using System;
using System.DirectoryServices;

namespace ADSI_Objekte
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// DirectoryEntry-Objekt für den Zugriff auf den Benutzer "Administrator" auf dem
			// lokalen Computer erzeugen
			DirectoryEntry de = null; 
			string adsiPath = "WinNT://" + Environment.MachineName + "/Administrator,user";
			string authUser = "Ford";
			string authPassword = "Handtuch";

			try
			{
				// DirectoryEntry-Objekt für das ADSI-Objekt erzeugen
				de = new DirectoryEntry(adsiPath, authUser, authPassword);

				// Einmal auf das Objekt zugreifen, um dessen Existenz zu überprüfen
				string name = de.Name;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				de = null;
			}

			// Eigenschaften auslesen
			if (de != null)
			{
				Console.WriteLine(de.Name);

				string fullName = null;
				try {fullName = de.Properties["FullName"].Value.ToString();}
				catch {}
				Console.WriteLine("Voller Name: {0}", fullName);

				string description = null;
				try {description = de.Properties["Description"].Value.ToString();} 
				catch {}
				Console.WriteLine("Beschreibung: {0}", description);
			
				try
				{
					// Die Eigenschaft FullName beschreiben
					de.Properties["FullName"].Add("Zaphod Beeblebrox");

					// Die gecachten Werte in den Verzeichnisdienst schreiben
					de.CommitChanges();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Fehler beim Schreiben der Eigenschaft: {0}", ex.Message);
				}

				// Schließen des ADSI-Objekts und Freigeben der ADSI-Ressourcen
				de.Close();
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
