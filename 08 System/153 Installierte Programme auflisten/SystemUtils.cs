using System;
using System.Management;
using System.Collections.Specialized; 
using Microsoft.Win32;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Methode zum Auflisten der installierten Software */
		public static StringCollection EnumInstalledPrograms()
		{
			// StringCollection f�r die R�ckgabe erzeugen
			StringCollection installedPrograms = new StringCollection();

			// RegistryKey-Instanz f�r den Schl�ssel HKEY_LOCAL_MACHINE\Software\
			// Microsoft\Windows\CurrentVersion\Uninstall erzeugen
			string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
			RegistryKey regKey = Registry.LocalMachine.OpenSubKey(keyPath);
			if (regKey != null)
			{
				// Alle Unterschl�ssel durchgehen
				string[] subKeyNames = regKey.GetSubKeyNames();
				for (int i = 0; i < subKeyNames.Length; i++)
				{
					// Unterschl�ssel �ffnen und den Wert DisplayName oder 
					// QuietDisplayName auslesen
					RegistryKey subKey = regKey.OpenSubKey(subKeyNames[i]);
					string programName = (string)subKey.GetValue("DisplayName");
					if (programName == null)
						programName = (string)subKey.GetValue("QuietDisplayName");

					// Wenn ein Programmname ermittelt werden konnte, diesen an die 
					// String-Auflistung anf�gen
					if (programName != null)
						installedPrograms.Add(programName);
				}
			}
			else
			{
				// Schl�ssel nicht gefunden: Ausnahme generieren
				throw new Exception("Registry-Schl�ssel " + 
					Registry.LocalMachine.Name + "\\" + keyPath + " nicht gefunden");
			}

			return installedPrograms;
		}
	}
}
