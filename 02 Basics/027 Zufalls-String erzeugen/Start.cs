using System;
using Addison_Wesley.Codebook.Basics;

namespace Zufalls_String
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string randomString = StringUtils.RandomString(25);
			Console.WriteLine("Zufalls-String:");
			Console.WriteLine(randomString);			

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
