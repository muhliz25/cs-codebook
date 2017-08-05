using System;
using System.Management;
using Addison_Wesley.Codebook.System;

namespace Datumswerte_konvertieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Testweise ein Win32_OperatingSystem-Objekt erzeugen 
			ManagementClass mc = new 
				ManagementClass("Win32_OperatingSystem"); 
			ManagementObjectCollection moc = mc.GetInstances();
			ManagementObjectCollection.ManagementObjectEnumerator
				mocEnumerator = moc.GetEnumerator();
			mocEnumerator.MoveNext();
			ManagementObject mo = (ManagementObject)mocEnumerator.Current; 

			// Das Installationsdatum auslesen
			string installDateString = (string)mo["InstallDate"];

			// Dieses Datum konvertieren
			DateTime installDate = SystemUtils.WMIDateToDateTime(installDateString);

			// Datum ausgeben
			Console.WriteLine("Installations-Datum: {0}", installDate);

			Console.WriteLine("Taste ...");
			Console.ReadLine();
		}
	}
}
