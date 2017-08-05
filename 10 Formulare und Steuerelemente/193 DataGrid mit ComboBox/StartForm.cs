using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Controls;

namespace DataGrid_mit_ComboBox
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid personGrid;
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
			this.personGrid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.personGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// personGrid
			// 
			this.personGrid.CaptionVisible = false;
			this.personGrid.DataMember = "";
			this.personGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.personGrid.Location = new System.Drawing.Point(16, 16);
			this.personGrid.Name = "personGrid";
			this.personGrid.Size = new System.Drawing.Size(352, 200);
			this.personGrid.TabIndex = 0;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 229);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.personGrid});
			this.Name = "StartForm";
			this.Text = "DataGrid mit ComboBox";
			this.Load += new System.EventHandler(this.StartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.personGrid)).EndInit();
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
			// DataTable-Objekte für die Daten erzeugen
			DataTable personTable = new DataTable();
			personTable.Columns.Add("FirstName", typeof(string));
			personTable.Columns.Add("LastName", typeof(string));
			personTable.Columns.Add("Country", typeof(string));
			personTable.Rows.Add(new object[] {"Zaphod", "Beeblebrox", "-"});
			personTable.Rows.Add(new object[] {"Ford", "Prefect", "-"});
			personTable.Rows.Add(new object[] {"Tricia", "McMillan", "GB"});
			personTable.Rows.Add(new object[] {"Arthur", "Dent", "GB"});

			DataTable countryTable = new DataTable();
			countryTable.Columns.Add("Id", typeof(string));
			countryTable.Columns.Add("Country", typeof(string));
			countryTable.Rows.Add(new object[] {"DE", "Deutschland"});
			countryTable.Rows.Add(new object[] {"GB", "Großbritannien"});
			countryTable.Rows.Add(new object[] {"US", "USA"});
			countryTable.Rows.Add(new object[] {"FR", "Frankreich"});
			countryTable.Rows.Add(new object[] {"IT", "Italien"});
			countryTable.Rows.Add(new object[] {"-", "Unbekannt"});

			// Die Spalten des DataGrid definieren
			DataGridTableStyle tableStyle = new DataGridTableStyle();

			// Eine TextBox-Spalte
			DataGridTextBoxColumn col1 = new DataGridTextBoxColumn();
			col1.MappingName = "FirstName";
			col1.HeaderText = "Vorname";
			col1.Width = 100;
			tableStyle.GridColumnStyles.Add(col1);

			// Noch eine TextBox-Spalte
			DataGridTextBoxColumn col2 = new DataGridTextBoxColumn();
			col2.MappingName = "LastName";
			col2.HeaderText = "Nachname";
			col2.Width = 100;
			tableStyle.GridColumnStyles.Add(col2);

			// Eine Spalte mit der DataGridComboBoxColumn
			DataGridComboBoxColumn col3 = new DataGridComboBoxColumn();
			col3.MappingName = "Country";
			col3.HeaderText = "Land";
			col3.Width = 100;
			tableStyle.GridColumnStyles.Add(col3);

			// Festlegen der bevorzugten Zeilenhöhe auf die Höhe der ComboBox
			tableStyle.PreferredRowHeight = col3.ComboBox.Height;

			// Füllen der ComboBox
			col3.ComboBox.ValueMember = "Id";
			col3.ComboBox.DisplayMember = "Country";
			col3.ComboBox.DataSource = countryTable;

			// Tabellenstil an das DataGrid übergeben
			this.personGrid.TableStyles.Add(tableStyle);
			
			
			// DataTable an das DataGrid anbinden
			this.personGrid.DataSource = personTable;
		}
	}
}
