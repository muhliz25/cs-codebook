using System;
using Addison_Wesley.Codebook.Basics;

namespace Wörter_extrahieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// String in seine Wörter zerlegen
			string source = "Das ist ein [Test-]String";
			Console.WriteLine("Quellstring: {0}", source);
			string[] words = StringUtils.GetWords(source);
			Console.WriteLine("Wörter:");
			foreach (string word in words)
				Console.WriteLine(word);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
