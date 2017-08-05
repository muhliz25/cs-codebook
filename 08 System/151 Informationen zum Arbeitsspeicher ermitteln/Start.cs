using System;
using Addison_Wesley.Codebook.System;

namespace Ram_Infos
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Arbeitsspeicher-Infos abfragen */
			SystemUtils.RamInformations ri = SystemUtils.GetRamInformations();

			Console.WriteLine("FreePhysicalMemory: {0}", ri.FreePhysicalMemory);
			Console.WriteLine("FreeSpaceInPagingFiles: {0}", ri.FreeSpaceInPagingFiles);
			Console.WriteLine("FreeVirtualMemory: {0}", ri.FreeVirtualMemory);
			Console.WriteLine("MaxProcessMemorySize: {0}", ri.MaxProcessMemorySize);
			Console.WriteLine("TotalVirtualMemorySize: {0}", ri.TotalVirtualMemorySize);
			Console.WriteLine("TotalVisibleMemorySize: {0}", ri.TotalVisibleMemorySize);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
