using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_aus_einer_Gruppe_entfernen
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

			/* Benutzer aus der Gruppe entfernen */
			try
			{
				UserUtils.RemoveUserFromGroup(domainName, machineName, 
					userName, groupName, bindUser, bindPassword);

				Console.WriteLine("Benutzer erfolgreich entfernt");

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
