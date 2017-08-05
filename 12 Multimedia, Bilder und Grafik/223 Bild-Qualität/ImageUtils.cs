using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Specialized;

namespace Addison_Wesley.Codebook.Images
{
	public class ImageUtils
	{
		/* Methode zum definierten Speichern einer JPEG-Datei */
		public static void SaveAsJpeg(Bitmap bitmap, string fileName, byte quality)
		{
			// Das in GDI+ enthaltetne ImageCodecInfo-Objekt für JPEG-Bilder
			// ermitteln 
			ImageCodecInfo imageCodec = null;
			ImageCodecInfo[] imageCodecs = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageCodecs.Length; i++)
			{
				if (imageCodecs[i].MimeType=="image/jpeg") 
				{
					imageCodec = imageCodecs[i];
					break;
				}
			}

			if (imageCodec == null)
				throw new Exception("Das ImageCodecInfo-Objekt für den Mimetyp image/jpeg " +
					"kann nicht lokalisiert werden");

			// Den wichtigsten der für JPEG unterstützten Encoding-Parameter definieren
			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality); 
			
			// Bitmap speichern
			bitmap.Save(fileName, imageCodec, encoderParams);
		}


		/* Hilfs-Methode zur Ermittlung der für ein Bildformat unterstützten Encoder */
		public static StringCollection GetAvailableEncoderNames(string mimeType)
		{
			StringCollection result = new StringCollection();

			// CodecInfo des übergebenen MIME-Typs ermitteln
			ImageCodecInfo imageCodec = null;
			ImageCodecInfo[] imageCodecs = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageCodecs.Length; i++)
			{
				if (imageCodecs[i].MimeType == mimeType) 
				{
					imageCodec = imageCodecs[i];
					break;
				}
			}

			if (imageCodec != null)
			{
				// Die unterstützten Encoder-Parameter durchgehen
				EncoderParameters encoderParams = null;
				Bitmap dummy = new Bitmap(1, 1);
				try
				{
					encoderParams = dummy.GetEncoderParameterList(imageCodec.Clsid);
					for (int i = 0; i < encoderParams.Param.Length; i++)
					{
						// Die GUID des Encoders auslesen (leider nicht anders möglich ...)
						string encoderGuid = encoderParams.Param[i].Encoder.Guid.ToString();  

						// Die GUID mit den Default-Encodern vergleichen
						string encoderName = null;
						if (encoderGuid == Encoder.ChrominanceTable.Guid.ToString())
							encoderName = "ChrominanceTable";
						else if (encoderGuid == Encoder.ColorDepth.Guid.ToString())
							encoderName = "ColorDepth";
						else if (encoderGuid == Encoder.Compression.Guid.ToString())
							encoderName = "Compression";
						else if (encoderGuid == Encoder.LuminanceTable.Guid.ToString())
							encoderName = "LuminanceTable";
						else if (encoderGuid == Encoder.Quality.Guid.ToString())
							encoderName = "Quality";
						else if (encoderGuid == Encoder.RenderMethod.Guid.ToString())
							encoderName = "RenderMethod";
						else if (encoderGuid == Encoder.SaveFlag.Guid.ToString())
							encoderName = "SaveFlag";
						else if (encoderGuid == Encoder.ScanMethod.Guid.ToString())
							encoderName = "ScanMethod";
						else if (encoderGuid == Encoder.Transformation.Guid.ToString())
							encoderName = "Transformation";
						else if (encoderGuid == Encoder.Version.Guid.ToString())
							encoderName = "Version";
						else
							encoderName = "Unknown GUID encoderGuid";
						
						result.Add(encoderName);
					}
				}
				catch {}
			}

			return result;
		}

		/* Hilfs-Methode zur Ermittlung der verfügbaren MIME-Typen */
		public static StringCollection GetAvailableMimeTypes()
		{
			StringCollection result = new StringCollection();

			// CodecInfos auslesen
			ImageCodecInfo[] imageCodecs = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageCodecs.Length; i++)
			{
				result.Add(imageCodecs[i].MimeType);
			}

			return result;
		}

	}
}
