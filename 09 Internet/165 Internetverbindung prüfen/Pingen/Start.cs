using System;
using Addison_Wesley.Codebook.Internet;

namespace Pingen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Prüfen, ob eine Internetverbindung nach www.google.de möglich ist */
			string address = "www.google.de";
			InternetUtils.PingResult pingResult = InternetUtils.Ping(address, 1000);
			switch (pingResult)
			{
				case InternetUtils.PingResult.OK:
					Console.WriteLine("Ping an {0} war erfolgreich", address);
					break;
				case InternetUtils.PingResult.Timeout:
					Console.WriteLine("Timeout beim Ping an {0}", address);
					break;
				case InternetUtils.PingResult.ChecksumError:
					Console.WriteLine("Daten wurden empfangen, aber es ist ein " +
						"Prüfsummenfehler aufgetreten {0}", address);
					break;
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
