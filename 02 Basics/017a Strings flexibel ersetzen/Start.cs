using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Addison_Wesley.Codebook.Basics;

namespace Strings_ersetzen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "abc aaa abc aaa abc AAA";
			Console.WriteLine("Quelle: {0}", source);
		
			// Ersetzen über die Replace-Methode
			string find = "aaa";
			string replacement = "xyz";
			string result = source.Replace(find, replacement);
			Console.WriteLine("String.Replace: {0}", result);

			// Ersetzen über ein StringBuilder-Objekt
			find = "aaa";
			replacement = "xyz";
			int start = 5;
			int count = 10;
			StringBuilder sb = new StringBuilder(source);
			result = sb.Replace(find, replacement, start, count).ToString();
			Console.WriteLine("StringBuilder.Replace: {0}", result);

			// Ersetzen über ein Regex-Objekt
			start = 0;
			count = 2;
			Regex re = new Regex(find, RegexOptions.IgnoreCase);
			result = re.Replace(source, replacement, count, start);
			Console.WriteLine("Regex: {0}", result);

			// Ersetzen über die VB-Replace-Methode
			find = "aaa";
			replacement = "xyz";
			start = 1;
			count = 2;
			result = Strings.Replace(source, find, replacement, start, count, CompareMethod.Text);
			Console.WriteLine("VB-Replace: {0}", result);

			// Ersetzen über die eigene Replace-Methode
			Console.WriteLine("Eigene Replace-Methode:");
			result = StringUtils.Replace(source, "aaa", "xyz", true, 1, -1);
			Console.WriteLine("Alle Fundstellen ersetzt: {0}", result);
			result = StringUtils.Replace(source, "aaa", "xyz", true, 2, -1);
			Console.WriteLine("Ab der zweiten alle weiteren ersetzt: {0}", result);
			result = StringUtils.Replace(source, "aaa", "xyz", true, 2, 1);
			Console.WriteLine("Ab der zweiten nur eine ersetzt: {0}", result);

			// Test der Replace-Methode
			Console.WriteLine();
			Console.WriteLine("Test der Replace-Methode");
			Console.WriteLine(StringUtils.Replace("1234567890", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("aaa 123 aaa", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("aaaaaa", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("aaa", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("aa", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("aaax", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("aaa 123", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("", "aaa", "xyz", true, 1, -1));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 2, -1));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 2, 0));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 2, 1));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 2, 2));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 2, 10));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 3, 10));
			Console.WriteLine(StringUtils.Replace("123 aaa 123 aaa 123 aaa", "aaa", "xyz", true, 4, 10));

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
