using System;
using System.Text;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class DateUtils
	{
		/* Struktur für das Setzen der Systemzeit */
		[StructLayout(LayoutKind.Sequential)]
			private struct SYSTEMTIME 
		{
			public short uYear;
			public short uMonth;
			public short uDayOfWeek;
			public short uDay;
			public short uHour;
			public short uMinute;
			public short uSecond;
			public short uMilliseconds;
		}

		/* Deklaration der API-Funktion SetSystemTime */
		[DllImport("kernel32.dll", SetLastError=true)]
		static extern int SetSystemTime(ref SYSTEMTIME lpSystemTime);

		/* Deklaration der API-Funktion zur Formatierung eines Windows-Fehlercodes */
		[DllImport("Kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, string lpSource,
			int dwMessageId, int dwLanguageId,System.Text.StringBuilder lpBuffer, 
			int nSize, string [] Arguments);
		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x100;

		/* Private Methode zum Setzen der Systemzeit */
		private static void setSystemTime(SYSTEMTIME sysTime)
		{
			// Systemzeit setzen
			if (SetSystemTime(ref sysTime) == 0)
			{
				// Fehler bei der Ausführung: Den letzten Windows-Fehlercode
				// auslesen, in eine Beschreibung umwandeln und damit
				// eine Ausnahme werfen
				int apiError = Marshal.GetLastWin32Error();
				StringBuilder errorMessage = new StringBuilder(1024);
				FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, null, apiError,
					0, errorMessage, 1024, null);
				throw new Exception(errorMessage.ToString());
			}
		}

		/* Methode zum Setzen des Systemdatums inkl. Zeit */
		public static void SetSystemDateTime(System.DateTime date)
		{
			// Zeit in UTC umrechnen
			date = date.ToUniversalTime();
 
			// SYSTEMTIME-Struktur erzeugen und initialisieren
			SYSTEMTIME sysTime = new SYSTEMTIME();
			sysTime.uYear = (short)date.Year;
			sysTime.uMonth = (short)date.Month;
			sysTime.uDay = (short)date.Day;
			sysTime.uHour = (short)date.Hour;
			sysTime.uMinute = (short)date.Minute;
			sysTime.uSecond = (short)date.Second;
			sysTime.uMilliseconds = (short)date.Millisecond;

			// Systemzeit über die private Methode setzen
			setSystemTime(sysTime);
		}

		/* Methode zum Setzen des Systemdatums ohne Zeit */
		public static void SetSystemDate(System.DateTime date)
		{
			// SYSTEMTIME-Struktur erzeugen und initialisieren
			SYSTEMTIME sysTime = new SYSTEMTIME();
			sysTime.uYear = (short)date.Year;
			sysTime.uMonth = (short)date.Month;
			sysTime.uDay = (short)date.Day;
			sysTime.uHour = (short)System.DateTime.Now.Hour;
			sysTime.uMinute = (short)System.DateTime.Now.Minute;
			sysTime.uSecond = (short)System.DateTime.Now.Second;
			sysTime.uMilliseconds = (short)System.DateTime.Now.Millisecond;

			// Systemzeit über die private Methode setzen
			setSystemTime(sysTime);
		}

		/* Methode zum Setzen der Systemzeit (ohne Datum) */
		public static void SetSystemTime(System.DateTime date)
		{
			// Zeit in UTC umrechnen
			date = date.ToUniversalTime();

			// SYSTEMTIME-Struktur erzeugen und initialisieren
			SYSTEMTIME sysTime = new SYSTEMTIME();
			sysTime.uYear = (short)System.DateTime.Now.Year;
			sysTime.uMonth = (short)System.DateTime.Now.Month;
			sysTime.uDay = (short)System.DateTime.Now.Day;
			sysTime.uHour = (short)date.Hour;
			sysTime.uMinute = (short)date.Minute;
			sysTime.uSecond = (short)date.Second;
			sysTime.uMilliseconds = (short)date.Millisecond;

			// Systemzeit über die private Methode setzen
			setSystemTime(sysTime);
		}
		
		/* Methode zur Abfrage der Zeitangabe eines NIST-Servers */ 
		public static System.DateTime GetNISTTime()
		{
			// Variable für Fehlermeldungen
			string errors = null;

			// Array für die abzufragenden Server
			string[] servers = {"time-a.nist.gov", "time-b.nist.gov",
								   "time.nist.gov", "utcnist.colorado.edu", "nist1.datum.com"};

			// Schleife, in der die Server abgefragt werden, bis das Ergebnis 
			// in Ordnung ist
			for (int i = 0; i < servers.Length; i++)
			{
				TcpClient tcpClient = null;
				try
				{
					// TcpClient erzeugen und den Empfangs-Timeout auf eine Sekunde
					// setzen
					tcpClient = new TcpClient();
					tcpClient.ReceiveTimeout = 1000;

					// Versuch, zum aktuellen Server eine Verbindung aufzubauen
					tcpClient.Connect(servers[i], 13);   

					// Den NetworkStream referenzieren
					NetworkStream networkStream = tcpClient.GetStream();

					string result = null;
					if (networkStream.CanWrite && networkStream.CanRead)
					{
						// Das Ergebnis empfangen und in ASCII konvertieren
						byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
						try
						{
							networkStream.Read(bytes, 0, 
								(int) tcpClient.ReceiveBufferSize);
							result = Encoding.ASCII.GetString(bytes);
						}
						catch (Exception ex)
						{
							// Fehler dokumentieren
							if (errors != null) errors += "\r\n";
							errors += "Fehler bei der Abfrage von '" + servers[i] + 
								": " + ex.Message;
						}
					}

					if (result != null)
					{
						// Das Ergebnis, das die Form JJJJJ YR-MO-DA HH:MM:SS TT L H msADV 
						// UTC(NIST) OTM besitzt, in einzelne Token aufsplitten
						string[] token = result.Split(' ');

						// Anzahl der Token überprüfen
						if (token.Length >= 6)
						{
							// Den Health-Status auslesen und überprüfen
							string health = token[5];
							if (health == "0")
							{
								// Alles OK:  Datums- und Zeitangaben auslesen
								string[] dates = token[1].Split('-');
								string[] times = token[2].Split(':');

								// DateTime-Instanz mit diesen Daten erzeugen
								System.DateTime utcDate = 
									new System.DateTime(Int32.Parse(dates[0]) + 2000,
									Int32.Parse(dates[1]), Int32.Parse(dates[2]),
									Int32.Parse(times[0]), Int32.Parse(times[1]),
									Int32.Parse(times[2]));

								// Lokale Zeit berechnen und zurückgeben
								return TimeZone.CurrentTimeZone.ToLocalTime(utcDate);
							}
							else
							{
								// Fehler dokumentieren
								if (errors != null) errors += "\r\n";
								errors += "Fehler bei der Abfrage von '" + servers[i] +
									": Der Health-Status ist " + health;
							}
						}
						else
						{
							// Fehler dokumentieren
							if (errors != null) errors += "\r\n";
							errors += "Fehler bei der Abfrage von '" + servers[i] +
								": Die Anzahl der Token ist kleiner als 6";
						}
					}
				}
				catch (Exception ex)
				{
					// Fehler dokumentieren
					if (errors != null) errors += "\r\n";
					errors += "Fehler bei der Abfrage von '" + 
						servers[i] + ": " + ex.Message;
				}
				finally
				{
					try 
					{
						// TcpClient schließen
						tcpClient.Close();
					}
					catch {}
				}
			}

			// Wenn die Methode hier ankommt, sind bei allen Abfragen
			// Fehler aufgetreten, also eine Ausnahme werfen
			throw new Exception(errors);
		}
	}
}
