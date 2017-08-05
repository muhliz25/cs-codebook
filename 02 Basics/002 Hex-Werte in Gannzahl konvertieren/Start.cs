using System;

namespace Hex_Werte_in_Gannzahl_konvertieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string hexNumber = "FFA033";

			// Konvertieren des Hex-Werts in eine long-Zahl
			long number = 0;
			try
			{
				number = Convert.ToInt64(hexNumber, 16);

				Console.WriteLine(number);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Konvertieren: {0}", ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
