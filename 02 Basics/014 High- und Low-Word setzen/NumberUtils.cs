using System;

namespace Addison_Wesley.Codebook.Basics
{
	public class NumberUtils
	{
		/* Methode zum Setzen des High-Word in einer uint-Variablen */
		public static uint SetHighWord(uint value, ushort highWord)
		{
			return (value & 0xFFFF) + (uint)(highWord << 16);
		}

		/* Methode zum Setzen des Low-Word in einer uint-Variablen */
		public static uint SetLowWord(uint value, ushort lowWord)
		{
			return (value & 0xFFFF0000) + lowWord;
		}

		/* Methode zum Setzen des High-Word in einer int-Variablen */
		public static int SetHighWord(int value, ushort highWord)
		{
			return (value & 0xFFFF) + (int)(highWord << 16);
		}

		/* Methode zum Setzen des Low-Word in einer uint-Variablen */
		public static int SetLowWord(int value, ushort lowWord)
		{
			return (int)(value & 0xFFFF0000) + lowWord;
		}
	}
}