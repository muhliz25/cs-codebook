using System;
using Microsoft.VisualBasic;

namespace Anwendung_aktivieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Anwendung über die Visual-Basic-Methode AppActivate aktivieren
			try
			{
				Interaction.AppActivate("Google - Mozilla");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Fertig");
			Console.ReadLine();

		}
	}
}
