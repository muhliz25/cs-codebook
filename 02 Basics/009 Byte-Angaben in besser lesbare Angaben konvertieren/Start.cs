using System;
using Addison_Wesley.Codebook.Basics;

namespace Byte_Angaben_umwandeln
{
	class Start
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine(NumberUtils.ByteToReadableFormat(1023, "#,#0.####"));
			Console.WriteLine(NumberUtils.ByteToReadableFormat(1024, "#,#0.00"));
			Console.WriteLine(NumberUtils.ByteToReadableFormat(2222, "#,#0.####"));
			Console.WriteLine(NumberUtils.ByteToReadableFormat(3333 * 1024, "#,#0.####"));
			Console.WriteLine(NumberUtils.ByteToReadableFormat(4444L * 1024 * 1024, "#,#0.####"));

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
