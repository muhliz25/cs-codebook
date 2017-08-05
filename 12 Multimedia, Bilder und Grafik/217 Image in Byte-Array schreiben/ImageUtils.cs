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

			// MemoryStream in ein Byte-Array schreiben und dieses zur�ckgeben
			return imageStream.ToArray();
		}
	}
}