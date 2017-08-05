using System;
using System.Globalization;
using Addison_Wesley.Codebook.DateAndTime;

namespace Datums_G�ltigkeit
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Den Anwender ein Datum im aktuellen Format eingeben lassen
			Console.Write("Geben Sie ein Datum im aktuellen " +
				"System-Format ein: ");

			string dateString = Console.ReadLine();

			// �berpr�fen, ob dieses Datum g�ltig ist
			if (DateUtil.IsDate(dateString))
			{
				Console.WriteLine("Das Datum ist g�ltig: {0}",
					System.DateTime.Parse(dateString));
			}
			else
				Console.WriteLine("Das Datum ist ung�ltig");

			// Den Anwender ein Datum im englischen Format eingeben lassen
			Console.Write("Geben Sie ein Datum im englischen Format ein: ");
			dateString = Console.ReadLine();

			// �berpr�fen, ob dieses Datum g�ltig ist
			if (DateUtil.IsDate(dateString, CultureInfo.CreateSpecificCulture("en")))
			{
				Console.WriteLine("Das Datum ist g�ltig: {0}",
					System.DateTime.Parse(dateString,
					CultureInfo.CreateSpecificCulture("en")));
			}
			else
				Console.WriteLine("Das Datum ist ung�ltig");
 
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
