using System;
using System.IO;

namespace Dateiattribute
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string fileName = "c:\\pagefile.sys";

			/* Ermitteln der Attribute der Datei */
			try
			{
				// FileInfo-Objekt erzeugen
				FileInfo fi = new FileInfo(fileName);

				// Attribute auslesen
				Console.WriteLine("Dateiattribute von {0}", fileName);

				if ((fi.Attributes & FileAttributes.Archive) > 0) 
					Console.WriteLine("Archiv");

				if ((fi.Attributes & FileAttributes.Compressed) > 0) 
					Console.WriteLine("Komprimiert");

				if ((fi.Attributes & FileAttributes.Encrypted) > 0) 
					Console.WriteLine("Verschl�sselt");

				if ((fi.Attributes & FileAttributes.Hidden) > 0) 
					Console.WriteLine("Versteckt");

				if ((fi.Attributes & FileAttributes.Normal) > 0) 
					Console.WriteLine("Normale Datei");

				if ((fi.Attributes & FileAttributes.
					NotContentIndexed) > 0) 
					Console.WriteLine("Nicht inhalts-indiziert");

				if ((fi.Attributes & FileAttributes.Offline) > 0) 
					Console.WriteLine("Offline");

				if ((fi.Attributes & FileAttributes.ReadOnly) > 0) 
					Console.WriteLine("Schreibgesch�tzt");

				if ((fi.Attributes & FileAttributes.ReparsePoint) > 0) 
					Console.WriteLine("Datei enth�lt einen Analysepunkt");

				if ((fi.Attributes & FileAttributes.SparseFile) > 0) 
					Console.WriteLine("D�nn besetzte Datei (mit vielen 0-Bytes)");

				if ((fi.Attributes & FileAttributes.System) > 0) 
					Console.WriteLine("System");

				if ((fi.Attributes & FileAttributes.Temporary) > 0) 
					Console.WriteLine("Tempor�r");
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Ermitteln der Dateiattribute " +
					"der Datei '{0}': {1}.", fileName, ex.Message); 
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}