using System;
using System.Diagnostics;

namespace Browser_starten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Standard-Browser öffnen
			Process.Start("http://www.google.de");

			// Internet Explorer öffnen
			Process process = new Process ();
			process.StartInfo.FileName = "iexplore.exe";
			process.StartInfo.Arguments = "http://www.addison-wesley.de";
			process.Start();
		}
	}
}
