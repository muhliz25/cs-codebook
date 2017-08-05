using System
;
using System.Text;

namespace Byte_Array_in_String
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			byte[] unicodeCharCodes = {0x41, 0, 0x42, 0, 0x20, 0, 0xE4, 0, 0xF6, 0};

			// Byte-Array in String umwandeln
			string result = Encoding.Unicode.GetString(unicodeCharCodes);
			// Test mit ISO-8859-1
			// string result = Encoding.GetEncoding("ISO-8859-1").GetString(unicodeCharCodes);
			// byte[] test = Encoding.GetEncoding("ISO-8859-1").GetBytes(result);
			// for (int i = 0; i < test.Length; i++)
			//	Console.WriteLine("{0}: {1} ", test[i], (char)test[i]);

			Console.WriteLine(result);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
