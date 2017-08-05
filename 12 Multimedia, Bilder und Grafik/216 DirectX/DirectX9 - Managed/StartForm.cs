using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.DirectX.AudioVideoPlayback;

namespace DirectX9
{
	public class StartForm: System.Windows.Forms.Form
	{
		private Audio audio = null;
		private Video video = null;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.CheckBox openVideoInFormCheckBox;
		private System.Windows.Forms.Button playAudioButton;
		private System.Windows.Forms.Button stopAutioButton;
		private System.Windows.Forms.Button playVideoButton;
		private System.Windows.Forms.Button stopVideoButton;
		private System.Windows.Forms.Button audioVolumeButton;
		private System.Windows.Forms.TextBox audioVolumeTextBox;
		private System.Windows.Forms.Button forwardAudioButton;
		private System.Windows.Forms.Button audioPositionButton;
		private System.Windows.Forms.TextBox audioPositionTextBox;
		private System.Windows.Forms.Button demoBotton;
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
			this.playAudioButton = new System.Windows.Forms.Button();
			this.stopAutioButton = new System.Windows.Forms.Button();
			this.playVideoButton = new System.Windows.Forms.Button();
			this.stopVideoButton = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.openVideoInFormCheckBox = new System.Windows.Forms.CheckBox();
			this.audioVolumeTextBox = new System.Windows.Forms.TextBox();
			this.audioVolumeButton = new System.Windows.Forms.Button();
			this.forwardAudioButton = new System.Windows.Forms.Button();
			this.audioPositionButton = new System.Windows.Forms.Button();
			this.audioPositionTextBox = new System.Windows.Forms.TextBox();
			this.demoBotton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// playAudioButton
			// 
			this.playAudioButton.Location = new System.Drawing.Point(16, 24);
			this.playAudioButton.Name = "playAudioButton";
			this.playAudioButton.Size = new System.Drawing.Size(128, 23);
			this.playAudioButton.TabIndex = 0;
			this.playAudioButton.Text = "Audiodatei abspielen";
			this.playAudioButton.Click += new System.EventHandler(this.playAudioButton_Click);
			// 
			// stopAutioButton
			// 
			this.stopAutioButton.Location = new System.Drawing.Point(16, 152);
			this.stopAutioButton.Name = "stopAutioButton";
			this.stopAutioButton.Size = new System.Drawing.Size(128, 23);
			this.stopAutioButton.TabIndex = 1;
			this.stopAutioButton.Text = "Audiodatei stoppen";
			this.stopAutioButton.Click += new System.EventHandler(this.stopAudioButton_Click);
			// 
			// playVideoButton
			// 
			this.playVideoButton.Location = new System.Drawing.Point(16, 208);
			this.playVideoButton.Name = "playVideoButton";
			this.playVideoButton.Size = new System.Drawing.Size(128, 23);
			this.playVideoButton.TabIndex = 3;
			this.playVideoButton.Text = "Videodatei abspielen";
			this.playVideoButton.Click += new System.EventHandler(this.playVideoButton_Click);
			// 
			// stopVideoButton
			// 
			this.stopVideoButton.Location = new System.Drawing.Point(16, 288);
			this.stopVideoButton.Name = "stopVideoButton";
			this.stopVideoButton.Size = new System.Drawing.Size(128, 23);
			this.stopVideoButton.TabIndex = 4;
			this.stopVideoButton.Text = "Videodatei stoppen";
			this.stopVideoButton.Click += new System.EventHandler(this.stopVideoButton_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox.Location = new System.Drawing.Point(216, 208);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(304, 208);
			this.pictureBox.TabIndex = 5;
			this.pictureBox.TabStop = false;
			// 
			// openVideoInFormCheckBox
			// 
			this.openVideoInFormCheckBox.Location = new System.Drawing.Point(16, 240);
			this.openVideoInFormCheckBox.Name = "openVideoInFormCheckBox";
			this.openVideoInFormCheckBox.Size = new System.Drawing.Size(160, 32);
			this.openVideoInFormCheckBox.TabIndex = 21;
			this.openVideoInFormCheckBox.Text = "Video innerhalb der PictureBox öffnen";
			// 
			// audioVolumeTextBox
			// 
			this.audioVolumeTextBox.Location = new System.Drawing.Point(160, 56);
			this.audioVolumeTextBox.Name = "audioVolumeTextBox";
			this.audioVolumeTextBox.Size = new System.Drawing.Size(72, 20);
			this.audioVolumeTextBox.TabIndex = 26;
			this.audioVolumeTextBox.Text = "0";
			// 
			// audioVolumeButton
			// 
			this.audioVolumeButton.Location = new System.Drawing.Point(16, 56);
			this.audioVolumeButton.Name = "audioVolumeButton";
			this.audioVolumeButton.Size = new System.Drawing.Size(128, 23);
			this.audioVolumeButton.TabIndex = 25;
			this.audioVolumeButton.Text = "Lautstärke";
			this.audioVolumeButton.Click += new System.EventHandler(this.audioVolumeButton_Click);
			// 
			// forwardAudioButton
			// 
			this.forwardAudioButton.Location = new System.Drawing.Point(16, 120);
			this.forwardAudioButton.Name = "forwardAudioButton";
			this.forwardAudioButton.Size = new System.Drawing.Size(128, 23);
			this.forwardAudioButton.TabIndex = 27;
			this.forwardAudioButton.Text = "Vorspulen";
			this.forwardAudioButton.Click += new System.EventHandler(this.forwardAudioButton_Click);
			// 
			// audioPositionButton
			// 
			this.audioPositionButton.Location = new System.Drawing.Point(16, 88);
			this.audioPositionButton.Name = "audioPositionButton";
			this.audioPositionButton.Size = new System.Drawing.Size(128, 23);
			this.audioPositionButton.TabIndex = 28;
			this.audioPositionButton.Text = "Position";
			this.audioPositionButton.Click += new System.EventHandler(this.audioPositionButton_Click);
			// 
			// audioPositionTextBox
			// 
			this.audioPositionTextBox.Location = new System.Drawing.Point(160, 88);
			this.audioPositionTextBox.Name = "audioPositionTextBox";
			this.audioPositionTextBox.Size = new System.Drawing.Size(72, 20);
			this.audioPositionTextBox.TabIndex = 29;
			this.audioPositionTextBox.Text = "0";
			// 
			// demoBotton
			// 
			this.demoBotton.Location = new System.Drawing.Point(16, 328);
			this.demoBotton.Name = "demoBotton";
			this.demoBotton.Size = new System.Drawing.Size(128, 23);
			this.demoBotton.TabIndex = 30;
			this.demoBotton.Text = "Demo";
			this.demoBotton.Click += new System.EventHandler(this.demoBotton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 429);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demoBotton,
																		  this.audioPositionTextBox,
																		  this.audioPositionButton,
																		  this.forwardAudioButton,
																		  this.audioVolumeTextBox,
																		  this.audioVolumeButton,
																		  this.openVideoInFormCheckBox,
																		  this.pictureBox,
																		  this.playVideoButton,
																		  this.stopVideoButton,
																		  this.stopAutioButton,
																		  this.playAudioButton});
			this.Name = "StartForm";
			this.Text = "Multimediadateien über DirectX abspielen";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}


		private void playAudioButton_Click(object sender, System.EventArgs e)
		{
			// Audio-Instanz erzeugen und die Audiodatei abspielen
			string fileName = Path.Combine(Application.StartupPath, 
				"PPK - Resurection Space Club Remix.mp3");
			this.audio = new Audio(fileName, false);
			audio.Play();

			// Aktuelle Lautstärke auslesen
			this.audioVolumeTextBox.Text = this.audio.Volume.ToString();
		}

		private void stopAudioButton_Click(object sender, System.EventArgs e)
		{
			// Den Abspielvorgang stoppen
			if (this.audio != null)
				audio.Stop();
		}

		private void stopVideoButton_Click(object sender, System.EventArgs e)
		{
			// Den Abspielvorgang stoppen
			if (this.video != null)
				video.Stop();
		}

		private void playVideoButton_Click(object sender, System.EventArgs e)
		{
			// Video-Instanz erzeugen 
			string fileName = Path.Combine(Application.StartupPath, "Tuborg.mpeg");
			this.video = new Video(fileName, false);
			
			// Wenn das Abspielen in der PictureBox erfolgen soll, diese als Parent angeben
			if (this.openVideoInFormCheckBox.Checked)
				this.video.Owner = this.pictureBox;
			
			// Vodeo abspielen
			this.video.Play();

			
		}

		private void audioVolumeButton_Click(object sender, System.EventArgs e)
		{
			// Einstellen der Audio-Lautstärke
			try
			{
				this.audio.Volume = Convert.ToInt32(this.audioVolumeTextBox.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void forwardAudioButton_Click(object sender, System.EventArgs e)
		{
			// Einstellen der Audio-Lautstärke
			if (this.audio != null)
			{
				double position = this.audio.CurrentPosition;
				this.audio.SeekCurrentPosition(1, SeekPositionFlags.RelativePositioning);
				this.audioPositionTextBox.Text = this.audio.CurrentPosition.ToString();;
			}
		}

		private void audioPositionButton_Click(object sender, System.EventArgs e)
		{
			// Ermitteln der Audio-Position
			if (this.audio != null)
			{
				this.audioPositionTextBox.Text = this.audio.CurrentPosition.ToString();;
			}
		}

		private void demoBotton_Click(object sender, System.EventArgs e)
		{
			// Video aus dem Internet laden
			// this.video = Video.FromUrl(@"http://www.grc.nasa.gov/WWW/PAO/images/mpeg/pionlnch.mpg", false); 

			// Abspielen pausieren
			this.video.Pause();

			// Vollbildmodus einschalten
			this.video.Fullscreen = true;

			// Weiter abspielen
			this.video.Play();

			// Lautstärke über die dem Video-Objekt zugeordnete Audio-Instanz einstellen
			// (die volle Lautstärke entspricht dem Wert Null)
			this.video.Audio.Volume = -500;

			// Position (in Sekunden) abfragen
			double position = this.video.CurrentPosition;

			// Zu einer neuen Position relativ von der aktuellen aus wechseln
			// (funktionierte in meinen Tests leider nicht: Es wurde immer
			// absolut vom Anfang aus positioniert)
			this.video.SeekCurrentPosition(10, SeekPositionFlags.RelativePositioning);

			// Abspielen stoppen
			this.video.Stop();
		}
	}
}
