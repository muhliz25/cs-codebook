using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_ändern
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string userName = "Test";
			string userFullName = "Test-User";
			string userDescription = "User for testing purposes";
			string userPassword = "yamaha";
			string userProfile = "c:\\Temp";
			string userLoginScript = "Log";
			string userHomeDirectory = "D:\\";
			bool cantChangePassword = false;
			bool passwordDontExpires = false;
			string bindUser = null;
			string bindPassword = null;

			// Benutzer ändern
			try
			{
				UserUtils.ChangeUser(domainName, machineName,
					userName, userFullName, userDescription,
					userProfile, userLoginScript, userHomeDirectory,
					userPassword, cantChangePassword, passwordDontExpires,
					bindUser, bindPassword);

				Console.WriteLine("Fertig");
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
