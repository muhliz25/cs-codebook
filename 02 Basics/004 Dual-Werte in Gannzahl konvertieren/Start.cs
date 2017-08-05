using System;

namespace Dual_Werte_konvertieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string dualNumber = "00001010";

			// Konvertieren des Dualwerts in eine byte-Zahl
			byte number = 0;
			try
			{
				number = Convert.ToByte(dualNumber, 2);

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
