using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Filesystem;

namespace Dateien_vergleichen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// Vergleichen der (identischen) Dateien Hitchhiker1.jpg 
				// und Hitchhiker2.jpg
				string fileName1 = Path.Combine(Application.StartupPath, "Hitchhiker1.jpg");
				string fileName2 = Path.Combine(Application.StartupPath, "Hitchhiker2.jpg");
				if (FileUtils.CompareFiles(fileName1, fileName2, FileUtils.FileCompareMethod.Content))
					Console.WriteLine("Die Dateien {0} und {1} sind identisch.", fileName1, fileName2);
				else
					Console.WriteLine("Die Dateien {0} und {1} sind nicht identisch.", fileName1, fileName2);
				Console.WriteLine();

				// Vergleichen der (unterschiedlichen) Dateien Hitchhiker1.jpg 
				// und Hitchhiker3.jpg
				fileName2 = Path.Combine(Application.StartupPath, "Hitchhiker3.jpg");
				if (FileUtils.CompareFiles(fileName1, fileName2, FileUtils.FileCompareMethod.Content))
					Console.WriteLine("Die Dateien {0} und {1} sind identisch.", fileName1, fileName2);
				else
					Console.WriteLine("Die Dateien {0} und {1} sind nicht identisch.", fileName1, fileName2);
				Console.WriteLine();

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
