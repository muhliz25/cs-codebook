using System;

namespace Zahl_Notationen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			double doubleNumber = 1234.5678;
			int intNumber = 1234;
			
			// W�hrung
			Console.WriteLine(doubleNumber.ToString("C"));

			// Wissenschaftliches Format
			Console.WriteLine(doubleNumber.ToString("e"));
			Console.WriteLine(doubleNumber.ToString("E"));

			// Formatierung als Prozentwert
			Console.WriteLine(doubleNumber.ToString("P"));

			// Formatierung als normale Zahl ohne Tausendertrennzeichen
			Console.WriteLine(doubleNumber.ToString("G"));

			// Formatierung mit mindestens einer Ziffer links
			// und zwei Ziffern rechts vom Dezimaltrennzeichen
			Console.WriteLine(doubleNumber.ToString("F"));

			// Formatierung als normale Zahl mit Tausendertrennzeichen
			// und zwei Dezimalziffern
			Console.WriteLine(doubleNumber.ToString("N"));

			// Hexadezimal (nur Integer-Werte)
			Console.WriteLine(intNumber.ToString("X"));

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}