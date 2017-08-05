using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Zusatzdaten_in_List__oder_Combobox
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox personList;
		private System.Windows.Forms.Label infoLabel;
		
		/* Klasse für die Listeneinträge */
		private class Person
		{
			public int Id;
			public string FirstName;
			public string LastName;

			/* Konstruktor */
			public Person(int id, string firstName, string lastName)
			{
				this.Id = id;
				this.FirstName = firstName;
				this.LastName = lastName;
			}

			/* Die ToString-Methode wird überschrieben */
			public override string ToString()
			{
				return this.FirstName + " " + this.LastName;
			}
		}

		
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
			this.personList = new System.Windows.Forms.ListBox();
			this.infoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// personList
			// 
			this.personList.Location = new System.Drawing.Point(16, 16);
			this.personList.Name = "personList";
			this.personList.Size = new System.Drawing.Size(184, 134);
			this.personList.TabIndex = 0;
			this.personList.SelectedIndexChanged += new System.EventHandler(this.personList_SelectedIndexChanged);
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(216, 16);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(224, 96);
			this.infoLabel.TabIndex = 1;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 165);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.infoLabel,
																		  this.personList});
			this.Name = "StartForm";
			this.Text = "Daten neben den Einträgen einer ListBox oder ComboBox verwalten";
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
			// Einige Personen an die ListBox anhängen
			this.personList.Items.Add(new Person(1001, "Zaphod", "Beeblebrox"));
			this.personList.Items.Add(new Person(1002, "Tricia", "McMillan"));
			this.personList.Items.Add(new Person(1003, "Arthur", "Dent"));
			this.personList.Items.Add(new Person(1004, "Ford", "Prefect"));
			this.personList.Items.Add(new Person(1005, "Marvin", ""));
		}

		private void personList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Auslesen des selektierten Objekts
			Person p = (Person)personList.SelectedItem;
			this.infoLabel.Text = "Id: " + p.Id + "\r\n" +
				"Vorname: " + p.FirstName + "\r\n" +
				"Nachname: " + p.LastName;
		}
	}
}
