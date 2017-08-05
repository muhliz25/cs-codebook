using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace Den_Inhalt_eines_Archivs_lesen
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button readButton;
		private System.Windows.Forms.PictureBox zipPictureBox;
		private System.Windows.Forms.TextBox zipTextBox;
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
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.readButton = new System.Windows.Forms.Button();
			this.zipPictureBox = new System.Windows.Forms.PictureBox();
			this.zipTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// readButton
			// 
			this.readButton.Location = new System.Drawing.Point(8, 16);
			this.readButton.Name = "readButton";
			this.readButton.TabIndex = 2;
			this.readButton.Text = "Lesen";
			this.readButton.Click += new System.EventHandler(this.readButton_Click);
			// 
			// zipPictureBox
			// 
			this.zipPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
			this.zipPictureBox.Location = new System.Drawing.Point(384, 48);
			this.zipPictureBox.Name = "zipPictureBox";
			this.zipPictureBox.Size = new System.Drawing.Size(160, 120);
			this.zipPictureBox.TabIndex = 1;
			this.zipPictureBox.TabStop = false;
			// 
			// zipTextBox
			// 
			this.zipTextBox.Location = new System.Drawing.Point(8, 48);
			this.zipTextBox.Multiline = true;
			this.zipTextBox.Name = "zipTextBox";
			this.zipTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.zipTextBox.Size = new System.Drawing.Size(368, 256);
			this.zipTextBox.TabIndex = 0;
			this.zipTextBox.Text = "";
			// 
			// StartForm
			// 
			this.AcceptButton = this.readButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.readButton,
																		  this.zipPictureBox,
																		  this.zipTextBox});
			this.Name = "StartForm";
			this.Text = "Den Inhalt eines Zip-Archivs lesen";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void readButton_Click(object sender, System.EventArgs e)
		{
			// Dateiname der Zip-Datei
			string zipFileName = Path.Combine(Application.StartupPath, "demo.zip");

			// Zip-Datei öffnen
			ZipInputStream zipInputStream = new ZipInputStream(
				new FileStream(zipFileName, FileMode.Open, FileAccess.Read));

			// Alle Dateien durchgehen
			ZipEntry zipEntry;
			while ((zipEntry = zipInputStream.GetNextEntry()) != null)
			{
				// Daten in einer Schleife (blockweise) einlesen (die Read-Methode
				// liefert leider nicht immer alle restlichen Daten im Stream,
				// deswegen muss in einer Schleife eingelesen werden)
				byte[] data = new byte[zipEntry.Size];
				int dataIndex = 0;
				byte[] buffer = new byte[1024];
				int count = 0;
				do
				{
					// Daten lesen
					count = zipInputStream.Read(buffer, 0, buffer.Length);

					// Das eingelesene Array an das data-Array hinten anhängen
					Array.Copy(buffer, 0, data, dataIndex, count);

					// Start-Index für das data-Array hochzählen
					dataIndex += count;
				} while (count > 0);
		
				// Überprüfen, ob es sich um eine Textdatei handelt
				FileInfo fi = new FileInfo(zipEntry.Name);
				if (fi.Extension == ".txt")
				{
					// Daten in einen Text konvertieren
					string text = Encoding.ASCII.GetString(data); 
					this.zipTextBox.Text  = text;
				}

				// Überprüfen, ob es sich um eine Bitmap-Grafik handelt
				if (fi.Extension == ".jpg" || fi.Extension == ".jpeg" 
					|| fi.Extension == ".gif" || fi.Extension == ".bmp")
				{
					// Daten in eine Bitmap-Grafik umwandeln
					Bitmap bitmap = new Bitmap(new MemoryStream(data));  
					this.zipPictureBox.Image = bitmap; 
				}
			}

			// ZipInputStream schließen
			zipInputStream.Close();
		}
	}
}