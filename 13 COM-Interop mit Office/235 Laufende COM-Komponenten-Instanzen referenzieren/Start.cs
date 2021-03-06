using System;
using System.Runtime.InteropServices;

namespace Laufende_Instanzen_referenzieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Versuch, eine eventuell bereits ausgef�hrte Outlook-Instanz zu referenzieren
			object outlookObject = null;
			try
			{
				outlookObject = Marshal.GetActiveObject("Outlook.Application");
			}
			catch {}

			Outlook.Application outlook = null;
			bool outlookInstanceCreated = false;
			if (outlookObject != null)
			{
				// Wenn eine Instanz referenziert werden konnte, wird diese in den passenden
				//.NET-Typ konvertiert (fr�he Bindung)
				outlook = (Outlook.Application)outlookObject;
			}
			else
			{
				// Wenn keine Instanz referenziert werden konnte, wird einfach eine neue erzeugt
				outlookInstanceCreated = true; // Merker f�r das Schlie�en unten
				outlook = new Outlook.ApplicationClass();
			}

			// Neue E-Mail erzeugen und versenden
			Outlook.MailItem mailItem = (Outlook.MailItem)outlook.CreateItem(
				Outlook.OlItemType.olMailItem);
			mailItem.To = "donald.duck@entenhausen.de";
			mailItem.Subject = "Party";
			mailItem.Body = "Hallo Donald, wir machen am Samstag eine Party." +
				"Du bist eingeladen"; 
			mailItem.Send();

			// Outlook beenden, wenn eine neue Instanz erzeugt wurde
			if (outlookInstanceCreated)
				outlook.Quit();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
