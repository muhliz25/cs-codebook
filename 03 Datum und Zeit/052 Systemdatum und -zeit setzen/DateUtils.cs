using System;
using System.Text;
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

		/* Deklaration der API-Funktion und -Konstante zur Formatierung eines 
		 * API-Fehlercodes */
		[DllImport("kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, IntPtr lpSource,
			int dwMessageId, int dwLanguageId,System.Text.StringBuilder lpBuffer, 
			int nSize, string [] Arguments);

		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

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
				FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, (IntPtr)0, apiError,
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

	}
}
