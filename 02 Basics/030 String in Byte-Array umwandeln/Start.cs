using System;
using System.Text;

namespace String_in_Byte_Array
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			string source = "abc-äöü";
			
			// String in byte-Array in der ISO-8859-1-Codierung umwandeln
			byte[] result = System.Text.Encoding.GetEncoding(
				"ISO-8859-1").GetBytes(source);

			// Byte-Array testweise ausgeben
			for (int i = 0; i < result.Length; i++)
				Console.WriteLine("{0}: {1} ", result[i], (char)result[i]);

			// String in byte-Array in der ASCII-Codierung umwandeln
			Console.WriteLine();
			source = "abc-äöü";
			Console.WriteLine("Originaler String: {0}", source);
			result = System.Text.Encoding.ASCII.GetBytes(source);
			
			for (int i = 0; i < result.Length; i++)
				Console.WriteLine("{0}: {1} ", result[i], (char)result[i]);

			// String zurückkonvertieren	
			source = System.Text.Encoding.ASCII.GetString(result);
			Console.WriteLine("Zurückkonvertierter String: {0}", source);

			// String mit kyrillischen Zeichen in ein byte-Array 
			// in der Unicode-Codierung umwandeln
			Console.WriteLine();
			source = "abc-äöü \u0400\u0410";
			result = System.Text.Encoding.Unicode.GetBytes(source);
			for (int i = 0; i < result.Length; i++)
				Console.WriteLine("{0}: {1} ", result[i], (char)result[i]);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
