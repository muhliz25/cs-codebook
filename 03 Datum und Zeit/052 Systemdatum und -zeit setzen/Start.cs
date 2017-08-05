using System;
using System.Globalization; 
using Addison_Wesley.Codebook.DateAndTime;

namespace Systemzeit_setzen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Den Anwender die neuen Datumswerte eingeben lassen
			Console.Write("Geben Sie das neue Datum ein: ");
			string dateString = Console.ReadLine();
			Console.Write("Geben Sie die neue Zeit ein: ");
			string timeString = Console.ReadLine();

			System.DateTime date = DateTime.Now;
			System.DateTime time = DateTime.Now; 
			try
			{
				// Datumswerte konvertieren
				date = System.DateTime.Parse(dateString);
				time = System.DateTime.Parse(timeString);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Konvertieren der " +
					"eingegebenen Daten: {0}", ex.Message);
			}

			try
			{
				// Systemdatum und -zeit setzen
				DateUtils.SetSystemDate(date);
				DateUtils.SetSystemTime(time);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Fehler beim Setzen der Systemzeit: {0} ", ex.Message);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
