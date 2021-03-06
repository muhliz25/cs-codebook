using System;
using System.Collections;
using System.Net;
using System.Management;

namespace Addison_Wesley.Codebook.Internet
{
	public class InternetUtils
	{
		public static string[] GetLocalIPAddresses()
		{
			string[] result = null;

			try 
			{
				ArrayList addressList = new ArrayList();
            
				// Alle Netzwerkadapter des Systems ermitteln und durchgehen
				ManagementClass mc = new ManagementClass(
					"Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mo in moc) 
				{
					if ((bool)mo["IpEnabled"]) 
					{
						// Wenn der Adapter das IP-Protokoll unterstützt: 
						// Adressen auslesen
						string[] ipAddresses = (string[])mo["IPAddress"];
						foreach (string ipAddress in ipAddresses) 
							addressList.Add(ipAddress);
					}
				}
            
				// ArrayList in String-Array kopieren
				if (addressList.Count > 0) 
				{
					result = new string[addressList.Count];
					addressList.CopyTo(result);
				} 
				else 
					result = new string[0];
			} 
			catch {} 
         
			return result;
		}
	}
}
