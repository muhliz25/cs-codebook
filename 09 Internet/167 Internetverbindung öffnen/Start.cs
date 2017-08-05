using System;
using Addison_Wesley.Codebook.Internet;

namespace Internetverbindung_�ffnen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Internetverbindung �ffnen
			try
			{
				InternetUtils.OpenLocalConnection(false, 0);

				Console.WriteLine("Internetverbindung ist ge�ffnet");
				Console.WriteLine("Schlie�en mit Return");
				Console.ReadLine();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			// Internetverbindung schlie�en
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
