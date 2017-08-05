using System;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Basics
{
	public class BasicUtils
	{
		/* Deklaration der API-Funktion MessageBeep und benötigter Konstanten */
		[DllImport("User32.dll")]
		private static extern int MessageBeep(uint uType); 

		private const uint MB_SIMPLE_BEEP = 1;
		private const uint MB_ICONHAND = 0x00000010;
		private const uint MB_ICONQUESTION = 0x00000020;
		private const uint MB_ICONEXCLAMATION = 0x00000030;
		private const uint MB_ICONASTERISK = 0x00000040;

		/* Aufzählung für die Art des Piepstons */
		public enum BeepType: uint
		{
			Simple = MB_SIMPLE_BEEP,
			Error = MB_ICONHAND,
			Exclamation = MB_ICONEXCLAMATION,
			Question = MB_ICONQUESTION,
			Information = MB_ICONASTERISK
		}

		/* Methode zur Ausgabe eines Piepstons */ 
		public static bool MessageBeep(BeepType beepType)
		{
			return (MessageBeep((uint)beepType) != 0);
		}
	}
}
