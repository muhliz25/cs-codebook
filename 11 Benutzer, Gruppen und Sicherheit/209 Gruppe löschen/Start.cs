using System;
using Addison_Wesley.Codebook.System;

namespace Gruppe_löschen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string groupName = "Test";
			string bindUser = null;
			string bindPassword = null;

			// Benutzer löschen
			try
			{
				UserUtils.RemoveGroup(domainName, machineName,
					groupName, bindUser, bindPassword);

				Console.WriteLine("Gruppe erfolgreich gelöscht");
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
