using System;
using System.Management;

namespace WMI_verwenden
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
		
			// WMI-Objekt für das Laufwerk C: erzeugen
			ManagementObject mo = new ManagementObject(
				"Win32_LogicalDisk.DeviceId='C:'");

			// Einige Eigenschaften auslesen
			Console.WriteLine("Eigenschaften von C:\\");

			uint availability = 0;
			try 
			{
				availability = (uint)mo["Availability"];
			} 
			catch {}

			string description = null;
			try 
			{
				description = (string)mo["Description"];
			} 
			catch {}

			uint mediaType = 0;
			try 
			{
				mediaType = (uint)mo["MediaType"];
			} 
			catch {}

			ulong size = 0;
			try 
			{
				size = (ulong)mo["Size"];
			} 
			catch {}

			Console.WriteLine("Verfügbarkeit: {0}", availability);
			Console.WriteLine("Beschreibung: {0}", description);
			Console.WriteLine("Medientyp: {0}", mediaType);
			Console.WriteLine("Größe: {0}", size);

			Console.WriteLine("Taste ...");
			Console.ReadLine();
		}
	}
}
