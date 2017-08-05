using System;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Methode zum Starten einer Java-Anwendung */
		public static void StartJavaApplication(string fileName, string classPath,
			bool isWindowApp)
		{
			// Überprüfen, ob die Datei existiert
			if (File.Exists(fileName) == false)
			{
				throw new IOException("Das Java-Programm '" + fileName + 
					"' existiert nicht");
			}

			// Variable für die Start-Argumente
			string arguments = null;

			// Pfad und Dateiname trennen
			FileInfo fi = new FileInfo(fileName);
			string path = fi.DirectoryName;
			fileName = fi.Name;

			// Argumente zusammensetzen und den Dateinamen bei einer .class-Datei 
			// ohne Endung auslesen
			if (fi.Extension == ".jar")
				arguments += " -jar";
			else if (fi.Extension == ".class")
				fileName = fileName.Substring(0, fileName.Length - 6);
			else
			{
				throw new IOException("Unbekannte Dateiendung '" + 
					fi.Extension + "'");
			}

			// Den Argumenten den Klassenpfad hinzufügen
			if (classPath != null)
				arguments += " -classpath " + classPath;

			// Den Dateinamen zu den Argumenten hinzufügen
			arguments += " " + fileName;

			// In den Ordner wechseln, in dem die Datei gespeichert ist
			Environment.CurrentDirectory = path;

			// Den Java-Interpreter starten
			string javaInterpreter = null;
			if (isWindowApp)
				javaInterpreter = "javaw.exe";
			else
				javaInterpreter = "java.exe";

			try
			{
				Process.Start(javaInterpreter, arguments);
			}
			catch (Win32Exception ex)
			{
				throw new IOException("Fehler beim Starten des " +
					"Java-Interpreters " + javaInterpreter + ": " +
					ex.Message); 
			}
		}
	}
}
