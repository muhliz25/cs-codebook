using System;
using Addison_Wesley.Codebook.Internet;

namespace Internetverbindung_�ber_CheckConnectedState_pr�fen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Pr�fen, ob eine Internetverbindung nach www.google.de m�glich ist */
			// string address = "http://www.google.de";
			string address = null;
			string error;
			if (InternetUtils.CheckConnection(address, out error))
				Console.WriteLine("Verbindung nach {0} ist m�glich", address);
			else
				Console.WriteLine("Verbindung nach {0} ist nicht m�glich: {1}", address, error);
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
