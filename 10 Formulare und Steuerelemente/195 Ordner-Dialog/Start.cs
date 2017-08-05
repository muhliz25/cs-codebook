using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using CP.Windows.Forms;

namespace Ordner_Dialog
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Einfache Variante für das .NET-Framework 1.0 über die
			 * Klasse FolderNameEditor aus System.Windows.Forms.Design */
			FolderNameEditor browser =	new FolderNameEditor();
			string folderPath = (string)browser.EditValue(null, null);
			if (folderPath != null)
				Console.WriteLine("{0}: {1}", folderPath, folderPath.Length);
			else
				Console.WriteLine("Abbruch");

			/* Variante über die API-Funktion SHBrowseForFolder 
			 * Quelle: www.codeproject.com/cs/miscctrl/folderbrowser.asp */
			ShellFolderBrowser folderBrowser = new ShellFolderBrowser();

			folderBrowser.BrowseFlags = BrowseFlags.ReturnOnlyFSDirs;
			// folderBrowser.EnableOkButton();
			folderBrowser.Title = "Suchen Sie den Ordner:";
			if (folderBrowser.ShowDialog()) 
				Console.WriteLine(folderBrowser.FolderPath);
			else
				Console.WriteLine("Abbruch");

			/* Framework 1.1-Variante über die Klasse FolderBrowserDialog */
			/*
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = "C:\\Programme";
			// fbd.RootFolder = Environment.SpecialFolder.Personal;
			fbd.ShowNewFolderButton = false;
			fbd.Description = "Wählen Sie einen Ordner aus:";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine(fbd.SelectedPath);
			}
			*/


			Console.ReadLine();
		}
	}
}
