using System;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Klasse f�r die R�ckgabe der Version */
		public class OSVersion
		{
			public ushort Major;
			public ushort Minor;
		}

		/* Methode zum Ermitteln der Version des aktuellen Service Pack */
		public static OSVersion GetServicePackVersion()
		{
			// Version-Instanz f�r die R�ckgabe erzeugen
			OSVersion version = new OSVersion();

			// Win32_OperatingSystem-Instanz f�r das aktive Betriebssystem ermitteln
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

			// WMI-Objekte freigeben um den Speicher m�glichst schnell zu entlasten
			mo.Dispose();
			moc.Dispose();
			mc.Dispose();

			// Ergebnis zur�ckgeben
			return version;
		}
	}
}
