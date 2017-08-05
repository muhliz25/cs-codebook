using System;

namespace Computername_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Den Namen des Computers auslesen
			string machineName = System.Environment.MachineName;
			
			Console.WriteLine(machineName);
			Console.ReadLine();
		}
	}
}
