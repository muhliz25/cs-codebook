using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Filesystem;

namespace Ordner_vergleichen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Vergleichen zweier identischer Ordner */
			string folderName1 = Path.Combine(Application.StartupPath, @"..\..\Demo-Ordner\Demo1");
			string folderName2 = Path.Combine(Application.StartupPath, @"..\..\Demo-Ordner\Demo2");

			if (FolderUtils.CompareFolders(folderName1, folderName2, false))
				Console.WriteLine("Die Ordner Demo1 und Demo2 sind identisch");
			else
				Console.WriteLine("Die Ordner Demo1 und Demo2 sind nicht identisch");

			/* Vergleichen zweier nicht identischer Ordner */
			folderName2 = Path.Combine(Application.StartupPath, @"..\..\Demo-Ordner\Demo3");

			if (FolderUtils.CompareFolders(folderName1, folderName2, false))
				Console.WriteLine("Die Ordner Demo1 und Demo3 sind identisch");
			else
				Console.WriteLine("Die Ordner Demo1 und Demo3 sind nicht identisch");


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
