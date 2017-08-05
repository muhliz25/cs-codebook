using System;
using Addison_Wesley.Codebook.Application;

namespace Anwendung_aktivieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Anwendung aktivieren
			try
			{
				AppUtils.ActivateApplication("MozillaWindowClass", "Google - Mozilla"); 
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
