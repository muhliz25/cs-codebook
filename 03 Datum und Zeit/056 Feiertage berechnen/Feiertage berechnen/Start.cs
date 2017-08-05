using System;
using System.Collections;
using Addison_Wesley.Codebook.DateAndTime;

namespace Feiertage_berechnen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			
			// Feiertage des aktuellen Jahrs berechnen
			DateUtils.GermanSpecialDays gsd = DateUtils.GetGermanSpecialDays(DateTime.Now.Year);

			// Ostersonntag ermitteln
			DateUtils.GermanSpecialDay easterSunday = gsd[DateUtils.GermanSpecialDaysEnum.Ostersonntag];
			Console.WriteLine(easterSunday.Name);
			Console.WriteLine(easterSunday.Date.ToShortDateString());
			Console.WriteLine();

			// Die speziellen Tage zur Sortierung in ein Array
			// schreiben und sortieren
			DateUtils.GermanSpecialDay[] outputArray = new DateUtils.GermanSpecialDay[gsd.Count];
			gsd.Values.CopyTo(outputArray, 0);
			Array.Sort(outputArray, 0, outputArray.Length);

			// Die bundesweiten Feiertage ausgeben
			Console.WriteLine("Bundesweite Feiertage\r\n");
			for (int i = 0; i < outputArray.Length; i++)
			{
				if (outputArray[i].Holiday && outputArray[i].Nationwide)
				{
					Console.WriteLine(outputArray[i].Name);
					Console.WriteLine(outputArray[i].Date.ToShortDateString());
					Console.WriteLine();
				}
			}

			// Die lokalen Feiertage ausgeben
			Console.WriteLine("Lokale Feiertage\r\n");
			for (int i = 0; i < outputArray.Length; i++)
			{
				if (outputArray[i].Holiday && outputArray[i].Nationwide == false)
				{
					Console.WriteLine(outputArray[i].Name);
					Console.WriteLine(outputArray[i].Date.ToShortDateString());
					Console.WriteLine();
				}
			}

			// Die bundesweiten Spezialtage ausgeben
			Console.WriteLine("Bundesweite Spezialtage\r\n");
			for (int i = 0; i < outputArray.Length; i++)
			{
				if (outputArray[i].Holiday == false && outputArray[i].Nationwide)
				{
					Console.WriteLine(outputArray[i].Name);
					Console.WriteLine(outputArray[i].Date.ToShortDateString());
					Console.WriteLine();
				}
			}

			// Die lokalen Spezialtage ausgeben
			Console.WriteLine("Lokale Spezialtage\r\n");
			for (int i = 0; i < outputArray.Length; i++)
			{
				if (outputArray[i].Holiday == false && 
					outputArray[i].Nationwide == false)
				{
					Console.WriteLine(outputArray[i].Name);
					Console.WriteLine(outputArray[i].Date.ToShortDateString());
					Console.WriteLine();
				}
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

			
		}
	}
}
