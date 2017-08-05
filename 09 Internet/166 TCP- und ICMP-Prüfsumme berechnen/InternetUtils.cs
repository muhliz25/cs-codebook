using System;

namespace Addison_Wesley.Codebook.Internet
{
	public class InternetUtils
	{
		/* Methode zur Berechnung der Prüfsumme eines TCP-Datagramms */
		public static ushort GetTCPCheckSum(byte[] tcpData)
		{
			// Wenn das byte-Array am Ende kein ganzes Wort mehr ergibt,
			// muss ein 0-Byte angehängt werden
			byte[] buffer;
			if ((tcpData.Length % 2) > 0)
			{
				buffer = new byte[tcpData.Length + 1];
				tcpData.CopyTo(buffer, 0);
				buffer[buffer.Length - 1] = 0;
			}
			else
			{
				buffer = new byte[tcpData.Length];
				tcpData.CopyTo(buffer, 0);
			}

			// Die einzelnen Wörter addieren
			int checkSum = 0;
			for (int i = 0; i < buffer.Length; i += 2)
			{
				byte lowByte = buffer[i+1];
				byte highByte = buffer[i];
				ushort wordValue = highByte;
				wordValue = (ushort)((wordValue << 8) + lowByte);
				checkSum += wordValue;
			}

			// Nur die niedrigen 16 Bits addiert mit den 
			// hohen 16 Bits auslesen
			checkSum = (checkSum >> 16) + (checkSum & 0xFFFF);
			checkSum += (checkSum >> 16);

			// Einerkomplement bilden
			return (ushort)(~checkSum);
		}
	}
}
