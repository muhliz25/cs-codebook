using System;
using Addison_Wesley.Codebook.System;

namespace Windows_Version
{
	class Start
	{
		
		[STAThread]
		static void Main(string[] args)
		{
			// Auslesen der Windows-Hauptversion
			SystemUtils.WindowsMainVersion winMainVersion = 
				SystemUtils.GetWindowsMainVersion();

			// Auslesen der ermittelten Version
			switch (winMainVersion)
			{
				case SystemUtils.WindowsMainVersion.Unknown:
					Console.WriteLine("Unbekannte (neue?) Version");
					break;
				case SystemUtils.WindowsMainVersion.Windows95:
					Console.WriteLine("Windows 95");
					break;
				case SystemUtils.WindowsMainVersion.Windows98:
					Console.WriteLine("Windows 98");
					break;
				case SystemUtils.WindowsMainVersion.WindowsMe:
					Console.WriteLine("Windows Me");
					break;
				case SystemUtils.WindowsMainVersion.WindowsNT35:
					Console.WriteLine("Windows NT 3.5");
					break;
				case SystemUtils.WindowsMainVersion.WindowsNT4:
					Console.WriteLine("Windows NT 4");
					break;
				case SystemUtils.WindowsMainVersion.Windows2000:
					Console.WriteLine("Windows 2000");
					break;
				case SystemUtils.WindowsMainVersion.WindowsXP:
					Console.WriteLine("Windows XP");
					break;
				case SystemUtils.WindowsMainVersion.WindowsServer2003:
					Console.WriteLine("Windows Server 2003");
					break;
			}

			Console.ReadLine();

		}
	}
}
