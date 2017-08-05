using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Feiertag
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Ermitteln, ob der 1.11. des aktuellen Jahres ein Feiertag ist
			DateTime date = new DateTime(DateTime.Now.Year, 11, 1);

			string name;
			bool nationWide;
			if (DateUtils.IsGermanHoliday(date, out name, out nationWide))
			{
				if (nationWide)
					Console.WriteLine("Der {0} ist ein bundesweiter Feiertag: {1}",
						date.ToShortDateString(), name);
				else
					Console.WriteLine("Der {0} ist ein lokaler Feiertag: {1}",
						date.ToShortDateString(), name);
			}
			else
				Console.WriteLine("Der {0} ist kein Feiertag", 
					date.ToShortDateString());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
