using System;
using System.Collections.Specialized;
using Addison_Wesley.Codebook.System;

namespace Gruppen_eines_Benutzers_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string userName = "Administrator";
			string bindUser = null;
			string bindPassword = null;

			try
			{
				StringCollection groups = UserUtils.EnumUserGroups(
					domainName, machineName, userName, bindUser, bindPassword);
				Console.WriteLine("Gruppen des Benutzers '" + userName + "':");
				for (int i = 0; i < groups.Count; i++)
				{
					Console.WriteLine(groups[i]);
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
