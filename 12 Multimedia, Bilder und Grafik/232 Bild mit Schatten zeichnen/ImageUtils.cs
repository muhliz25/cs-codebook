using System;
using System.Drawing;

namespace Addison_Wesley.Codebook.Images
{
	public class ImageUtils
	{
		/* Methode zum Zeichnen eines Bildes mit Schatten */
		public static void DrawBitmapWithShadow(Graphics g, Image image, int left, int top, int shadowSize)
		{
			// Schatten zeichnen
			Color shadowColor = Color.FromArgb(160, 0, 0, 0);
			g.FillRectangle(new SolidBrush(shadowColor), left + shadowSize, 
				top + shadowSize, image.Width, image.Height);

			// Bild zeichnen
			g.DrawImage(image, new Rectangle(left, top, image.Width, image.Height),
				0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
		}
	}
}
