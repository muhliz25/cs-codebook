using System;
using System.Collections;
using System.Management;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Klasse f�r die F�higkeiten eines parallelen Ports */
		public class ParallellPortCapabilities
		{
			public bool XTATCompatible;
			public bool PS2Compatible;
			public bool ECP;
			public bool EPP;
			public bool PC98;
			public bool PC98Hireso;
			public bool PCH98;
			public bool Other;
		}

		/* Aufz�hlung f�r den Status eines parallelen Ports */
		public enum ParallelPortStatusInfo: ushort
		{
			NotDefined = 0,
			Other = 1,
			Unknown = 2,
			Enabled = 3,
			Diabled = 4,
			NotApplicable = 5
		}

		/* Klasse mit den wichtigsten Eigenschaften eines parallelen Ports */
		public class ParallelPort
		{
			public string DeviceId;
			public ParallellPortCapabilities Capabilities =
				new ParallellPortCapabilities();
			public bool DMASupport;
			public ParallelPortStatusInfo StatusInfo;
		}

		/* Auflistung f�r ParallelPort-Instanzen */
		public class ParallelPorts: CollectionBase
		{
			/* Implementierung des Indizierers */
			public ParallelPort this[int index]
			{
				get {return (ParallelPort)base.InnerList[index];}
				set {base.InnerList[index] = value;}
			}

			/* Implementierung der Add-Methode */
			public void Add(ParallelPort port)
			{
				base.InnerList.Add(port);
			}
		}

		/* Methode zum Auflisten der parallelen Ports des Systems */
		public static ParallelPorts EnumParallelPorts()
		{
			// ParallelPorts-Instanz f�r die R�ckgabe erzeugen
			ParallelPorts ports = new ParallelPorts();

			// WMI-Auflistung der Objekte der Win32_ParallelPort-Klasse erzeugen
			ManagementClass mc = new ManagementClass("Win32_ParallelPort"); 
			ManagementObjectCollection moc = mc.GetInstances();

			// Die einzelnen Objekte durchgehen
			foreach (ManagementBaseObject mbo in moc)
			{
				// ParallelPort-Instanz erzeugen und initialisieren
				ParallelPort port = new ParallelPort();
				try{port.DeviceId = (string)mbo["DeviceId"];}
				catch {}
				try{port.DMASupport  = (bool)mbo["DMASupport"];}
				catch {}
				try
				{port.StatusInfo = (ParallelPortStatusInfo)mbo["StatusInfo"];}
				catch {}

				// F�higkeiten aus dem Capabilities-Array auslesen
				try
				{
					uint[] caps = (uint[])mbo["Capabilities"];
					for (int i = 0; i < caps.Length; i++)
					{
						switch (caps[i])
						{
							case 2:  // Other 
								port.Capabilities.Other = true;
								break;
							case 3:  // XT/AT Compatible 
								port.Capabilities.XTATCompatible = true;
								break;
							case 4:  //  PS/2 Compatible 
								port.Capabilities.PS2Compatible = true;
								break;
							case 5:  //  ECP 
								port.Capabilities.ECP = true;
								break;
							case 6:  //  EPP 
								port.Capabilities.EPP = true;
								break;
							case 7:  //  PC-98 
								port.Capabilities.PC98 = true;
								break;
							case 8:  //  PC-98-Hireso 
								port.Capabilities.PC98Hireso = true;
								break;
							case 9:  //  PC-H98 
								port.Capabilities.PCH98 = true;
								break;
						}
					}
				}
				catch {}

				// ParallelPort-Instanz an die Auflistung anf�gen
				ports.Add(port);
			}

			// Speicher der WMI-Objekte freigeben um den Arbeitsspeicher m�glichst
			// schnell zu entlasten
			moc.Dispose();
			mc.Dispose();

			// Ergebnis zur�ckgeben
			return ports;
		}
	}
}
