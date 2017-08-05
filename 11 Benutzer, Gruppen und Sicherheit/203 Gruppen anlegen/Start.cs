using System;
using Addison_Wesley.Codebook.System;

namespace Gruppe_anlegen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string groupName = "Test";
			string groupDescription = "Testgruppe";
			string bindUser = null;
			string bindPassword = null;

			// Gruppe hinzufügen
			try
			{
				UserUtils.AddGroup(domainName, machineName,
					groupName, groupDescription, 
					bindUser, bindPassword);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Taste ...");
			Console.ReadLine();
		}
	}
}
