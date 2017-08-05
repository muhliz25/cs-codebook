using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Aufzählungen_in_Strings_umwandeln
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox daysListBox;
		private System.Windows.Forms.Label infoLabel;
		private System.ComponentModel.Container components = null;

		public StartForm()
		{
			InitializeComponent();
		}

		[STAThread]
		static void Main()
		{
			Application.Run(new StartForm());
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
			this.daysListBox = new System.Windows.Forms.ListBox();
			this.infoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// daysListBox
			// 
			this.daysListBox.Location = new System.Drawing.Point(16, 24);
			this.daysListBox.Name = "daysListBox";
			this.daysListBox.Size = new System.Drawing.Size(176, 134);
			this.daysListBox.TabIndex = 0;
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(16, 168);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(304, 23);
			this.infoLabel.TabIndex = 1;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 213);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.infoLabel,
																		  this.daysListBox});
			this.Name = "StartForm";
			this.Text = "Aufzählungs-Konstantennamen auslesen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Alle Werte einer Aufzählung als String auslesen
			string[] enumNames = Enum.GetNames(typeof(DayOfWeek));
			for (int i = 0; i < enumNames.Length; i++)
				this.daysListBox.Items.Add(enumNames[i]);

			// Einen bestimmten Wert auslesen
			string name = Enum.GetName(typeof(DayOfWeek), 0);
			this.infoLabel.Text = "Der Name der Konstante mit dem Wert 0 ist " + name;
		}
	}
}
