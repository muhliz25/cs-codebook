using System;
using System.DirectoryServices;

namespace Addison_Wesley.Codebook.System
{
	/* Klasse mit Utilities zur Arbeit mit Benutzern */
	public class UserUtils
	{
		/* Klasse mit den Eigenschaften für einen Benutzer */
		public class User
		{
			// Direkte Eigenschaften
			public string Name;
			public string FullName;
			public string Description;
			public int UserFlags;
			public string Parameters;
			public int MaxStorage;
			public string HomeDirectory;
			public string HomeDirDrive;
			public string LoginScript;
			public string Profile;
			public int MinPasswordLength;
			public int MinPasswordAge;
			public int MaxPasswordAge;
			public int PasswordAge;
			public bool PasswordExpired;
			public int BadPasswordAttempts;
			public int PasswordHistoryLength;
			public DateTime LastLogin;
			public DateTime LastLogoff;
			public int MaxLogins;
			public string LoginWorkstations;
			public byte[] LoginHours;
			public DateTime AccountExpirationDate;
			public int RasPermissions;
			public int LockoutObservationInterval;
			public int PrimaryGroupID;
			public byte[] objectSid;
			// Eigenschaften, deren Wert sich aus der Eigenschaft UserFlags
			// berechnet (Eingeschränkte Auswahl!). Siehe
			// msdn.microsoft.com/library/en-us/netdir/adsi/ads_user_flag_enum.asp
			public bool AccountDisabled;
			public bool AccountLocked;
			public bool HomeDirRequired;
			public bool PasswortNotRequired;
			public bool PasswordCantChange;
			public bool PasswordNotExpires;
			public bool EncryptedPasswordAllowed;
			public bool LocalAccount;
			public bool NormalAccount;
			public bool SmartcardRequired;
		}

		/* Private Methode zum Auslesen einer User-Eigenschaft */
		private static object GetADSIProperty(DirectoryEntry entry,
			string propertyName, Type t)
		{
			// Lesen der Eigenschaft
			object propertyValue = entry.Properties[propertyName].Value;

			if (propertyValue != null)
			{
				// Wenn ein Wert gespeichert ist: diesen zurückgeben
				// (boolesche Werte müssen konvertiert werden)
				if (t == typeof(bool))
					return (int)propertyValue == 0 ? false : true; 
				else
					return propertyValue;
			}
			else
			{
				// Wenn kein Wert gespeichert ist: je nach dem übergebenen Typ
				// einen passenden Leerwert zurückgeben
				if (t == typeof(string))
					return null;
				else if (t == typeof(DateTime))
					return new DateTime(0);
				else if (t == typeof(int))
					return 0;
				else if (t == typeof(bool))
					return false;
				else
					return null;
			}
		}
		
		/* Methode zum Auslesen der Eigenschaften eines Benutzers */
		public static User GetUser(string domainName,string machineName, 
			string userName, string bindUser, string bindPassword)
		{
			// Konstanten für die Flags eines Benutzers (Eingeschränkte Auswahl!)
			const int ADS_UF_ACCOUNTDISABLE = 0x0002;
			const int ADS_UF_LOCKOUT = 0x0010;
			const int ADS_UF_HOMEDIR_REQUIRED = 0x0008;
			const int ADS_UF_PASSWD_NOTREQD = 0x0020;
			const int ADS_UF_PASSWD_CANT_CHANGE = 0x0040;
			const int ADS_UF_DONT_EXPIRE_PASSWD = 0x10000;
			const int ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x0080;
			const int ADS_UF_TEMP_DUPLICATE_ACCOUNT = 0x0100;
			const int ADS_UF_NORMAL_ACCOUNT = 0x0200;
			const int ADS_UF_SMARTCARD_REQUIRED = 0x40000;

			// Gültigen Rechnernamen für den lokalen Computer erzeugen 
			// falls weder die Domäne noch der Rechnername übergeben wurden
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
   
			// DirectoryEntry-Objekt für den Benutzer erzeugen
			if (domainName == null && machineName == null)
				machineName = Environment.MachineName;
			string adsiPath = "WinNT://" +
				(domainName != null ? domainName + "/" : "") +
				(machineName != null ? machineName + "/" : "") +
				userName + ",user";
			DirectoryEntry userEntry = new DirectoryEntry(adsiPath, 
				bindUser, bindPassword);

			// User-Objekt erzeugen
			User user = new User();

			try
			{
				// Eigenschaften dieses Benutzers einlesen
				user.Name = userName;
				user.Description = (string)GetADSIProperty(
					userEntry, "Description", typeof(string));
				user.FullName = (string)GetADSIProperty(
					userEntry, "FullName", typeof(string));
				user.UserFlags = (int)GetADSIProperty(
					userEntry, "UserFlags", typeof(int));
				user.Parameters = (string)GetADSIProperty(
					userEntry, "Parameters", typeof(string));
				user.MaxStorage = (int)GetADSIProperty(
					userEntry, "MaxStorage", typeof(int));
				user.HomeDirectory = (string)GetADSIProperty(
					userEntry, "HomeDirectory", typeof(string));
				user.HomeDirDrive = (string)GetADSIProperty(
					userEntry, "HomeDirDrive", typeof(string));
				user.LoginScript = (string)GetADSIProperty(
					userEntry, "LoginScript", typeof(string));
				user.Profile = (string)GetADSIProperty(
					userEntry, "Profile", typeof(string));
				user.MinPasswordLength = (int)GetADSIProperty(
					userEntry, "MinPasswordLength", typeof(int));
				user.MinPasswordAge = (int)GetADSIProperty(
					userEntry, "MinPasswordAge", typeof(int));
				user.MaxPasswordAge = (int)GetADSIProperty(
					userEntry, "MaxPasswordAge", typeof(int));
				user.PasswordAge = (int)GetADSIProperty(
					userEntry, "PasswordAge", typeof(int));
				user.PasswordExpired = (bool)GetADSIProperty(
					userEntry, "PasswordExpired", typeof(bool));
				user.BadPasswordAttempts = (int)GetADSIProperty(
					userEntry, "BadPasswordAttempts", typeof(int));
				user.PasswordHistoryLength = (int)GetADSIProperty(
					userEntry, "PasswordHistoryLength", typeof(int));
				user.LastLogin = (DateTime)GetADSIProperty(
					userEntry, "LastLogin", typeof(DateTime));
				user.LastLogoff = (DateTime)GetADSIProperty(
					userEntry, "LastLogoff", typeof(DateTime));
				user.MaxLogins = (int)GetADSIProperty(
					userEntry, "MaxLogins", typeof(int));
				user.LoginHours =( byte[])GetADSIProperty(
					userEntry, "LoginHours", typeof(byte[]));
				user.RasPermissions = (int)GetADSIProperty(
					userEntry, "RasPermissions", typeof(int));
				user.LockoutObservationInterval = (int)GetADSIProperty(
					userEntry, "LockoutObservationInterval", typeof(int));
				user.PrimaryGroupID = (int)GetADSIProperty(
					userEntry, "PrimaryGroupID", typeof(int));
				user.objectSid = (byte[])GetADSIProperty(
					userEntry, "objectSid", typeof(byte[]));
				// Auswerten der User-Flags
				if((user.UserFlags & ADS_UF_ACCOUNTDISABLE) != 0)
					user.AccountDisabled = true;
				if((user.UserFlags & ADS_UF_DONT_EXPIRE_PASSWD) != 0)
					user.PasswordNotExpires = true;
				if((user.UserFlags & ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED) != 0)
					user.EncryptedPasswordAllowed = true;
				if((user.UserFlags & ADS_UF_HOMEDIR_REQUIRED) != 0)
					user.HomeDirRequired = true;
				if((user.UserFlags & ADS_UF_LOCKOUT ) != 0)
					user.AccountLocked = true;
				if((user.UserFlags & ADS_UF_NORMAL_ACCOUNT) != 0)
					user.NormalAccount = true;
				if((user.UserFlags & ADS_UF_PASSWD_CANT_CHANGE) != 0)
					user.PasswordCantChange = true;
				if((user.UserFlags & ADS_UF_PASSWD_NOTREQD ) != 0)
					user.PasswortNotRequired = true;
			}
			finally 
			{
				// ADSI-Objekt freigeben
				userEntry.Dispose();
			}

			// Das User-Objekt zurückgeben
			return user;
		}
	}
}