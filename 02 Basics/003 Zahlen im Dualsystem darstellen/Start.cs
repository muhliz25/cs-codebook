using System;
using Addison_Wesley.Codebook.Basics;

namespace Zahlen_dual_darstellen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("ulong-Werte als Dualzahl:");
			for (ulong i = 0; i < 10; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));
			Console.WriteLine("{0:000}: {1}", ulong.MaxValue, NumberUtils.DualNumber(ulong.MaxValue));
			Console.WriteLine();

			Console.WriteLine("long-Werte als Dualzahl:");
			for (long i = -10; i < 10; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));
			Console.WriteLine("{0:000}: {1}", long.MinValue + 1, NumberUtils.DualNumber(long.MinValue + 1));
			Console.WriteLine("{0:000}: {1}", long.MinValue, NumberUtils.DualNumber(long.MinValue));
			Console.WriteLine("{0:000}: {1}", long.MaxValue, NumberUtils.DualNumber(long.MaxValue));
			Console.WriteLine();

			Console.WriteLine("uint-Werte als Dualzahl:");
			for (uint i = 0; i < 10; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));
			Console.WriteLine("{0:000}: {1}", uint.MaxValue, NumberUtils.DualNumber(uint.MaxValue));
			Console.WriteLine();

			Console.WriteLine("int-Werte als Dualzahl:");
			for (int i = -10; i < 10; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));
			Console.WriteLine("{0:000}: {1}", int.MinValue, NumberUtils.DualNumber(int.MinValue));
			Console.WriteLine("{0:000}: {1}", int.MaxValue, NumberUtils.DualNumber(int.MaxValue));
			Console.WriteLine();

			// Zahlen vom -5 bis +2 als Dualzahl darstellen
			for (short i = -5; i < 5; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));

			// Kleinste short-Zahl + 1 darstellen
			Console.WriteLine("{0:000}: {1}", short.MinValue + 1,
				NumberUtils.DualNumber((short)(short.MinValue + 1)));

			// Kleinste short-Zahl darstellen
			Console.WriteLine("{0:000}: {1}", short.MinValue,
				NumberUtils.DualNumber(short.MinValue));

			// Größte short-Zahl darstellen
			Console.WriteLine("{0:000}: {1}", short.MaxValue,
				NumberUtils.DualNumber(short.MaxValue));
			Console.WriteLine();

			Console.WriteLine("ushort-Werte als Dualzahl:");

			// Zahlen vom 0 bis +5 als Dualzahl darstellen
			for (ushort i = 0; i < 10; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));

			// Größte ushort-Zahl darstellen
			Console.WriteLine("{0:000}: {1}", ushort.MaxValue,
				NumberUtils.DualNumber(ushort.MaxValue));

			Console.WriteLine("byte-Werte als Dualzahl:");
			for (byte i = 0; i < 10; i++)
				Console.WriteLine("{0:000}: {1}", i, NumberUtils.DualNumber(i));
			Console.WriteLine("{0:000}: {1}", byte.MaxValue, NumberUtils.DualNumber(byte.MaxValue));
			Console.WriteLine();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
