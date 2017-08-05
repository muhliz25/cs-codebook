using System;
using System.Xml;
using System.Configuration;

namespace Addison_Wesley.Codebook.Configuration
{
	/* Klasse zur Speicherung der Datenbank-Konfiguration */
	public class DatabaseConfig
	{
		public string Server;
		public string UserId;
		public string Password;

		internal DatabaseConfig(string server, string userId, string password)
		{
			this.Server = server;
			this.UserId = userId;
			this.Password = password;
		}
	}

	/* Klasse zur Speicherung der System-Konfiguration */
	public class SystemConfig
	{
		public string LastAccess;

		internal SystemConfig(string lastAccess)
		{
			this.LastAccess = lastAccess;
		}
	}

	/* Klasse, die den Konfigurations-Sektions-Handler implementiert */
	public class ConfigSectionHandler: IConfigurationSectionHandler
	{
		/* Implementierung der Create-Methode */
		public object Create(object parent, object configContext, XmlNode section)
		{
			if (section.Name == "database")
			{
				// Einlesen der Unterelemente der Sektion
				XmlNode subNode;
				string server = null;
				subNode = section.SelectSingleNode("server");
				if (subNode != null)
					server = subNode.InnerText;

				string userId = null;
				subNode = section.SelectSingleNode("userId");
				if (subNode != null)
					userId = subNode.InnerText;

				string password = null;
				subNode = section.SelectSingleNode("password");
				if (subNode != null)
					password = subNode.InnerText;

				// Neue DatabaseConfig-Instanz zurückgeben 
				return new DatabaseConfig(server, userId, password);

			}
			else if (section.Name == "system")
			{
				// Einlesen der Unterelemente der Sektion
				XmlNode subNode;
				string lastAccess = null;
				subNode = section.SelectSingleNode("lastAccess");
				if (subNode != null)
					lastAccess = subNode.InnerText;

				// Neue SystemConfig-Instanz zurückgeben 
				return new SystemConfig(lastAccess);
			}
			else
			{
				// Unbekannte Sektion: Ausnahme werfen
				throw new ConfigurationException("Unbekannte Konfigurations-" +
					"Sektion '" + section.Name + "'");
			}
		}
	}
}
