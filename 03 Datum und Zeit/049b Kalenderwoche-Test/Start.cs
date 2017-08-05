using System;
using System.IO;
using System.Globalization;
using Addison_Wesley.Codebook.DateAndTime;

namespace Kalenderwoche_Test
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			StreamWriter sw = new StreamWriter("C:\\kw.txt");

			for (int year = 1899; year <= 2999; year++)
			{
				Console.WriteLine(year);
				for (int month = 1; month < 13; month ++)
				{
					for (int day = 1; day < 32; day++)
					{
						DateTime d;
						try
						{
							d = new DateTime(year, month, day);
							DateUtils.CalendarWeek w1 = DateUtils.GetCalendarWeek1(d);
							DateUtils.CalendarWeek w2 = DateUtils.GetCalendarWeek2(d);

							if (w1.Week != w2.Week)
							{
								sw.WriteLine("*****************************************");
								sw.WriteLine("ERROR {0}: {1}/{2} - {3}/{4} ({5})", String.Format("{0:dd.MM.yyyy}", d), w1.Week, w1.Year, w2.Week, w2.Year,  String.Format("{0:dddd}", d));
								sw.WriteLine("*****************************************");
							}
							else
								sw.WriteLine("{0}: {1}/{2} - {3}/{4} ({5})", String.Format("{0:dd.MM.yyyy}", d), w1.Week, w1.Year, w2.Week, w2.Year,String.Format("{0:dddd}", d));
						}
						catch {}
					}
				}
			}
			sw.Close();
		}
	}
}
