using System;
using System.Threading;
using System.Diagnostics;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zum Schlie�en einer anderen Anwendung */ 
		public static int CloseApplication(string processName, 
			string mainWindowTitle, int waitForExitTimeout)
		{
			int count = 0; 

			// Liste der Prozesse holen, die den �bergebenen Prozessnamen tragen
			Process[] processes = Process.GetProcessesByName(processName);
			foreach (Process process in processes)
			{
				// �berpr�fen des Hauptfenster-Titels, sofern dieser �bergeben wurde
				if ((mainWindowTitle != null && 
					process.MainWindowTitle == mainWindowTitle) || 
					(mainWindowTitle == null))
				{
					// Eine Beenden-Nachricht an das Hauptfenster senden
					process.CloseMainWindow();
         
					// Auf das Beenden des Prozesses warten, wenn ein Timeout 
					// �bergeben wurde
					if (waitForExitTimeout > 0)
					{
						if (process.WaitForExit(waitForExitTimeout))
							count++;
					}
					else
					{
						// Etwas warten, um dem Prozess Zeit zu lassen sich zu beenden
						Thread.Sleep(100);
						if (process.HasExited)
							count++;
					}
				}
			}

			// Anzahl der beendeten Prozesse zur�ckgeben
			return count;
		}
	}
}
