using System;
using System.Globalization;

namespace Zahlen_länderspezifisch_formatieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			double number = 1234.5678;

			// CultureInfo-Objekt für die englische Kultur erzeugen
			CultureInfo englishCulture = CultureInfo.CreateSpecificCulture("en-US");

			// Zahl in das US-englische Format formatieren
			string formattedNumber = number.ToString("#,#0.00", englishCulture);

			Console.WriteLine(formattedNumber);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}
	}
}
