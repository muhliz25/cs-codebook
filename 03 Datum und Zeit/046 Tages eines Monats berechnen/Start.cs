using System;

namespace Tages_eines_Monats
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Berechnen der Anzahl der Tage des aktuellen Monats
			DateTime now = DateTime.Now;
			int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);

			Console.WriteLine("Tage des Monats {0}/{1}: {2}", 
				now.Month, now.Year, daysInMonth);
	
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}
	}
}
