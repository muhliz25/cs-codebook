using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Addison_Wesley.Codebook.Serialization
{
	public class Serializer
	{
		/* Methode zum Serialisieren eines Font-Objekts in einen String */
		public static string SerializeFont(Font font)
		{
			// Das Objekt in einen MemoryStream serialisieren
			BinaryFormatter sf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			sf.Serialize(ms, font);

			// Den MemoryStream in ein Byte-Array schreiben und dieses in einen
			// Base64-String umgewandelt zur�ckgeben
			ms.Seek(0, SeekOrigin.Begin);
			byte[] buffer = new byte[ms.Length];
			ms.Read(buffer, 0, buffer.Length);
			ms.Close();
			return Convert.ToBase64String(buffer, 0, buffer.Length);
		}

		/* Methode zum Deserialisieren eines Strings in ein Font-Objekt */
		public static Font DeserializeFont(string fontString)
		{
			// Den �bergebenen Base64-String �ber ein Byte-Array in einen
			// MemoryStream schreiben
			byte[] buffer = Convert.FromBase64String(fontString);
			MemoryStream ms = new MemoryStream(buffer);

			// Den Stream deserialisieren und ein daraus erzeugtes Font-Objekt
			// zur�ckgeben
			BinaryFormatter sf = new BinaryFormatter();
			Font font = (Font)sf.Deserialize(ms);
			ms.Close();
			return font;
		}
	}
}