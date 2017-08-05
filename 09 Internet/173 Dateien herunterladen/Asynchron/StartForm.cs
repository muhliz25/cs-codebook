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
		private System.Windows.Forms.Button testButton;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button asyncDownloadAsFile;
		private System.Windows.Forms.TextBox destFileNameTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox bytesTotalTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button syncDownloadAsFile;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Label label1;
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
			this.testButton = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.asyncDownloadAsFile = new System.Windows.Forms.Button();
			this.destFileNameTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.bytesTotalTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.syncDownloadAsFile = new System.Windows.Forms.Button();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// testButton
			// 
			this.testButton.Location = new System.Drawing.Point(408, 72);
			this.testButton.Name = "testButton";
			this.testButton.Size = new System.Drawing.Size(104, 24);
			this.testButton.TabIndex = 25;
			this.testButton.Text = "Test";
			this.testButton.Click += new System.EventHandler(this.testButton_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 239);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(552, 22);
			this.statusBar.TabIndex = 24;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.progressBar.Location = new System.Drawing.Point(120, 144);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(424, 23);
			this.progressBar.TabIndex = 23;
			// 
			// asyncDownloadAsFile
			// 
			this.asyncDownloadAsFile.Location = new System.Drawing.Point(208, 72);
			this.asyncDownloadAsFile.Name = "asyncDownloadAsFile";
			this.asyncDownloadAsFile.Size = new System.Drawing.Size(176, 23);
			this.asyncDownloadAsFile.TabIndex = 22;
			this.asyncDownloadAsFile.Text = "Asynchroner Download als Datei";
			this.asyncDownloadAsFile.Click += new System.EventHandler(this.asyncDownloadAsFile_Click);
			// 
			// destFileNameTextBox
			// 
			this.destFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.destFileNameTextBox.Location = new System.Drawing.Point(80, 32);
			this.destFileNameTextBox.Name = "destFileNameTextBox";
			this.destFileNameTextBox.Size = new System.Drawing.Size(464, 20);
			this.destFileNameTextBox.TabIndex = 21;
			this.destFileNameTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(264, 24);
			this.label4.TabIndex = 20;
			this.label4.Text = "Zieldatei:";
			// 
			// bytesTotalTextBox
			// 
			this.bytesTotalTextBox.Location = new System.Drawing.Point(120, 176);
			this.bytesTotalTextBox.Name = "bytesTotalTextBox";
			this.bytesTotalTextBox.Size = new System.Drawing.Size(72, 20);
			this.bytesTotalTextBox.TabIndex = 19;
			this.bytesTotalTextBox.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 24);
			this.label3.TabIndex = 18;
			this.label3.Text = "Bytes gesamt:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(264, 24);
			this.label2.TabIndex = 17;
			this.label2.Text = "Bytes gelesen:";
			// 
			// syncDownloadAsFile
			// 
			this.syncDownloadAsFile.Location = new System.Drawing.Point(8, 72);
			this.syncDownloadAsFile.Name = "syncDownloadAsFile";
			this.syncDownloadAsFile.Size = new System.Drawing.Size(176, 23);
			this.syncDownloadAsFile.TabIndex = 16;
			this.syncDownloadAsFile.Text = "Synchroner Download als Datei";
			this.syncDownloadAsFile.Click += new System.EventHandler(this.syncDownloadAsFile_Click);
			// 
			// urlTextBox
			// 
			this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.urlTextBox.Location = new System.Drawing.Point(80, 8);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(464, 20);
			this.urlTextBox.TabIndex = 15;
			this.urlTextBox.Text = "http://www.juergen-bayer.net/artikel/CSS/CSS.pdf";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 24);
			this.label1.TabIndex = 14;
			this.label1.Text = "Url:";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 261);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
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
			long currentBytes, long totalBytes)
		{
			switch (downloadState)
			{
				case WebDownload.DownloadState.OpeningConnection:
					this.progressBar.Value = 0;
					this.statusBar.Text = "Öffne Verbindung ...";
					this.bytesTotalTextBox.Text = "0";
					break;
				case WebDownload.DownloadState.ReadingData:
					this.statusBar.Text = "Lade das Dokument ...";
					int progress = (int)((currentBytes / (double)totalBytes) * 100);
					this.progressBar.Value = progress;
					this.bytesTotalTextBox.Text = totalBytes.ToString();
					break;
			}
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
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				// FileStream schließen
				try {fs.Close();} 
				catch {}
			}
		}

		/* Methode für den Download-Ende-Delegate */
		public void DownloadEndHandler(Stream stream)
		{
			// Den Stream schließen
			stream.Close();

			// Info ausgeben
			this.statusBar.Text = "Fertig ...";
			this.progressBar.Value = 0;
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
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

				// FileStream schließen
				try {fileStream.Close();} 
				catch {}

				return;
			}

			// Datei asynchron herunterladen
			WebDownload webDownload = new WebDownload();
			webDownload.DownloadAsync(this.urlTextBox.Text, fileStream, 1024,
				new WebDownload.DownloadProgress(this.DownloadProgressHandler),
				new WebDownload.DownloadEnd(this.DownloadEndHandler));
		}

		private void testButton_Click(object sender, System.EventArgs e)
		{
			// Einige Dateien parallel asynchron herunterladen
			try
			{
				FileStream fs1 = new FileStream(Path.Combine(Path.GetTempPath(), "Test1.pdf"), FileMode.Create,
					FileAccess.Write);
				WebDownload webDownload = new WebDownload();
				webDownload.DownloadAsync(this.urlTextBox.Text, fs1, 1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
			{
				FileStream fs2 = new FileStream(Path.Combine(Path.GetTempPath(), "Test2.pdf"), FileMode.Create,
					FileAccess.Write);
				WebDownload webDownload = new WebDownload();
				webDownload.DownloadAsync(this.urlTextBox.Text, fs2, 1024,
					new WebDownload.DownloadProgress(this.DownloadProgressHandler), null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
