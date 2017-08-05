using System;
using System.Threading;

namespace Addison_Wesley.Codebook.Application
{
	public class AppUtils
	{
		/* Variable für den Mutex, der von der Anwendung erzeugt wird */
		private static Mutex mutex;

		/* Methode zur Ermittlung, ob bereits eine Instanz der Anwendung ausgeführt
		 * wird */
		public static bool OtherInstanceRunning()
		{
			// Mutex mit einem systemweit eindeutigen Namen erzeugen
			string mutexName = System.Windows.Forms.Application.ProductName +
				"_MultiStartPrevent";
			mutex = new Mutex(false, mutexName);

			// Signalisieren des Mutex und gleichzeitig abfragen, ob bereits ein
			// gleichnamiger Mutex existiert
			if (mutex.WaitOne(0, true))
				return false;
			else
				return true;
		}
	}
}
