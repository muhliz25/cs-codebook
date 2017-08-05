using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Textdateien_anf�gen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{

			// Dateiname ermitteln
			string fileName = Path.Combine(Application.StartupPath, "log.txt");

			// StreamWriter-Instanz f�r die Datei erzeugen
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(fileName, true, Encoding.GetEncoding("windows-1252"));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim �ffnen der Datei '" + fileName + "': " + 
					ex.Message, Application.ProductName, MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			// Zeile anf�gen
			sw.WriteLine(DateTime.Now.ToString() + ": Anzahl Prozesse: " +
				System.Diagnostics.Process.GetProcesses().Length);

			// StreamWriter schlie�en
			sw.Close();

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
