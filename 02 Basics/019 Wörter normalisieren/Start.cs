using System;
using System.Globalization;
using Addison_Wesley.Codebook.Basics;

namespace Wörter_normalisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "das IST ein TEST-string";
			Console.WriteLine("Quelle: {0}", source);

			// Ersten Buchstaben über die TextInfo.ToTitleCase-Methode eines 
			// CultureInfo-Objekts großschreiben
			string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source);
			Console.WriteLine("ToTitleCase: {0}", result);

			// Wörter über NormalizeWords normalisieren
			result = StringUtils.NormalizeWords(source);
			Console.WriteLine("NormalizeWords: {0}", result);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
