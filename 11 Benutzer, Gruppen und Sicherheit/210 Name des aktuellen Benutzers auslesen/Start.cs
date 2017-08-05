using System;
using System.Runtime.InteropServices;

namespace Benutzername_auslesen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Auslesen des Namens des Benutzers, der dem aktuellen
			// Thread zugeordnet ist
			string currentUserName = System.Environment.UserName;
			Console.WriteLine(currentUserName);
			
			Console.WriteLine("Taste");
			Console.ReadLine();
		}
	}
}
