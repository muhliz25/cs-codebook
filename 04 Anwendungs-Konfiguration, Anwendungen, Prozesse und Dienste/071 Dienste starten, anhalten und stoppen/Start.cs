using System;
using System.ServiceProcess;
using Addison_Wesley.Codebook.Services;

namespace Dienste_starten__anhalten_und_stoppen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dienst starten
			ServiceControllerStatus serviceStatus; 
			try
			{
				Console.WriteLine("Starte NetDDE ...");
				serviceStatus = ServiceUtil.StartService("NetDDE", null, null, 2000);
				if (serviceStatus != ServiceControllerStatus.Running)
				{
					Console.WriteLine("Der Dienst konnte nicht innerhalb " +
						"des Timeout gestartet werden");
					return;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Starten: {0}", ex.Message);
				Console.ReadLine();
				return;
			}

			Console.WriteLine("Dienst gestartet ... Return zum Anhalten");
			Console.ReadLine();

			// Dienst anhalten
			try
			{
				ServiceUtil.PauseService("NetDDE", null, 2000);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Anhalten: {0}", ex.Message);
				Console.ReadLine();
				return;
			}

			Console.WriteLine("Dienst angehalten ... Return zum Fortfahren");
			Console.ReadLine();

			// Dienst wieder starten
			try
			{
				serviceStatus = ServiceUtil.ContinueService("NetDDE", null, 2000);
				if (serviceStatus != ServiceControllerStatus.Running)
				{
					Console.WriteLine("Der Dienst konnte nicht innerhalb " +
						"des Timeout fortgefahren werden");
					return;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Fortfahren: {0}", ex.Message);
				Console.ReadLine();
				return;
			}

			Console.WriteLine("Dienst fortgefahren ... Return zum Stoppen");
			Console.ReadLine();
			
			// Dienst stoppen
			try
			{
				serviceStatus = ServiceUtil.StopService("NetDDE", null, 2000);
				if (serviceStatus != ServiceControllerStatus.Stopped)
				{
					Console.WriteLine("Der Dienst konnte nicht innerhalb " +
						"des Timeout gestoppt werden");
					return;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Stoppen: {0}", ex.Message);
				Console.ReadLine();
				return;
			}

			Console.WriteLine("Dienst gestoppt");
			Console.ReadLine();
		}
	}
}
