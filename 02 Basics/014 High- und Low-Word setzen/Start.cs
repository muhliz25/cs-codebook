using System;
using Addison_Wesley.Codebook.Basics;

namespace High_und_Low_Word_setzen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			ushort lowWord = 0xAAAA;
			ushort highWord = 0xFFFF;
			
			// High-Word setzen
			uint value1 = 0xCCCCCCCC;
			value1 = NumberUtils.SetHighWord(value1, highWord);
			Console.WriteLine("{0:X}", value1);

			// Low-Word setzen
			value1 = 0xCCCCCCCC;
			value1 = NumberUtils.SetLowWord(value1, lowWord);
			Console.WriteLine("{0:X}", value1);

			// High-Word setzen
			int value2 = 0x0CCCCCCC;
			value2 = NumberUtils.SetHighWord(value2, highWord);
			Console.WriteLine("{0:X}", value2);

			// Low-Word setzen
			value2 = 0x0CCCCCCC;
			value2 = NumberUtils.SetLowWord(value2, lowWord);
			Console.WriteLine("{0:X}", value2);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
