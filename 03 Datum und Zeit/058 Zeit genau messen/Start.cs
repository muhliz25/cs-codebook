using System;
using Addison_Wesley.Codebook.DateAndTime;

namespace Zeit_genau_messen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Zeit ungenau (mit einem Intervall von etwa 15 bis 55ms) �ber die Ticks 
			// der DateTime-Struktur messen
			Console.WriteLine("Zeitmessung �ber DateTime.Now.Ticks:");
			long startTicks = DateTime.Now.Ticks;

			int i = 0;
			while (i < 1000000)
				i++;

			long ticks = (DateTime.Now.Ticks - startTicks);
			double seconds = ticks / 10000000F;
			Console.WriteLine("Ben�tigte Zeit: {0} Ticks, {1} Sekunden", ticks, seconds);

			// Zeit genau �ber QueryPerformanceCounter messen
			Console.WriteLine();
			Console.WriteLine("Zeitmessung �ber QueryPerformanceCounter:");
			HighResStopClock stopClock;
			try
			{
				stopClock = new HighResStopClock();
				Console.WriteLine("Aktuelle Frequenz: {0}", stopClock.PCFrequency);
				Console.WriteLine("Aktuelle Aufl�sung: {0:G} Sekunden", stopClock.PCResolution);

				stopClock.Start();
				i = 0;
				while (i < 1000000)
					i++;
				seconds = stopClock.Stop();
				Console.WriteLine("Ben�tigte Zeit: {0} Sekunden", seconds);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			



			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();




		}
	}
}
