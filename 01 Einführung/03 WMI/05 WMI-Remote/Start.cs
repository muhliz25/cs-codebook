using System;
using System.Management; 

namespace WMI_Remote
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string hostName = "Trillian";
			string authUser = "Ford";
			string authPassword = "Handtuch";

			// Verbindungsinformationen für das entfernte System und die Authentifizierung der
			// Abfrage erzeugen
			ManagementScope scope = new ManagementScope(@"\\" + hostName + @"\root\cimv2");
			scope.Options.Username = authUser;
			scope.Options.Password = authPassword; 

			// Die Betriebssysteme des Remote-Systems abfragen
			ManagementClass mc = new ManagementClass(scope, 
				new ManagementPath("Win32_OperatingSystem"), new ObjectGetOptions());
			ManagementObjectCollection moc = mc.GetInstances();
			foreach (ManagementBaseObject mbo in moc)
			{
				Console.WriteLine("Computername: {0}", mbo.Properties["CSName"].Value);
				Console.WriteLine("Betriebssystem: {0}", mbo.Properties["Caption"].Value);
				Console.WriteLine("Version: {0}", mbo.Properties["Version"].Value);
				Console.WriteLine("Freier physischer Speicher: {0}", 
					mbo.Properties["FreePhysicalMemory"].Value);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
