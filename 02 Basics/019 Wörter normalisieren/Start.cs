using System;
using System.Globalization;
using Addison_Wesley.Codebook.Basics;

namespace W�rter_normalisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "das IST ein TEST-string";
			Console.WriteLine("Quelle: {0}", source);

			// Ersten Buchstaben �ber die TextInfo.ToTitleCase-Methode eines 
			// CultureInfo-Objekts gro�schreiben
			string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source);
			Console.WriteLine("ToTitleCase: {0}", result);

			// W�rter �ber NormalizeWords normalisieren
			result = StringUtils.NormalizeWords(source);
			Console.WriteLine("NormalizeWords: {0}", result);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
