using System;

namespace Strings_in_Aufzählungswerte
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{

			string value = "friday";
			try
			{
				// Konstantenwert auslesen und in den Typ DayOfWeek casten
				DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), value, true);

				Console.WriteLine("Wert von '{0}': {1}", value, (int)day);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
