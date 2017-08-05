using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Laufzeit_Menüs
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMenu;
		private System.Windows.Forms.MenuItem fileMenuSeparator1;
		private System.Windows.Forms.MenuItem fileCloseMenu;
		private System.Windows.Forms.MenuItem fileOpenMenu;
		private System.Windows.Forms.MenuItem fileMenuSeparator2;
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMenu = new System.Windows.Forms.MenuItem();
			this.fileMenuSeparator1 = new System.Windows.Forms.MenuItem();
			this.fileCloseMenu = new System.Windows.Forms.MenuItem();
			this.fileOpenMenu = new System.Windows.Forms.MenuItem();
			this.fileMenuSeparator2 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMenu});
			// 
			// fileMenu
			// 
			this.fileMenu.Index = 0;
			this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.fileOpenMenu,
																					 this.fileMenuSeparator1,
																					 this.fileMenuSeparator2,
																					 this.fileCloseMenu});
			this.fileMenu.Text = "&Datei";
			// 
			// fileMenuSeparator1
			// 
			this.fileMenuSeparator1.Index = 1;
			this.fileMenuSeparator1.Text = "-";
			// 
			// fileCloseMenu
			// 
			this.fileCloseMenu.Index = 3;
			this.fileCloseMenu.Text = "&Schließen";
			// 
			// fileOpenMenu
			// 
			this.fileOpenMenu.Index = 0;
			this.fileOpenMenu.Text = "&Öffnen";
			this.fileOpenMenu.Click += new System.EventHandler(this.fileOpenMenu_Click);
			// 
			// fileMenuSeparator2
			// 
			this.fileMenuSeparator2.Index = 2;
			this.fileMenuSeparator2.Text = "-";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 145);
			this.Menu = this.mainMenu1;
			this.Name = "StartForm";
			this.Text = "Laufzeit-Menüs";
			this.Load += new System.EventHandler(this.StartForm_Load);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void DynamicMenuHandler(object sender, System.EventArgs e)
		{
			MenuItem menuItem = (MenuItem)sender;
			string fileName = menuItem.Text;
			MessageBox.Show(fileName);
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Hinzufügen von Menübefehlen für alle Textdateien
			// im Windows-Systemordner zum Datei-Menü
			DirectoryInfo winDir = new DirectoryInfo(Environment.SystemDirectory);
			FileInfo[] files = winDir.GetFiles("*.txt");
			for (int i = 0; i < files.Length && i < 9; i++)
			{
				// MenuItem-Objekt erzeugen und den Text und die Click-Ereignismethode
				// übergeben
				MenuItem menuItem = new MenuItem(files[i].Name, 
					new EventHandler(this.DynamicMenuHandler));

				// Menü ab dem Index 2 + i an das Dateimenü anfügen
				this.fileMenu.MenuItems.Add(2 + i, menuItem); 
			}
		}

		private void fileOpenMenu_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
