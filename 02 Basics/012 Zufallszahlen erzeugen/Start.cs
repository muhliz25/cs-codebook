using System;
using System.Collections;
using System.Security.Cryptography;
using Addison_Wesley.Codebook.Basics;

namespace Zufallszahlen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Erzeugen von drei Zufallszahlen zwischen 1 und 42
			Console.WriteLine("Zufallszahlen zwischen 1 und 42");
			Random random = new Random();
			int number1 = random.Next(1, 42);
			int number2 = random.Next(1, 42);
			int number3 = random.Next(1, 42);

			Console.WriteLine(number1);
			Console.WriteLine(number2);
			Console.WriteLine(number3);

			// Zehn echte Zufallszahlen im Bereich zwischen 1 und 255 erzeugen
			Console.WriteLine("Zufallszahlen zwischen 1 und 255");
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] randomNumbers = new byte[10];
			rng.GetNonZeroBytes(randomNumbers);
			for (int i = 0; i < 10; i++)
				Console.WriteLine(randomNumbers[i]);
			Console.WriteLine();

			// Zehn echte Zufallszahlen im Bereich zwischen 1 und 255 * 255 erzeugen
			Console.WriteLine("Zufallszahlen zwischen 1 und 65025");
			byte[] randomNumbers1 = new byte[10];
			byte[] randomNumbers2 = new byte[10];
			rng.GetNonZeroBytes(randomNumbers1);
			rng.GetNonZeroBytes(randomNumbers2);
			for (int i = 0; i < 10; i++)
				Console.WriteLine(randomNumbers1[i] * randomNumbers2[i]);

			// Zehn echte Zufallszahlen im Bereich zwischen 10 und 20
			Console.WriteLine("Zufallszahlen zwischen 10 und 20");
			byte[] randomNumbers3 = NumberUtils.RandomNumbers(10, 10, 20);
			for (int i = 0; i < randomNumbers3.Length; i++)
				Console.Write(randomNumbers3[i] + " ");

			// Test der RandomNumbers-Methode auf Gleichverteilung
			Console.WriteLine("Test der RandomNumbers-Methode auf Gleichverteilung");
			byte[] randomNumbers4 = NumberUtils.RandomNumbers(100000, 10, 50);
			ArrayList testList = new ArrayList(10000);
			for (int i = 0; i < randomNumbers4.Length; i++)
				testList.Add(randomNumbers4[i]);
			testList.Sort();
			byte currentNumber = 0;
			byte lastNumber = 0;
			int count = 1;
			foreach (byte number in testList)
			{
				if (number == currentNumber)
				{
					count++;
					lastNumber = number;
				}
				else 
				{
					if (lastNumber != 0)
						Console.WriteLine("{0} kommt {1} mal vor", lastNumber, count);
					count = 1;
					currentNumber = number;
				}
			}
			Console.WriteLine("{0} kommt {1} mal vor", lastNumber, count);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
