using System;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zur �berpr�fung, ob ein Benutzer existiert */
		public static bool UserExists(string userName, string domainName, 
			string machineName, string bindUser, string bindPassword)
		{
			// G�ltigen Rechnernamen f�r den lokalen Computer erzeugen, falls
			// weder die Dom�ne noch der Rechnername �bergeben wurden
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
   
			// DirectoryEntry-Objekt f�r den Computer bzw. die Dom�ne erzeugen
			string adsiPath = "WinNT://";
			if (domainName != null && machineName != null)
				adsiPath += domainName + "/" + machineName + ",computer";
			else if (machineName != null)
				adsiPath += machineName + ",computer";
			else if (domainName != null)
				adsiPath += domainName + ",domain";
			DirectoryEntry computerEntry = new DirectoryEntry(adsiPath, bindUser,
				bindPassword);

			try
			{
				DirectoryEntry userEntry = computerEntry.Children.Find(
					userName, "user");
				return true;
			}
			catch 
			{
				return false;
			}
		}
	}
}
