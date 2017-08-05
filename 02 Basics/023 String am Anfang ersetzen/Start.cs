using System;
using Addison_Wesley.Codebook.Basics;

namespace String_am_Anfang_ersetzen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// String am Anfang ersetzen
			string source = @"^$ {}[] \1 \2 # \w. C:\Codebook\Basics\Strings (Test)";
			string find = @"^$ {}[] \1 \2 # \w. C:\Codebook";
			string replacement = @"C:\Books\C#-Codebook";
			string result = StringUtils.ReplaceLeadingString(source, find, replacement, true);

			Console.WriteLine(source);
			Console.WriteLine(result);
						

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
