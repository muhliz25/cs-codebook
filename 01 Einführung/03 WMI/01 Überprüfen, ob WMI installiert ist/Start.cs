using System;
using Microsoft.Win32;


namespace Überprüfen__ob_WMI_installiert_ist
{
	class Start
	{
		public static bool WmiInstalled()
		{
			Microsoft.Win32.RegistryKey regKey = 
				Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
				@"Software\Microsoft\Wbem");
			return regKey != null;
		}
		
		[STAThread]
		static void Main(string[] args)
		{
			if (WmiInstalled())
				Console.WriteLine("WMI ist installiert");
			else
				Console.WriteLine("WMI ist nicht installiert");

			

			
			
			
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
