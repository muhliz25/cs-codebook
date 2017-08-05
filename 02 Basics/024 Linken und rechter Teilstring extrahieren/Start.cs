using System;
using System.IO;
using Addison_Wesley.Codebook.Basics;
using Addison_Wesley.Codebook.DateAndTime;

namespace Linker_und_rechter_Teilstring
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "abc def ghi";
			string left = StringUtils.Left(source, 3);
			string right = StringUtils.Right(source, 3);

			Console.WriteLine(left);
			Console.WriteLine(right);

			// Performance-Test
			Console.WriteLine();
			Console.WriteLine("Performance-Test");
			HighResStopClock sc = new HighResStopClock();
			
			//StreamWriter sr = new StreamWriter("c:\\performance.txt");
			//Console.SetOut(sr);
			
			string name;

			// Die Methoden einmal aufrufen, sodass die CLR diese kompiliert
			StringUtils.Left(source, 3);
			StringUtils.Right(source, 3);

			name = "Left";
			sc.Start();
			for (int i = 0; i < 10000; i++)
			{
				StringUtils.Left(source, 3);
			}
			Console.WriteLine("{0}: {1}", name, sc.Stop());

			name = "Substring(0, count)";
			sc.Start();
			for (int i = 0; i < 10000; i++)
			{
				source.Substring(0, 3);
			}
			Console.WriteLine("{0}: {1}", name, sc.Stop());

			name = "Right";
			sc.Start();
			for (int i = 0; i < 10000; i++)
			{
				StringUtils.Right(source, 3);
			}
			Console.WriteLine("{0}: {1}", name, sc.Stop());

			name = "Substring(Length - count, count)";
			sc.Start();
			for (int i = 0; i < 10000; i++)
			{
				source.Substring(source.Length - 3, 3);
			}
			Console.WriteLine("{0}: {1}", name, sc.Stop());

			// sr.Close();
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
