using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListView_sortieren
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView bookList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
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
			this.bookList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// bookList
			// 
			this.bookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2,
																					   this.columnHeader3});
			this.bookList.Location = new System.Drawing.Point(16, 16);
			this.bookList.Name = "bookList";
			this.bookList.Size = new System.Drawing.Size(456, 216);
			this.bookList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.bookList.TabIndex = 0;
			this.bookList.View = System.Windows.Forms.View.Details;
			this.bookList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.bookList_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Titel";
			this.columnHeader1.Width = 250;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Autor";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "ISBN";
			this.columnHeader3.Width = 100;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 245);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bookList});
			this.Name = "StartForm";
			this.Text = "ListView sortieren";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		// Klasse, die IComparer implementiert und die das 
		// Sortieren übernimmt
		public class ColumnComparer: IComparer
		{
			/* Eigenschaft für die aktuelle Spalte */
			public int CurrentColumn = 0;
   
			/* Implementieren der Compare-Methode */
			public int Compare(object x, object y)
			{
				ListViewItem firstItem = (ListViewItem)x;
				ListViewItem secondItem = (ListViewItem)y;

				return string.Compare(
					firstItem.SubItems[CurrentColumn].Text,
					secondItem.SubItems[CurrentColumn].Text);
			}
		}

		// Eigenschaft für den Spaltenvergleicher
		private ColumnComparer columnComparer = new ColumnComparer();


		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Füllen des ListView-Steuerelements
			this.bookList.Items.Add(new ListViewItem(new string[] {
				"Fool on the Hill", "Matt Ruff", "0802135358"}));
			this.bookList.Items.Add(new ListViewItem(new string[] {
				"G.A.S. ( GAS). Die Trilogie der Stadtwerke", "Matt Ruff",
				"342312721X"}));
			this.bookList.Items.Add(new ListViewItem(new string[] {
				"Per Anhalter durch die Galaxis", "Douglas Adams", 
				"3453209613"}));
			this.bookList.Items.Add(new ListViewItem(new string[] {
				"Der lange dunkle Fünfuhrtee der Seele", "Douglas Adams",
				"3453210727"}));
			this.bookList.Items.Add(new ListViewItem(new string[] {
				"Die wilde Geschichte vom Wassertrinker", "John Irving",
				"3257224451"}));

			// Comparer zuweisen
			this.columnComparer.CurrentColumn = 2; // Sortieren nach ISBN
			this.bookList.ListViewItemSorter = this.columnComparer;
		}


		private void bookList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Umsortieren der Liste beim Klick auf eine Spalte
			this.columnComparer.CurrentColumn = e.Column;
			this.bookList.Sort();
		}
	}
}
