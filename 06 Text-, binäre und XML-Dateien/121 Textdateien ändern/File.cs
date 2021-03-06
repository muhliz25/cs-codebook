using System;
using System.IO;
using System.Text;

namespace Addison_Wesley.Codebook.Files
{
	public class TextFile
	{
		public static void AddFileNumbers(string textFileName)
		{
			// Dateiname f�r die tempor�re Datei ermitteln
			string tempFileName = Path.GetTempFileName();

			// Textdatei zum Lesen �ffnen
			StreamReader sr = null;
			sr = new StreamReader(textFileName, Encoding.GetEncoding("windows-1252"));

			// Temp-Datei zum Schreiben �ffnen
			StreamWriter sw = null;
			sw = new StreamWriter(tempFileName, false, 
				Encoding.GetEncoding("windows-1252"));

			// Textdatei zeilenweise einlesen, Zeilen ver�ndern und in die tempor�re
			// Datei schreiben
			string line;
			int lineNumber = 0;
			while ((line = sr.ReadLine()) != null)
			{
				lineNumber++;
				sw.WriteLine(lineNumber + ": " + line);
			}

			// Streams schlie�en
			sr.Close();
			sw.Close();

			// Textdatei l�schen und die tempor�re Datei auf die Textdatei verschieben
			File.Delete(textFileName);
			File.Move(tempFileName, textFileName);
		}
	}
}
