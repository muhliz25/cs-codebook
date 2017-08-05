using System;
using System.Collections;
using Addison_Wesley.Codebook.System;

namespace Parallelport_Infos
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Auflisten der parallelen Ports des Systems */
			SystemUtils.ParallelPorts ports = SystemUtils.EnumParallelPorts();

			foreach(SystemUtils.ParallelPort port in ports)
			{
				Console.WriteLine("DeviceId: {0}", port.DeviceId);
				Console.WriteLine("DMASupport: {0}", port.DMASupport);
				Console.WriteLine("StatusInfo: {0}", port.StatusInfo);
				Console.WriteLine("Capabilities:");
				Console.WriteLine("ECP: {0}", port.Capabilities.ECP);
				Console.WriteLine("EPP: {0}", port.Capabilities.EPP);
				Console.WriteLine("PC98: {0}", port.Capabilities.PC98);
				Console.WriteLine("PC98Hireso: {0}", port.Capabilities.PC98Hireso);
				Console.WriteLine("PCH98: {0}", port.Capabilities.PCH98);
				Console.WriteLine("PS2Compatible: {0}", port.Capabilities.PS2Compatible);
				Console.WriteLine("Other: {0}", port.Capabilities.Other);
				Console.WriteLine();
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
