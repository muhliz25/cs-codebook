using System;
using System.IO;

namespace Ordner_verschieben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Zu Demozwecken Ordner erzeugen
			Directory.CreateDirectory(@"C:\DemoFolder");
			
			string sourceFolderName = @"C:\DemoFolder";   
			string destFolderName = @"C:\Temp\DemoFolder";

			try
			{
				// Ordner verschieben
				Directory.Move(sourceFolderName, destFolderName);

				Console.WriteLine("Ordner erfolgreich verschoben");
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Verschieben des Ordners: " +
					ex.Message);
			}

			Console.ReadLine();
		}
	}
}
