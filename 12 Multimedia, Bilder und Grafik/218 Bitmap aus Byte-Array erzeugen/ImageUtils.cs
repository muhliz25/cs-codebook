using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Addison_Wesley.Codebook.Multimedia
{
	public class ImageUtils
	{
		/* Methode zum Umwandeln eines Image-Objekts in ein Byte-Array */
		public static byte[] Image2Byte(Image image, ImageFormat format)
		{
			// MemoryStream erzeugen und das Bild in diesen schreiben
			MemoryStream imageStream = new MemoryStream();
			image.Save(imageStream, format);
			imageStream.Flush();

			// MemoryStream in ein Byte-Array schreiben und dieses zurückgeben
			return imageStream.ToArray();
		}

		/* Methode zum Umwandeln eines Byte-Array in ein Bitmap-Objekt */
		public static Bitmap Byte2Btmap(byte[] imageBytes)
		{
			// MemoryStream erzeugen, das Bild in diesen schreiben und
			// den Stream zurückgeben
			MemoryStream imageStream = new MemoryStream(imageBytes);
			Bitmap bitmap = new Bitmap(imageStream);
			imageStream.Close();
			return bitmap;
		}
	}
}
