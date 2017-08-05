using System;
using System.Collections;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	/* Klasse mit Benutzer-Utilities */
	public class UserUtils
	{
		/* Klasse für eine Benutzer-Gruppe */
		public class Group
		{
			public string Name;          // Benutzername 
			public string Description;   // eine Beschreibung
		}

		/* Klasse zur Auflistung von Group-Instanzen */
		public class Groups: CollectionBase
		{
			/* Indizierer */
			public Group this[int index]
			{
				set {base.InnerList[index] = value;}
				get {return (Group)base.InnerList[index];}
			}

			/* Add-Methode */
			internal void Add(Group group)
			{
				base.InnerList.Add(group);
			}
		}

		/* Methode zum Auflisten aller Gruppen eines Computers */
		public static Groups EnumGroups(string domainName, 
			string machineName, string bindGroup, string bindPassword)
		{
			// Groups-Auflistung für das Ergebnis erzeugen
			Groups groups = new Groups();

			// Gültigen Rechnernamen für den lokalen Computer erzeugen, falls
			// weder die Domäne noch der Rechnername übergeben wurden
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;

			// DirectoryEntry-Objekt für den Computer oder die Domäne erzeugen
			string adsiPath = "WinNT://";
			if (domainName != null && machineName != null)
				adsiPath += domainName + "/" + machineName + ",computer";
			else if (machineName != null)
				adsiPath += machineName + ",computer";
			else if (domainName != null)
				adsiPath += domainName + ",domain";
			DirectoryEntry computerEntry = new DirectoryEntry(
				adsiPath, bindGroup, bindPassword);

			try
			{
				// Alle dem Computer untergeordneten Objekte durchgehen
				foreach(DirectoryEntry de in computerEntry.Children)
				{
					// Überprüfen, ob es sich um ein Group-Objekt handelt
					if (de.SchemaClassName.ToLower() == "group")
					{
						// Neues Group-Objekt erzeugen und initialisieren
						Group group = new Group();
						group.Name = de.Name;
						try 
						{
							group.Description = (string)de.Properties[
								"Description"].Value;} 
						catch {}
            
						// Group-Objekt an die Auflistung anfügen
						groups.Add(group);
					}
				}
			}
			finally 
			{
				// ADSI-Objekt freigeben
				computerEntry.Dispose();
			}

			// Benutzer-Auflistung zurückgeben
			return groups;
		}
	}
}
