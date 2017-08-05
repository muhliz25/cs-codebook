using System;
using System.Collections.Specialized; 
using Addison_Wesley.Codebook.System;

namespace Benutzer_einer_Gruppe_auslesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = "Arbeitsgruppe"; 
			string machineName = "Zaphod";
			string groupName = "Administratoren";
			string bindUser = null;
			string bindPassword = null;

			// Benutzer der Gruppe abfragen
			try
			{
				StringCollection users = UserUtils.EnumGroupMembers(
					domainName, machineName, groupName, bindUser, bindPassword);
				Console.WriteLine("Benutzer der Gruppe '" + groupName + "':");
				for (int i = 0; i < users.Count; i++)
				{
					Console.WriteLine(users[i]);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
