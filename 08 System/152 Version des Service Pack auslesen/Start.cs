using System;
using Addison_Wesley.Codebook.System;

namespace Service_Pack_Info
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Version des aktuellen Service Pack abfragen */
			SystemUtils.OSVersion  servicePackVersion = SystemUtils.GetServicePackVersion();

			Console.WriteLine("Service-Pack-Version: {0}", 
				servicePackVersion.Major + "." +
				servicePackVersion.Minor); 

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
