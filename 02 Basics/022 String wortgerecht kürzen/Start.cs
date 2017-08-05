using System;
using Addison_Wesley.Codebook.Basics;

namespace String_wortgerecht_kürzen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{	
			// Kürzen eines String auf eine maximale Länge
			string source = "Die Antwort auf die Frage aller Fragen ist 42";
			string result = StringUtils.AbbreviateString(source, 20);
			Console.WriteLine("Quellstring: {0}", source);
			Console.WriteLine("Gekürzter String: {0}", result);

			source = "Formular-Authentifizierung";
			result = StringUtils.AbbreviateString(source, 20);
			Console.WriteLine("Quellstring: {0}", source);
			Console.WriteLine("Gekürzter String: {0}", result);


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
