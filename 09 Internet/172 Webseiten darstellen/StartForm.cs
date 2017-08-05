using System;
using System.Windows.Forms;
using System.Reflection;

namespace Webseiten_darstellen
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Button forwardButton;
		private System.Windows.Forms.Button reloadButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Button printButton;
		private System.Windows.Forms.Button homeButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button saveButton;
		private AxSHDocVw.AxWebBrowser browser;
		private System.ComponentModel.IContainer components;

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StartForm));
			this.label1 = new System.Windows.Forms.Label();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.openButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.forwardButton = new System.Windows.Forms.Button();
			this.reloadButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.printButton = new System.Windows.Forms.Button();
			this.homeButton = new System.Windows.Forms.Button();
			this.stopButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.browser = new AxSHDocVw.AxWebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.browser)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Url:";
			// 
			// urlTextBox
			// 
			this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.urlTextBox.Location = new System.Drawing.Point(32, 48);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.Size = new System.Drawing.Size(536, 20);
			this.urlTextBox.TabIndex = 9;
			this.urlTextBox.Text = "";
			this.urlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.urlTextBox_KeyPress);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// openButton
			// 
			this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openButton.Location = new System.Drawing.Point(576, 48);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(72, 24);
			this.openButton.TabIndex = 10;
			this.openButton.Text = "Öffnen";
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// backButton
			// 
			this.backButton.Location = new System.Drawing.Point(88, 8);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(72, 23);
			this.backButton.TabIndex = 2;
			this.backButton.Text = "Zurück";
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// forwardButton
			// 
			this.forwardButton.Location = new System.Drawing.Point(168, 8);
			this.forwardButton.Name = "forwardButton";
			this.forwardButton.Size = new System.Drawing.Size(72, 23);
			this.forwardButton.TabIndex = 3;
			this.forwardButton.Text = "Vor";
			this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
			// 
			// reloadButton
			// 
			this.reloadButton.Enabled = false;
			this.reloadButton.Location = new System.Drawing.Point(328, 8);
			this.reloadButton.Name = "reloadButton";
			this.reloadButton.Size = new System.Drawing.Size(72, 23);
			this.reloadButton.TabIndex = 5;
			this.reloadButton.Text = "Neu laden";
			this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
			// 
			// editButton
			// 
			this.editButton.Enabled = false;
			this.editButton.Location = new System.Drawing.Point(408, 8);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(72, 23);
			this.editButton.TabIndex = 6;
			this.editButton.Text = "Bearbeiten";
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// printButton
			// 
			this.printButton.Enabled = false;
			this.printButton.Location = new System.Drawing.Point(488, 8);
			this.printButton.Name = "printButton";
			this.printButton.Size = new System.Drawing.Size(72, 23);
			this.printButton.TabIndex = 7;
			this.printButton.Text = "Drucken";
			this.printButton.Click += new System.EventHandler(this.printButton_Click);
			// 
			// homeButton
			// 
			this.homeButton.Location = new System.Drawing.Point(8, 8);
			this.homeButton.Name = "homeButton";
			this.homeButton.Size = new System.Drawing.Size(72, 23);
			this.homeButton.TabIndex = 0;
			this.homeButton.Text = "Home";
			this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
			// 
			// stopButton
			// 
			this.stopButton.Location = new System.Drawing.Point(248, 8);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(72, 23);
			this.stopButton.TabIndex = 4;
			this.stopButton.Text = "Stop";
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Enabled = false;
			this.saveButton.Location = new System.Drawing.Point(568, 8);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(72, 23);
			this.saveButton.TabIndex = 8;
			this.saveButton.Text = "Speichern";
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// browser
			// 
			this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.browser.Enabled = true;
			this.browser.Location = new System.Drawing.Point(8, 80);
			this.browser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("browser.OcxState")));
			this.browser.Size = new System.Drawing.Size(640, 296);
			this.browser.TabIndex = 11;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 381);
			this.Controls.Add(this.browser);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.homeButton);
			this.Controls.Add(this.printButton);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.reloadButton);
			this.Controls.Add(this.forwardButton);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.openButton);
			this.Controls.Add(this.urlTextBox);
			this.Controls.Add(this.label1);
			this.Name = "StartForm";
			this.Text = "Webseiten darstellen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.browser)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Zur Startseite wechseln
			browser.GoHome();
		}

		private void openButton_Click(object sender, System.EventArgs e)
		{
			// Navigieren
			object missing = Missing.Value;
			object url = urlTextBox.Text;
			browser.Navigate2(ref url, ref missing, ref missing, ref missing, ref missing);
		}

		private void urlTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true; // Warnton verhindern

				// Navigieren
				object missing = Missing.Value;
				object url = urlTextBox.Text;
				browser.Navigate2(ref url, ref missing, ref missing, ref missing, ref missing);
			}
		}
		private void homeButton_Click(object sender, System.EventArgs e)
		{
			browser.GoHome();
		}

		private void backButton_Click(object sender, System.EventArgs e)
		{
			browser.GoBack();
		}

		private void forwardButton_Click(object sender, System.EventArgs e)
		{
			browser.GoForward();
		}

		private void reloadButton_Click(object sender, System.EventArgs e)
		{
			// Aufruf des Refresh-Befehls über ExecWB 
			object missing = Missing.Value;
			browser.ExecWB(SHDocVw.OLECMDID.OLECMDID_REFRESH,
				SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
				ref missing, ref missing);
		}

		private void editButton_Click(object sender, System.EventArgs e)
		{
			// Referenzieren der IHTMLDocument2-Schnittstelle des Dokuments
			mshtml.IHTMLDocument2 htmlDocument =
				(mshtml.IHTMLDocument2)browser.Document;

			if (htmlDocument != null)
			{
				if (editButton.Text == "Bearbeiten")
				{
					// Edit-Modus einschalten
					editButton.Text = "Beenden";
					htmlDocument.designMode = "On";	
				}
				else
				{
					// Edit-Modus ausschalten
					editButton.Text = "Bearbeiten";
					htmlDocument.designMode = "Off";	
				}
			}
		}

		private void printButton_Click(object sender, System.EventArgs e)
		{
			// Aufruf des Drucken-Befehls über ExecWB 
			object missing = Missing.Value;
			browser.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINT,
				SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER,
				ref missing, ref missing);		
		}


		private void browser_TitleChange(object sender, AxSHDocVw.DWebBrowserEvents2_TitleChangeEvent e)
		{
			this.Text = e.text + " - " + Application.ProductName;
		}

		private void browser_CommandStateChange(object sender,
			AxSHDocVw.DWebBrowserEvents2_CommandStateChangeEvent e)
		{
			// Änderung des Befehls-Status
			switch (e.command)
			{
				case (int)SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEBACK:
					// Der Status des Zurück-Befehls hat sich geändert
					backButton.Enabled = e.enable;
					break;
   
				case (int)SHDocVw.CommandStateChangeConstants.CSC_NAVIGATEFORWARD:
					// Der Status des Vorwärts-Befehls hat sich geändert
					forwardButton.Enabled = e.enable;
					break;

				case (int)SHDocVw.CommandStateChangeConstants.CSC_UPDATECOMMANDS:
					// Der Status eines Befehls, der sich auf ein geladenes Dokument
					// bezieht, hat sich geändert

					// Den int-Wert für die Flags ermitteln, die bestimmen, dass
					// ein Befehl unterstützt wird und aktiviert ist 
					int enabled = Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_SUPPORTED)
						+ Convert.ToInt32(SHDocVw.OLECMDF.OLECMDF_ENABLED);

					// Den Status der einzelnen Befehle abfragen und mit dem int-Wert für
					// den unterstützten, aktivierten Befehl vergleichen
					reloadButton.Enabled = (enabled == 
						(int)(browser.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_REFRESH)));
					saveButton.Enabled = (enabled ==
						(int)(browser.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS)));
					printButton.Enabled = (enabled ==
						(int)(browser.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_PRINT))); 
					editButton.Enabled = (enabled ==
						(int)(browser.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS)));
					printButton.Enabled = (enabled == 
						(int)(browser.QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_PRINT)));
					// Der Status des Stop-Buttons muss über die Busy-Eigenschaft
					// abgefragt werden, damit dieser korrekt ausgewertet wird
					stopButton.Enabled = browser.Busy;
					break;
			}
		}

		private void saveButton_Click(object sender, System.EventArgs e)
		{
			// Aufruf des Speichern-Befehls über ExecWB 
			object missing = Missing.Value;
			browser.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS,
				SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
				ref missing, ref missing);
		}

		private void stopButton_Click(object sender, System.EventArgs e)
		{
			browser.Stop();
		}
	}
}
