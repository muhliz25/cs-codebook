using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_löschen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string userName = "Test";
			string bindUser = null;
			string bindPassword = null;

			// Benutzer löschen
			try
			{
				UserUtils.RemoveUser(domainName, machineName,
					userName, bindUser, bindPassword);

				Console.WriteLine("Benutzer erfolgreich gelöscht");
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
