using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Addison_Wesley.Codebook.Images
{
	public class ImageUtils
	{
		/* Methode zum Skalieren eines Bitmaps unter der Angabe der neuen Breite und Höhe,
		 * des Interpolier-Modus, des Pixel-Offset und des Smoothing-Modus */
		public static Bitmap ScaleBitmap(Bitmap source, int width, int height,
			InterpolationMode interpolationMode, PixelOffsetMode pixelOffsetMode,
			SmoothingMode smoothingMode)
		{
			// Bitmap in der neu berechneten Größe erstellen
			Bitmap result = new Bitmap(width, height);

			// Graphics-Objekt für das Bitmap erzeugen und den
			// Interpolier-Modus, Pixeloffset-Modus und den
			// Smoothing-Modus einstellen
			Graphics g = Graphics.FromImage(result);
			g.InterpolationMode = interpolationMode;
			g.PixelOffsetMode = pixelOffsetMode;
			g.SmoothingMode =  smoothingMode;
	
			// Bild von der Quelle auf das Ziel übertragen und dabei skalieren
			g.DrawImage(source, new Rectangle(0, 0, width, height),
				new Rectangle(0, 0, source.Width, source.Height),
				GraphicsUnit.Pixel);
			g.Dispose();
	
			return result;
		}

		/* Methode zum Skalieren eines Bitmaps unter der Angabe des Skalierungsfaktors,
		 * des Interpolier-Modus, des Pixel-Offset und des Smoothing-Modus */
		public static Bitmap ScaleBitmap(Bitmap source, double scaleFactor,
			InterpolationMode interpolationMode, PixelOffsetMode pixelOffsetMode,
			SmoothingMode smoothingMode)
		{
			// Neue Breite und Höhe berechnen und damit die erste Variante aufrufen
			int width = (int)(source.Width * scaleFactor);
			int height = (int)(source.Height * scaleFactor);
			return ScaleBitmap(source, width, height, interpolationMode, pixelOffsetMode,
				smoothingMode);
		}
	}
}
