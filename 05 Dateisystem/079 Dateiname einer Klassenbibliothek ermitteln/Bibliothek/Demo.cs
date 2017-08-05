using System;
using Addison_Wesley.Codebook.Filesystem;

namespace Addison_Wesley.Codebook.Filesystem.DemoLib
{
	public class Demo
	{
		/* Methode zum Auslesen des Dateinamens der Klassenbibliothek.
		 * Wird zu Demozwecken von der Anwendung aus aufgerufen */
		public string GetFilename()
		{
			return FileUtil.GetLibraryFilename();
		}

	}
}
