using System;
using System.Collections.Specialized;
using Addison_Wesley.Codebook.System; 

namespace Gruppen_eines_Computers_auflisten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string bindUser = null;
			string bindPassword = null;
			
			// Gruppen abfragen
			try
			{
				UserUtils.Groups groups = UserUtils.EnumGroups(domainName, machineName, 
					bindUser, bindPassword);

				// Benutzer durchgehen und deren Daten ausgeben
				for (int i = 0; i < groups.Count; i++)
				{
					Console.WriteLine();
					Console.WriteLine("Name: {0}", groups[i].Name);
					Console.WriteLine("Beschreibung: {0}", groups[i].Description);
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
