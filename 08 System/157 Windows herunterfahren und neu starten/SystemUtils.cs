using System;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Methode zum Herunterfahren und Booten eines Systems */
		public static void ShutdownSystem(string hostName, string remoteAuthUser,
			string remoteAuthPassword, bool reboot)
		{
			// Den Hostnamen auf localhost setzen, wenn keiner übergeben wurde
			if (hostName == null || hostName == "")
				hostName = "localhost";
   
			// ManagementScope-Objekt erzeugen, damit die EnablePrivileges-Eigenschaft
			// gesetzt und die Authentifizierungs-Informationen übergeben werden 
			// können
			ManagementScope scope = new ManagementScope(@"\\" + hostName + 
				"\\root\\cimv2");
			scope.Options.EnablePrivileges = true;
			scope.Options.Username = remoteAuthUser;
			scope.Options.Password = remoteAuthPassword;

			// Win32_OperatingSystem-Instanz für das aktive Betriebssystem ermitteln
			ManagementClass mc = new ManagementClass(scope, new ManagementPath(
				"Win32_OperatingSystem"), new ObjectGetOptions());
			ManagementObjectCollection moc = mc.GetInstances();
			ManagementObjectCollection.ManagementObjectEnumerator
				mocEnumerator = moc.GetEnumerator();
			mocEnumerator.MoveNext();
			ManagementObject mo = (ManagementObject)mocEnumerator.Current;

			// Rechner über die Win32Shutdown-Methode neu starten oder herunterfahren
			if (reboot)
				mo.InvokeMethod("Reboot", null);
			else
				mo.InvokeMethod("Shutdown", null);

			// WMI-Objekte freigeben um den Speicher möglichst schnell zu entlasten
			mo.Dispose();
			moc.Dispose();
			mc.Dispose();
		}
	}
}
