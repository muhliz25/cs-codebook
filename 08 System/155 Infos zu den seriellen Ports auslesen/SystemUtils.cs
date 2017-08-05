using System;
using System.Collections;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Klasse für die Fähigkeiten eines seriellen Ports */
		public class SerialPortCapabilities
		{
			public bool   Unknown;
			public bool CompatibleXTAT;
			public bool Compatible16450;
			public bool Compatible16550;
			public bool Compatible16550A;
			public bool Compatible8251;
			public bool Compatible8251FIFO;
			public bool Other;
		}

		/* Aufzählung für den Status eines seriellen Ports */
		public enum SerialPortStatusInfo: ushort
		{
			NotDefined = 0,
			Other = 1,
			Unknown = 2,
			Enabled = 3,
			Diabled = 4,
			NotApplicable = 5
		}

		/* Klasse mit den wichtigsten Eigenschaften eines seriellen Ports */
		public class SerialPort
		{
			public string DeviceId;
			public uint MaxBaudRate;
			public bool Supports16BitMode;
			public bool SupportsDTRDSR;
			public bool SupportsElapsedTimeouts;
			public bool SupportsIntTimeouts;
			public bool SupportsParityCheck;
			public bool SupportsRLSD;
			public bool SupportsRTSCTS;
			public bool SupportsSpecialCharacters;
			public bool SupportsXOnXOff;
			public bool SupportsXOnXOffSet;
			public SerialPortCapabilities Capabilities =
				new SerialPortCapabilities();
			public SerialPortStatusInfo StatusInfo;
		}

		/* Auflistung für SerialPort-Objekte */
		public class SerialPorts: CollectionBase
		{
			/* Implementierung des Indizierers */
			public SerialPort this[int index]
			{
				get {return (SerialPort)base.InnerList[index];}
				set {base.InnerList[index] = value;}
			}

			/* Implementierung der Add-Methode */
			public void Add(SerialPort port)
			{
				base.InnerList.Add(port);
			}
		}

		/* Methode zum Auflisten der seriellen Ports des Systems */
		public static SerialPorts EnumSerialPorts()
		{
			// SerialPorts-Instanz für die Rückgabe erzeugen
			SerialPorts ports = new SerialPorts();

			// WMI-Auflistung der Objekte der Win32_SerialPort erzeugen
			ManagementClass mc = new ManagementClass("Win32_SerialPort"); 
			ManagementObjectCollection moc = mc.GetInstances();

			// Die einzelnen Objekte durchgehen
			foreach (ManagementBaseObject mbo in moc)
			{
				// SerialPort-Instanz erzeugen und initialisieren
				SerialPort port = new SerialPort();
				try{port.DeviceId = (string)mbo["DeviceId"];}
				catch {}
				try{port.MaxBaudRate = (uint)mbo["MaxBaudRate"];}
				catch {}
				try{port.Supports16BitMode = (bool)mbo["Supports16BitMode"];}
				catch {}
				try{port.SupportsDTRDSR = (bool)mbo["SupportsDTRDSR"];}
				catch {}
				try
				{
					port.SupportsElapsedTimeouts = 
						(bool)mbo["SupportsElapsedTimeouts"];}
				catch {}
				try{port.SupportsIntTimeouts = (bool)mbo["SupportsIntTimeouts"];}
				catch {}
				try{port.SupportsParityCheck = (bool)mbo["SupportsParityCheck"];}
				catch {}
				try{port.SupportsRLSD = (bool)mbo["SupportsRLSD"];}
				catch {}
				try{port.SupportsRTSCTS = (bool)mbo["SupportsRTSCTS"];}
				catch {}
				try
				{
					port.SupportsSpecialCharacters = 
						(bool)mbo["SupportsSpecialCharacters"];}
				catch {}
				try{port.SupportsXOnXOff = (bool)mbo["SupportsXOnXOff"];}
				catch {}
				try{port.SupportsXOnXOffSet = (bool)mbo["SupportsXOnXOffSet"];}
				catch {}
				try{port.StatusInfo = (SerialPortStatusInfo)mbo["StatusInfo"];}
				catch {}
				// Fähigkeiten aus dem Capabilities-Array auslesen
				try
				{
					uint[] caps = (uint[])mbo["Capabilities"];
					for (int i = 0; i < caps.Length; i++)
					{
						switch (caps[i])
						{
							case 1:    // Other 
								port.Capabilities.Other = true;
								break;
							case 2:    // Unknown 
								port.Capabilities.Unknown = true;
								break;
							case 3:    // XT/AT Compatible 
								port.Capabilities.CompatibleXTAT = true;
								break;
							case 4:    // 16450 Compatible 
								port.Capabilities.Compatible16450 = true;
								break;
							case 5:    // 16550 Compatible 
								port.Capabilities.Compatible16550 = true;
								break;
							case 6:    // 16550A Compatible 
								port.Capabilities.Compatible16550A = true;
								break;
							case 160:  // 8251 Compatible 
								port.Capabilities.Compatible8251 = true;
								break;
							case 161:  // 8251FIFO Compatible 
								port.Capabilities.Compatible8251FIFO = true;
								break;
						}
					}
				}
				catch {}

				// SerialPort-Instanz an die Auflistung anfügen
				ports.Add(port);
			}

			// Speicher des WMI-Objekts freigeben um den Arbeitsspeicher möglichst
			// schnell zu entlasten
			moc.Dispose();
			mc.Dispose();

			// Ergebnis zurückgeben
			return ports;
		}
	}
}
