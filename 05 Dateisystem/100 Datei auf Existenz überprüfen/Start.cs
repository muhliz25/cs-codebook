using System;

namespace Datei_Existenz
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// �ber die statische Exists-Methode der File-Klasse 
			// �berpr�fen, ob die Datei c:\autoexec.bat existiert
			string fileName = "c:\\autoexec.bat";
			if (System.IO.File.Exists(fileName))
				Console.WriteLine(fileName + " existiert");
			else
				Console.WriteLine(fileName + " existiert nicht");

			// �ber die Exists-Eigenschaft eines FileInfo-Objekts
			// �berpr�fen, ob die Datei c:\autoexec.bat existiert
			System.IO.FileInfo di = new System.IO.FileInfo(fileName);
			if (di.Exists)
				Console.WriteLine(fileName + " existiert");
			else
				Console.WriteLine(fileName + " existiert nicht");

			Console.ReadLine();
		}
	}
}
