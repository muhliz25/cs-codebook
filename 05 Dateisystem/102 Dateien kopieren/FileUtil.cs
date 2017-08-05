using System;
using System.IO;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Methode zum Kopieren einer Datei */
		public static bool CopyFile(string sourceFileName, string destFileName)
		{
			// Abfragen, ob die Datei existiert 
			if (System.IO.File.Exists(destFileName))
			{
				// Den Anwender fragen, ob die Datei überschrieben werden soll 
				if (MessageBox.Show("Die Datei '" + destFileName + 
					"' existiert bereits.\r\n\r\nSoll diese Datei überschrieben werden?",
					Application.ProductName, MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation) == DialogResult.No)

					// Funktion beenden und false zurückgeben
					return false;
			}

			try
			{
				// Datei kopieren 
				System.IO.File.Copy(sourceFileName, destFileName, true);

				return true;
			}
			catch (Exception ex)
			{
				// Fehlermeldung ausgeben
				MessageBox.Show("Die Datei '" + sourceFileName + "' kann nicht " +
					"kopiert werden: " + ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				return false;
			}
		}
	}
}
