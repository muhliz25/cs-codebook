using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Files;

namespace Texte_an_Textdateien_anfügen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname ermitteln
			string fileName = Path.Combine(
				Application.StartupPath, "hitchhiker.txt");

			// Zeilennummern anfügen
			try
			{
				TextFile.AddFileNumbers(fileName);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Fertig");
			Console.ReadLine();
		}
	}
}



