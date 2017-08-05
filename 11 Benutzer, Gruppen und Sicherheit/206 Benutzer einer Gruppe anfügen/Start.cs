using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_einer_Gruppe_anfügen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string userName = "Test";
			string groupName = "Administratoren";
			string bindUser = null;
			string bindPassword = null;

			/* Benutzer der Gruppe hinzufügen */
			try
			{
				UserUtils.AddUserToGroup(domainName, machineName, 
					userName, groupName, bindUser, bindPassword);

				Console.WriteLine("Benutzer erfolgreich hinzugefügt");

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
