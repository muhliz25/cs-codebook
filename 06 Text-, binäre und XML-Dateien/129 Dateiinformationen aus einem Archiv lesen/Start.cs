using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Archiv_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{

			string zipFileName = "c:\\demo.zip";

			// ZipInputStream für die Zip-Datei erzeugen 
			ZipInputStream zipInputStream = new ZipInputStream(
				File.Open(zipFileName, FileMode.Open, FileAccess.Read));

			// Alle im Archiv gespeicherten ZipEntry-Objekte durchgehen
			ZipEntry zipEntry;
			while ((zipEntry = zipInputStream.GetNextEntry()) != null)
			{
				Console.WriteLine("Name : {0}", zipEntry.Name); 
				Console.WriteLine("Größe : {0}", zipEntry.Size); 
				Console.WriteLine("Komprimierte Größe : {0}", zipEntry.CompressedSize); 
				Console.WriteLine("Kompressionsmethode : {0}", zipEntry.CompressionMethod); 
				Console.WriteLine("Dateidatum : {0}", zipEntry.DateTime.ToString()); 
				Console.WriteLine("Kommentar : {0}", zipEntry.Comment); 
				Console.WriteLine("CRC : {0}", zipEntry.Crc); 
				Console.WriteLine();
			}

			// ZipInputStream schließen
			zipInputStream.Close();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
