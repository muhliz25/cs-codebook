using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace ISO_Datum
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Das aktuelle Datum in das ISO-Format konvertieren
			string isoDate = DateUtils.DateTime2ISO(DateTime.Now, true);

			Console.WriteLine(isoDate);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
