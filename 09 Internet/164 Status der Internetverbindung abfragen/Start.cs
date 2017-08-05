using System;
using Addison_Wesley.Codebook.Internet;

namespace Internetverbindungs_Status
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// Internetverbindungs-Status abfragen
				InternetUtils.InternetConnectionState ics = InternetUtils.GetInternetConnectionState();

				// Ergebnis ausgeben
				Console.WriteLine("Name: {0}", ics.Name);
				Console.WriteLine("Online: {0}", ics.Online);
				Console.WriteLine("Configured: {0}", ics.Configured);
				Console.WriteLine("Lan: {0}", ics.Lan);
				Console.WriteLine("ModemConnection: {0}", ics.ModemConnection);
				Console.WriteLine("Offline: {0}", ics.Offline);
				Console.WriteLine("ProxyConnection: {0}", ics.ProxyConnection);
				Console.WriteLine("RASInstalled: {0}", ics.RASInstalled);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler bei der Abfrage des Internet-Verbindungsstatus: {0}", ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
