using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Binäre_Daten_in_einer_Datenbank
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox personIdTextBox;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.PictureBox personPictureBox;
		private System.Windows.Forms.Button readAuthor;
		private System.Windows.Forms.Button createDatabase;
		private System.Windows.Forms.Button addAuthorButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox authorFirstNameTextBox;
		private System.Windows.Forms.TextBox authorLastNameTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
			this.readAuthor = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.personIdTextBox = new System.Windows.Forms.TextBox();
			this.infoLabel = new System.Windows.Forms.Label();
			this.personPictureBox = new System.Windows.Forms.PictureBox();
			this.createDatabase = new System.Windows.Forms.Button();
			this.addAuthorButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.authorFirstNameTextBox = new System.Windows.Forms.TextBox();
			this.authorLastNameTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// readAuthor
			// 
			this.readAuthor.Location = new System.Drawing.Point(24, 112);
			this.readAuthor.Name = "readAuthor";
			this.readAuthor.Size = new System.Drawing.Size(120, 24);
			this.readAuthor.TabIndex = 0;
			this.readAuthor.Text = "Autor  lesen";
			this.readAuthor.Click += new System.EventHandler(this.readPerson_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(152, 112);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Id:";
			// 
			// personIdTextBox
			// 
			this.personIdTextBox.Location = new System.Drawing.Point(176, 112);
			this.personIdTextBox.Name = "personIdTextBox";
			this.personIdTextBox.Size = new System.Drawing.Size(40, 20);
			this.personIdTextBox.TabIndex = 2;
			this.personIdTextBox.Text = "1";
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(24, 144);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(312, 16);
			this.infoLabel.TabIndex = 3;
			// 
			// personPictureBox
			// 
			this.personPictureBox.Location = new System.Drawing.Point(24, 168);
			this.personPictureBox.Name = "personPictureBox";
			this.personPictureBox.Size = new System.Drawing.Size(160, 160);
			this.personPictureBox.TabIndex = 4;
			this.personPictureBox.TabStop = false;
			// 
			// createDatabase
			// 
			this.createDatabase.Location = new System.Drawing.Point(24, 16);
			this.createDatabase.Name = "createDatabase";
			this.createDatabase.Size = new System.Drawing.Size(128, 23);
			this.createDatabase.TabIndex = 5;
			this.createDatabase.Text = "Datenbank erzeugen";
			this.createDatabase.Click += new System.EventHandler(this.createDatabase_Click);
			// 
			// addAuthorButton
			// 
			this.addAuthorButton.Location = new System.Drawing.Point(24, 48);
			this.addAuthorButton.Name = "addAuthorButton";
			this.addAuthorButton.Size = new System.Drawing.Size(128, 23);
			this.addAuthorButton.TabIndex = 6;
			this.addAuthorButton.Text = "Autor anfügen";
			this.addAuthorButton.Click += new System.EventHandler(this.addAuthorButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 7;
			this.label2.Text = "Vorname:";
			// 
			// authorFirstNameTextBox
			// 
			this.authorFirstNameTextBox.Location = new System.Drawing.Point(232, 48);
			this.authorFirstNameTextBox.Name = "authorFirstNameTextBox";
			this.authorFirstNameTextBox.Size = new System.Drawing.Size(192, 20);
			this.authorFirstNameTextBox.TabIndex = 8;
			this.authorFirstNameTextBox.Text = "";
			// 
			// authorLastNameTextBox
			// 
			this.authorLastNameTextBox.Location = new System.Drawing.Point(232, 72);
			this.authorLastNameTextBox.Name = "authorLastNameTextBox";
			this.authorLastNameTextBox.Size = new System.Drawing.Size(192, 20);
			this.authorLastNameTextBox.TabIndex = 10;
			this.authorLastNameTextBox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(160, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 9;
			this.label3.Text = "Nachname:";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.authorLastNameTextBox,
																		  this.label3,
																		  this.authorFirstNameTextBox,
																		  this.label2,
																		  this.addAuthorButton,
																		  this.createDatabase,
																		  this.personPictureBox,
																		  this.infoLabel,
																		  this.personIdTextBox,
																		  this.label1,
																		  this.readAuthor});
			this.Name = "StartForm";
			this.Text = "Binäre Daten in einer Datenbank";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void readPerson_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = null;
			SqlDataReader reader = null;
			try
			{
				// Verbindung zur Persons-Datenbank auf dem lokalen
				// SQL Server aufbauen
				connection = new SqlConnection("Server=(local);" +
					"Database=Persons;Trusted_Connection=Yes");
				connection.Open();

				// Person einlesen
				int personId = Convert.ToInt32(this.personIdTextBox.Text);
				string sql = "SELECT * FROM Persons WHERE Id = " + personId;
				SqlCommand command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();
				if (reader.Read())
				{
					// Textdaten einlesen
					infoLabel.Text = (string)reader["FirstName"] + " " + (string)reader["LastName"];
	
					// Binäre Daten einlesen
					byte[] imageData = (byte[])reader["Picture"];
					if (imageData != null)
					{
						MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length);
						this.personPictureBox.Image = new Bitmap(ms);
						ms.Close();
					}
					else
						this.personPictureBox.Image = null;
				}
				else
				{
					MessageBox.Show("Kategorie nicht gefunden", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				try 
				{
					reader.Close();
					connection.Close();
				}
				catch {}
			}
		}

		private void createDatabase_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = null;
			try
			{
				// Verbindung zum lokalen SQL Server aufbauen und Datenbank erzeugen
				connection = new SqlConnection("Server=(local);" +
					"Trusted_Connection=Yes");
				connection.Open();
				string sql = "CREATE DATABASE Persons";
				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
				connection.Close();

				connection = new SqlConnection("Server=(local);" +
					"Database=Persons;Trusted_Connection=Yes");
				connection.Open();
				sql = "CREATE TABLE Persons (Id int PRIMARY KEY " +
					"NOT NULL IDENTITY, FirstName nvarchar(255), " +
					"LastName nvarchar(255), Picture image)";
				command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
				
				MessageBox.Show("Fertig", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				try 
				{
					connection.Close();
				}
				catch {}
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();

		}

		private void addAuthorButton_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.Title = "Bild suchen";
			openFileDialog1.Filter = "Bilddateien|*.bmp;*.jpg;*.jpeg;*.gif;*.png|Alle Dateien|*.*";
			openFileDialog1.CheckFileExists = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Bitmap bitmap = new Bitmap(openFileDialog1.FileName);

				// Verbindung zur Persons-Datenbank auf dem lokalen
				// SQL Server aufbauen
				SqlConnection connection = new SqlConnection("Server=(local);" +
					"Database=Persons;Trusted_Connection=Yes");
				connection.Open();

				// Daten in ein DataTable-Objekt lesen
				SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Persons", connection);
				new SqlCommandBuilder(adapter);
				DataTable dataTable = new DataTable();
				adapter.FillSchema(dataTable, SchemaType.Source);

				// DataRow erzeugen und mit den Textdaten füllen
				DataRow newRow = dataTable.NewRow();
				newRow["FirstName"] = this.authorFirstNameTextBox.Text;
				newRow["LastName"] = this.authorLastNameTextBox.Text;

				// Das Bitmap in ein Byte-Array umwandeln und speichern
				MemoryStream ms = new MemoryStream();
				bitmap.Save(ms, ImageFormat.Bmp);
				byte[] buffer = ms.ToArray();
				newRow["Picture"] = buffer;

				// Datensatz anfügen und Tabelle aktualisieren
				dataTable.Rows.Add(newRow);

				adapter.Update(dataTable);
			}
		}
	}
}
