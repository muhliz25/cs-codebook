using System;
using System.IO;
using System.Windows.Forms;
using Win32Mapi;

namespace Mails_�ber_MAPI_versenden_
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Mapi-Instanz erzeugen
			Mapi mapi = new Mapi();

			// Logon in MAPI. Sie k�nnen den aktuellen
			// Benutzer einloggen, indem Sie IntPtr.Zero �bergeben.
			// Wollen Sie einen spezifischen Benutzer einloggen,
			// k�nnen Sie ein Token �ber die API-Funktion LogonUser 
			// erzeugen und dessen Handle �bergeben.
			if(mapi.Logon(IntPtr.Zero) == false)
			{
				Console.WriteLine("Der Login in MAPI ist fehlgeschlagen: " + mapi.Error());
				return;
			}

			// Empf�nger hinzuf�gen
			string mailAddress = "juergen.bayer@t-online.de";
			mapi.AddRecip(mailAddress, null, false);

			// Datei anf�gen
			string fileName = Path.Combine(Application.StartupPath, "dontpanic.gif");
			mapi.Attach(fileName);

			// Mail senden
			string subject = "Party";
			string message = "Hallo Zaphod, hast du Lust auf eine Party im Restaurant " +
				"am Ende der Galaxis?";
			if (mapi.Send(subject, message))
				Console.WriteLine("E-Mail erfolgreich versendet");
			else
				Console.WriteLine("Das Senden ist fehlgeschlagen: {0}", mapi.Error());

			// Aus MAPI ausloggen
			mapi.Logoff();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
