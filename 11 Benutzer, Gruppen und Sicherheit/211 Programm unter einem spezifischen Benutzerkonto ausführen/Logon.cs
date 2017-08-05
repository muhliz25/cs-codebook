using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Addison_Wesley.Codebook.System
{
	public class Logon
	{
		/* Deklaration benötigter API-Funktionen und Konstanten */
		[DllImport("advapi32.dll", SetLastError=true)]
		private static extern int LogonUser(string lpszUsername,
			string lpszDomain, string lpszPassword, int dwLogonType,
			int dwLogonProvider, out int phToken);

		[DllImport("kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, string lpSource, 
			int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, 
			string [] Arguments);

		private const int LOGON32_LOGON_NETWORK_CLEARTEXT = 3;
		private const int LOGON32_PROVIDER_DEFAULT = 0;
		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

		/* Eigenschaft, die ein bei einer Personifizierung erzeugtes 
		 * WindowsImpersonationContext-Objekt referenziert, über das die 
		 * Personifizierung wieder rückgängig gemacht werden kann */
		private static WindowsImpersonationContext 
			winImpersonationContext = null;

		/* Methode zur Personifizierung der aktuellen Anwendung mit einem
		 * speziellen Benutzerkonto. Funktioniert nur unter Windows NT, 2000, XP
		 * und neueren Windows-Versionen */
		public static void ImpersonateUser(string domain, string userName,
			string password)
		{
			// Benutzer einloggen
			int userToken = 0;
			bool loggedOn = (LogonUser(userName, domain, password, 
				LOGON32_LOGON_NETWORK_CLEARTEXT, LOGON32_PROVIDER_DEFAULT,
				out userToken) != 0);

			if (loggedOn == false)
			{
				// Fehler auslesen, in einen Text umwandeln und damit eine
				// Ausnahme werfen
				int apiError = Marshal.GetLastWin32Error();
				StringBuilder errorMessage = new StringBuilder(1024);
				FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, null, apiError,
					0, errorMessage, 1024, null);
				throw new Exception(errorMessage.ToString());
			}

			// WindowsIdentity mit diesem Token erzeugen
			WindowsIdentity identity = new WindowsIdentity((IntPtr)userToken);

			// Überprüfen, ob das erzeugte WindowsIdentity-Objekt den übergebenen
			// Benutzer repräsentiert
			string tokenUserName = null;
			if (userName.IndexOf("@") > 0)
			{
				// Benutzername im UPN-Format (user@DNS_domain_name)
				tokenUserName = userName.Replace('@', '\\');
			}
			else
			{
				// Normaler Benutzername
				tokenUserName = domain + "\\" + userName;
			}

			// Prozess mit der ermittelten Windows-Identität personifizieren
			winImpersonationContext = identity.Impersonate();
		}

		/* Methode zum Rückgängigmachen der Personifizierung */
		public static void UndoImpersonation()
		{
			if (winImpersonationContext != null)
			{
				winImpersonationContext.Undo();
			}
		}
	}
}
