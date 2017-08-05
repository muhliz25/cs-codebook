using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Addison_Wesley.Codebook.Images
{
	public class ImageUtils
	{
		/* Methode zur Erzeugung eines Bildnegativs über das Setzen einzelner Pixel */
		public static Bitmap CreateNegative2(Bitmap bitmap)
		{
			// Neues Bitmap aus dem übergebenen erzeugen
			Bitmap newBitmap = (Bitmap)bitmap.Clone();

			// Den Speicher des Bitmaps sperren, damit die CLR diesen nicht
			// an einen anderen Platz verlegen kann
			//			newBitmap.LockBits(new ;

			// Die einzelnen Pixel durchgehen und neu berechnen
			for (int x = 0; x < newBitmap.Width; x++)
			{
				for (int y = 0; y < newBitmap.Height; y++)
				{
					Color color = newBitmap.GetPixel(x, y);
					if (color == Color.Black)
						newBitmap.SetPixel(x, y, Color.White);
					else
					{
						unchecked 
						{
							newBitmap.SetPixel(x, y, Color.FromArgb((byte)(color.R * -1), 
								(byte)(color.G * -1), (byte)(color.B * -1)));
						}
					}
				}
			}

			// Bits wieder freigeben
			//			newBitmap.UnlockBits();

			return newBitmap;
		}
	}
}
