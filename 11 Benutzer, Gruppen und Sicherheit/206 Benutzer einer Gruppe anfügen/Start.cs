using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_einer_Gruppe_anf�gen
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

			/* Benutzer der Gruppe hinzuf�gen */
			try
			{
				UserUtils.AddUserToGroup(domainName, machineName, 
					userName, groupName, bindUser, bindPassword);

				Console.WriteLine("Benutzer erfolgreich hinzugef�gt");

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
