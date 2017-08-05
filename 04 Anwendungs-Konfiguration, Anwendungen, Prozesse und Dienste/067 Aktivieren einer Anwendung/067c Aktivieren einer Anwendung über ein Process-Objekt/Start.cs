using System;
using System.Diagnostics;
using Addison_Wesley.Codebook.Application;

namespace Anwendung_aktivieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Prozess aktivieren
			string processName = "winword";
			Process[] processes = Process.GetProcessesByName(processName);
			if (processes.Length > 0)
			{
				try
				{
					AppUtils.ActivateApplication(processes[0]); 
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			else
			{
				Console.WriteLine("Kein Prozess '{0}' gefunden", processName);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
