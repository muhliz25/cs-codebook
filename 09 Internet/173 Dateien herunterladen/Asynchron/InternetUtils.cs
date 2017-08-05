using System;
using System.Net;
using System.IO;
using System.Threading;

namespace Addison_Wesley.Codebook.Internet
{
	public class WebDownload
	{
		/* Aufzählung und Delegates für den Fortschritt und das Ende der Download-Methode */
		public enum DownloadState
		{
			OpeningConnection,
			ReadingData
		}
		public delegate void DownloadProgress(DownloadState downloadState, 
			long currentBytes, long totalBytes);
		public delegate void DownloadEnd(Stream destStream);
		
		/* Methode zum synchronen Download einer Datei */
		public void DownloadSync(string url, Stream destStream, int blockSize,
			DownloadProgress downloadProgress, DownloadEnd downloadEnd)
		{
			// WebRequest-Instanz für den Download erzeugen
			WebRequest request = WebRequest.Create(url);

			// Die Antwort anfordern
			WebResponse response = request.GetResponse();
			long fileSize = response.ContentLength;

			// Den Antwort-Stream ermitteln
			Stream responseStream = response.GetResponseStream();

			// Stream blockweise lesen und in den Zielstream schreiben
			int bytesRead = 0;
			int totalBytesRead = 0;
			byte[] buffer = new byte[blockSize];
			do
			{
				bytesRead = responseStream.Read(buffer, 0, blockSize);
				totalBytesRead += bytesRead;
				destStream.Write(buffer, 0, bytesRead);

				// Fortschritt melden
				if (downloadProgress != null)
					downloadProgress(DownloadState.ReadingData, totalBytesRead, fileSize);

			} while (bytesRead > 0);

			// Den Response-Stream und das WebResponse-Objekt schließen
			responseStream.Close();
			response.Close();

			// Ende des Download melden
			if (downloadEnd != null)
				downloadEnd(destStream);
		}

		/* Klasse für die Übergabe des Status für den asynchronen Download */
		private class DownloadStatus
		{
			public WebRequest Request;
			public int BlockSize;
			public byte[] ReadBuffer;
			public Stream ResponseStream;
			public long DataSize;
			public long BytesSoFar = 0;
			public ManualResetEvent manualResetEvent;
			public DownloadProgress DownloadProgress;
			public DownloadEnd DownloadEnd;
			public Stream DestStream;
		}

		/* Methode für den Callback beim asynchronen Lesen des Response-Stream */
		private void ReadCallback(IAsyncResult asyncResult)
		{
			// Das DownloadStatus-Objekt aus den AsyncResult-Status auslesen.
			DownloadStatus downloadStatus = (DownloadStatus)asyncResult.AsyncState;

			// Das Asynchrone Lesen abschließen und die gelesenen
			// Bytes ermitteln
			int bytesRead = downloadStatus.ResponseStream.EndRead(asyncResult);
			if (bytesRead > 0)
			{
				// Wenn Bytes gelesen wurden, diese in den Ergebnis-Stream schreiben
				downloadStatus.DestStream.Write(downloadStatus.ReadBuffer, 0, bytesRead);
				downloadStatus.BytesSoFar += bytesRead;

				// Den DownloadProgress-Delegate aufrufen
				if (downloadStatus.DownloadProgress != null)
					downloadStatus.DownloadProgress(DownloadState.ReadingData,
						downloadStatus.BytesSoFar, downloadStatus.DataSize);

				// Noch einmal asynchron lesen, bis beim Lesen keine Bytes mehr
				// zur Verfügung stehen
				downloadStatus.ResponseStream.BeginRead(
					downloadStatus.ReadBuffer, 0, downloadStatus.BlockSize,
					new AsyncCallback(ReadCallback), downloadStatus);
			}
			else
			{
				downloadStatus.ResponseStream.Close();
				downloadStatus.manualResetEvent.Set();
				
				// Den DownloadEnd-Delegate aufrufen
				if (downloadStatus.DownloadEnd != null)
					downloadStatus.DownloadEnd(downloadStatus.DestStream);
			}
			return;
		}

		/* Methode für den asynchronen Response-Callback */
		private void ResponseCallback(IAsyncResult asyncResult)
		{
			// Das beim asynchronen Aufruf übergebene downloadStatus-Objekt auslesen
			DownloadStatus downloadStatus = (DownloadStatus)asyncResult.AsyncState;

			// Get the WebRequest from RequestState.
			WebRequest request = downloadStatus.Request;

			// Die Methode EndGetResponse aufrufen, die das WebResponse-Objekt
			// erzeugt 
			WebResponse response = request.EndGetResponse(asyncResult);

			// Die Gesamtlänge der Daten aus dem Response-Header auslesen
			string contentLength = response.Headers["Content-Length"];
			if (contentLength != null)
				downloadStatus.DataSize = Convert.ToInt32(contentLength);

			// Den Response-Stream auslesen
			Stream responseStream = response.GetResponseStream();

			// Den Response-Stream in das DownloadStatus-Objekt schreiben ...
			downloadStatus.ResponseStream = responseStream;

			// ... und den Stream ebenfalls asynchron einlesen
			IAsyncResult readAsyncResult = responseStream.BeginRead(downloadStatus.ReadBuffer, 
				0, downloadStatus.BlockSize, new AsyncCallback(ReadCallback), downloadStatus);
		}


		/* Methode zum asynchronen Download einer Datei */
		public void DownloadAsync(string url, Stream destStream, int blockSize, 
			DownloadProgress downloadProgress, DownloadEnd downloadEnd)
		{
			// Das Download-Status-Objekt, das über das Status-
			// Feld des asynchronen Aufrufs weitergegeben wird,
			// erzeugen und initialisieren
			DownloadStatus downloadStatus = new DownloadStatus();
			downloadStatus.BlockSize = blockSize;
			downloadStatus.ReadBuffer = new Byte[blockSize];
			downloadStatus.DownloadProgress = downloadProgress;
			downloadStatus.DownloadEnd = downloadEnd;
			downloadStatus.DestStream = destStream;
			downloadStatus.manualResetEvent = new ManualResetEvent(false);
			downloadStatus.manualResetEvent.Reset();
			
			// WebRequest-Instanz für den Download erzeugen
			downloadStatus.Request = WebRequest.Create(url);

			// Die Antwort asynchron abfragen
			IAsyncResult asyncResult = (IAsyncResult)downloadStatus.Request.BeginGetResponse(
				new AsyncCallback(ResponseCallback), downloadStatus);

			//downloadStatus.manualResetEvent.WaitOne();
		}
	}
}
