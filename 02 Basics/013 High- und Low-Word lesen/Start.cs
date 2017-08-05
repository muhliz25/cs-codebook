using System;
using Addison_Wesley.Codebook.Basics;

namespace High_und_Low_Word_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			uint value1 = 0xAAAAFFFF;

			// Auslesen des hohen und des niedrigen Word
			ushort highWord = NumberUtils.GetHighWord(value1);
			ushort lowWord = NumberUtils.GetLowWord(value1);

			Console.WriteLine("uint-Originalwert: {0} ({1})", value1, value1.ToString("X"));
			Console.WriteLine("High Word: {0} ({1})", highWord, highWord.ToString("X"));
			Console.WriteLine("Low Word: {0} ({1})", lowWord, lowWord.ToString("X"));
			Console.WriteLine();

			int value2 = (int)value1;

			// Auslesen des hohen und des niedrigen Word
			ushort highWord2 = NumberUtils.GetHighWord(value2);
			ushort lowWord2 = NumberUtils.GetLowWord(value2);

			Console.WriteLine("int-Originalwert: {0} ({1})", value2, value2.ToString("X"));
			Console.WriteLine("High Word: {0} ({1})", highWord2, highWord2.ToString("X"));
			Console.WriteLine("Low Word: {0} ({1})", lowWord2, lowWord2.ToString("X"));


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
