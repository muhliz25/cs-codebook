// #define WRITETOFILE
using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Addison_Wesley.Codebook.DateAndTime;
using Addison_Wesley.Codebook.Basics;

namespace Performance_Test
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			HighResStopClock sc = new HighResStopClock();
			string source = "ab cd ab cd ab cd ab cd";

#if WRITETOFILE
			StreamWriter Console = new StreamWriter("C:\\String-Replace-Performance.txt");
#endif
            
			// string.Replace
			sc.Start();
			for (int i = 0; i < 10000; i++)
				source.Replace("ab", "XYZ");
			Console.WriteLine("string.Replace: {0}", sc.Stop());

			// StringBuilder.Replace
			sc.Start();
			for (int i = 0; i < 10000; i++)
			{
				StringBuilder sb = new StringBuilder(source);
				sb.Replace("ab", "XYZ");
			}
			Console.WriteLine("StringBuilder.Replace: {0}", sc.Stop());

			
			// Regex.Replace mit bin�rem Vergleich
			sc.Start();
			Regex re = new Regex("ab");
			int count = -1;
			for (int i = 0; i < 10000; i++)
				re.Replace(source, "XYZ", count, 0);
			Console.WriteLine("Regul�rer Ausdruck (Bin�r): {0}", sc.Stop());

			// Regex.Replace mit Textvergleich
			sc.Start();
			re = new Regex("ab", RegexOptions.IgnoreCase);
			count = -1;
			for (int i = 0; i < 10000; i++)
				re.Replace(source, "XYZ", count, 0);
			Console.WriteLine("Regul�rer Ausdruck (Text): {0}", sc.Stop());

			// Microsoft.VisualBasic.Strings.Replace - bin�rer Vergleich
			sc.Start();
			for (int i = 0; i < 10000; i++)
				Microsoft.VisualBasic.Strings.Replace(source, "ab", "XYZ", 1, -1, CompareMethod.Binary);
			Console.WriteLine("VB-Replace (Binary): {0}", sc.Stop());

			// Microsoft.VisualBasic.Strings.Replace - Textvergleich
			sc.Start();
			for (int i = 0; i < 10000; i++)
				Microsoft.VisualBasic.Strings.Replace(source, "ab", "XYZ", 1, -1, CompareMethod.Text);
			Console.WriteLine("VB-Replace (Bin�r): {0}", sc.Stop());
			
			// Eigene Replace-Methode Microsoft - bin�rer Vergleich
			sc.Start();
			for (int i = 0; i < 10000; i++)
				StringUtils.Replace(source, "ab", "XYZ", false, 1, -1);
			Console.WriteLine("Replace (Bin�r): {0}", sc.Stop());

			// Eigene Replace-Methode - Textvergleich
			sc.Start();
			for (int i = 0; i < 10000; i++)
				StringUtils.Replace(source, "ab", "XYZ", true, 1, -1);
			Console.WriteLine("Replace (Text): {0}", sc.Stop());
#if WRITETOFILE
			Console.Close();
#else
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
#endif
		}
	}
}
