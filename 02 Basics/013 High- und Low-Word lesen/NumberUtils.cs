using System;

namespace Addison_Wesley.Codebook.Basics
{
	public class NumberUtils
	{
		/* Methode zum Extrahieren des High-Word aus einem uint-Wert */
		public static ushort GetHighWord(uint value)
		{
			return (ushort)(value >> 16);
		}

		/* Methode zum Extrahieren des Low-Word aus einem uint-Wert */
		public static ushort GetLowWord(uint value)
		{
			return (ushort)(value & 0xFFFF); 
		}

		/* Methode zum Extrahieren des High-Word aus einem int-Wert */
		public static ushort GetHighWord(int value)
		{
			return (ushort)(value >> 16);
		}

		/* Methode zum Extrahieren des Low-Word aus einem int-Wert */
		public static ushort GetLowWord(int value)
		{
			return (ushort)(value & 0xFFFF); 
		}
	}
}
