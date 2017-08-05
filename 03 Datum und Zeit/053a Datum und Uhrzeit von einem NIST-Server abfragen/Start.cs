using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace NIST_Server_abfragen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Offizielles Datum vom NIST-Server abfragen */
			try
			{
				DateTime officialDate = DateUtils.GetNISTTime();

				Console.WriteLine(officialDate.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();



		}
	}
}
