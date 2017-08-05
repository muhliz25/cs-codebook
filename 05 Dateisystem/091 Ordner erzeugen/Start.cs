using System;
using System.IO;
using System.Windows.Forms;

namespace Ordner_erzeugen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Ordner erzeugen */
			string folderName = @"C:\Test\Test\Test";
			try
			{
				Directory.CreateDirectory(folderName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Fehler beim Erzeugen des Ordners '" + folderName + "': " +
					ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
