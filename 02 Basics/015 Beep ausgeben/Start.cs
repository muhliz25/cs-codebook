using System;
using System.Threading;
using Addison_Wesley.Codebook.Basics;

namespace Beep
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Ausgeben der verschiedenen Piepstöne
			Console.WriteLine("Simple");
			BasicUtils.MessageBeep(BasicUtils.BeepType.Simple);
			Thread.Sleep(500);

			Console.WriteLine("Information");
			BasicUtils.MessageBeep(BasicUtils.BeepType.Information);
			Thread.Sleep(500);

			Console.WriteLine("Question");
			BasicUtils.MessageBeep(BasicUtils.BeepType.Question);
			Thread.Sleep(500);

			Console.WriteLine("Exclamation");
			BasicUtils.MessageBeep(BasicUtils.BeepType.Exclamation);
			Thread.Sleep(500);

			Console.WriteLine("Error");
			BasicUtils.MessageBeep(BasicUtils.BeepType.Error);
			Thread.Sleep(500);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
