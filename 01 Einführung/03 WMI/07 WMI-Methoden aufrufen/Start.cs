using System;
using System.Management;

namespace WMI_Methoden
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Aufruf einer Methode mit einfachen Argumenten */

			// Instanz der Klasse Win32_Share erzeugen
			ManagementClass mc = new ManagementClass("Win32_Share");

			// Über die Create-Methode eine Freigabe erzeugen
			string share = "c:\\windows";
			string name = "Windows-Ordner";
			int type = 0; // Festplattenlaufwerk
			object result = mc.InvokeMethod("Create", new Object[] {share, name, type});
			if (Convert.ToInt32(result) == 0)
				Console.WriteLine("Freigabe erfolgreich erzeugt");
			else
				Console.WriteLine("Freigabe konnte nicht erzeugt werden." +
					"Möglicher Grund: Es existiert bereits eine identische Freigabe");

			
			/* Aufruf einer Methode mit By-Reference-Argumenten */

			// Die aktuellen Prozesse ermitteln
			mc = new ManagementClass("Win32_Process");
			ManagementObjectCollection moc = mc.GetInstances();
			foreach (ManagementObject mo in moc)
			{
				// Prozessname ausgeben
				Console.WriteLine(mo.Properties["Name"].Value.ToString());
				
				// Den Besitzer des Prozesses ermitteln
				object[] resultArray = new String[2];
				result = mo.InvokeMethod("GetOwner", resultArray);
				if (Convert.ToInt32(result) == 0)
				{
					// Auswerten der zurückgegebenen Daten
					string user = resultArray[0].ToString();
					string domain = resultArray[1].ToString();
					Console.WriteLine("User: {0}", user);
					Console.WriteLine("Domäne: {0}", domain);
				}
				Console.WriteLine();
				
			}


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();


		}
	}
}
