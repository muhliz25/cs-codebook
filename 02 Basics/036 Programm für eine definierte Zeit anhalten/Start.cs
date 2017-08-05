using System;
using System.Threading;

namespace Programm_pausieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Jetzt folgt eine Pause von einer Sekunde");
			Thread.Sleep(1000);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
