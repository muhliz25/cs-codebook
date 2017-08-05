using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Alter_berechnen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			
			// Das Alter einer Person berechnen
			int age = DateUtils.GetAge(new DateTime(1962, 9, 27), new DateTime(2005, 10, 27));

			Console.WriteLine("Alter: {0}", age);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
