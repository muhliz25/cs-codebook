using System;
using System.Configuration;
using Addison_Wesley.Codebook.Configuration;

namespace Config_Handler_Demo
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			DatabaseConfig databaseConfig = null;
			SystemConfig systemConfig = null;

			try
			{
				// Einlesen der Konfiguration
				systemConfig = (SystemConfig)ConfigurationSettings.GetConfig(
					"codebook/system");
				databaseConfig = (DatabaseConfig)ConfigurationSettings.GetConfig(
					"codebook/database");

				// Überprüfen, ob der System-Konfigurationsabschnitt eingelesen wurde
				if (systemConfig != null)
				{
					// Ausgeben der Konfigurationsdaten
					Console.WriteLine("LastAccess: {0}", systemConfig.LastAccess);
				}
				else
					Console.WriteLine("Die Systemkonfiguration konnte nicht " +
						"eingelesen werden");

				// Überprüfen, ob der Datenbank-Konfigurationsabschnitt 
				// eingelesen wurde
				if (databaseConfig != null)
				{
					// Ausgeben der Konfigurationsdaten
					Console.WriteLine("Server: {0}", databaseConfig.Server);
					Console.WriteLine("UserId: {0}", databaseConfig.UserId);
					Console.WriteLine("Passwort: {0}", databaseConfig.Password);
				}
				else
					Console.WriteLine("Die Datenbankkonfiguration konnte nicht " +
						"eingelesen werden");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
