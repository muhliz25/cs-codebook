using System;
using System.Configuration;

namespace Konfigurationsdaten_aus_der_config_Datei_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string server = ConfigurationSettings.AppSettings["Server"];
			string userId = ConfigurationSettings.AppSettings["UserId"];
			string password = ConfigurationSettings.AppSettings["password"];

			Console.WriteLine("Server: {0}", server);
			Console.WriteLine("User-Id: {0}", userId);
			Console.WriteLine("Passwort: {0}", password);


			Console.ReadLine();
		}
	}
}

