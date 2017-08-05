using System;

namespace Zahlen_in_Hex_Werte_umwandeln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			int i = 0xFAFBFC;

			// Zahl hexadezimal formatieren
			string hexNumber = String.Format("{0:X}", i);
			Console.WriteLine(hexNumber);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
