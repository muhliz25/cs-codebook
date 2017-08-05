using System;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zum Erzeugen einer Gruppe */
		public static void AddGroup(string domainName, string machineName, 
			string groupName, string groupDescription, string bindUser, 
			string bindPassword)
		{
			// DirectoryEntry-Objekt f�r den Computer bzw. die Dom�ne erzeugen
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
   
			try
			{
				// Gruppe hinzuf�gen und Eigenschaften definieren
				DirectoryEntry groupEntry = 
					computerEntry.Children.Add(groupName, "group");
				groupEntry.Properties["description"].Add(groupDescription);
				groupEntry.CommitChanges();
			}
			finally
			{
				computerEntry.Dispose();
			}
		}
	}
}