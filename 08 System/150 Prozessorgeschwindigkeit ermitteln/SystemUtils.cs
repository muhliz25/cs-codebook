using System;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Methode zur Ermittlung der Prozessorgeschwindigkeit */
		public static uint GetProcessorSpeed()
		{
			// Win32_Processor-Instanz für den ersten Prozessor erzeugen und die
			// Geschwindigkeit abfragen
			ManagementObject mo = new ManagementObject(
				"Win32_Processor.DeviceID='CPU0'");
			uint currentClockSpeed = 0;
			try
			{
				currentClockSpeed = (uint)(mo["CurrentClockSpeed"]);
			}
			catch {}

			// Speicher des WMI-Objekts freigeben um den Arbeitsspeicher
			// möglichst schnell zu entlasten
			mo.Dispose();

			return currentClockSpeed;
		}
	}
}
