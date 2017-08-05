using System;
using System.Collections.Specialized;
using Addison_Wesley.Codebook.System;

namespace Installierte_Software
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				StringCollection installedPrograms = SystemUtils.EnumInstalledPrograms();
				foreach (string programName in installedPrograms)
					Console.WriteLine(programName);
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
