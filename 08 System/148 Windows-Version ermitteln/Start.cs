using System;

namespace Windows_Version
{
	class Start
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			// Auslesen der Windows-Version
			Console.WriteLine("Version:");
			Console.WriteLine("Major: {0}", Environment.OSVersion.Version.Major);
			Console.WriteLine("Minor: {0}", Environment.OSVersion.Version.Minor);
			Console.WriteLine("Revision: {0}", Environment.OSVersion.Version.Revision);
			Console.WriteLine("Build: {0}", Environment.OSVersion.Version.Build);
			Console.WriteLine("Plattform: {0}", Environment.OSVersion.Platform);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
