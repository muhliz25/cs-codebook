using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Addison_Wesley.Codebook.Filesystem.DemoLib
{
	public class Demo
	{
		/* Methode zum Auslesen des Ordnernamens der Klassenbibliothek.
		 * Wird in der Demo-Anwendung aufgerufen */
		public string GetFolderName()
		{
			return FileUtil.GetLibraryFolderName();
		}
	}
}
