using System;
using Addison_Wesley.Codebook.System;

namespace Prozessorgeschwindigkeit_ermitteln
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Prozessorgeschwindigkeit ermitteln
			uint processorSpeed = SystemUtils.GetProcessorSpeed();

			Console.WriteLine("Prozessorgeschwindigkeit: {0}", processorSpeed);
			Console.ReadLine();
		}
	}
}
