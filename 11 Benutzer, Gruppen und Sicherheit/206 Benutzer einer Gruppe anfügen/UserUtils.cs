using System;
using System.DirectoryServices;
using System.Reflection;

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zum Hinzufügen eines Benutzers zu einer Gruppe */
		public static void AddUserToGroup(string domainName, string machineName,
			string userName, string groupName, string bindUser,
			string bindPassword)
		{
			// DirectoryEntry-Objekt für die Gruppe holen
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
			string groupPath = "WinNT://" + 
				(domainName != null ? domainName + "/" : "") + 
				(machineName != null ? machineName + "/" : "") +
				groupName + ",group";
			DirectoryEntry groupEntry = new DirectoryEntry(groupPath, 
				bindUser, bindPassword);

			// Pfad zum Benutzer zusammensetzen
			string userPath = "WinNT://" + 
				(domainName != null ? domainName + "/" : "") + 
				(machineName != null ? machineName + "/" : "") +
				userName + ",user";

			// Benutzer der Gruppe anfügen
			try
			{
				groupEntry.Invoke("Add", new object[] {userPath});
			}
				// Abfangen der Ausnahmen, die bei Invoke auftreten können
			catch (TargetInvocationException ex)
			{
				// Die eigentliche Fehlermeldung steht häufig in der
				// inneren Ausnahme. Diese wird hier einfach weitergegeben
				if (ex.InnerException != null)
					throw ex.InnerException;
				else
					throw ex;
			}

			// Änderungen wegschreiben
			groupEntry.CommitChanges();
		}
	}
}
