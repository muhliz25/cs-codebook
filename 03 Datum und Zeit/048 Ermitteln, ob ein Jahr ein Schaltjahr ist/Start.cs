using System;

namespace Schaltjahr
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Aktuelles Datum ermitteln
			DateTime now = DateTime.Now;

			// Ermitteln, ob es sich um ein Schaltjahr handelt
			if (DateTime.IsLeapYear(now.Year))
				Console.WriteLine("Schaltjahr");
			else
				Console.WriteLine("Kein Schaltjahr");

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
