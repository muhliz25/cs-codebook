using System;
using System.Drawing;
using Addison_Wesley.Codebook.Serialization;

namespace Font_Objekte_serialisieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Font-Objekt erzeugen und serialisieren
			Font font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
			string fontString = Serializer.SerializeFont(font);
			Console.WriteLine("Serialisierter Font:");
			Console.WriteLine(fontString);
			Console.WriteLine();

			// String deserialisieren
			font = Serializer.DeserializeFont(fontString);
 
			Console.WriteLine("Deserialisierter Font:");
			Console.WriteLine(font.ToString());

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
