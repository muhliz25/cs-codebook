using System;
using System.Management;

namespace WMI_Objekt_Auflistungen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// ManagementClass-Instanz f�r die WMI-Klasse erzeugen
			ManagementClass mc = new ManagementClass("Win32_LogicalDisk"); 

			// Alle dieser Klasse angeh�renden Objekte abfragen
			ManagementObjectCollection moc = mc.GetInstances();

			// Die einzelnen Objekte durchgehen
			foreach (ManagementBaseObject mbo in moc)
			{
				Console.WriteLine("{0} {1} Byte", 
					mbo["DeviceId"], mbo["Size"]);
			}

			Console.WriteLine("Taste ...");
			Console.ReadLine();
		}
	}
}
