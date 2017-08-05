using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Cryptography;
using Addison_Wesley.Codebook.DateAndTime;
using Addison_Wesley.Codebook.Security;

namespace SymetricEncryptorTest
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			HighResStopClock sc = new HighResStopClock();
			string logFileName = Path.Combine(Application.StartupPath, "Log.txt");
			StreamWriter sw = new StreamWriter(logFileName, false, Encoding.Default);
			PerformanceCounter pc = new PerformanceCounter("Process", "Working Set");
			pc.InstanceName = Process.GetCurrentProcess().ProcessName;

			Console.WriteLine("Start-Speicherauslastung: {0:0} KB\r\n", pc.NextValue() / 1024);
			sw.WriteLine("Start-Speicherauslastung: {0:0} KB\r\n", pc.NextValue() / 1024);

			FileInfo fi = new FileInfo(
				Path.Combine(Application.StartupPath, "Hitchhiker.txt"));
			Console.WriteLine("Datei-Größe: {0} Byte\r\n", fi.Length);
			sw.WriteLine("Datei-Größe: {0} Byte\r\n", fi.Length);

			double sumSeconds1 = 0;
			double sumSeconds2 = 0;

			int testCycles = 10000;

			for (int i = 0; i < testCycles; i++)
			{
				SymmetricEncryptor se = null;
				try
				{
					se = new SymmetricEncryptor(SymmetricEncryptAlgorithm.Rijndael);
					se.Key = "abcdefgh12345678äöüÄÖÜßßø£Ø×*áíó";
					se.IV = "46¶0?-B,-7,kerkh";
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Beenden mit Return");
					Console.ReadLine();
					return;
				}

				// Eine Datei verschlüsseln 
				FileStream sourceStream = new FileStream(
					Path.Combine(Application.StartupPath, "Hitchhiker.txt"),
					FileMode.Open, FileAccess.Read);
				FileStream destStream = new FileStream(
					Path.Combine(Application.StartupPath, "Hitchhiker_Encrypted.txt"), 
					FileMode.Create, FileAccess.Write);
				
				sc.Start();
				se.Encrypt(sourceStream, destStream);
				double seconds1 = sc.Stop();
				sumSeconds1 += seconds1;
				
				sourceStream.Close();
				destStream.Close();

				// Eine Datei entschlüsseln 
				sourceStream = new FileStream(
					Path.Combine(Application.StartupPath, "Hitchhiker_Encrypted.txt"),
					FileMode.Open, FileAccess.Read);
				destStream = new FileStream(
					Path.Combine(Application.StartupPath, "Hitchhiker_Decrypted.txt"), 
					FileMode.Create, FileAccess.Write);
				
				sc.Start();
				se.Encrypt(sourceStream, destStream);
				double seconds2 = sc.Stop();
				sumSeconds2 += seconds2;
				
				sourceStream.Close();
				destStream.Close();

				sw.WriteLine("Durchlauf {0}", i);
				sw.WriteLine("Verschlüsseln: {0}", seconds1);
				sw.WriteLine("Entschlüsseln: {0}", seconds2);
				sw.WriteLine("Speicherauslastung: {0:0} KB", pc.NextValue() / 1024);
				sw.WriteLine();

				Console.WriteLine("Durchlauf {0}", i);
				Console.WriteLine("Verschlüsseln: {0}", seconds1);
				Console.WriteLine("Entschlüsseln: {0}", seconds2);
				Console.WriteLine("Speicherauslastung: {0:0} KB", pc.NextValue() / 1024);
				Console.WriteLine();

				System.GC.WaitForPendingFinalizers();
			}
			Console.WriteLine("\r\nDurchschnittliche Zeit für das Verschlüsseln: {0}", sumSeconds1 / testCycles);
			sw.WriteLine("\r\nDurchschnittliche Zeit für das Verschlüsseln: {0}", sumSeconds1 / testCycles);
			Console.WriteLine("\r\nDurchschnittliche Zeit für das Entschlüsseln: {0}", sumSeconds2 / testCycles);
			sw.WriteLine("\r\nDurchschnittliche Zeit für das Entschlüsseln: {0}", sumSeconds2 / testCycles);
			
			Console.WriteLine("\r\nEnd-Speicherauslastung: {0:0} KB", pc.NextValue() / 1024);
			sw.WriteLine("\r\nEnd-Speicherauslastung: {0:0} KB", pc.NextValue() / 1024);

			sw.Close();

			Process.Start("notepad.exe", logFileName);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
