using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Addison_Wesley.Codebook.Multimedia
{
	public class ImageUtils
	{
		/* Methode zum Lesen eines Bildes aus der Zwischenablage */
		public static Bitmap GetBitmapFromClipboard()
		{
			// Die Zwischenablagedaten auslesen und �berpr�fen
			IDataObject clipboardData = Clipboard.GetDataObject();
			if (clipboardData != null)
			{
				// �berpr�fen, ob ein Bitmap gespeichert ist
				if (clipboardData.GetDataPresent(typeof(Bitmap)))
				{
					return (Bitmap)clipboardData.GetData(typeof(Bitmap));
				}
			}
			
			// null zur�ckgeben, falls kein Bitmap in der Zwischenablage
			// gespeichert ist
			return null;
		}
	}
}
