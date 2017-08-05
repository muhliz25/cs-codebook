using System;

namespace Datumsdifferenz
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Zwei DateTime-Objekte erzeugen
			DateTime birthDate = new DateTime(2000, 1, 2);
			DateTime now = DateTime.Now;

			// Berechnen der Differenz
			TimeSpan dateDiff = now - birthDate;

			// Ausgabe der Differenz
			Console.WriteLine("Differenz zwischen dem {0}\r\nund dem {1}:",
				birthDate.ToString(), now.ToString());
			Console.WriteLine("Ticks: {0}", dateDiff.Ticks);
			Console.WriteLine("Tage: {0}", dateDiff.Days);
			Console.WriteLine("Stunden: {0}", dateDiff.Hours);
			Console.WriteLine("Minuten: {0}", dateDiff.Minutes);
			Console.WriteLine("Sekunden: {0}", dateDiff.Seconds);
			Console.WriteLine("Millisekunden: {0}", dateDiff.Milliseconds);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
