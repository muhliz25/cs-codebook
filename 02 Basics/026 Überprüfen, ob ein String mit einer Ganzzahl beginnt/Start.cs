using System;
using Addison_Wesley.Codebook.Basics;

namespace String_auf_Zahl_am_Anfang_prüfen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "1234 abc";
			int result = StringUtils.NumberAtStart(source);
			if (result > 0)
			{
				long number = Convert.ToInt64(source.Substring(0, result)); 
				Console.WriteLine("{0} beginnt mit einer Zahl: {1}", source, number);
			}
			else
				Console.WriteLine("{0} beginnt nicht mit einer Zahl", source);

			source = "A1234 abc";
			result = StringUtils.NumberAtStart(source);
			if (result > 0)
			{
				long number = Convert.ToInt64(source.Substring(0, result)); 
				Console.WriteLine("{0} beginnt mit einer Zahl: {1}", source, number);
			}
			else
				Console.WriteLine("{0} beginnt nicht mit einer Zahl", source);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
