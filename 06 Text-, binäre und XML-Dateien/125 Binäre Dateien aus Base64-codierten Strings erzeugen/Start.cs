using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.File;

namespace Base642Binär
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Base-64-Textdatei einlesen
			string base64FileName = Path.Combine(
				Application.StartupPath, "Base64CodedFile.txt");
			StreamReader sr = new StreamReader(base64FileName);
			string base64CodedString = sr.ReadToEnd();
			sr.Close();
			
			// Base64-codierten String in Datei umwandeln
			string imageFileName = Path.Combine(
				Application.StartupPath, "Hitchhiker.jpg");
			FileUtils.CreateFileFromBase64(base64CodedString, 
				imageFileName);

			Console.WriteLine("Fertig");
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
