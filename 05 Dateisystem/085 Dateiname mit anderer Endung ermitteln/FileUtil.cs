using System;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	public class FileUtil
	{
		/* Methode zum Austausch der Dateiendung eines Dateinamens */
		public static string ChangeExtension(string filename, string newExtension)
		{
			FileInfo fi = new FileInfo(filename);
			return fi.FullName.Replace(fi.Extension, newExtension);
		}
	}
}
