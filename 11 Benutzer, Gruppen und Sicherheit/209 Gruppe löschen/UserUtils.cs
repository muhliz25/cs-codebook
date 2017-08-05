using System;
using System.Reflection;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zum Löschen einer Gruppe */
		public static void RemoveGroup(string domainName, string machineName,
			string groupName, string bindUser, string bindPassword)
		{
			// DirectoryEntry-Objekt für den Computer bzw. die Domäne erzeugen
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
			string adsiPath = "WinNT://";
			if (domainName != null && machineName != null)
				adsiPath += domainName + "/" + machineName + ",computer";
			else if (machineName != null)
				adsiPath += machineName + ",computer";
			else if (domainName != null)
				adsiPath += domainName + ",domain";
			DirectoryEntry computerEntry = new DirectoryEntry(
				adsiPath, bindUser, bindPassword);

			// DirectoryEntry-Objekt für die Gruppe erzeugen
			adsiPath = "WinNT://" +
				(domainName != null ? domainName + "/" : "") +
				(machineName != null ? machineName + "/" : "") +
				groupName + ",group";
			DirectoryEntry groupEntry = new DirectoryEntry(
				adsiPath, bindUser, bindPassword);

			// Gruppe vom Computer bzw. von der Domäne entfernen
			computerEntry.Children.Remove(groupEntry);
		}
	}
}
