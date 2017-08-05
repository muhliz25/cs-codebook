using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Textdateien_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname ermitteln
			string fileName = Path.Combine(Application.StartupPath, "hitchhiker.txt");

			// StreamReader-Instanz f�r die Datei erzeugen
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(fileName, Encoding.GetEncoding("windows-1252"));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim �ffnen der Datei '" + fileName + "': " + 
					ex.Message, Application.ProductName, MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			// Datei zeilenweise einlesen
			string line = null;
			while ((line = sr.ReadLine()) != null)
			{
				Console.WriteLine(line);
			}

			// StreamReader schlie�en
			sr.Close();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
