using System;
using Addison_Wesley.Codebook.Application;

namespace Anwendung_pr�fen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// �berpr�fen, ob Outlook l�uft
			if (AppUtils.ApplicationRunning("Outlook", "Microsoft Outlook"))
				Console.WriteLine("Outlook l�uft");
			else
				Console.WriteLine("Outlook l�uft nicht");

			Console.ReadLine();
		}
	}
}
