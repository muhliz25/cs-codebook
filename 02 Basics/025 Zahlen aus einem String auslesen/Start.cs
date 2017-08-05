using System;
using Addison_Wesley.Codebook.Basics;

namespace Zahlen_aus_String_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "12345-67890 aaa 10 11,12";
			long[] numbers = StringUtils.ExtractNumbers(source);
			for (int i = 0; i < numbers.Length; i++)
				Console.WriteLine(numbers[i]);
			
			source = "abc def ghi";
			numbers = StringUtils.ExtractNumbers(source);
			for (int i = 0; i < numbers.Length; i++)
				Console.WriteLine(numbers[i]);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
