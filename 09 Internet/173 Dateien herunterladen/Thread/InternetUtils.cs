using System;
using System.Net;
using System.IO;
using System.Threading;

namespace Addison_Wesley.Codebook.Internet
{
	public class WebDownload
	{
		/* Aufz�hlung und Delegates f�r den Fortschritt und das Ende der
		 * Download-Methode und f�r Fehlermeldungen */
		public enum DownloadState
		{
			OpeningConnection,
			ReadingData,
			DataReady
		}
		public delegate void DownloadProgress(DownloadState downloadState, 
			int currentBytes, long totalBytes);
		public delegate void DownloadEnd(Stream destStream);
		public delegate void DownloadError(string message);

		/* Klasse, �ber deren Instanzen ein Download ausgef�hrt wird */
		private class Download
		{
			public string Url;
			public int BlockSize;
			public DownloadProgress DownloadProgress;
			public DownloadEnd DownloadEnd;
			public DownloadError DownloadError;
			public Stream DestStream;

			/* Konstruktor */
			public Download(string url, Stream destStream, int blockSize,
				DownloadProgress downloadProgress, DownloadEnd downloadEnd,
				DownloadError downloadError)
			{
				this.Url = url;
				this.BlockSize = blockSize;
				this.DownloadProgress = downloadProgress;
				this.DownloadEnd  = downloadEnd;
				this.DestStream = destStream;
				this.DownloadError = downloadError ;
			}

			/* Methode, die den Download ausf�hrt */
			public void PerformDownload()
			{
				WebRequest request = null;
				WebResponse response = null;
				Stream responseStream = null;
				try
				{
					// WebRequest-Instanz f�r den Download erzeugen, die Antwort
					// anfordern und die L�nge der Daten ermitteln
					if (this.DownloadProgress != null)
						this.DownloadProgress(DownloadState.OpeningConnection, 0, 0);
					request = WebRequest.Create(this.Url);
					response = request.GetResponse();
					long fileSize = response.ContentLength;

					// Den Antwort-Stream ermitteln, diesen blockweise lesen und
					// in den Zielstream schreiben
					responseStream = response.GetResponseStream();
					int bytesRead = 0;
					int totalBytesRead = 0;
					byte[] buffer = new byte[this.BlockSize];
					do
					{
						bytesRead = responseStream.Read(buffer, 0, this.BlockSize);
						totalBytesRead += bytesRead;
						this.DestStream.Write(buffer, 0, bytesRead);

						// Fortschritt melden
						if (this.DownloadProgress!= null)
							this.DownloadProgress(DownloadState.ReadingData,
								totalBytesRead, fileSize);
					} while (bytesRead > 0);

				}
				catch (Exception ex)
				{
					if (this.DownloadError != null)
						// Delegate f�r Fehlermeldungen aufrufen
						this.DownloadError(ex.Message);
					else
						// Ausnahme weiterwerfen
						throw ex;
				}
				finally
				{
					try 
					{
						// Den Response-Stream und das WebResponse-Objekt schlie�en
						responseStream.Close();
						response.Close();
					}
					catch {}

					// Den Delegate f�r das Ende des Downloads aufrufen
					if (this.DownloadEnd != null)
						this.DownloadEnd(this.DestStream); 
				}
			}
		}
		
		/* Methode zum synchronen Download einer Datei */
		public void DownloadSync(string url, Stream destStream, int blockSize,
			DownloadProgress downloadProgress, DownloadEnd downloadEnd,
			DownloadError downloadError)
		{
			// Download-Objekt erzeugen und initialisieren
			Download download = new Download(url, destStream, blockSize,
				downloadProgress, downloadEnd, downloadError);

			// Download synchron starten
			download.PerformDownload();
		}

		
		/* Methode zum asynchronen Download einer Datei */
		public void DownloadAsync(string url, Stream destStream, int blockSize, 
			DownloadProgress downloadProgress, DownloadEnd downloadEnd,
			DownloadError downloadError)
		{
			// Download-Objekt erzeugen und initialisieren
			Download download = new Download(url, destStream, blockSize,
				downloadProgress, downloadEnd, downloadError);

			// Thread f�r den Download starten
			Thread downloadThread = new Thread(new ThreadStart(download.PerformDownload));
			downloadThread.Start();
		}
	}
}

