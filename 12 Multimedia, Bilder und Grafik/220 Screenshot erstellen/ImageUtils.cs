using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Multimedia
{
	public class ImageUtils
	{
		/* Deklaration der ben�tigten API-Funktionen und Konstanten */
		[DllImport("gdi32.dll", SetLastError=true)]
		private static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
			int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc,
			int dwRop);

		[DllImport("gdi32.dll", SetLastError=true)]
		private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice,
			string lpszOutput, IntPtr lpInitData);

		private static int SRCCOPY = 0x00CC0020;
		
		
		/* Methode zum Erzeugen eines Screenshot des Bildschirms */
		public static Bitmap Screenshot()
		{
			// Device Context f�r den Bildschirm ermitteln und damit ein
			// Graphics-Objekt erzeugen
			IntPtr screenDC = CreateDC("DISPLAY", null, null, (IntPtr)null);
			Graphics screenGraphics = Graphics.FromHdc(screenDC);

			// Bitmap mit den Ausma�en des Bildschirms und der Aufl�sung des 
			// Graphics-Objekts erzeugen
			Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, 
				Screen.PrimaryScreen.Bounds.Height, screenGraphics);

			// Zweites Graphics-Objekt aus dem noch leeren Bitmap erzeugen um den
			// DC des Bitmap-Objekts auslesen zu k�nnen
			Graphics bitmapGraphics = Graphics.FromImage(bitmap);
			IntPtr bitmapDC  = bitmapGraphics.GetHdc();

			// Nach dem Erzeugen des Graphic-Objekts muss der DC des Bildschirms 
			// erneut ermittelt werden, da dieser anscheinend beim Aufruf der 
			// FromHdc-Methode freigegeben wurde (ohne dieses erneute Auslesen 
			// schl�gt BitBlt ohne Fehlermeldung fehl und die Freigabe des DC 
			// f�hrt zu einem Fehler).
			screenDC = screenGraphics.GetHdc();

			// �ber BitBlt das �ber den Bildschirm-DC repr�sentierte Bild in das
			// �ber den Bitmap-DC repr�sentierte Bild kopieren
			if (BitBlt(bitmapDC, 0, 0, Screen.PrimaryScreen.Bounds.Width, 
				Screen.PrimaryScreen.Bounds.Height, screenDC, 0, 0, SRCCOPY) == 0)
			{
				bitmapGraphics.ReleaseHdc(bitmapDC);
				screenGraphics.ReleaseHdc(screenDC);
				throw new Exception("API-Fehler " + Marshal.GetLastWin32Error() +
					" beim Aufruf von BitBlt");
			}

			// Die DCs freigeben und das Bild zur�ckgeben
			bitmapGraphics.ReleaseHdc(bitmapDC);
			screenGraphics.ReleaseHdc(screenDC);
			return bitmap;
		}


		/* Methode zum Erzeugen eines Screenshot eines Formulars */
		public static Bitmap Screenshot(Form form)
		{
			// Graphics-Objekt f�r das Formular erzeugen und ein neues Bitmap-Objekt
			// und Graphics-Objekt f�r das Ergebnis erzeugen
			Graphics formGraphics = form.CreateGraphics();
			Bitmap bitmap = new Bitmap(form.ClientRectangle.Width, 
				form.ClientRectangle.Height, formGraphics);
			Graphics bitmapGraphics = Graphics.FromImage(bitmap);

			// Die DCs auslesen
			IntPtr formDC = formGraphics.GetHdc();
			IntPtr bitmapDC = bitmapGraphics.GetHdc();

			// Die Grafik des Formulars in das Ziel-Bitmap kopieren
			if (BitBlt(bitmapDC, 0, 0, form.ClientRectangle.Width,
				form.ClientRectangle.Height, formDC, 0, 0, SRCCOPY) == 0)
			{
				formGraphics.ReleaseHdc(formDC);
				bitmapGraphics.ReleaseHdc(bitmapDC);
				throw new Exception("API-Fehler " + Marshal.GetLastWin32Error() +
					" beim Aufruf von BitBlt");
			}

			// DCs freigeben und Bitmap zur�ckgeben
			formGraphics.ReleaseHdc(formDC);
			bitmapGraphics.ReleaseHdc(bitmapDC);
			return bitmap;
		}
	}
}
