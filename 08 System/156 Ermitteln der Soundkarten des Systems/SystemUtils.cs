using System;
using System.Collections;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Methode zum Ermitteln der Grunddaten der installierten Soundkarten */
		public static Hashtable EnumSoundcards()
		{
			// HashTable f�r die R�ckgabe erzeugen
			Hashtable soundcards = new Hashtable();

			// Abfragen der installierten Soundkarten
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(
				"SELECT * FROM Win32_SoundDevice");
			ManagementObjectCollection moc = searcher.Get();
			foreach (ManagementBaseObject mbo in moc)
			{
				// DevideId (als Schl�ssel) und ProductName (als Wert) 
				// an die Hashtable-Instanz anf�gen
				soundcards.Add(mbo["DeviceId"], mbo["ProductName"]);
			}

			// ManagementObjectSearcher freigeben, um den Speicher m�glichst schnell zu
			// entlasten
			searcher.Dispose();

			// StringCollection zur�ckgeben
			return soundcards;
		}
	}
}
