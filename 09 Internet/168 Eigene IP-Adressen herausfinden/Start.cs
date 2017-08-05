using System;
using System.Net;
using Addison_Wesley.Codebook.Internet;

namespace Eigene_IP_Adressen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Die eigenen IP-Adressen �ber Dns herausfinden
			Console.WriteLine("Die IP-Adressen �ber DNS:");
			IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
			for (int i = 0; i < addressList.Length; i ++)
			{
				string ipAddress = addressList[i].ToString();
				Console.WriteLine(ipAddress);
			} 
			Console.WriteLine();

			// Die eigenen IP-Adressen �ber WMI herausfinden
			Console.WriteLine("Die IP-Adressen �ber WMI:");
			string[] ipAddresses = InternetUtils.GetLocalIPAddresses();
			foreach (string ipAddress in ipAddresses)
				Console.WriteLine(ipAddress);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
