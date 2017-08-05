using System;
using System.DirectoryServices;
using System.Reflection;

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zum Entfernen eines Benutzers aus einer Gruppe */
		public static void RemoveUserFromGroup(string domainName, string machineName,
			string userName, string groupName, string bindUser, string bindPassword)
		{
			// DirectoryEntry-Objekt f�r die Gruppe erzeugen
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

			// Benutzer aus der Gruppe entfernen
			try
			{
				groupEntry.Invoke("Remove", new object[] {userPath});
			}
				// Abfangen der Ausnahmen, die bei Invoke auftreten k�nnen
			catch (TargetInvocationException ex)
			{
				// Die eigentliche Fehlermeldung steht h�ufig in der
				// inneren Ausnahme. Diese wird hier einfach weitergegeben
				if (ex.InnerException != null)
					throw ex.InnerException;
				else
					throw ex;
			}

			// �nderungen wegschreiben
			groupEntry.CommitChanges();
		}
	}
}
