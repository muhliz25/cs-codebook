using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Addison_Wesley.Codebook.Images
{
	public class ImageUtils
	{
		/* Methode zum Drehen eines Bildes */
		public static Bitmap RotateImage(Image image, float angle, Color fillColor,
			bool resizeBitmap)
		{
			// Neue Breite und Höhe berechnen
			int newHeight, newWidth;
			if (resizeBitmap)
			{
				// Berechnung des Umfassungsrechtecks
				int x = image.Width / 2;
				int y = image.Height / 2;
				double cosTheta = Math.Cos(2 * Math.PI * angle / 360);
				double sinTheta = Math.Sin(2 * Math.PI * angle / 360);
				double a = Math.Max(Math.Abs(x * cosTheta + y * sinTheta), 
					Math.Abs(x * cosTheta - y * sinTheta));
				double b = Math.Max(Math.Abs(x * sinTheta - y * cosTheta), 
					Math.Abs(x * sinTheta + y * cosTheta));
				newWidth = (int)Math.Round(2 * a);
				newHeight = (int)Math.Round(2 * b);
			}
			else
			{
				newHeight = image.Height;
				newWidth = image.Width;
			}

			// Neues Bitmap-Objekt mit den vergrößerten Ausmaßen des alten erzeugen
			Bitmap bitmap = new Bitmap(newWidth, newHeight);

			// Graphics-Objekt für das Bitmap erzeugen und mit der übergebenen 
			// Farbe füllen
			Graphics g = Graphics.FromImage(bitmap);
			g.Clear(fillColor);

			// Neue Transformationsmatrix erzeugen
			Matrix matrix = new Matrix();

			// Die Transformation so einstellen, dass die Ausgabe des Bildes 
			// in der Mitte der Zeichenfläche erscheint und dass diese um den
			// Mittelpunkt um den angegebenen Winkel gedreht wird
			int xOffset = (int)((newWidth - image.Width) / 2);
			int yOffset = (int)((newHeight - image.Height) / 2);
			matrix.Translate(xOffset, yOffset);
			Point rotatePoint = new Point(image.Width / 2, image.Height / 2);
			matrix.RotateAt(angle, rotatePoint, MatrixOrder.Prepend);
			g.Transform = matrix;

			// Die Zeichenqualität einstellen
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.SmoothingMode = SmoothingMode.HighQuality;

			// Das Bild entsprechend der Transformation verschoben und verdreht
			// ausgeben 
			g.DrawImage(image, 0, 0, image.Width, image.Height );

			// Das Bild zurückgeben
			return bitmap;
		}
	}
}