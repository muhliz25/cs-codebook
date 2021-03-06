using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Multimedia
{
	/* Klasse f�r MCI-Ausnahmen */   
	public class MciException: Exception
	{
		public MciException(string context, string message): 
			base("Fehler beim " + context + ": " + message)
		{
		}
	}

	/* Klasse f�r das Abspielen von Mediadateien �ber MCI */   
	public class Mci: IDisposable
	{
		/* Deklaration der MCI-Funktionen, -Konstanten und -Strukturen */
		[DllImport("winmm.dll", CharSet=CharSet.Auto)]
		private static extern int mciSendString(string lpstrCommand,
			StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);

		[DllImport("winmm.dll", CharSet=CharSet.Auto)]
		private static extern int mciGetErrorString(int dwError,
			StringBuilder lpstrBuffer, int uLength);

		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		private static extern int GetShortPathName(string lpszLongPath,
			StringBuilder lpszShortPath, int cchBuffer);
 
		/* Eigenschaft f�r den MCI-Alias */
		private string alias;

		/* Eigenschaft, die angibt, ob gerade ein Ger�t ge�ffnet ist */
		private bool isOpen = false;
		public bool IsOpen
		{
			get {return this.isOpen;}
		}

		/* Methoden zum Auslesen von MCI-Fehlern */
		private string GetMciError(int errorCode) 
		{
			StringBuilder errorMessage = new StringBuilder(255);
			if (mciGetErrorString(errorCode, errorMessage, errorMessage.Capacity) == 0)
				return "MCI-Fehler " + errorCode;
			else
				return errorMessage.ToString();
		}
		
		/* Methoden zum �ffnen */
		public void Open(string fileName)
		{
			Open(fileName, null);
		}

		public void Open(string fileName, Control owner)
		{
			// Alias f�r das MCI-Ger�t erzeugen
			this.alias = Guid.NewGuid().ToString("N");

			// �berpr�fen, ob die Datei existiert
			if (File.Exists(fileName) == false)
				throw new FileNotFoundException("Die Datei '" + fileName + 
					"' existiert nicht", fileName);

			// Den kurzen Dateinamen ermitteln
			StringBuilder shortPath = new StringBuilder(261);
			if (GetShortPathName(fileName, shortPath, shortPath.Capacity) == 0)
				throw new MciException("Auslesen des kurzen Dateinamens f�r '" +
					fileName + "'", "Windows-Fehler " + Marshal.GetLastWin32Error());

			// MCI-Befehlsstring zum �ffnen zusammensetzen
			string mciString = "open " + shortPath.ToString() + 
				" type mpegvideo alias " + this.alias;

			if (owner != null)
				mciString += " parent " + (int)owner.Handle + " style child";

			// MCI-Ger�t �ffnen
			int result = mciSendString(mciString, null, 0, IntPtr.Zero);
			if (result != 0)
				throw new MciException("�ffnen des MCI-Ger�ts", GetMciError(result));
         
			this.isOpen = true;

			// Das Zeitformat f�r L�ngen- und Positionsangaben explizit
			// auf Millisekunden setzen
			mciString = "set " + this.alias + " time format ms" ;
			result = mciSendString(mciString, null, 0, IntPtr.Zero);
			if (result != 0)
				throw new MciException("Setzen des Zeitformats",
					GetMciError(result));
		}

		/* Eigenschaft zur Ermittlung der Abspiell�nge */
		public int Length 
		{
			get
			{
				StringBuilder buffer = new StringBuilder(261);
				int result = mciSendString("status " + this.alias + " length", buffer,
					buffer.Capacity, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Lesen der L�nge", GetMciError(result));

				return int.Parse(buffer.ToString());
			}
		}

		/* Methoden zum Abspielen */
		public void Play(bool repeat)
		{
			Play(0, this.Length, repeat);
		}

		public void Play(int from, bool repeat)
		{
			Play(from, this.Length - from, repeat);
		}

		public void Play(int from, int to, bool repeat)
		{
			string mciString = "play " + this.alias+ " from " + from + " to " + to;
			if (repeat)
				mciString += " repeat";
			int result = mciSendString(mciString, null, 0, IntPtr.Zero);
			if (result != 0)
				throw new MciException("Aufruf von Play", GetMciError(result));
		}

		/* Eigenschaft zum Lesen und Schreiben der Lautst�rke */
		public int Volume 
		{
			get
			{
				StringBuilder buffer = new StringBuilder(261);
				int result = mciSendString("status " + this.alias + " volume", buffer, buffer.Capacity, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Lesen von Volume", GetMciError(result));
				return int.Parse(buffer.ToString());
			}
			set
			{
				int result = mciSendString("setaudio " + this.alias + " volume to " + value, null, 0, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Aufruf von SetAudio", GetMciError(result));
			}
		}

		/* Eigenschaft f�r die Position */
		public int Position 
		{
			get
			{
				StringBuilder buffer = new StringBuilder(261);
				int result = mciSendString("status " + this.alias + " position", buffer, buffer.Capacity, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Lesen von Position", GetMciError(result));
				return int.Parse(buffer.ToString());
			}
			set
			{
				int result = mciSendString("seek " + this.alias + " to " + value, null, 0, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Aufruf von Seek", GetMciError(result));
				result = mciSendString("play " + this.alias, null, 0, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Aufruf von Play", GetMciError(result));
			}
		}

		/* Eigenschaft f�r die Abspiel-Geschwindigkeit */
		public int PlaybackSpeed 
		{
			get 
			{
				StringBuilder buffer = new StringBuilder(261);
				int result = mciSendString("status " + this.alias + " speed", buffer, buffer.Capacity, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Lesen von Speed", GetMciError(result));
				return int.Parse(buffer.ToString());
			}
			set
			{
				string mciString = "set " + this.alias + " speed " + value;
				int result = mciSendString(mciString, null, 0, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Setzen von Speed", GetMciError(result));
			}
		}

		/* Methode zur Definition der Abspielposition und -gr��e f�r Videos,
		 * die auf einem Formular, einer PictureBox o. �. dargestellt werden */
		public void SetRectangle(int x, int y, int width, int height)
		{
			string mciString = "put " + this.alias + " window at " + x + " " + y + 
				" " + width + " " + height;
			int result = mciSendString(mciString, null, 0, IntPtr.Zero);
			if (result != 0)
				throw new MciException("Aufruf von Put Window at",
					GetMciError(result));
		}

		/* Methode zum Stoppen */
		public void Stop()
		{
			string mciString = "stop " + this.alias;
			int result = mciSendString(mciString, null, 0, IntPtr.Zero);
			if (result != 0)
				throw new MciException("Aufruf von Stop", GetMciError(result));
		}

		/* Methode zum Schlie�en */
		public void Close()
		{
			if (this.isOpen)
			{
				string mciString = "close " + this.alias;
				int result = mciSendString(mciString, null, 0, IntPtr.Zero);
				if (result != 0)
					throw new MciException("Aufruf von Close", GetMciError(result));

				this.isOpen = false;
			}
		}

		/* Dispose-Methode */
		public void Dispose()
		{
			this.Close();
		}

		/* Destruktor */
		~Mci()
		{
			this.Close();
		}
	}
}
