using System;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Klasse zur Speicherung von Arbeitsspeicher-Informationen */
		public class RamInformations
		{
			public ulong FreePhysicalMemory = 0;
			public ulong FreeSpaceInPagingFiles = 0;
			public ulong FreeVirtualMemory = 0;
			public ulong MaxProcessMemorySize = 0;
			public ulong TotalVirtualMemorySize = 0;
			public ulong TotalVisibleMemorySize = 0;
		}

		/* Methode zur Ermittlung von Informationen zum Arbeitsspeicher */
		public static RamInformations GetRamInformations()
		{
			// Instanz der Klasse RamInformations erzeugen
			RamInformations ri = new RamInformations();

			// Speicher-Infos über WMI abfragen
			ManagementClass mc = new ManagementClass("Win32_OperatingSystem"); 
			ManagementObjectCollection moc = mc.GetInstances();
			ManagementObjectCollection.ManagementObjectEnumerator
				mocEnumerator = moc.GetEnumerator();
			mocEnumerator.MoveNext();
			ManagementObject mo = (ManagementObject)mocEnumerator.Current; 

			try{ri.FreePhysicalMemory = (ulong)mo["FreePhysicalMemory"];}
			catch {}
			try{ri.FreeSpaceInPagingFiles = (ulong)mo["FreeSpaceInPagingFiles"];}
			catch {}
			try{ri.FreeVirtualMemory = (ulong)mo["FreeVirtualMemory"];}
			catch {}
			try{ri.MaxProcessMemorySize = (ulong)mo["MaxProcessMemorySize"];}
			catch {}
			try
			{ri.TotalVirtualMemorySize = (ulong)mo["TotalVirtualMemorySize"];}
			catch {}
			try{ri.TotalVisibleMemorySize = (ulong)mo["TotalVisibleMemorySize"];}
			catch {}
   
			// Speicher der WMI-Objekte freigeben um den Arbeitsspeicher möglichst
			// schnell zu entlasten
			mo.Dispose();
			moc.Dispose();
			mc.Dispose();

			// Informationen zurückgeben
			return ri;
		}
	}
}
