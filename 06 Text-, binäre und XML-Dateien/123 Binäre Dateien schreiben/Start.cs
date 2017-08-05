using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Windows.Forms;

namespace Bin‰re_Dateien_schreiben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Dateinamen ermitteln
			string xmlFileName = Path.Combine(Application.StartupPath, "hitchhiker.xml"); 
			string imageFileName = Path.Combine(Application.StartupPath, "hitchhiker.jpg");

			// FileStream-Instanz zum Schreiben erzeugen
			FileStream fs = File.OpenWrite(imageFileName);

			// XML-Datei ˆffnen
			XmlTextReader xmlReader = new XmlTextReader(xmlFileName);

			// Zum splashImage-Element navigieren (das dem applicationData-Element folgt)
			xmlReader.ReadStartElement("applicationData"); 

			// XML-Daten des splashImage-Elements blockweise einlesen
			byte [] buffer = new Byte[1024];
			int count = 0;
			do
			{
				count = xmlReader.ReadBase64(buffer, 0, buffer.Length);
				if (count > 0)
				{
					// Eingelesene Daten in den FileStream schreiben
					fs.Write(buffer, 0, count);
				}
			} while (count > 0);

			// XML-Datei schlieﬂen
			xmlReader.Close();

			// FileStream schlieﬂen
			fs.Close();
			
			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
