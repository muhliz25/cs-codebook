using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using QuartzTypeLib;

namespace DirectX_Demo
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button getFileButton;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.TextBox fileNameTextBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button volumeButton;
		private System.Windows.Forms.TextBox volumeTextBox;
		private System.Windows.Forms.Button stopButton;
		private System.ComponentModel.Container components = null;

		public StartForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.getFileButton = new System.Windows.Forms.Button();
			this.playButton = new System.Windows.Forms.Button();
			this.openButton = new System.Windows.Forms.Button();
			this.fileNameTextBox = new System.Windows.Forms.TextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.volumeButton = new System.Windows.Forms.Button();
			this.volumeTextBox = new System.Windows.Forms.TextBox();
			this.stopButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// getFileButton
			// 
			this.getFileButton.Location = new System.Drawing.Point(384, 8);
			this.getFileButton.Name = "getFileButton";
			this.getFileButton.TabIndex = 17;
			this.getFileButton.Text = "...";
			this.getFileButton.Click += new System.EventHandler(this.getFileButton_Click);
			// 
			// playButton
			// 
			this.playButton.Location = new System.Drawing.Point(8, 72);
			this.playButton.Name = "playButton";
			this.playButton.TabIndex = 12;
			this.playButton.Text = "Abspielen";
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// openButton
			// 
			this.openButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.openButton.Location = new System.Drawing.Point(8, 40);
			this.openButton.Name = "openButton";
			this.openButton.TabIndex = 11;
			this.openButton.Text = "Öffnen";
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// fileNameTextBox
			// 
			this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.fileNameTextBox.Location = new System.Drawing.Point(48, 8);
			this.fileNameTextBox.Name = "fileNameTextBox";
			this.fileNameTextBox.Size = new System.Drawing.Size(328, 20);
			this.fileNameTextBox.TabIndex = 10;
			this.fileNameTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 9;
			this.label1.Text = "Datei:";
			// 
			// infoLabel
			// 
			this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.infoLabel.Location = new System.Drawing.Point(8, 304);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(160, 16);
			this.infoLabel.TabIndex = 18;
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox.Location = new System.Drawing.Point(184, 72);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(272, 248);
			this.pictureBox.TabIndex = 21;
			this.pictureBox.TabStop = false;
			// 
			// volumeButton
			// 
			this.volumeButton.Location = new System.Drawing.Point(8, 104);
			this.volumeButton.Name = "volumeButton";
			this.volumeButton.TabIndex = 23;
			this.volumeButton.Text = "Lautstärke";
			this.volumeButton.Click += new System.EventHandler(this.volumeButton_Click);
			// 
			// volumeTextBox
			// 
			this.volumeTextBox.Location = new System.Drawing.Point(96, 104);
			this.volumeTextBox.Name = "volumeTextBox";
			this.volumeTextBox.Size = new System.Drawing.Size(72, 20);
			this.volumeTextBox.TabIndex = 24;
			this.volumeTextBox.Text = "0";
			// 
			// stopButton
			// 
			this.stopButton.Location = new System.Drawing.Point(8, 136);
			this.stopButton.Name = "stopButton";
			this.stopButton.TabIndex = 13;
			this.stopButton.Text = "Stop";
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.volumeTextBox,
																		  this.volumeButton,
																		  this.pictureBox,
																		  this.infoLabel,
																		  this.stopButton,
																		  this.playButton,
																		  this.openButton,
																		  this.fileNameTextBox,
																		  this.label1,
																		  this.getFileButton});
			this.Name = "StartForm";
			this.Text = "DirectX-Multimedia";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.StartForm_Closing);
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		/* Eigenschaft für die FilgraphManager-Instanz */
		QuartzTypeLib.FilgraphManager fgm = null;

		private void openButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Datei in DirectX öffnen
				fgm.RenderFile(fileNameTextBox.Text);
				
				// Aktuelle Lautstärke auslesen
				this.volumeTextBox.Text = ((IBasicAudio)fgm).Volume.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void playButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.fgm.Run();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void stopButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.fgm.Stop();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void getFileButton_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				this.fileNameTextBox.Text = openFileDialog.FileName;

		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			this.fgm = new FilgraphManager();
			this.fileNameTextBox.Text = Path.Combine(Application.StartupPath, "PPK - Resurection Space Club Remix.mp3");
			openFileDialog.Filter = "Sounddateien|*.mp3;*.wav|Videodateien|*.avi;*.mpg;*.mpeg|Alle Dateien|*.*";
		}


		private void volumeButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				((IBasicAudio)fgm).Volume = Convert.ToInt32(this.volumeTextBox.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void StartForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.fgm.Stop();
		}

		private void forwardButton_Click(object sender, System.EventArgs e)
		{
		
		}

	}	
}
