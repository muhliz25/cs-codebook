using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Addison_Wesley.Codebook.DateAndTime;

namespace Datum_einer_Kalenderwoche
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Textdatei öffnen
			string fileName = Path.Combine(Application.StartupPath,
				"Kalenderwochen.txt");
			StreamWriter sr = new StreamWriter(fileName, false,
				Encoding.Default);

			// Startdatums-Werte für die Kalenderwochen zwischen 1999
			// und 2009 berechnen
			for (int year = 1999; year < 2010; year++)
			{
				for (int calendarWeek = 1; calendarWeek < 54;
					calendarWeek++)
				{
					// Das Startdatum dieser Kalenderwoche ermitteln 
					// und ausgeben
					DateTime date =
						DateUtils.GetGermanCalendarWeekStartDate(
						calendarWeek, year);

					Console.WriteLine("KW {0}/{1}: {2}", calendarWeek,
						year, date.ToLongDateString());
					sr.WriteLine("KW {0}/{1}: {2}", calendarWeek,
						year, date.ToLongDateString());
				}
			}

			// StreamWriter schließen
			sr.Close();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
