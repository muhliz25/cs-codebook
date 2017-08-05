using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Multimedia;

namespace MCI_Konsole
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string fileName = Path.Combine(Application.StartupPath, "Club Generation - Patience.mp3");
			try
			{
				// Leider funktioniert MCI (auf jeden Fall auf meinem XP-System) 
				// nicht in einer Konsolenanwendung
				Mci mci = new Mci();
				mci.Open(fileName);
				mci.Play(true);
				Console.WriteLine("Abspielen beenden mit Return");
				mci.Close();
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
