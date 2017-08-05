using System;
using System.IO;
using Addison_Wesley.Codebook.Basics;
using Addison_Wesley.Codebook.DateAndTime;

namespace Anzahl_Wörter_in_einem_String
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{	
			string source = "Das ist ein Test-String mit 11 Wörtern\r\nund einem Zeilenumbruch.";
			long wordCount = StringUtils.WordCount2(source);
			Console.WriteLine("Der String\r\n'{0}'\r\nhat {1} Wörter.", source, wordCount);

			source = "Das ist ein Unicode-Test-String mit 13 Wörtern und speziellen Zeichen ÿÖÜø";
			wordCount = StringUtils.WordCount2(source);
			Console.WriteLine("Der String\r\n'{0}'\r\nhat {1} Wörter.", source, wordCount);

			// Performance-Test
			Console.WriteLine("Performance-Test");
			HighResStopClock sc = new HighResStopClock();
			source = "ab cd ef";

			sc.Start();
			for (int i = 0; i < 10000; i++)
				StringUtils.WordCount1(source);
			Console.WriteLine("WordCount1: {0}", sc.Stop());

			sc.Start();
			for (int i = 0; i < 10000; i++)
				StringUtils.WordCount1(source);
			Console.WriteLine("WordCount1: {0}", sc.Stop());

			sc.Start();
			for (int i = 0; i < 10000; i++)
				StringUtils.WordCount2(source);
			Console.WriteLine("WordCount2: {0}", sc.Stop());

			sc.Start();
			for (int i = 0; i < 10000; i++)
				StringUtils.WordCount2(source);
			Console.WriteLine("WordCount2: {0}", sc.Stop());


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
