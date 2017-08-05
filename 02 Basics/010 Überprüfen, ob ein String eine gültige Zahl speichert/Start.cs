using System;
using System.Globalization;
using Addison_Wesley.Codebook.Basics;

namespace Zahleingaben_pr�fen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Den Anwender eine Dezimalzahl eingeben lassen
			Console.Write("Geben Sie eine Dezimalzahl ein: ");
			string input = Console.ReadLine();

			// Eingabe �ber IsNumber �berpr�fen
			if (NumberUtils.IsNumber(input))
				Console.WriteLine("Die Zahl ist g�ltig");
			else
				Console.WriteLine("Die Zahl ist nicht g�ltig");

			// Eingabe �ber IsDouble �berpr�fen
			if (NumberUtils.IsDouble(input))
				Console.WriteLine("Die Zahl ist g�ltig");
			else
				Console.WriteLine("Die Zahl ist nicht g�ltig");

			// Den Anwender eine Ganzzahl eingeben lassen
			Console.WriteLine();
			Console.Write("Geben Sie eine Ganzzahl ein: ");
			input = Console.ReadLine();

			// Eingabe �ber IsLong �berpr�fen
			if (NumberUtils.IsLong(input))
				Console.WriteLine("Die Zahl ist g�ltig");
			else
				Console.WriteLine("Die Zahl ist nicht g�ltig");

			// Den Anwender eine Dezimalzahl im englischen Format eingeben lassen
			Console.WriteLine();
			Console.Write("Geben Sie eine Dezimalzahl im englischen Format ein: ");
			input = Console.ReadLine();

			// Eingabe �ber IsDouble �berpr�fen
			if (NumberUtils.IsDouble(input, CultureInfo.CreateSpecificCulture("en-US")) == false)
				Console.WriteLine("Die Zahl ist nicht g�ltig");
			else
				Console.WriteLine("Die Zahl ist g�ltig");
            
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
