using System;
using System.Management;

namespace WMI_Abfragen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// ManagementObjectSearcher-Instanz für die Abfrage aller
			// Festplatten-Laufwerke erzeugen
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(
				"SELECT DeviceId, Description, Size " +
				"FROM Win32_LogicalDisk WHERE DriveType = 3");

			// Das Ergebnis abfragen ...
			ManagementObjectCollection moc = searcher.Get();

			// ... und durchgehen
			foreach (ManagementBaseObject mbo in moc)
			{
				Console.WriteLine();
				Console.WriteLine("DeviceId:{0}", mbo["DeviceId"]);
				Console.WriteLine("Description:{0}", mbo["Description"]);
				Console.WriteLine("Size:{0}", mbo["Size"]);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
