using System;
using System.IO;

namespace Ordner_umbenennen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Zu Demozwecken Ordner erzeugen
			Directory.CreateDirectory(@"C:\Temp\DemoFolder");
			
			// Ordner umbenennen
			string sourceDirName = @"C:\Temp\DemoFolder";  // Alter Name
			string destDirName = @"C:\Temp\Demo Folder";   // Neuer Name

			try
			{
				// Ordner umbenennen
				Directory.Move(sourceDirName, destDirName);

				Console.WriteLine("Ordner erfolgreich umbenannt");
			}
			catch (IOException ex)
			{
				Console.WriteLine("Fehler beim Umbenennen des Ordners: " + ex.Message);
			}

			Console.ReadLine();


		}
	}
}
