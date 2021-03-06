using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace Addison_Wesley.Codebook.Internet
{
	public class InternetUtils
	{
		/* Methode zur Berechnung der Checksumme eines TCP-
		 * oder ICMP-Datagramms */
		public static ushort GetTCPCheckSum(byte[] tcpData)
		{
			// Wenn das byte-Array am Ende kein ganzes Wort mehr ergibt,
			// muss ein 0-Byte angehangen werden
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

			// Die einzelnen W�rter addieren
			int checkSum = 0;
			for (int i = 0; i < buffer.Length; i += 2)
			{
				byte lowByte = buffer[i+1];
				byte highByte = buffer[i];
				ushort wordValue = highByte;
				wordValue = (ushort)((wordValue << 8) + lowByte);
				checkSum += wordValue;
			}

			// Nur die niedrigen 16 Bits, addiert mit den 
			// hohen 16 Bits auslesen
			checkSum = (checkSum >> 16) + (checkSum & 0xFFFF);
			checkSum += (checkSum >> 16);

			// Einerkomplement bilden
			return (ushort)(~checkSum);
		}
		
		/* Aufz�hlung f�r die R�ckgabe von Ping */
		public enum PingResult
		{
			OK,
			Timeout,
			ChecksumError
		}

		/* Methode zum Pingen */
		public static PingResult Ping(string address, int timeout)
		{
			// IP-Adresse des Host ermitteln
			IPHostEntry ipHostEntry = Dns.Resolve(address);
			IPAddress ipAddress = ipHostEntry.AddressList[0];

			// IPEndPoint-Instanz f�r den Port 7 der angegebenen Adresse erzeugen
			IPEndPoint epHost = new IPEndPoint(ipAddress, 7);

			// Socket f�r das Senden von ICMP-Daten erzeugen
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw,
				ProtocolType.Icmp);

			// Byte-Array f�r die Sende-Daten erzeugen und initialisieren
			byte[] sendBuffer = {8, 0, 0xF7, 0xFF, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
									0, 0, 0};

			// ECHO senden
			int sent = socket.SendTo(sendBuffer, sendBuffer.Length, SocketFlags.None,
				epHost);

			// �ber Socket.Select pr�fen, ob im gegebenen Timeout Daten zum Lesen
			// bereitstehen
			ArrayList checkReadSockets = new ArrayList();
			checkReadSockets.Add(socket);
			Socket.Select(checkReadSockets, null, null, timeout * 1000);
         
			// Lesen der Daten 
			byte[] receiveBuffer = new byte[200];
			int receivedBytes = 0;
			if (checkReadSockets.Count > 0)
			{
				// Wenn das Socket nicht aus der ArrayList gel�scht wurde,
				// sind Daten zum Lesen verf�gbar: Die ECHO-Antwort empfangen
				receivedBytes = socket.Receive(receiveBuffer, receiveBuffer.Length,
					SocketFlags.None);

				// Pr�fsumme vergleichen (muss bei einer erneuten Berechnung 0 
				// ergeben)
				if (GetTCPCheckSum(receiveBuffer) == 0)
					return PingResult.OK;
				else
					return PingResult.ChecksumError;
			}
			else
				return PingResult.Timeout;
		}
	}
}
