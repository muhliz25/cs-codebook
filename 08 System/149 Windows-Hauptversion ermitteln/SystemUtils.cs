using System;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Aufz�hlung f�r die Windows-Hauptversion */
		public enum WindowsMainVersion
		{
			WindowsNT35,
			Windows95,
			Windows98,
			WindowsMe,
			WindowsNT4,
			Windows2000,
			WindowsXP,
			WindowsServer2003,
			Unknown
		}

		/* Methode zum Ermitteln der Windows-Hauptversion */
		public static WindowsMainVersion GetWindowsMainVersion()
		{
			switch (Environment.OSVersion.Version.Major)
			{
				case 3:
					return WindowsMainVersion.WindowsNT35;
				case 4:
					if (Environment.OSVersion.Version.Minor == 0)
						if (Environment.OSVersion.Platform ==
							PlatformID.Win32NT)
							return WindowsMainVersion.WindowsNT4 ;
						else
							return WindowsMainVersion.Windows95;
					else if (Environment.OSVersion.Version.Minor == 10)
						return WindowsMainVersion.Windows98;
					else if (Environment.OSVersion.Version.Minor == 90)
						return WindowsMainVersion.WindowsMe;
					else
						return WindowsMainVersion.Unknown;
				case 5:
					if (Environment.OSVersion.Version.Minor == 0)
						return WindowsMainVersion.Windows2000;
					else if (Environment.OSVersion.Version.Minor == 1)
						return WindowsMainVersion.WindowsXP;
					else if (Environment.OSVersion.Version.Minor == 2)
						return WindowsMainVersion.WindowsServer2003;
					else
						return WindowsMainVersion.Unknown;
				default:
					return WindowsMainVersion.Unknown;
			}
		}

	}
}
