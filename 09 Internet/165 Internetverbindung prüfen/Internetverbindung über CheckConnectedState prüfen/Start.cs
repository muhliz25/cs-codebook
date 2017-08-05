using System;
using Addison_Wesley.Codebook.Internet;

namespace Internetverbindung_über_CheckConnectedState_prüfen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Prüfen, ob eine Internetverbindung nach www.google.de möglich ist */
			// string address = "http://www.google.de";
			string address = null;
			string error;
			if (InternetUtils.CheckConnection(address, out error))
				Console.WriteLine("Verbindung nach {0} ist möglich", address);
			else
				Console.WriteLine("Verbindung nach {0} ist nicht möglich: {1}", address, error);
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
