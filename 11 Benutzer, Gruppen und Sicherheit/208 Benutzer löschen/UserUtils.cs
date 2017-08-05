using System;
using System.Reflection;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zum L�schen eines Benutzers */
		public static void RemoveUser(string domainName, string machineName, 
			string userName, string bindUser, string bindPassword)
		{
			// DirectoryEntry-Objekt f�r den Computer bzw. die Dom�ne erzeugen
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
			string adsiPath = "WinNT://";
			if (domainName != null && machineName != null)
				adsiPath += domainName + "/" + 
					machineName + ",computer";
			else if (machineName != null)
				adsiPath += machineName + ",computer";
			else if (domainName != null)
				adsiPath += domainName + ",domain";
			DirectoryEntry computerEntry = new DirectoryEntry(
				adsiPath, bindUser, bindPassword);

			// DirectoryEntry-Objekt f�r den Benutzer erzeugen
			adsiPath = "WinNT://" +
				(domainName != null ? domainName + "/" : "") +
				(machineName != null ? machineName + "/" : "") +
				userName + ",user";
			DirectoryEntry userEntry = new DirectoryEntry(
				adsiPath, bindUser, bindPassword);

			// Benutzer vom Computer bzw. von der Dom�ne entfernen
			computerEntry.Children.Remove(userEntry);
		}
	}
}
