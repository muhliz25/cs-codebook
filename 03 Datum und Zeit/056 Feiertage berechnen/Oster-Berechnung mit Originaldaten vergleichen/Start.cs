using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Addison_Wesley.Codebook.DateAndTime;

namespace Feiertage_berechnen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Die Textdatei mit den Osterfeiertagen einlesen
			StreamReader sr = new StreamReader(Path.Combine(
				Application.StartupPath,  "Ostersonntage.txt"), Encoding.Default);
			string[] easterDays = sr.ReadToEnd().Split(';');
			sr.Close();
			
			// Datum des Ostersonntags für die Jahre 1700 bis 2299 berechnen
			for (int year = 1700; year < 2300; year ++)
			{
				// Ostersonntags-Datum berechnen und ausgeben
				DateTime easterSundayDate = DateUtils.GetEasterSundayDate(year);
				Console.WriteLine(easterSundayDate.ToShortDateString());
				
				// Vergleichen mit dem Tag im Array
				bool ok = false;
				for (int i = 0; i < easterDays.Length; i++)
				{
					string yearString = easterDays[i];
					if (yearString != "")
					{
						int y = Convert.ToInt32(yearString.Substring(easterDays[i].LastIndexOf(".") + 1, 4));
						if (y == year)
						{
							// Jahr gefunden: Datum auslesen
							DateTime d = DateTime.Parse(easterDays[i].Trim());
							// Datum vergleichen 
							if (easterSundayDate.ToShortDateString() == d.ToShortDateString())
								Console.WriteLine("OK");
							else
								Console.WriteLine("Nicht OK");
							ok = true;
						}
					}
				}

				if (ok == false)
					Console.WriteLine("Jahr nicht gefunden");
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
