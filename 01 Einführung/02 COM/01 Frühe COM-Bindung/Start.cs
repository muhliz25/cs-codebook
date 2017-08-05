using System;

namespace Frühe_COM_Bindung
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// FileSystemObjectClass-Instanz erzeugen
			Scripting.FileSystemObjectClass fso = new Scripting.FileSystemObjectClass();
 
			// Laufwerk referenzieren
			Scripting.Drive drive = fso.GetDrive("c:");

			// Informationen zum Laufwerk ausgeben
			Console.WriteLine("Freier Platz: {0}", drive.FreeSpace);
			Console.WriteLine("Größe: {0}", drive.TotalSize);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}
	}
}
