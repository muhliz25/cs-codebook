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
			// Den Hostnamen auf localhost setzen, wenn keiner �bergeben wurde
			if (hostName == null || hostName == "")
				hostName = "localhost";
   
			// ManagementScope-Objekt erzeugen, damit die EnablePrivileges-Eigenschaft
			// gesetzt und die Authentifizierungs-Informationen �bergeben werden 
			// k�nnen
			ManagementScope scope = new ManagementScope(@"\\" + hostName + 
				"\\root\\cimv2");
			scope.Options.EnablePrivileges = true;
			scope.Options.Username = remoteAuthUser;
			scope.Options.Password = remoteAuthPassword;

			// Win32_OperatingSystem-Instanz f�r das aktive Betriebssystem ermitteln
			ManagementClass mc = new ManagementClass(scope, new ManagementPath(
				"Win32_OperatingSystem"), new ObjectGetOptions());
			ManagementObjectCollection moc = mc.GetInstances();
			ManagementObjectCollection.ManagementObjectEnumerator
				mocEnumerator = moc.GetEnumerator();
			mocEnumerator.MoveNext();
			ManagementObject mo = (ManagementObject)mocEnumerator.Current;

			// Rechner �ber die Win32Shutdown-Methode neu starten oder herunterfahren
			if (reboot)
				mo.InvokeMethod("Reboot", null);
			else
				mo.InvokeMethod("Shutdown", null);

			// WMI-Objekte freigeben um den Speicher m�glichst schnell zu entlasten
			mo.Dispose();
			moc.Dispose();
			mc.Dispose();
		}
	}
}
