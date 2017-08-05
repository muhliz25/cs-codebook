using System;
using Addison_Wesley.Codebook.Basics;

namespace W�rter_extrahieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// String in seine W�rter zerlegen
			string source = "Das ist ein [Test-]String";
			Console.WriteLine("Quellstring: {0}", source);
			string[] words = StringUtils.GetWords(source);
			Console.WriteLine("W�rter:");
			foreach (string word in words)
				Console.WriteLine(word);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
