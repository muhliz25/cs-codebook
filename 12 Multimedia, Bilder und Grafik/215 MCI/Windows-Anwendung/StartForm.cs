using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using Addison_Wesley.Codebook.Multimedia;

namespace MCI_Demo
{
	public class StartForm: System.Windows.Forms.Form
	{
		[ DllImport( "winmm.dll", EntryPoint="mciSendStringA", CharSet=CharSet.Ansi )]
		protected static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);

		[ DllImport( "winmm.dll", EntryPoint="mciGetErrorStringA", CharSet=CharSet.Ansi )]
		protected static extern int mciGetErrorString(int dwError, StringBuilder lpstrBuffer, int uLength);

		[ DllImport( "kernel32.dll", EntryPoint="GetShortPathNameA", CharSet=CharSet.Ansi )]
		protected static extern int GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

		protected string GetMciError(int errorCode) 
		{
			StringBuilder buffer = new StringBuilder(255);
			if (mciGetErrorString(errorCode, buffer, buffer.Capacity) == 0)
				return "";
			return buffer.ToString();
		}

		protected string GetShortPath(string file) 
		{
			StringBuilder buffer = new StringBuilder(file.Length + 1);
			int ret = GetShortPathName(file, buffer, buffer.Capacity);
			if (ret == 0)		
				return "";
			else				// Success
				return buffer.ToString();
		}

	
		public int GetLength(string Alias)
		{
			StringBuilder buffer = new StringBuilder(260);
			string mciString = "STATUS " + Alias + " LENGTH";
			int ret = mciSendString(mciString, buffer, buffer.Capacity, IntPtr.Zero);
			if (ret != 0)
				throw new Exception(GetMciError(ret));
			return int.Parse(buffer.ToString());
		}

		
		private System.Windows.Forms.Button getFileButton;
		private System.Windows.Forms.CheckBox repeatCheckBox;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.TextBox fileNameTextBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.CheckBox openVideoInFormCheckBox;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button forwardButton;
		private System.Windows.Forms.Button volumeButton;
		private System.Windows.Forms.TextBox volumeTextBox;
		private System.Windows.Forms.TextBox playbackSpeedTextBox;
		private System.Windows.Forms.Button playbackSpeedButton;
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
			this.repeatCheckBox = new System.Windows.Forms.CheckBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.stopButton = new System.Windows.Forms.Button();
			this.playButton = new System.Windows.Forms.Button();
			this.openButton = new System.Windows.Forms.Button();
			this.fileNameTextBox = new System.Windows.Forms.TextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.openVideoInFormCheckBox = new System.Windows.Forms.CheckBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.forwardButton = new System.Windows.Forms.Button();
			this.volumeButton = new System.Windows.Forms.Button();
			this.volumeTextBox = new System.Windows.Forms.TextBox();
			this.playbackSpeedTextBox = new System.Windows.Forms.TextBox();
			this.playbackSpeedButton = new System.Windows.Forms.Button();
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
			// repeatCheckBox
			// 
			this.repeatCheckBox.Location = new System.Drawing.Point(96, 72);
			this.repeatCheckBox.Name = "repeatCheckBox";
			this.repeatCheckBox.TabIndex = 16;
			this.repeatCheckBox.Text = "Wiederholen";
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(8, 256);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 14;
			this.closeButton.Text = "Schließen";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// stopButton
			// 
			this.stopButton.Location = new System.Drawing.Point(8, 224);
			this.stopButton.Name = "stopButton";
			this.stopButton.TabIndex = 13;
			this.stopButton.Text = "Stop";
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
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
			this.fileNameTextBox.Text = "c:\\Club Generation - Patience.mp3";
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
			// openVideoInFormCheckBox
			// 
			this.openVideoInFormCheckBox.Location = new System.Drawing.Point(96, 40);
			this.openVideoInFormCheckBox.Name = "openVideoInFormCheckBox";
			this.openVideoInFormCheckBox.Size = new System.Drawing.Size(248, 24);
			this.openVideoInFormCheckBox.TabIndex = 20;
			this.openVideoInFormCheckBox.Text = "Video innerhalb der PictureBox öffnen";
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
			// forwardButton
			// 
			this.forwardButton.Location = new System.Drawing.Point(8, 192);
			this.forwardButton.Name = "forwardButton";
			this.forwardButton.TabIndex = 22;
			this.forwardButton.Text = "Vorspulen";
			this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
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
			// playbackSpeedTextBox
			// 
			this.playbackSpeedTextBox.Location = new System.Drawing.Point(96, 136);
			this.playbackSpeedTextBox.Name = "playbackSpeedTextBox";
			this.playbackSpeedTextBox.Size = new System.Drawing.Size(72, 20);
			this.playbackSpeedTextBox.TabIndex = 26;
			this.playbackSpeedTextBox.Text = "0";
			// 
			// playbackSpeedButton
			// 
			this.playbackSpeedButton.Location = new System.Drawing.Point(8, 136);
			this.playbackSpeedButton.Name = "playbackSpeedButton";
			this.playbackSpeedButton.TabIndex = 25;
			this.playbackSpeedButton.Text = "Speed";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.playbackSpeedTextBox,
																		  this.playbackSpeedButton,
																		  this.volumeTextBox,
																		  this.volumeButton,
																		  this.forwardButton,
																		  this.pictureBox,
																		  this.openVideoInFormCheckBox,
																		  this.infoLabel,
																		  this.repeatCheckBox,
																		  this.closeButton,
																		  this.stopButton,
																		  this.playButton,
																		  this.openButton,
																		  this.fileNameTextBox,
																		  this.label1,
																		  this.getFileButton});
			this.Name = "StartForm";
			this.Text = "MCI-Multimedia";
			this.Resize += new System.EventHandler(this.StartForm_Resize);
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

		/* Eigenschaft für die MCI-Instanz */
		private Mci mci = null;

		private void openButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				// MCI-Gerät öffnen
				if (this.openVideoInFormCheckBox.Checked)
					mci.Open(fileNameTextBox.Text, this.pictureBox);
				else
					mci.Open(fileNameTextBox.Text);
				
				// Länge, aktuelle Lautstärke und aktuelle Abspielgeschwindigkeit auslesen
				infoLabel.Text = "Länge: " + mci.Length + " ms";
				this.volumeTextBox.Text = mci.Volume.ToString();
				this.playbackSpeedTextBox.Text = mci.PlaybackSpeed.ToString(); 

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
				mci.Play(this.repeatCheckBox.Checked);
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
				mci.Stop();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				mci.Close();
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
			this.mci = new Mci();
			openFileDialog.Filter = "Sounddateien|*.mp3;*.wav;*.mid;*.midi|Videodateien|*.avi;*.mpg;*.mpeg|Alle Dateien|*.*";
			this.fileNameTextBox.Text = Path.Combine(Application.StartupPath, "Club Generation - Patience.mp3");
		}

		private void StartForm_Resize(object sender, System.EventArgs e)
		{
			if (mci.IsOpen)
			{
				mci.SetRectangle(0, 0, this.pictureBox.Width, this.pictureBox.Height);
			}
		}

		private void volumeButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				mci.Volume = Convert.ToInt32(this.volumeTextBox.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void forwardButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				int position = mci.Position;
				this.infoLabel.Text = "Aktuelle Position: " + position;
				mci.Position = position + 10000;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void StartForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			mci.Close();
		}
	}	
}
