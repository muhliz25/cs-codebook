using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Application;

namespace Java_Programme_starten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Java-Programm in .class-Dateien ohne explizite Angabe des ClassPath starten
			string javaFileName = Path.Combine(Application.StartupPath,
				@"Java\class\hello.class");
			try
			{
				AppUtils.StartJavaApplication(javaFileName, null, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			// Java-Programm in .jar-Datei ohne explizite Angabe das ClassPath starten
			javaFileName = Path.Combine(Application.StartupPath,
				@"Java\jar\hello.jar");
			try
			{
				AppUtils.StartJavaApplication(javaFileName, null, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Taste ...");
			Console.ReadLine();
		}
	}
}
