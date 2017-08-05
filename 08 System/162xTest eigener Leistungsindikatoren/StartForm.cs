using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace Test_eigener_Leistungsindikatoren
{

	public class StartForm : System.Windows.Forms.Form
	{
		/* Struktur LARGE_INTEGER für QueryPerformanceCounter */
		internal struct LARGE_INTEGER
		{
			public UInt32 lowpart;
			public UInt32 highpart;

			// Methode zum Umrechnen des Werts in einen 64-Bit-Integerwert
			public long GetValue()
			{
				Int64 value = highpart;
				value = (value << 32) + lowpart;
				return value;
			}
		} 
		
		/* Import der benötigten API-Funktionen */
		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceCounter(ref LARGE_INTEGER lpPerformanceCount);

		[DllImport("kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(ref long lpFrequency);

		private long performanceFrequency;

		PerformanceCounter pc1;
		PerformanceCounter pc2;
		PerformanceCounter pc3;
		PerformanceCounter pc4;
		PerformanceCounter pc5;
		PerformanceCounter pc6;

		long startTicks = 0;
		DateTime lastAverageTimeMeasure = new DateTime();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox valueTextBox;
		private System.Windows.Forms.Button setValueButton;
		private System.Windows.Forms.Button readValueButton;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button averageTimerDemoButton;
		private System.Windows.Forms.Button readAverageTimerButton;
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
			this.label1 = new System.Windows.Forms.Label();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.setValueButton = new System.Windows.Forms.Button();
			this.readValueButton = new System.Windows.Forms.Button();
			this.infoLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.averageTimerDemoButton = new System.Windows.Forms.Button();
			this.readAverageTimerButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Wert:";
			// 
			// valueTextBox
			// 
			this.valueTextBox.Location = new System.Drawing.Point(48, 16);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.TabIndex = 1;
			this.valueTextBox.Text = "100";
			this.valueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valueTextBox_KeyPress);
			// 
			// setValueButton
			// 
			this.setValueButton.Location = new System.Drawing.Point(8, 48);
			this.setValueButton.Name = "setValueButton";
			this.setValueButton.Size = new System.Drawing.Size(88, 24);
			this.setValueButton.TabIndex = 2;
			this.setValueButton.Text = "Setzen";
			this.setValueButton.Click += new System.EventHandler(this.setValueButton_Click);
			// 
			// readValueButton
			// 
			this.readValueButton.Location = new System.Drawing.Point(8, 80);
			this.readValueButton.Name = "readValueButton";
			this.readValueButton.Size = new System.Drawing.Size(88, 24);
			this.readValueButton.TabIndex = 3;
			this.readValueButton.Text = "Lesen";
			this.readValueButton.Click += new System.EventHandler(this.readValueButton_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(8, 112);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(376, 216);
			this.infoLabel.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(208, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(272, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "AverageTimer:";
			// 
			// averageTimerDemoButton
			// 
			this.averageTimerDemoButton.Location = new System.Drawing.Point(208, 48);
			this.averageTimerDemoButton.Name = "averageTimerDemoButton";
			this.averageTimerDemoButton.Size = new System.Drawing.Size(80, 24);
			this.averageTimerDemoButton.TabIndex = 6;
			this.averageTimerDemoButton.Text = "Demo";
			this.averageTimerDemoButton.Click += new System.EventHandler(this.averageTimerDemoButton_Click);
			// 
			// readAverageTimerButton
			// 
			this.readAverageTimerButton.Location = new System.Drawing.Point(208, 80);
			this.readAverageTimerButton.Name = "readAverageTimerButton";
			this.readAverageTimerButton.Size = new System.Drawing.Size(80, 24);
			this.readAverageTimerButton.TabIndex = 7;
			this.readAverageTimerButton.Text = "Lesen";
			this.readAverageTimerButton.Click += new System.EventHandler(this.readAverageTimerButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 421);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.readAverageTimerButton,
																		  this.averageTimerDemoButton,
																		  this.label2,
																		  this.infoLabel,
																		  this.readValueButton,
																		  this.setValueButton,
																		  this.valueTextBox,
																		  this.label1});
			this.Name = "StartForm";
			this.Text = "Test eigener Leistungsindikatoren";
			this.Load += new System.EventHandler(this.StartForm_Load);
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
			// Ermitteln der Basis-Frequenz des Motherboard
			if (QueryPerformanceFrequency(ref performanceFrequency) == false)
				MessageBox.Show("Die Basis-Motherboardfrequenz konnte nicht ermittelt werden",
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			// Ermitteln, ob die Leistungsindikatoren-Kategorie bereits existiert
			// und Löschen derselben falls dies der Fall ist
			if (PerformanceCounterCategory.Exists("Performance-Counter-Test"))
				PerformanceCounterCategory.Delete("Performance-Counter-Test");

			// Erzeugen einer neuen Leistungsindikatoren-Kategorie mit
			// zwei Leistungsindikatoren 
			CounterCreationDataCollection ccdCol = new CounterCreationDataCollection();
			CounterCreationData ccd1 = new CounterCreationData("Demo1", "Demo-Counter", PerformanceCounterType.NumberOfItems32);
			CounterCreationData ccd2 = new CounterCreationData("Demo2", "Demo-Counter", PerformanceCounterType.CounterDelta32);
			CounterCreationData ccd3 = new CounterCreationData("Demo3", "Demo-Counter", PerformanceCounterType.CounterDelta32);
			// CounterCreationData ccd4 = new CounterCreationData("Demo3Base", "Basis für Demo3", PerformanceCounterType.AverageBase);
			CounterCreationData ccd5 = new CounterCreationData("Demo4", "Demo-Counter", PerformanceCounterType.AverageTimer32);
			CounterCreationData ccd6 = new CounterCreationData("Demo4Base", "Basis für Demo4", PerformanceCounterType.AverageBase);

			ccdCol.Add(ccd1);
			ccdCol.Add(ccd2);
			ccdCol.Add(ccd3);
			//ccdCol.Add(ccd4);
			ccdCol.Add(ccd5);
			ccdCol.Add(ccd6);

			PerformanceCounterCategory.Create("Performance-Counter-Test", "Performance-Counter für Testzwecke", ccdCol);

			pc1 = new PerformanceCounter("Performance-Counter-Test", "Demo1", false);
			pc2 = new PerformanceCounter("Performance-Counter-Test", "Demo2", false);
			pc3 = new PerformanceCounter("Performance-Counter-Test", "Demo3", false);
			pc4 = new PerformanceCounter("Performance-Counter-Test", "Demo3Base", false);
			pc5 = new PerformanceCounter("Performance-Counter-Test", "Demo4", false);
			pc6 = new PerformanceCounter("Performance-Counter-Test", "Demo4Base", false);

			//pc3.NextValue();
			pc3.RawValue = 0;
			pc5.RawValue = 0;


		}

		private void setValueButton_Click(object sender, System.EventArgs e)
		{
			// Aktualisieren der eigenen Leistungsindikatoren
			pc1.RawValue = Convert.ToInt32(valueTextBox.Text);
			pc2.RawValue = Convert.ToInt32(valueTextBox.Text);
			pc3.IncrementBy(Convert.ToInt32(valueTextBox.Text));
			pc4.Increment();
		}

		private void readValueButton_Click(object sender, System.EventArgs e)
		{
			infoLabel.Text =
				"Demo1: " + pc1.NextValue() + "\r\n" + 
				"Demo2: " + pc2.NextValue() + "\r\n" + 
				"Demo3: " + pc3.NextValue();
		}

		private void averageTimerDemoButton_Click(object sender, System.EventArgs e)
		{
			// Ermitteln der Systemticks
			LARGE_INTEGER pc = new LARGE_INTEGER();
			if (QueryPerformanceCounter(ref pc))
			{
				long systemTicks = pc.GetValue();
				
				pc5.IncrementBy(systemTicks - startTicks);
				// pc5.RawValue = systemTicks - startTicks;
				pc6.IncrementBy(1);
			
				infoLabel.Text = "Sekunden zwischen den letzten beiden Clicks: " +
					((systemTicks - startTicks) / (double)performanceFrequency);

				startTicks = systemTicks;
			}
			else
			{
				infoLabel.Text = "Kann QueryPerformanceCounter nicht verwenden";
			}
				

		}

		private void valueTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				setValueButton_Click(null, null);
				valueTextBox.SelectAll();
			}

		}

		private void readAverageTimerButton_Click(object sender, System.EventArgs e)
		{
			
			infoLabel.Text = "Durchschnittliche Sekunden zwischen den Clicks seit " + 
				lastAverageTimeMeasure.ToString() + ": " +  pc5.NextValue() ;
			lastAverageTimeMeasure = DateTime.Now;
		}
	}
}
