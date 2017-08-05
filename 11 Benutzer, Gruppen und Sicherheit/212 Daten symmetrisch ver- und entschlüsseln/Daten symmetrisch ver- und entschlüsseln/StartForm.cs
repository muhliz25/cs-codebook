using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Addison_Wesley.Codebook.Security; 
using System.Windows.Forms;

namespace Ver_und_entschlüsseln
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button demoButton;
		private System.Windows.Forms.TextBox infoTextBox;
		private System.ComponentModel.Container components = null;

		[STAThread]
		static void Main()
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
			this.demoButton = new System.Windows.Forms.Button();
			this.infoTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// demoButton
			// 
			this.demoButton.Location = new System.Drawing.Point(8, 16);
			this.demoButton.Name = "demoButton";
			this.demoButton.Size = new System.Drawing.Size(88, 32);
			this.demoButton.TabIndex = 0;
			this.demoButton.Text = "Demo";
			this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.infoTextBox.Location = new System.Drawing.Point(8, 56);
			this.infoTextBox.Multiline = true;
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.Size = new System.Drawing.Size(408, 264);
			this.infoTextBox.TabIndex = 1;
			this.infoTextBox.Text = "";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.infoTextBox,
																		  this.demoButton});
			this.Name = "StartForm";
			this.Text = "SymetricEncryptor-Demo";
			this.ResumeLayout(false);

		}
		#endregion

		private void demoButton_Click(object sender, System.EventArgs e)
		{
			SymmetricEncryptor se = null;
			try
			{
				// SymmetricEncryptor-Instanz erzeugen und den eigenen Schlüssel und
				// Initialisierungsvektor übergeben
				se = new SymmetricEncryptor(SymmetricEncryptAlgorithm.Rijndael);
				se.Key = "dfd0ß3q3ßdsäfßq3#sfjbxya<xsd-:,?";
				se.IV = "460?-B,-7,kerkh-";

				// Einige Informationen ausgeben
				infoTextBox.AppendText("Schlüssel: " + se.Key + "\r\n");
				infoTextBox.AppendText("Initialisierungsvektor: " + se.IV + "\r\n");
				infoTextBox.AppendText("Chiffrier-Modus: " + 
					Enum.GetName(typeof(CipherMode), se.CipherMode) + "\r\n"); 
				infoTextBox.AppendText("Blockgröße: " + se.BlockSize + "\r\n"); 
				infoTextBox.AppendText("Padding-Modus: " + 
					Enum.GetName(typeof(PaddingMode), se.PaddingMode) + "\r\n"); 
				infoTextBox.AppendText("\r\n");;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			// Einen String verschlüsseln und wieder entschlüsseln
			string sourceString = "Das ist ein Test-String mit Umlauten: äöü";
			string encryptedString = se.Encrypt(sourceString);
			string decryptedString = se.Decrypt(encryptedString);
			infoTextBox.AppendText("Quellstring: " + sourceString + "\r\n");
			infoTextBox.AppendText("Verschlüsselt: " + encryptedString + "\r\n");
			infoTextBox.AppendText("Entschlüsselt: " + decryptedString + "\r\n");
			infoTextBox.AppendText("\r\n");;

			// Eine Datei verschlüsseln
			string sourceFileName = Path.Combine(Application.StartupPath,
				"Hitchhiker.txt");
			string destFileName = Path.Combine(Application.StartupPath,
				"Hitchhiker_Encrypted.txt");
			FileStream sourceStream = new FileStream(sourceFileName, FileMode.Open,
				FileAccess.Read);
			FileStream destStream = new FileStream(destFileName, FileMode.Create,
				FileAccess.Write);
			se.Encrypt(sourceStream, destStream);
			sourceStream.Close();
			destStream.Close();

			// Die Datei wieder entschlüsseln
			sourceFileName = Path.Combine(Application.StartupPath,
				"Hitchhiker_Encrypted.txt");
			destFileName = Path.Combine(Application.StartupPath,
				"Hitchhiker_Decrypted.txt");
			sourceStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read);
			destStream = new FileStream(destFileName, FileMode.Create, FileAccess.Write);
			se.Decrypt(sourceStream, destStream);
			sourceStream.Close();
			destStream.Close();

			// MemoryStream ver- und entschlüsseln
			MemoryStream decryptedData = new MemoryStream(
				new Byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9});

			// Streamdaten ausgeben
			infoTextBox.AppendText("Originaler MemoryStream:\r\n");
			int value;
			while ((value = decryptedData.ReadByte()) > -1)
				infoTextBox.AppendText(value + " ");
			decryptedData.Seek(0, SeekOrigin.Begin);
			infoTextBox.AppendText("\r\n\r\n");

			// MemoryStream verschlüsseln
			MemoryStream encryptedData = new MemoryStream();
			se.Encrypt(decryptedData, encryptedData);

			// Streamdaten ausgeben
			infoTextBox.AppendText("Verschlüsselter MemoryStream:\r\n");
			encryptedData.Seek(0, SeekOrigin.Begin);
			while ((value = encryptedData.ReadByte()) > -1)
				infoTextBox.AppendText(value + " ");
			encryptedData.Seek(0, SeekOrigin.Begin);
			infoTextBox.AppendText("\r\n\r\n");

			// MemoryStream entschlüsseln
			decryptedData.Close();
			decryptedData = new MemoryStream();
			se.Decrypt(encryptedData, decryptedData);

			// Ergebnis ausgeben
			infoTextBox.AppendText("Entschlüsselter MemoryStream:\r\n");
			decryptedData.Seek(0, SeekOrigin.Begin);
			while ((value = decryptedData.ReadByte()) > -1)
				infoTextBox.AppendText(value + " ");
			infoTextBox.AppendText("\r\n\r\n");

			// Streams schließen
			encryptedData.Close();
			decryptedData.Close();
		}


	}
}
