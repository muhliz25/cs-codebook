using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace Parameter_an_Threads_übergeben
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.TextBox minValueTextBox;
		private System.Windows.Forms.TextBox maxValueTextBox;
		private System.Windows.Forms.Label label2;
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
			this.startButton = new System.Windows.Forms.Button();
			this.minValueTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.maxValueTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(16, 64);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(120, 24);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "Thread starten";
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// minValueTextBox
			// 
			this.minValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.minValueTextBox.Location = new System.Drawing.Point(48, 8);
			this.minValueTextBox.Name = "minValueTextBox";
			this.minValueTextBox.Size = new System.Drawing.Size(344, 20);
			this.minValueTextBox.TabIndex = 1;
			this.minValueTextBox.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Von:";
			// 
			// infoLabel
			// 
			this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.infoLabel.Location = new System.Drawing.Point(16, 112);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(384, 24);
			this.infoLabel.TabIndex = 3;
			// 
			// maxValueTextBox
			// 
			this.maxValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.maxValueTextBox.Location = new System.Drawing.Point(48, 32);
			this.maxValueTextBox.Name = "maxValueTextBox";
			this.maxValueTextBox.Size = new System.Drawing.Size(344, 20);
			this.maxValueTextBox.TabIndex = 4;
			this.maxValueTextBox.Text = "0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 32);
			this.label2.Name = "label2";
			this.label2.TabIndex = 5;
			this.label2.Text = "Bis:";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 149);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.maxValueTextBox,
																		  this.label2,
																		  this.infoLabel,
																		  this.minValueTextBox,
																		  this.label1,
																		  this.startButton});
			this.Name = "StartForm";
			this.Text = "Parameter an Threads übergeben und Ergebnisse auslesen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		/* Klasse für den Thread */
		private class PrimeNumberCalculator
		{
			public long MinValue;
			public long MaxValue;
			public Control ResultControl;

			/* Methode für den Thread */
			public void Calc()
			{
				// Berechnen aller Primzahlen von MinValue bis MaxValue
				for (long i = this.MinValue; i <= this.MaxValue; i++)
				{
					bool isPrimeNumber = true;
					for (long j = 2; j < i; j++)
					{
						if (i % j == 0)
						{
							isPrimeNumber = false;
							break;
						}
						if (isPrimeNumber)
						{
							lock (this.ResultControl)
							{
								this.ResultControl.Text = i.ToString();
							}
						}
					}
				}
			}
		}
		
		private void startButton_Click(object sender, System.EventArgs e)
		{
			// Instanz der PrimeNumberCalculator-Klasse erzeugen und initialisieren
			PrimeNumberCalculator pnc = new PrimeNumberCalculator();
			pnc.MinValue = Convert.ToInt64(this.minValueTextBox.Text);
			pnc.MaxValue = Convert.ToInt64(this.maxValueTextBox.Text);
			pnc.ResultControl = this.infoLabel;

			// Thread mit der Calc-Methode des PrimeNumberCalculator-Objekts starten
			Thread thread = new Thread(new ThreadStart(pnc.Calc));
			thread.IsBackground = true;
			thread.Start();
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			this.minValueTextBox.Text = "0";
			this.maxValueTextBox.Text = long.MaxValue.ToString();
		}
	}
}
