using System;
using System.Globalization;
using Addison_Wesley.Codebook.Basics;

namespace Zahleingaben_prüfen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Den Anwender eine Dezimalzahl eingeben lassen
			Console.Write("Geben Sie eine Dezimalzahl ein: ");
			string input = Console.ReadLine();

			// Eingabe über IsNumber überprüfen
			if (NumberUtils.IsNumber(input))
				Console.WriteLine("Die Zahl ist gültig");
			else
				Console.WriteLine("Die Zahl ist nicht gültig");

			// Eingabe über IsDouble überprüfen
			if (NumberUtils.IsDouble(input))
				Console.WriteLine("Die Zahl ist gültig");
			else
				Console.WriteLine("Die Zahl ist nicht gültig");

			// Den Anwender eine Ganzzahl eingeben lassen
			Console.WriteLine();
			Console.Write("Geben Sie eine Ganzzahl ein: ");
			input = Console.ReadLine();

			// Eingabe über IsLong überprüfen
			if (NumberUtils.IsLong(input))
				Console.WriteLine("Die Zahl ist gültig");
			else
				Console.WriteLine("Die Zahl ist nicht gültig");

			// Den Anwender eine Dezimalzahl im englischen Format eingeben lassen
			Console.WriteLine();
			Console.Write("Geben Sie eine Dezimalzahl im englischen Format ein: ");
			input = Console.ReadLine();

			// Eingabe über IsDouble überprüfen
			if (NumberUtils.IsDouble(input, CultureInfo.CreateSpecificCulture("en-US")) == false)
				Console.WriteLine("Die Zahl ist nicht gültig");
			else
				Console.WriteLine("Die Zahl ist gültig");
            
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
