using System;
using System.Windows.Forms;
using Addison_Wesley.Codebook.System;

namespace WIndows_booten
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Hostname und Authentifizierungsinformationen
			// Die Authentifizierungsinformationen werden nur für
			// einen Remote-Zugriff verwendet. Lokale Zugriffe
			// erfolgen immer unter dem Konto das der aktuelle
			// Prozess verwendet.
			string hostName = "localhost";
			string authUser = null;
			string authPassword = null;
			
			/* Rechner herunterfahren oder neu starten */
			try
			{
				switch(MessageBox.Show(hostName + " herunterfahren (Ja) oder neu starten (Nein)?",
					Application.ProductName, MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						SystemUtils.ShutdownSystem(hostName, authUser, authPassword, false);
						break;
					case DialogResult.No :
						SystemUtils.ShutdownSystem(hostName, authUser, authPassword, true);
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
