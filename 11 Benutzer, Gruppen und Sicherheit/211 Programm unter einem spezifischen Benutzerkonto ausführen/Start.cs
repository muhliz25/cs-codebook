using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using Addison_Wesley.Codebook.System;

namespace Impersonation
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{

			// Variablen für die Personifizierung
			string userName = "Ford";
			string password = "Handtuch";

			try
			{
				// Den Namen des aktuellen Benutzers ausgeben
				WindowsIdentity identity = WindowsIdentity.GetCurrent();
				Console.WriteLine("Aktueller Benutzer: {0}", identity.Name);

				// Aktion ausführen, zu der das interaktive Konto keine Rechte besitzt
				StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath,
					"demo.txt"), Encoding.Default);
				string line = sr.ReadLine();
				Console.WriteLine(line);
				sr.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			try
			{
				// Programm personifizieren
				Logon.ImpersonateUser(null, userName, password);

				// Den Namen des nun aktuellen Benutzers ausgeben
				WindowsIdentity identity = WindowsIdentity.GetCurrent();
				Console.WriteLine("Aktueller Benutzer: {0}", identity.Name);

				// Aktion ausführen, zu der das neue Konto nun (hoffentlich) Rechte
				// besitzt
				StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath,
					"demo.txt"), Encoding.Default);
				string line = sr.ReadLine();
				Console.WriteLine(line);
				sr.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			// Personifizierung rückgängig machen
			Logon.UndoImpersonation();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
