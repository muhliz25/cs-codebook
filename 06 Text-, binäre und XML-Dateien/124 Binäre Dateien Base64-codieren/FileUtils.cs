using System;
using System.IO;

namespace Addison_Wesley.Codebook.File
{
	public class FileUtils
	{
		/* Methode zum Lesen einer Datei als Base64-codierten String */
		public static string ReadAsBase64(string fileName)
		{
			// Datei einlesen
			FileInfo fi = new FileInfo(fileName);
			byte[] buffer = new byte[fi.Length];
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			fs.Read(buffer, 0, buffer.Length);
			fs.Close();

			// Das Byte-Array Base64-codiert zurückgeben
			return Convert.ToBase64String(buffer, 0, buffer.Length);
		}
	}
}
