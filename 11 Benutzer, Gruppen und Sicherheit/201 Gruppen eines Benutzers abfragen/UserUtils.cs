using System;
using System.DirectoryServices;
using System.Collections;
using System.Collections.Specialized;

// Import der COM-Typbibliothek ActiveDS. Ben�tigt eine COM-Referenz
// auf die Datei activeds.tlb im Windows-Systemverzeichnis
using ActiveDs; 

namespace Addison_Wesley.Codebook.System
{
	public class UserUtils
	{
		/* Methode zum Ermitteln aller Gruppen eines Benutzers */
		public static StringCollection EnumUserGroups(string domainName,
			string machineName, string userName, string bindUser, string bindPassword)
		{
			// StringCollection f�r die ermittelten Gruppennamen    
			StringCollection groups = new StringCollection();

			// DirectoryEntry-Objekt f�r den Benutzer erzeugen
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
			string adsiPath = "WinNT://" +
				(domainName != null ? domainName + "/" : "") +
				(machineName != null ? machineName + "/" : "") +
				userName + ",user";
			DirectoryEntry userEntry = new DirectoryEntry(adsiPath, 
				bindUser, bindPassword);

			try
			{
				// Gruppen dieses Benutzers einlesen
				IADsMembers adsMembers = (IADsMembers)userEntry.Invoke("Groups");

				// Member so filtern, dass nur Group-Objekte �brig bleiben
				adsMembers.Filter = new object[] {"group"};

				// Gruppen durchgehen
				foreach (IADsGroup adsGroup in adsMembers)
				{
					groups.Add(adsGroup.Name);
				}
			}
			finally 
			{
				// ADSI-Objekt freigeben
				userEntry.Dispose();
			}

			// Die ermittelten Gruppen zur�ckgeben
			return groups;
		}
	}
}
