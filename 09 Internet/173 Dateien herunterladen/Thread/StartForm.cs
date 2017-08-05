using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Internet;

namespace Dateien_herunterladen
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox destFileNameTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button syncDownloadAsFile;
		private System.Windows.Forms.TextBox bytesTotalTextBox;
		private System.Windows.Forms.Button asyncDownloadAsFile;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Button testButton;
		private System.Windows.Forms.TextBox bytesReadTextBox;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;

		public static void Main()
		{
			Application.Run(new StartForm());
		}

		public StartForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.syncDownloadAsFile = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.bytesTotalTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.destFileNameTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.asyncDownloadAsFile = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.testButton = new System.Windows.Forms.Button();
			this.bytesReadTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Url:";
			// 
			// urlTextBox
			// 
			this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.urlTextBox.Location = new System.Drawing.Point(80, 16);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(464, 20);
			this.urlTextBox.TabIndex = 1;
			this.urlTextBox.Text = "http://www.juergen-bayer.net/artikel/CSS/CSS.pdf";
			// 
			// syncDownloadAsFile
			// 
			this.syncDownloadAsFile.Location = new System.Drawing.Point(8, 80);
			this.syncDownloadAsFile.Name = "syncDownloadAsFile";
			this.syncDownloadAsFile.Size = new System.Drawing.Size(176, 23);
			this.syncDownloadAsFile.TabIndex = 2;
			this.syncDownloadAsFile.Text = "Synchroner Download als Datei";
			this.syncDownloadAsFile.Click += new System.EventHandler(this.syncDownloadAsFile_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(264, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Bytes gelesen:";
			// 
			// bytesTotalTextBox
			// 
			this.bytesTotalTextBox.Location = new System.Drawing.Point(120, 184);
			this.bytesTotalTextBox.Name = "bytesTotalTextBox";
			this.bytesTotalTextBox.Size = new System.Drawing.Size(72, 20);
			this.bytesTotalTextBox.TabIndex = 6;
			this.bytesTotalTextBox.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "Bytes gesamt:";
			// 
			// destFileNameTextBox
			// 
			this.destFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.destFileNameTextBox.Location = new System.Drawing.Point(80, 40);
			this.destFileNameTextBox.Name = "destFileNameTextBox";
			this.destFileNameTextBox.Size = new System.Drawing.Size(464, 20);
			this.destFileNameTextBox.TabIndex = 8;
			this.destFileNameTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(264, 24);
			this.label4.TabIndex = 7;
			this.label4.Text = "Zieldatei:";
			// 
			// asyncDownloadAsFile
			// 
			this.asyncDownloadAsFile.Location = new System.Drawing.Point(208, 80);
			this.asyncDownloadAsFile.Name = "asyncDownloadAsFile";
			this.asyncDownloadAsFile.Size = new System.Drawing.Size(176, 23);
			this.asyncDownloadAsFile.TabIndex = 9;
			this.asyncDownloadAsFile.Text = "Asynchroner Download als Datei";
			this.asyncDownloadAsFile.Click += new System.EventHandler(this.asyncDownloadAsFile_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.progressBar.Location = new System.Drawing.Point(120, 120);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(424, 23);
			this.progressBar.TabIndex = 11;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 223);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(552, 22);
			this.statusBar.TabIndex = 12;
			// 
			// testButton
			// 
			this.testButton.Location = new System.Drawing.Point(408, 80);
			this.testButton.Name = "testButton";
			this.testButton.Size = new System.Drawing.Size(104, 24);
			this.testButton.TabIndex = 13;
			this.testButton.Text = "Test";
			this.testButton.Click += new System.EventHandler(this.testButton_Click);
			// 
			// bytesReadTextBox
			// 
			this.bytesReadTextBox.Location = new System.Drawing.Point(120, 160);
			this.bytesReadTextBox.Name = "bytesReadTextBox";
			this.bytesReadTextBox.Size = new System.Drawing.Size(72, 20);
			this.bytesReadTextBox.TabIndex = 15;
			this.bytesReadTextBox.Text = "0";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(264, 24);
			this.label5.TabIndex = 14;
			this.label5.Text = "Bytes gelesen:";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 245);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bytesReadTextBox,
																		  this.label5,
																		  this.testButton,
																		  this.statusBar,
																		  this.progressBar,
																		  this.asyncDownloadAsFile,
																		  this.destFileNameTextBox,
																		  this.label4,
																		  this.bytesTotalTextBox,
																		  this.label3,
																		  this.label2,
																		  this.syncDownloadAsFile,
																		  this.urlTextBox,
																		  this.label1});
			this.Name = "StartForm";
			this.Text = "Download von Dateien";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/* Methode für den Fortschritts-Delegate */
		public void DownloadProgressHandler(WebDownload.DownloadState downloadState,
			int currentBytes, long totalBytes)
		{
			lock (this)
			{
				switch (downloadState)
				{
					case WebDownload.DownloadState.OpeningConnection:
						this.progressBar.Value = 0;
						this.statusBar.Text = "Öffne Verbindung ...";
						this.bytesReadTextBox.Text = "0";
						this.bytesTotalTextBox.Text = "0";
						break;
			
					case WebDownload.DownloadState.ReadingData:
						this.statusBar.Text = "Lade das Dokument ...";
						int progress = (int)((currentBytes / (double)totalBytes) * 100);
						this.progressBar.Value = progress;
						this.bytesReadTextBox.Text = currentBytes.ToString();
						this.bytesTotalTextBox.Text = totalBytes.ToString();
						break;
			
					case WebDownload.DownloadState.DataReady:
						this.progressBar.Value = 0;
						this.statusBar.Text = "Fertig";
						break;
				}
			}
		}

		/* Methode für den Download-Ende-Delegate */
		public void DownloadEndHandler(Stream destStream)
		{
			// Die Datei schließen
			destStream.Close();

			// Info ausgeben
			this.statusBar.Text = "Fertig ...";
			this.progressBar.Value = 0;
		}

		/* Methode für den Fehler-Delegate */
		public void DownloadErrorHandler(string error)
		{
			MessageBox.Show(error, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}



		private void StartForm_Load(object sender, System.EventArgs e)
		{
			this.destFileNameTextBox.Text = Path.Combine(Application.StartupPath, "XML-Doku.pdf");
		}

		/* Methode für den Schalter zum synchronen Download */ 
		private void syncDownloadAsFile_Click(object sender, System.EventArgs e)
		{
			FileStream fs = null;
			try
			{
				// FileStream für die Datei erzeugen
				fs = new FileStream(this.destFileNameTextBox.Text, 
					FileMode.Create, FileAccess.Write);

				// Datei herunterladen
				WebDownload webDownload = new WebDownload();
				webDownload.DownloadSync(this.urlTextBox.Text, fs, 1024, 
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), 
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));

				this.statusBar.Text = "Fertig ...";
				this.progressBar.Value = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				// FileStream schließen
				try {fs.Close();} 
				catch {}
			}
		}

		/* Methode für den Schalter zum asynchronen Download */ 
		private void asyncDownloadAsFile_Click(object sender, System.EventArgs e)
		{
			FileStream fileStream = null;
			try
			{
				// FileStream für die Datei erzeugen
				fileStream = new FileStream(this.destFileNameTextBox.Text, 
					FileMode.Create, FileAccess.Write);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				// FileStream schließen
				try {fileStream.Close();} 
				catch {}

				return;
			}

			// Datei asynchron herunterladen
			try
			{
				WebDownload webDownload = new WebDownload();
				webDownload.DownloadAsync(this.urlTextBox.Text, fileStream, 1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), 
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		/* Test des parallelen Download (Funktioniert nicht, wenn der Webzugriff
		 * aufgrund einer Firewall auch nur kurzzeitig blockiert wird */
		private void testButton_Click(object sender, System.EventArgs e)
		{
			// Einige Dateien parallel asynchron herunterladen
			try
			{
				FileStream fs1 = new FileStream(Path.Combine(Path.GetTempPath(), 
					"Test1.pdf"), FileMode.Create, FileAccess.Write);
				WebDownload webDownload1 = new WebDownload();
				webDownload1.DownloadAsync(this.urlTextBox.Text, fs1, 1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), 
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				FileStream fs2 = new FileStream(Path.Combine(Path.GetTempPath(), "Test2.pdf"), FileMode.Create,
					FileAccess.Write);
				WebDownload webDownload2 = new WebDownload();
				webDownload2.DownloadAsync(this.urlTextBox.Text, fs2, 1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), 
					new WebDownload.DownloadEnd(this.DownloadEndHandler),
					new WebDownload.DownloadError(this.DownloadErrorHandler));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
