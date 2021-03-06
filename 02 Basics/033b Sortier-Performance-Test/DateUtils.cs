using System;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.DateAndTime
{
	public class HighResStopClock
	{
		/* Deklaration der ben�tigten API-Funktionen */
		[DllImport("kernel32.dll", SetLastError=true)]
		private extern static int QueryPerformanceCounter(
			ref long lpPerformanceCount);

		[DllImport("kernel32.dll", SetLastError=true)]
		private extern static int QueryPerformanceFrequency(
			ref long lpFrequency );

		/* Variablen f�r die Frequenz des Performance-Counters und f�r 
		 * den Start einer Zeitmessung */
		private long pcFrequency = 0;
		private long startCount;

		/* Konstruktor */
		public HighResStopClock()
		{
			// Ermitteln der Performance-Counter-Frequenz
			if (QueryPerformanceFrequency(ref this.pcFrequency) == 0)
				throw new Exception("Die Frequenz des Performance-Counters " +
					"kann nicht ermittelt werden. Windows-Fehler " +
					Marshal.GetLastWin32Error() + ". Wahrscheinlich besitzt " +
					"das Motherboard keinen Performance-Counter");
		}

		/* Eigenschaft zum Lesen der Frequenz */
		public long PCFrequency
		{
			get {return this.pcFrequency;}
		}

		/* Eigenschaft zum Lesen der Aufl�sung */
		public double PCResolution
		{
			get {return 1F / this.pcFrequency;}
		}

		/* Methode zum Starten der Zeitmessung */
		public void Start()
		{
			if (QueryPerformanceCounter(ref this.startCount) == 0)
				throw new Exception("Der Wert des Performance-Counters kann " +
					"nicht ermittelt werden. Windows-Fehler " + 
					Marshal.GetLastWin32Error());
		}

		/* Methode zum Stoppen der Zeitmessung */
		public double Stop()
		{
			long count = 0;
			if (QueryPerformanceCounter(ref count) == 0)
				throw new Exception("Der Wert des Performance-Counters kann " +
					"nicht ermittelt werden. Windows-Fehler " +
					Marshal.GetLastWin32Error());
			return (count - this.startCount) / (double)this.pcFrequency;
		}
	}
}
