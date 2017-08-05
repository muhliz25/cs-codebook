using System;
using System.IO;
using System.Windows.Forms; 
using Addison_Wesley.Codebook.Xml;

namespace XSL
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Die Dateinamen
			string xmlFileName = Path.Combine(Application.StartupPath, "Persons.xml");
			string xslFileName = Path.Combine(Application.StartupPath, "Persons.xsl");
			string htmlFileName = Path.Combine(Application.StartupPath, "Persons.html");

			// Transformieren der XML-Datei
			XmlUtils.TransformXmlFile(xmlFileName, xslFileName, htmlFileName);

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
