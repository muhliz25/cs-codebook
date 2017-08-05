using System;
using Addison_Wesley.Codebook.Application;

namespace Konfigurationsdaten_in_der_config_Datei_speichern
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
            // Konfigurationsdaten in die Anwendungskonfigurationsdatei schreiben
            AppUtils.SaveSettingToDefaultConfigFile("Server", "Zaphod");
            AppUtils.SaveSettingToDefaultConfigFile("UserId", "Trillian");
            AppUtils.SaveSettingToDefaultConfigFile("Password", "42");
            
            Console.WriteLine("Fertig");
            Console.ReadLine();
		}
	}
}
