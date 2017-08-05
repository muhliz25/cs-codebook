using System;
using System.IO;
using System.Windows.Forms;

namespace Ordner_löschen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string folderName = @"C:\Test\Test\Test";
			try
			{
				// Ordner löschen
				Directory.Delete(folderName, true);

				Console.WriteLine("Fertig");
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Fehler beim Löschen des Ordners '" + folderName + "': " +
					ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}

			Console.ReadLine();
		}
	}

}
