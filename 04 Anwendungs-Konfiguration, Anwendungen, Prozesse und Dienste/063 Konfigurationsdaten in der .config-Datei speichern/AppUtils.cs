using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zum Speichern von Konfigurationsdaten in der 
		 * Konfigurationsdatei einer Anwendung */
		public static void SaveSettingToDefaultConfigFile(string settingName, 
			object settingValue)
		{
			// Dateiname zusammenstellen
			string configFileName = System.Windows.Forms.Application.ExecutablePath +
				".config";
      
			// XmlDocument für diese Datei erzeugen
			XmlDocument xmlDoc = new XmlDocument();
			try
			{
				xmlDoc.Load(configFileName);
			}
			catch (XmlException ex)
			{
				throw new XmlException("Fehler beim Laden der Konfigurationsdatei: " + 
					ex.Message, ex);
			}

			// appSettings-Element suchen und falls nicht vorhanden einfach neu 
			// anlegen
			XmlNode appSettingsNode = xmlDoc.SelectSingleNode(
				"//configuration/appSettings");
			if (appSettingsNode == null)
			{
				// appSettings-Element erzeugen
				appSettingsNode = xmlDoc.CreateElement("appSettings");

				// configuration-Element suchen
				XmlNode configurationNode = xmlDoc.SelectSingleNode(
					"//configuration");
				if (configurationNode == null)
				{
					// configuration-Element nicht gefunden: Ausnahme werfen
					throw new XmlException("configuration-Element nicht gefunden",
						null);
				}
				// appSettings-Element anhängen
				configurationNode.AppendChild(appSettingsNode);
			}

			// Einstellungs-Element suchen
			XmlNode settingNode = xmlDoc.SelectSingleNode("//configuration/" +
				"appSettings/add[attribute::key='" + settingName + "']");
			if (settingNode != null)
			{
				// Element gefunden: Wert des Attributs value aktualisieren
				settingNode.Attributes["value"].InnerText = settingValue.ToString(); 
			}
			else
			{
				// Element nicht gefunden, also neu anlegen 
				XmlElement settingElement = xmlDoc.CreateElement("add");
  
				// Attribute definieren
				settingElement.SetAttribute("key", settingName.ToString());
				settingElement.SetAttribute("value", settingValue.ToString());

				// Einstellungs-Element an das appsettings-Element anfügen
				appSettingsNode.AppendChild(settingElement);
			}

			// Datei speichern
			try
			{
				xmlDoc.Save(configFileName);
			}
			catch (XmlException ex)
			{
				throw new XmlException("Fehler beim Speichern der " +
					"Konfigurationsdatei: " + ex.Message, ex);
			}
		}
	}
}
