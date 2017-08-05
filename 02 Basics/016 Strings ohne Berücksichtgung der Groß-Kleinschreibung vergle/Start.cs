using System;

namespace Stringvergleich
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{	
			string string1 = "Hallo";
			string string2 = "hallo";

			// Normaler Vergleich
			Console.WriteLine("Normaler Vergleich");
			if (string1 == string2)
				Console.WriteLine("'{0}' und '{1}' sind gleich", string1, string2);
			else
				Console.WriteLine("'{0}' und '{1}' sind nicht gleich", string1, string2);

			Console.WriteLine();

			// Vergleich ohne Groﬂ-/Kleinschreibung
			Console.WriteLine("Vergleich ohne Groﬂ-/Kleinschreibung");
			if (String.Compare(string1, string2, true) == 0)
				Console.WriteLine("'{0}' und '{1}' sind gleich", string1, string2);
			else
				Console.WriteLine("'{0}' und '{1}' sind nicht gleich", string1, string2);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
