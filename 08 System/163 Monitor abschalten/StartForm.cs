using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.System;

namespace Monitor_abschalten
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button PowerOffButton;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button PowerOfAndOnButton;
		private System.Windows.Forms.Button LowPowerButton;
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
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.PowerOffButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.PowerOfAndOnButton = new System.Windows.Forms.Button();
			this.LowPowerButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PowerOffButton
			// 
			this.PowerOffButton.Location = new System.Drawing.Point(16, 32);
			this.PowerOffButton.Name = "PowerOffButton";
			this.PowerOffButton.Size = new System.Drawing.Size(264, 23);
			this.PowerOffButton.TabIndex = 0;
			this.PowerOffButton.Text = "Monitor abschalten";
			this.PowerOffButton.Click += new System.EventHandler(this.PowerOffButton_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// PowerOfAndOnButton
			// 
			this.PowerOfAndOnButton.Location = new System.Drawing.Point(16, 64);
			this.PowerOfAndOnButton.Name = "PowerOfAndOnButton";
			this.PowerOfAndOnButton.Size = new System.Drawing.Size(264, 23);
			this.PowerOfAndOnButton.TabIndex = 1;
			this.PowerOfAndOnButton.Text = "Monitor ab- und über Timer wieder einschalten";
			this.PowerOfAndOnButton.Click += new System.EventHandler(this.PowerOfAndOnButton_Click);
			// 
			// LowPowerButton
			// 
			this.LowPowerButton.Location = new System.Drawing.Point(16, 96);
			this.LowPowerButton.Name = "LowPowerButton";
			this.LowPowerButton.Size = new System.Drawing.Size(264, 23);
			this.LowPowerButton.TabIndex = 2;
			this.LowPowerButton.Text = "Monitor in Low Power Modus schalten";
			this.LowPowerButton.Click += new System.EventHandler(this.LowPowerButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.LowPowerButton,
																		  this.PowerOfAndOnButton,
																		  this.PowerOffButton});
			this.Name = "StartForm";
			this.Text = "Monitor abschalten";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void PowerOffButton_Click(object sender, System.EventArgs e)
		{
			Monitor.TurnOff();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Monitor.TurnOn();
			timer1.Enabled = false;
		}

		private void PowerOfAndOnButton_Click(object sender, System.EventArgs e)
		{
			Monitor.TurnOff();
			timer1.Enabled = true;
		}

		private void LowPowerButton_Click(object sender, System.EventArgs e)
		{
			Monitor.SwitchToLowPower();
		}
	}
}
