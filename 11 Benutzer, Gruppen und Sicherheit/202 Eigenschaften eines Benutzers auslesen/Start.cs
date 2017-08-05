using System;
using Addison_Wesley.Codebook.System;

namespace Benutzer_Eigenschaften
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

			// Benutzerdaten auslesen
			UserUtils.User user = UserUtils.GetUser(domainName, machineName, userName, bindUser,
				bindPassword);

			// Die wichtigsten Daten ausgeben
			Console.WriteLine("Name: {0}",userName);
			Console.WriteLine("Description: {0}", user.Description);
			Console.WriteLine("FullName: {0}", user.FullName);
			Console.WriteLine("AccountDisabled: {0}", user.AccountDisabled);
			Console.WriteLine("AccountLocked: {0}", user.AccountLocked);
			Console.WriteLine("HomeDirRequired: {0}", user.HomeDirRequired); 
			Console.WriteLine("PasswortNotRequired: {0}", user.PasswortNotRequired); 
			Console.WriteLine("PasswordCantChange: {0}", user.PasswordCantChange); 
			Console.WriteLine("PasswordNotExpires: {0}", user.PasswordNotExpires); 
			Console.WriteLine("EncryptedPasswordAllowed: {0}", user.EncryptedPasswordAllowed); 
			Console.WriteLine("LocalAccount: {0}", user.LocalAccount); 
			Console.WriteLine("NormalAccount: {0}", user.NormalAccount); 
			Console.WriteLine("MaxStorage: {0}", user.MaxStorage);
			Console.WriteLine("HomeDirectory: {0}", user.HomeDirectory);
			Console.WriteLine("HomeDirDrive: {0}", user.HomeDirDrive);
			Console.WriteLine("LoginScript: {0}", user.LoginScript);
			Console.WriteLine("Profile: {0}", user.Profile);
			Console.WriteLine("PasswordExpired: {0}", user.PasswordExpired);
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
