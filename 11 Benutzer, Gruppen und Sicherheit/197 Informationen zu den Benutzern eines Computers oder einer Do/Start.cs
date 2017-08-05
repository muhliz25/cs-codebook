using System;
using Addison_Wesley.Codebook.System; 

namespace Benutzer_eines_Computers_auflisten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = "Zaphod";
			string bindUser = null;
			string bindPassword = null;

			// Benutzer abfragen
			try
			{
				UserUtils.Users users = UserUtils.EnumUsers(domainName, machineName, 
					bindUser, bindPassword);

				// Benutzer durchgehen und deren Daten ausgeben
				for (int i = 0; i < users.Count; i++)
				{
					Console.WriteLine();
					Console.WriteLine("Name: {0}", users[i].Name);
					Console.WriteLine("Voller Name: {0}", users[i].FullName);
					Console.WriteLine("Beschreibung: {0}", users[i].Description);
					Console.WriteLine("Letzter Login: {0}", users[i].LastLogin);
					Console.WriteLine("Home-Verzeichnis: {0}", users[i].HomeDirectory);
					Console.WriteLine("Maximaler Speicherplatz: {0}", users[i].MaxStorage);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}
	}
}
