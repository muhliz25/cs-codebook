using System;
using Addison_Wesley.Codebook.Basics;

namespace Zahlen_kaufmännisch_runden
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Zahl mit Math.Round runden
			double number1 = 1.15;
			double number2 = 1.25;
			double number3 = 1.151;
			double number4 = 1.125000000001;
			double number5 = 1.124999999999;

			double result1 = Math.Round(number1, 1);
			double result2 = Math.Round(number2, 1);
			double result3 = Math.Round(number3, 1);
			double result4 = Math.Round(number4, 2);
			double result5 = Math.Round(number5, 2);

			Console.WriteLine("Math.Round:");
			Console.WriteLine("{0} auf zwei Dezimalstellen gerundet: {1}", number1, result1); // 1.2
			Console.WriteLine("{0} auf zwei Dezimalstellen gerundet: {1}", number2, result2); // 1.2
			Console.WriteLine("{0} auf zwei Dezimalstellen gerundet: {1}", number3, result3); // 1.2
			Console.WriteLine("{0} auf drei Dezimalstellen gerundet: {1}", number4, result4); // 1.2
			Console.WriteLine("{0} auf drei Dezimalstellen gerundet: {1}", number5, result5); // 1.2
			Console.WriteLine();

			result1 = NumberUtils.RoundCommercial(number1, 1);
			result2 = NumberUtils.RoundCommercial(number2, 1);
			result3 = NumberUtils.RoundCommercial(number3, 1);
			result4 = NumberUtils.RoundCommercial(number4, 2);
			result5 = NumberUtils.RoundCommercial(number5, 2);

			Console.WriteLine("RoundCommercial:");
			Console.WriteLine("{0} auf zwei Dezimalstellen gerundet: {1}", number1, result1); // 1.2
			Console.WriteLine("{0} auf zwei Dezimalstellen gerundet: {1}", number2, result2); // 1.2
			Console.WriteLine("{0} auf zwei Dezimalstellen gerundet: {1}", number3, result3); // 1.2
			Console.WriteLine("{0} auf drei Dezimalstellen gerundet: {1}", number4, result4); // 1.2
			Console.WriteLine("{0} auf drei Dezimalstellen gerundet: {1}", number5, result5); // 1.2

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
