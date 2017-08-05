using System;
using System.Collections;
using Addison_Wesley.Codebook.System;

namespace Seriellport_Infos
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Auflisten der seriellen Ports des Systems */
			SystemUtils.SerialPorts ports = SystemUtils.EnumSerialPorts();

			foreach(SystemUtils.SerialPort port in ports)
			{
				Console.WriteLine("DeviceId: {0}", port.DeviceId);
				Console.WriteLine("MaxBaudRate: {0}", port.MaxBaudRate);
				Console.WriteLine("Supports16BitMode: {0}", port.Supports16BitMode);
				Console.WriteLine("SupportsDTRDSR: {0}", port.SupportsDTRDSR);
				Console.WriteLine("SupportsElapsedTimeouts: {0}", port.SupportsElapsedTimeouts);
				Console.WriteLine("SupportsIntTimeouts: {0}", port.SupportsIntTimeouts);
				Console.WriteLine("SupportsParityCheck: {0}", port.SupportsParityCheck);
				Console.WriteLine("SupportsRLSD: {0}", port.SupportsRLSD);
				Console.WriteLine("SupportsRTSCTS: {0}", port.SupportsRTSCTS);
				Console.WriteLine("SupportsSpecialCharacters: {0}", 
					port.SupportsSpecialCharacters);
				Console.WriteLine("SupportsXOnXOff: {0}", port.SupportsXOnXOff);
				Console.WriteLine("SupportsXOnXOffSet: {0}", port.SupportsXOnXOffSet);
				Console.WriteLine("StatusInfo: {0}", port.StatusInfo);
				Console.WriteLine("Capabilities:");
				Console.WriteLine("Unknown: {0}", port.Capabilities.Unknown);
				Console.WriteLine("XTAT Compatible: {0}", port.Capabilities.CompatibleXTAT);
				Console.WriteLine("16450 Compatible: {0}", port.Capabilities.Compatible16450);
				Console.WriteLine("16550 Compatible: {0}", port.Capabilities.Compatible16550);
				Console.WriteLine("16550A Compatible: {0}", port.Capabilities.Compatible16550A);
				Console.WriteLine("8251 Compatible: {0}", port.Capabilities.Compatible8251);
				Console.WriteLine("8251FIFO Compatible: {0}",
					port.Capabilities.Compatible8251FIFO);
				Console.WriteLine("Other: {0}", port.Capabilities.Other);
				Console.WriteLine();
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
