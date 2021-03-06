using System;
using System.IO;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		public static bool DeleteFile(string fileName)
		{
			try
			{
				// Datei löschen
				System.IO.File.Delete(fileName);
			}
			catch (Exception ex)
			{
				// Fehlermeldung ausgeben
				MessageBox.Show("Die Datei '" + fileName + "' kann nicht " +
					"gelöscht werden: " + ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				// Misserfolg zurückmelden
				return false;
			}

			// Erfolg zurückmelden
			return true;
		}
	}
}
