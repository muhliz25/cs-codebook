using System;
using System.IO;

namespace Ordner_auf_Existenz_berprfen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// �ber die statische Exists-Methode der Directory-Klasse 
			// �berprfen, ob der Ordner c:\Temp existiert
			string folderName = "c:\\temp";
			if (Directory.Exists(folderName))
				Console.WriteLine(folderName + " existiert");
			else
				Console.WriteLine(folderName + " existiert nicht");

			// �ber die Exists-Eigenschaft eines DirectoryInfo-Objekts
			// �berprfen, ob der Ordner c:\Temp existiert
			folderName = "c:\\temp";
			DirectoryInfo di = new DirectoryInfo(folderName);
			if (di.Exists)
				Console.WriteLine(folderName + " existiert");
			else
				Console.WriteLine(folderName + " existiert nicht");

			Console.ReadLine();
		}
	}
}
