using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Dateiendung
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string filename = @"c:\Test.txt";

			Console.WriteLine(FileUtil.ChangeExtension(filename, ".ini"));

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}

	}
}
