using System;
using System.IO;
using System.Windows.Forms; 
using Addison_Wesley.Codebook.File;

namespace Binär2Base64
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Datei Base-64-codieren
			string fileName = Path.Combine(
				Application.StartupPath, "Hitchhiker.jpg");
			string base64CodedFile = FileUtils.ReadAsBase64(fileName);

			Console.WriteLine("Base64-codierte Datei:");
			Console.WriteLine(base64CodedFile);

			Console.ReadLine();
		}
	}
}
