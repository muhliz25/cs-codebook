using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Addison_Wesley.Codebook.Images
{
	public class ImageUtils
	{
		/* Methode zur Konvertierung eines Bildes in ein Graustufen-Bild */
		public static Bitmap CreateGrayscaledBitmap(Image image)
		{
			// Neues Bitmap-Objekt mit den Ausma�en der Quelle erzeugen
			Bitmap bitmap = new Bitmap(image.Width, image.Height);

			// ColorMatrix f�r die Transformation der Farben erzeugen
			ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
																		new float[] {0.3F, 0.3F, 0.3F, 0, 0},
																		new float[] {0.59F, 0.59F, 0.59F, 0, 0},
																		new float[] {0.11F, 0.11F, 0.11F, 0, 0},
																		new float[] {0, 0, 0, 1, 0},
																		new float[] {0, 0, 0, 0, 1}
																	});

			// Grafik auf dem Bitmap-Objekt ausgeben und dabei ein neues
			// ImageAttributes-Objekt mit der ColorMatrix �bergeben 
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			Graphics g = Graphics.FromImage(bitmap);
			g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
				0, 0, image.Width, image.Height, GraphicsUnit.Pixel,
				imageAttributes);
			g.Dispose();

			return bitmap;
		}
	}
}
