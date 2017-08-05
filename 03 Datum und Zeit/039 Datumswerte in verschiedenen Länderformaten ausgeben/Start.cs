using System;
using System.Globalization;
using System.Threading;

namespace Datumswerte_in_verschiedenen_Länderformaten_ausgeben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Aktuell eingestellte Kultur merken
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

			// Aktuelle Kultur auf die englische umschalten
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

			// Datumswert formatieren und ausgeben
			string formattedDate = DateTime.Now.ToLongDateString();
			Console.WriteLine(formattedDate);

			// Aktuelle Kultur wieder zurücksetzen
			Thread.CurrentThread.CurrentCulture = currentCulture;

			// Datum über String.Format formatieren
			formattedDate = String.Format(CultureInfo.CreateSpecificCulture(
				"en-US"), "{0:F}", DateTime.Now);
			Console.WriteLine(formattedDate);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
