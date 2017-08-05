using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Internet
{
	public class InternetUtils
	{
		/* Deklaration der API-Funktion InternetGetConnectedStateEx */
		[DllImport("wininet.dll")]
		private static extern int InternetGetConnectedStateEx(out int lpdwFlags, 
			StringBuilder lpszConnectionName, int dwNameLen, int dwReserved);

		/* Konstanten für InternetGetConnectedStateEx */
		private const int INTERNET_CONNECTION_MODEM = 0x01;
		private const int INTERNET_CONNECTION_LAN = 0x02;
		private const int INTERNET_CONNECTION_PROXY = 0x04;
		private const int INTERNET_RAS_INSTALLED = 0x10;
		private const int INTERNET_CONNECTION_OFFLINE = 0x20;
		private const int INTERNET_CONNECTION_CONFIGURED = 0x40;

		/* Klasse für die Rückgabe des Internet-Verbindungsstatus */
		public class InternetConnectionState
		{
			// Der Name der Verbindung
			public string Name;
			// Info, ob die Verbindung online ist
			public bool Online;
			// Info, ob die Verbindung konfiguriert ist
			public bool Configured; 
			// Info, ob eine Modem-Verbindung besteht (auch ISDN und DSL)
			public bool ModemConnection;
			// Info, ob die Verbindung über das LAN erfolgt (z. B. bei TDSL)
			public bool Lan;
			// Info, ob die Verbindung über einen Proxy erfolgt 
			public bool ProxyConnection;
			// Info, ob RAS installiert ist
			public bool RASInstalled;
			// Info, ob das System im Offline-Modus ist
			public bool Offline;    
		}
		
		/* Methode zur Ermittlung der Art der aktuellen Internetverbindung */
		public static InternetConnectionState GetInternetConnectionState()
		{
			// InternetConnectionState-Instanz erzeugen
			InternetConnectionState ics = new InternetConnectionState();

			// Verbindungsstatus abfragen
			StringBuilder icsName = new StringBuilder(1024);
			int flags;
			ics.Online = (InternetGetConnectedStateEx(out flags, icsName, 1024, 0) != 0);
			ics.Name = icsName.ToString();
			ics.Configured = ((flags & INTERNET_CONNECTION_CONFIGURED) > 0);
			ics.Lan = ((flags & INTERNET_CONNECTION_LAN) > 0);
			ics.ModemConnection = ((flags & INTERNET_CONNECTION_MODEM) > 0);
			ics.Offline = ((flags & INTERNET_CONNECTION_OFFLINE) > 0);
			ics.ProxyConnection = ((flags & INTERNET_CONNECTION_PROXY) > 0);
			ics.RASInstalled = ((flags & INTERNET_RAS_INSTALLED) > 0);

			// Das InternetConnectionState-Objekt zurückgeben
			return ics;
		}
	}
}
