using System;
using System.Collections;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	/* Klasse mit Benutzer-Utilities */
	public class UserUtils
	{
		/* Klasse f�r einen Benutzer mit den wichtigsten Eigenschaften */
		public class User
		{
			public string Name;          // Benutzername 
			public string FullName;      // der volle Name
			public string Description;   // eine Beschreibung
			public int MaxStorage;       // Maximaler Speicherplatz 
			public string HomeDirectory; // Benutzer-Home-Verzeichnis
			public DateTime LastLogin;   // letzter Login
		}

		/* Klasse zur Auflistung von User-Instanzen */
		public class Users: CollectionBase
		{
			/* Indizierer */
			public User this[int index]
			{
				set {base.InnerList[index] = value;}
				get {return (User)base.InnerList[index];}
			}

			/* Add-Methode */
			internal void Add(User user)
			{
				base.InnerList.Add(user);
			}
		}
	
		/* Methode zum Auflisten aller Benutzer eines Computers */
		public static Users EnumUsers(string domainName, string machineName, 
			string bindUser, string bindPassword)
		{
			// Users-Auflistung f�r das Ergebnis erzeugen
			Users users = new Users();

			// G�ltigen Rechnernamen f�r den lokalen Computer erzeugen, falls
			// weder die Dom�ne noch der Rechnername �bergeben wurden
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;

			// ADSI-Pfad f�r den WinNT-Provider zum Auslesen des Computers bzw. 
			// der Dom�ne zusammenstellen
			string adsiPath = "WinNT://";
			if (domainName != null && machineName != null)
				adsiPath += domainName + "/" + machineName + ",computer";
			else if (machineName != null)
				adsiPath += machineName + ",computer";
			else if (domainName != null)
				adsiPath += domainName + ",domain";

			// DirectoryEntry-Objekt erzeugen
			DirectoryEntry computerEntry = new DirectoryEntry(adsiPath, bindUser,
				bindPassword);
   
			try
			{
				// Alle dem Computer untergeordneten Objekte durchgehen
				foreach(DirectoryEntry de in computerEntry.Children)
				{
					// �berpr�fen, ob es sich um ein User-Objekt handelt
					if (de.SchemaClassName.ToLower() == "user")
					{
						// Neues Benutzer-Objekt erzeugen und initialisieren
						User user = new User();
						user.Name = de.Name;
						try 
						{
							user.FullName = (string)de.Properties[
								"FullName"].Value;} 
						catch {}
						try 
						{
							user.Description = (string)de.Properties[
								"Description"].Value;} 
						catch {}
						try
						{
							user.HomeDirectory = (string)de.Properties[
								"HomeDirectory"].Value;} 
						catch {}
						try
						{
							user.MaxStorage = (int)de.Properties[
								"MaxStorage"].Value;} 
						catch {}
						try 
						{
							user.LastLogin = (DateTime)de.Properties[
								"LastLogin"].Value;} 
						catch {}
            
						// User-Objekt an die Auflistung anf�gen
						users.Add(user);
					}
				}
			}
			finally 
			{
				// ADSI-Objekt freigeben
				computerEntry.Dispose();
			}

			// Benutzer-Auflistung zur�ckgeben
			return users;
		}
	}
}
