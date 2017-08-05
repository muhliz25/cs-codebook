using System;
using Addison_Wesley.Codebook.Basics;

namespace Mehrfache_Leerzeichen_in_ein_Leerzeichen_konvertieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "abc    def    ghi   ";
			string result = StringUtils.ToSingleSpace(source);

			Console.WriteLine(source);
			Console.WriteLine(result);

			source = "abc xxx def xxxx ghi   ";
			result = StringUtils.ToSingleChar(source, 'x');

			Console.WriteLine(source);
			Console.WriteLine(result);


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
