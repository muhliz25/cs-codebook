using System;
using Addison_Wesley.Codebook.System;

namespace Gruppe_l�schen
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

			// Benutzer l�schen
			try
			{
				UserUtils.RemoveGroup(domainName, machineName,
					groupName, bindUser, bindPassword);

				Console.WriteLine("Gruppe erfolgreich gel�scht");
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
