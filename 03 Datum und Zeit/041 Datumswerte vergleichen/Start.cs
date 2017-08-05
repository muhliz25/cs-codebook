using System;

namespace Datumswerte_vergleichen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// DateTime-Instanzen erzeugen
			DateTime d1 = new DateTime(2003, 12, 31);
			DateTime d2 = new DateTime(2004, 1, 1);
			DateTime d3 = new DateTime(2004, 1, 1);
			DateTime d4 = new DateTime(2004, 1, 1, 12, 0, 0);

			if (d1 < d2)
				Console.WriteLine("{0} ist kleiner als {1}", d1, d2);
			if (d2 == d3)
				Console.WriteLine("{0} ist gleich {1}", d2, d3);
			if (d3 != d4)
				Console.WriteLine("{0} ist ungleich {1}", d3, d4);
			if (d4 > d3)
				Console.WriteLine("{0} ist gr��er als {1}", d4, d3);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
