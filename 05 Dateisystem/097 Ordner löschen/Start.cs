using System;
using System.IO;
using System.Windows.Forms;

namespace Ordner_l�schen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string folderName = @"C:\Test\Test\Test";
			try
			{
				// Ordner l�schen
				Directory.Delete(folderName, true);

				Console.WriteLine("Fertig");
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Fehler beim L�schen des Ordners '" + folderName + "': " +
					ex.Message, Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}

			Console.ReadLine();
		}
	}

}
