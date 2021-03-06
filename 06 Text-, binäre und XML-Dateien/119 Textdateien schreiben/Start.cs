using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Textdateien_schreiben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname ermitteln
			string fileName = Path.Combine(Application.StartupPath, "fish.txt");

			// �berpr�fen, ob die Datei bereits existiert
			if (File.Exists(fileName))
			{
				// Den Anwender fragen, ob er die Datei �berschreiben will
				if (MessageBox.Show("Die Datei '" + fileName + "' existiert bereits.\r\n\r\n" +
					"Wollen Sie diese Datei �berschreiben?", Application.ProductName, 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			// StreamWriter-Instanz f�r die Datei erzeugen
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(fileName, false, Encoding.GetEncoding("windows-1252"));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim �ffnen der Datei '" + fileName + "': " + 
					ex.Message, Application.ProductName, MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			// Datei zeilenweise schreiben
			sw.WriteLine("Macht's gut");
			sw.WriteLine("und Danke f�r den Fisch");

			// StreamWriter schlie�en
			sw.Close();

			Console.WriteLine("Fertig");
			Console.ReadLine();
		}
	}
}

