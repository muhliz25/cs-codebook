using System;
using Microsoft.Win32;

namespace Addison_Wesley.Codebook.AppUtils
{
	/* Aufzählung für die Registry-Wurzel-Schlüssel */
	public enum RegistryRootKeys
	{
		HKEY_CLASSES_ROOT, 
		HKEY_CURRENT_CONFIG, 
		HKEY_CURRENT_USER, 
		HKEY_DYN_DATA, 
		HKEY_LOCAL_MACHINE, 
		HKEY_PERFORMANCE_DATA,
		HKEY_USERS
	}
	
	/* Klasse zur Vereinfachung von Registry-Zugriffen */
	public class RegUtils
	{
		private static RegistryKey GetRegistryRootKey(RegistryRootKeys rootKey)
		{
			// Ermitteln des Registry-Wurzel-Schlüssels
			RegistryKey regKey = null; 
			switch (rootKey)
			{
				case RegistryRootKeys.HKEY_CLASSES_ROOT:
					regKey = Registry.ClassesRoot; 
					break;
				case RegistryRootKeys.HKEY_CURRENT_CONFIG:
					regKey = Registry.CurrentConfig;
					break;
				case RegistryRootKeys.HKEY_CURRENT_USER:
					regKey = Registry.CurrentUser; 
					break;
				case RegistryRootKeys.HKEY_DYN_DATA:
					regKey = Registry.DynData;
					break;
				case RegistryRootKeys.HKEY_LOCAL_MACHINE:
					regKey = Registry.LocalMachine;
					break;
				case RegistryRootKeys.HKEY_PERFORMANCE_DATA:
					regKey = Registry.PerformanceData;
					break;
				case RegistryRootKeys.HKEY_USERS:
					regKey = Registry.Users;
					break;
			}

			return regKey;
		}

		/* Methode zum Lesen eines Registry-Eintrags */
		public static object ReadValue(RegistryRootKeys rootKey, string keyPath,
			string valueName, object defaultValue)
		{
			// Schlüssel ermitteln
			RegistryKey regKey = GetRegistryRootKey(rootKey).OpenSubKey(keyPath);

			// Wert auslesen, wenn der Unterschlüssel gefunden wurde
			object regValue = defaultValue;
			if (regKey != null)
			{
				regValue = regKey.GetValue(valueName);
			}

			return regValue;
		}

		/*  Methode zum Schreiben eines Registry-Eintrags */
		public static void WriteValue(RegistryRootKeys rootKey, string keyPath,
			string valueName, object value, bool createIfNotExist)
		{
			// Wurzel-Schlüssel ermitteln
			RegistryKey regKey = GetRegistryRootKey(rootKey);

			// Den Pfad in seine Einzelteile zerlegen
			string[] pathToken = keyPath.Split('\\');

			// Pfad durchgehen und den Schlüssel referenzieren
			RegistryKey subKey = null;
			for (int i = 0; i < pathToken.Length; i++)
			{
				if (regKey != null)
				{
					// Unterschlüssel zum Lesen und Schreiben öffnen
					subKey = regKey.OpenSubKey(pathToken[i], true);
            
					if (subKey == null && createIfNotExist)
					{
						// Unterschlüssel nicht gefunden: Schlüssel erzeugen 
						// falls dies gewünscht ist
						subKey = regKey.CreateSubKey(pathToken[i]);
					}
					regKey = subKey;
				}
			}

			// Wert schreiben, wenn der Unterschlüssel gefunden wurde
			if (regKey != null)
			{
				regKey.SetValue(valueName, value);
			}
			else
			{
				// Ausnahme werfen
				throw new Exception("Schlüssel " + rootKey.ToString() + "\\" + 
					keyPath + " nicht gefunden");
			}
		}

		/* Methode zum Löschen eines Werts in der Registry */
		public static void DeleteValue(RegistryRootKeys rootKey, string keyPath, 
			string valueName)
		{
			// Unterschlüssel zum Schreiben öffnen
			RegistryKey regKey = GetRegistryRootKey(rootKey).OpenSubKey(
				keyPath, true);

			// Wert über den übergeordneten Schlüssel löschen 
			// wenn dieser gefunden wurde
			if (regKey != null)
				regKey.DeleteValue(valueName, false);
			else
				// Schlüssel nicht gefunden: Ausnahme werfen
				throw new Exception("Schlüssel " + rootKey.ToString() + "\\" + 
					keyPath + " nicht gefunden");
		}

		/* Methode zum Löschen eines Schlüssels in der Registry */
		public static void DeleteKey(RegistryRootKeys rootKey, string keyPath)
		{
			// Den Pfad zum übergeordneten Schlüssel und den Namen des zu löschenden
			// Schlüssels ermitteln
			int i = keyPath.LastIndexOf("\\");
			string parentKeyPath = keyPath.Substring(0, i);
			string keyName = keyPath.Substring(i + 1, keyPath.Length - i - 1);
   
			// Den dem zu löschenden Schlüssel übergeordneten Schlüssel zum Schreiben 
			// öffnen
			RegistryKey regKey = GetRegistryRootKey(rootKey).OpenSubKey(
				parentKeyPath, true);

			if (regKey != null)
			{   
				// Schlüssel über den übergeordneten Schlüssel löschen
				regKey.DeleteSubKey(keyName);
			}
			else
				// Schlüssel nicht gefunden: Ausnahme werfen
				throw new Exception("Schlüssel " + rootKey.ToString() + "\\" + 
					keyPath + " nicht gefunden");
		}
	}
}
		


    

