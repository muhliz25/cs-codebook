using System;
using Addison_Wesley.Codebook.System;

namespace Benutzerexistenz_pr�fen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string domainName = null;
			string machineName = null;
			string bindUser = null;
			string bindPassword = null;
			
			/* �berpr�fen, ob der Benutzer Arthur existiert */
			if (UserUtils.UserExists("Arthur", domainName, machineName, bindUser, bindPassword))
				Console.WriteLine("Arthur existiert");
			else
				Console.WriteLine("Arthur existiert nicht");

			/* �berpr�fen, ob der Benutzer Administrator existiert */
			if (UserUtils.UserExists("Administrator", domainName, machineName, bindUser, bindPassword))
				Console.WriteLine("Administrator existiert");
			else
				Console.WriteLine("Administrator existiert nicht");

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}
	}
}
