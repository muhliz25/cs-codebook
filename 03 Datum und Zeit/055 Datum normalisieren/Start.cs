using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Datum_normalisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string dateString = null;
			do
			{
				// Den Anwender einen Datums-String eingeben lassen
				Console.Write("Geben Sie ein Datum ein (Beenden mit leerer Eingabe): ");
				dateString = Console.ReadLine();

				if (dateString != "")
				{

					try
					{
						// Das Datum normalisieren
						DateTime date = DateUtils.NormalizeDate(dateString);

						// Das normalisierte Datum ausgeben
						Console.WriteLine(date.ToString());
						Console.WriteLine();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
			} while (dateString != "");
		}
	}
}
