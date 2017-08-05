using System;
using System.IO;
using System.Net;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace Daten_packen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateiname der Zip-Datei
			string zipFileName = "c:\\demo3.zip";

			// ZipOutputStream erzeugen
			ZipOutputStream zipOutputStream = new ZipOutputStream(
				File.Open(zipFileName, FileMode.CreateNew));

			// Kompressionsrate definieren (0 bis 9)
			zipOutputStream.SetLevel(9);

			// PDF-Datei aus dem Internet in ein Byte-Array herunterladen
			string pdfUrl = "http://www.juergen-bayer.net/referenzen/CSharp-Referenz.pdf";
			WebClient webClient = new WebClient();
			byte[] buffer = webClient.DownloadData(pdfUrl);

			// ZipEntry-Objekt für die neue Datei erzeugen, dem ZipOutputStream hinzufügen und
			// den Byte-Puffer in den Stream schreiben
			ZipEntry zipEntry = new ZipEntry("CSharp-Referenz.pdf");
			zipOutputStream.PutNextEntry(zipEntry);
			zipOutputStream.Write(buffer, 0, buffer.Length); 

			// String definieren
			string demo = "Das ist eine Demo für das Schreiben von Daten in ein Archiv";

			// Byte-Array mit der System-Default-Codierung aus dem String erzeugen 
			// und an das Archiv anhängen
			buffer = Encoding.Default.GetBytes(demo);
			zipEntry = new ZipEntry("Demo.txt");
			zipOutputStream.PutNextEntry(zipEntry);
			zipOutputStream.Write(buffer, 0, buffer.Length); 

			// ZipOutputStream abschließen und schließen
			zipOutputStream.Finish();
			zipOutputStream.Close();

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
