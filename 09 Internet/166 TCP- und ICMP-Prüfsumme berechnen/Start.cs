using System;
using Addison_Wesley.Codebook.Internet;

namespace IP_Pr�fsumme
{
	class Start
	{
		private static string DualNumber(int number)
		{
			string result = "";
			for (int i = 0; i < 32; i++)
			{
				result = (number & 1).ToString() + result;
				number = (byte)(number >> 1);
			}
			return result;
		}
		

		[STAThread]
		static void Main(string[] args)
		{
			// Byte-Array f�r das die Pr�fsumme berechnet werden soll
			byte[] buffer = {8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

			// IP-Pr�fsumme berechnen
			ushort checkSum = InternetUtils.GetTCPCheckSum(buffer);

			// Low- und High-Byte extrahieren 
			byte lowByte = (byte)(checkSum & 0xFF);
			byte highByte = (byte)(checkSum >> 8);

			// Pr�fsumme als Hex-Werte ausgeben
			Console.WriteLine("{0:X} {1:X} ", highByte, lowByte);

			// Pr�fsumme in die Daten schreiben
			buffer[2] = highByte;
			buffer[3] = lowByte;

			// Pr�fsumme mit diesen Daten noch einmal berechnen (muss 0 ergeben)
			checkSum = InternetUtils.GetTCPCheckSum(buffer);
			lowByte = (byte)(checkSum & 0xFF);
			highByte = (byte)(checkSum >> 8);
			Console.WriteLine("{0:X} {1:X} ", highByte, lowByte);

		
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
