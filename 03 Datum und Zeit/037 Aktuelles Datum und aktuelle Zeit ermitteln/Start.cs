using System;

namespace Aktuelles_Datum
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Aktuelles Datum ermitteln 
			DateTime now = DateTime.Now;

			// Datum und Zeit ausgeben
			Console.WriteLine("Datum: {0}", now.ToShortDateString());
			Console.WriteLine("Zeit: {0}", now.ToLongTimeString());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
