using System;
using System.DirectoryServices;

namespace ADSI
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// DirectoryEntry-Objekt für den Zugriff auf den lokalen Computer erzeugen
			DirectoryEntry de = null; 
			string adsiPath = "WinNT://" + Environment.MachineName + ",computer";
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

			// Eine Eigenschaft auslesen und die enthaltenen Objekte durchgehen 
			if (de != null)
			{
				Console.WriteLine("Computername: {0}", de.Name);

				// Die Child-Objekte durchgehen
				foreach (DirectoryEntry child in de.Children)
				{
					// Name ausgeben
					Console.WriteLine("Name: {0}", child.Name);
					Console.WriteLine("Schema: {0}", child.SchemaClassName);
					Console.WriteLine();
				}
			}

			// Nur User-Objekte durchgehen
			Console.WriteLine("Alle User:");
			de.Children.SchemaFilter.Clear();
			de.Children.SchemaFilter.Add("User");
			if (de != null)
			{
				// Die Child-Objekte durchgehen
				foreach (DirectoryEntry child in de.Children)
				{
					// Name ausgeben
					Console.WriteLine(child.Name);
					Console.WriteLine();
				}
			}

			// Schließen des ADSI-Objekts und Freigeben der ADSI-Ressourcen
			de.Close();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
