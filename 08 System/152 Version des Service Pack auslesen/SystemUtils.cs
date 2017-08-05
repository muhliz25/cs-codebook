using System;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Klasse für die Rückgabe der Version */
		public class OSVersion
		{
			public ushort Major;
			public ushort Minor;
		}

		/* Methode zum Ermitteln der Version des aktuellen Service Pack */
		public static OSVersion GetServicePackVersion()
		{
			// Version-Instanz für die Rückgabe erzeugen
			OSVersion version = new OSVersion();

			// Win32_OperatingSystem-Instanz für das aktive Betriebssystem ermitteln
			ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
			ManagementObjectCollection moc = mc.GetInstances();
			ManagementObjectCollection.ManagementObjectEnumerator
				mocEnumerator = moc.GetEnumerator();
			mocEnumerator.MoveNext();
			ManagementObject mo = (ManagementObject)mocEnumerator.Current;

			// Die Version abfragen und speichern
			try{version.Major =(ushort)mo["ServicePackMajorVersion"];}
			catch {}
			try{version.Minor =(ushort)mo["ServicePackMinorVersion"];}
			catch {}

			// WMI-Objekte freigeben um den Speicher möglichst schnell zu entlasten
			mo.Dispose();
			moc.Dispose();
			mc.Dispose();

			// Ergebnis zurückgeben
			return version;
		}
	}
}
