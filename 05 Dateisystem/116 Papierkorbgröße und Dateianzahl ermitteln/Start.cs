using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Papierkorbgr��e
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Anzahl und Gr��e der Dateien und Gr��e des gesamten Papierkorbs ermitteln
			RecycleBin.RecycleBinInfo rbi = RecycleBin.GetRecycleBinInfo(null);
			Console.WriteLine("Anzahl der Dateien im gesamten Papierkorb: {0}", rbi.Count);
			Console.WriteLine("Gr��e des gesamten Papierkorbs: {0} Byte", rbi.Size);
			Console.WriteLine();	

			// Anzahl der Dateien und Gr��e des Papierkorbs auf C: ermitteln
			rbi = RecycleBin.GetRecycleBinInfo("C:\\");
			Console.WriteLine("Anzahl der Dateien im Papierkorb auf C: {0}", rbi.Count);
			Console.WriteLine("Gr��e des Papierkorbs auf C: {0} Byte", rbi.Size);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
