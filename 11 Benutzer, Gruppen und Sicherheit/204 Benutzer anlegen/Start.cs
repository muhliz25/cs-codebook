using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_anlegen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null; 
			string machineName = null;
			string userName = "Test";
			string userFullName = "Testuser";
			string userDescription = "User für Testzwecke";
			string userPassword = "honda";
			string userProfile = "c:\\Profiles\\Test";
			string userLoginScript = "Login";
			string userHomeDirectory = "C:\\";
			bool cantChangePassword = true;
			bool passwordDontExpires = true;
			string bindUser = null;
			string bindPassword = null;

			// Benutzer hinzufügen
			try
			{
				UserUtils.AddUser(domainName, machineName,
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
