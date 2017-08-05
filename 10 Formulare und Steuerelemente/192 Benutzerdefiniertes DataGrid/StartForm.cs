using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Benutzerdefiniertes_DataGrid
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid productsGrid;
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
			this.productsGrid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.productsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// productsGrid
			// 
			this.productsGrid.CaptionVisible = false;
			this.productsGrid.DataMember = "";
			this.productsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.productsGrid.Location = new System.Drawing.Point(8, 16);
			this.productsGrid.Name = "productsGrid";
			this.productsGrid.Size = new System.Drawing.Size(368, 232);
			this.productsGrid.TabIndex = 0;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.productsGrid});
			this.Name = "StartForm";
			this.Text = "Benutzerdefniertes DataGrid";
			this.Load += new System.EventHandler(this.StartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.productsGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		/* Erweiterte Klasse für eine Textspalte, die die Zellenfarbe 
		 * ändert wenn es sich um einen Auslaufartikel handelt */
		private class ExtDataGridTextBoxColumn: DataGridTextBoxColumn 
		{
			/* Überschreiben der Paint-Methode */
			protected override void Paint(Graphics g, Rectangle bounds,
				CurrencyManager source, int rowNum, Brush backBrush,
				Brush foreBrush, bool alignToRight)
			{
				// Überprüfen, ob es sich um einen Auslaufartikel handelt
				DataView dataView = (DataView)source.List;
				bool discontinued = (bool)dataView[rowNum]["Discontinued"];
				if (discontinued)
				{
					backBrush = new SolidBrush(Color.Red);
					foreBrush = new SolidBrush(Color.Yellow);
				}
				base.Paint(g, bounds, source, rowNum, backBrush,
					foreBrush, alignToRight);
			}
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Einlesen der Products-Tabelle der Northwind-Datenbank
			string server = ConfigurationSettings.AppSettings["server"];
			SqlConnection connection = new SqlConnection("Server=" + server +
				";Database=Northwind;Trusted_Connection=Yes");
			try
			{
				connection.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Verbindungsaufbau zur Northwind-" + 
					"Datenbank:" + ex.Message + "\r\nKontrollieren Sie die " +
					"Einstellungen in der Anwendungskonfiguration",
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT ProductId, " +
				"ProductName, Discontinued FROM Products", connection);
			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Products");

			// DataGridTableStyle-Objekt erzeugen und initialisieren
			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = "Products";
   
			// Spalten des DataSet definieren
			DataGridTextBoxColumn col1 = new ExtDataGridTextBoxColumn();
			col1.HeaderText = "Artikel-Nr";
			col1.MappingName = "ProductId";
			col1.Width = 70;
			col1.ReadOnly = true;
			tableStyle.GridColumnStyles.Add(col1);

			DataGridTextBoxColumn col2 = new ExtDataGridTextBoxColumn();
			col2.HeaderText = "Artikelname";
			col2.MappingName = "ProductName";
			col2.Width = 150;
			tableStyle.GridColumnStyles.Add(col2);

			DataGridBoolColumn col3 = new DataGridBoolColumn();
			col3.HeaderText = "Auslaufartikel";
			col3.MappingName = "Discontinued";
			col3.AllowNull = false; // Dreiwertigkeit unterbinden
			col3.Width = 80;
			tableStyle.GridColumnStyles.Add(col3);

			// DataGridTableStyle-Instanz dem DataGrid zuweisen
			this.productsGrid.TableStyles.Add(tableStyle);
			
			// DataSet an das DataGrid anbinden
			this.productsGrid.DataMember = "Products";
			this.productsGrid.DataSource = dataSet;
		}
	}
}
