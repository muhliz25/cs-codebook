using System;
using Addison_Wesley.Codebook.Internet;

namespace Internetverbindung_öffnen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Internetverbindung öffnen
			try
			{
				InternetUtils.OpenLocalConnection(false, 0);

				Console.WriteLine("Internetverbindung ist geöffnet");
				Console.WriteLine("Schließen mit Return");
				Console.ReadLine();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			// Internetverbindung schließen
			try
			{
				InternetUtils.CloseLocalConnection();

				Console.WriteLine("Internetverbindung ist geschlossen");
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
