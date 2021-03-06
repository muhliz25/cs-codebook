using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace Addison_Wesley.Codebook.Objects
{
	public class Serializer
	{
		/* Methode zum Serialisieren eines Objekts in eine XML-Datei */
		public static void SerializeToXmlFile(object obj, string fileName, Encoding encoding)
		{
			StreamWriter streamWriter = null;
			try
			{
				// XmlSerializer f�r den Typ des Objekts erzeugen
				XmlSerializer serializer = new XmlSerializer(obj.GetType());

				// Objekt �ber ein StreamWriter-Objekt serialisieren 
				streamWriter = new StreamWriter(fileName, false, encoding);
				serializer.Serialize(streamWriter, obj);
			}
			finally 
			{
				if (streamWriter != null)
					streamWriter.Close();
			}
		}

		/* Methode zum Serialisieren eines Objekts in einen XML-String */
		public static string SerializeToXmlString(object obj, Encoding encoding)
		{
			MemoryStream memoryStream = null;
			StreamWriter streamWriter = null;
			try
			{
				// XmlSerializer f�r den Typ des Objekts erzeugen
				XmlSerializer serializer = new XmlSerializer(obj.GetType());

				// Objekt �ber ein MemoryStream-Objekt serialisieren
				memoryStream = new MemoryStream();
				streamWriter = new StreamWriter(memoryStream, encoding);
				serializer.Serialize(streamWriter, obj);

				// MemoryStream in einen String umwandeln und diesen zur�ckgeben
				byte[] buffer = memoryStream.ToArray();
				return encoding.GetString(buffer, 0, buffer.Length);
			}
			finally 
			{
				if (memoryStream != null)
					memoryStream.Close();
				if (streamWriter != null)
					streamWriter.Close();
			}
		}

		/* Methode zum Deserialisieren eines Objekts aus einer XML-Datei */
		public static object DeserializeFromXmlFile(string fileName, Type objectType, Encoding encoding)
		{
			StreamReader streamReader = null;
			try
			{
				// XmlSerializer f�r den Typ des Objekts erzeugen
				XmlSerializer serializer = new XmlSerializer(objectType);

				// Objekt �ber ein StreamReader-Objekt serialisieren
				streamReader = new StreamReader(fileName, encoding);
				return serializer.Deserialize(streamReader);
			}
			finally 
			{
				if (streamReader != null)
					streamReader.Close();
			}

		}

		/* Methode zum Deserialisieren eines Objekts aus einem XML-String */
		public static object DeserializeFromXmlString(string xmlString, Type objectType, Encoding encoding)
		{
			MemoryStream memoryStream = null;
			try
			{
				// XmlSerializer f�r den Typ des Objekts erzeugen
				XmlSerializer serializer = new XmlSerializer(objectType);

				// Objekt �ber ein MemoryStream-Objekt deserialisieren
				memoryStream = new MemoryStream(encoding.GetBytes(xmlString));
				return serializer.Deserialize(memoryStream);
			}
			finally 
			{
				if (memoryStream != null)
					memoryStream.Close();
			}
		}
	}
}
