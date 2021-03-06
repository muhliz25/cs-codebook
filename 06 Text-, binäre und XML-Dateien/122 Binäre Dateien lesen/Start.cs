using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Windows.Forms;

namespace Bin�re_Dateien_lesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateinamen ermitteln
			string imageFileName = Path.Combine(Application.StartupPath, "hitchhiker.jpg");
			string xmlFileName = Path.Combine(Application.StartupPath, "hitchhiker.xml"); 

			// FileStream-Instanz erzeugen
			FileInfo fi = new FileInfo(imageFileName);
			FileStream fs = fi.OpenRead();

			// Byte-Puffer erzeugen und die Datei in diesen einlesen
			byte[] buffer = new Byte[fi.Length];
			fs.Read(buffer, 0, buffer.Length);

			// Die eingelesenen Daten Base-64-codiert in eine XML-Datei schreiben
			XmlTextWriter xmlWriter = new XmlTextWriter(xmlFileName, Encoding.UTF8);
			xmlWriter.WriteStartDocument(true);
			xmlWriter.WriteStartElement("applicationData");
			xmlWriter.WriteStartElement("splashImage");
			xmlWriter.WriteBase64(buffer, 0, buffer.Length);
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();

			// XML-Datei schlie�en
			xmlWriter.Close();

			// FileStream schlie�en
			fs.Close();

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}

