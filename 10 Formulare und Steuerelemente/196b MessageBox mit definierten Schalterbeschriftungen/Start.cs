using System;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Windows.Forms;

namespace MessageBox_mit_definierten_Schalterbeschriftungen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			switch(ExtMessageBox.Show("Die Datei 'c:\\codebook\\codebook.mdb' " +
				"existiert bereits\r\n\r\nWollen Sie diese Datei �berschreiben?", 
				"Dateien kopieren", "Ja", "Nein", "Alle", 
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))

			{
				case ExtMessageBox.ExtDialogResult.FirstButton:
					Console.WriteLine("Datei �berschreiben ...");
					break;
				case ExtMessageBox.ExtDialogResult.SecondButton:
					Console.WriteLine("Datei nicht �berschreiben ...");
					break;
				case ExtMessageBox.ExtDialogResult.ThirdButton:
					Console.WriteLine("ALle Dateien �berschreiben ...");
					break;
			}

			Console.ReadLine();
		}
	}
}

