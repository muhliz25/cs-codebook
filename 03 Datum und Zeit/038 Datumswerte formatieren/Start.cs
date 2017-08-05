using System;

namespace Datumswerte_formatieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Das aktuelle Datum ermitteln
			DateTime now = DateTime.Now;

			Console.WriteLine("ToString:\r\n{0}\r\n",
				now.ToString());
			Console.WriteLine("ToShortDateString:\r\n{0}\r\n",
				now.ToShortDateString());
			Console.WriteLine("ToLongDateString:\r\n{0}\r\n",
				now.ToLongDateString());
			Console.WriteLine("ToShortTimeString:\r\n{0}\r\n",
				now.ToShortTimeString());
			Console.WriteLine("ToLongTimeString:\r\n{0}\r\n",
				now.ToLongTimeString());
			Console.WriteLine(String.Format("dd.MM.yy:\r\n{0:dd.MM.yy}\r\n",
				now));
			Console.WriteLine(String.Format("dddd, dd. MMMM yy:\r\n" +
				"{0:dddd, dd. MMMM yyyy}\r\n", now));
			Console.WriteLine(String.Format("ddd, dd. MMM yy:\r\n" +
				"{0:ddd, dd. MMM yyyy}\r\n", now));
			Console.WriteLine(String.Format("HH:mm:ss:\r\n" +
				"{0:HH:mm:ss}", now));
	
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
