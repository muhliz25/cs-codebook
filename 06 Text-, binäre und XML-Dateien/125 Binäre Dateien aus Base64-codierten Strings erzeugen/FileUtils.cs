using System;
using System.IO;

namespace Addison_Wesley.Codebook.File
{
	public class FileUtils
	{
		/* Methode zur Erzeugung einer Datei aus einem Base64-
		 * codierten String */
		public static void CreateFileFromBase64(string base64CodedString, 
			string fileName)
		{
			// String in Byte-Array konvertieren
			byte[] buffer = Convert.FromBase64String(base64CodedString);

			// Datei �ber einen FileStream schreiben
			FileStream fs = new FileStream(fileName, FileMode.Create, 
				FileAccess.Write);
			fs.Write(buffer, 0, buffer.Length);
			fs.Close();
		}
	}
}
