using System;
using Microsoft.Win32;

namespace Addison_Wesley.Codebook.AppUtils
{
	/* Aufz�hlung f�r die Registry-Wurzel-Schl�ssel */
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
			// Ermitteln des Registry-Wurzel-Schl�ssels
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
			// Schl�ssel ermitteln
			RegistryKey regKey = GetRegistryRootKey(rootKey).OpenSubKey(keyPath);

			// Wert auslesen, wenn der Unterschl�ssel gefunden wurde
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
			// Wurzel-Schl�ssel ermitteln
			RegistryKey regKey = GetRegistryRootKey(rootKey);

			// Den Pfad in seine Einzelteile zerlegen
			string[] pathToken = keyPath.Split('\\');

			// Pfad durchgehen und den Schl�ssel referenzieren
			RegistryKey subKey = null;
			for (int i = 0; i < pathToken.Length; i++)
			{
				if (regKey != null)
				{
					// Unterschl�ssel zum Lesen und Schreiben �ffnen
					subKey = regKey.OpenSubKey(pathToken[i], true);
            
					if (subKey == null && createIfNotExist)
					{
						// Unterschl�ssel nicht gefunden: Schl�ssel erzeugen 
						// falls dies gew�nscht ist
						subKey = regKey.CreateSubKey(pathToken[i]);
					}
					regKey = subKey;
				}
			}

			// Wert schreiben, wenn der Unterschl�ssel gefunden wurde
			if (regKey != null)
			{
				regKey.SetValue(valueName, value);
			}
			else
			{
				// Ausnahme werfen
				throw new Exception("Schl�ssel " + rootKey.ToString() + "\\" + 
					keyPath + " nicht gefunden");
			}
		}

		/* Methode zum L�schen eines Werts in der Registry */
		public static void DeleteValue(RegistryRootKeys rootKey, string keyPath, 
			string valueName)
		{
			// Unterschl�ssel zum Schreiben �ffnen
			RegistryKey regKey = GetRegistryRootKey(rootKey).OpenSubKey(
				keyPath, true);

			// Wert �ber den �bergeordneten Schl�ssel l�schen 
			// wenn dieser gefunden wurde
			if (regKey != null)
				regKey.DeleteValue(valueName, false);
			else
				// Schl�ssel nicht gefunden: Ausnahme werfen
				throw new Exception("Schl�ssel " + rootKey.ToString() + "\\" + 
					keyPath + " nicht gefunden");
		}

		/* Methode zum L�schen eines Schl�ssels in der Registry */
		public static void DeleteKey(RegistryRootKeys rootKey, string keyPath)
		{
			// Den Pfad zum �bergeordneten Schl�ssel und den Namen des zu l�schenden
			// Schl�ssels ermitteln
			int i = keyPath.LastIndexOf("\\");
			string parentKeyPath = keyPath.Substring(0, i);
			string keyName = keyPath.Substring(i + 1, keyPath.Length - i - 1);
   
			// Den dem zu l�schenden Schl�ssel �bergeordneten Schl�ssel zum Schreiben 
			// �ffnen
			RegistryKey regKey = GetRegistryRootKey(rootKey).OpenSubKey(
				parentKeyPath, true);

			if (regKey != null)
			{   
				// Schl�ssel �ber den �bergeordneten Schl�ssel l�schen
				regKey.DeleteSubKey(keyName);
			}
			else
				// Schl�ssel nicht gefunden: Ausnahme werfen
				throw new Exception("Schl�ssel " + rootKey.ToString() + "\\" + 
					keyPath + " nicht gefunden");
		}
	}
}
		


    

