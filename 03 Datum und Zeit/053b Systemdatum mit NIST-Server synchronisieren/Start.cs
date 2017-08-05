using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Systemdatum_mit_NIST_Server_synchronisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Hole das offizielle Datum von einem NIST-Server ...");
			try
			{
				// NIST-Server abfragen
				DateTime officialDate = DateUtils.GetNISTTime();

				// Systemdatum setzen
				DateUtils.SetSystemDateTime(officialDate);

				Console.WriteLine("Systemdatum auf den " + officialDate.ToString() + " gesetzt");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Lesen oder Setzen des Systemdatums: {0}",
					ex.Message);
			}
		}
	}
}
