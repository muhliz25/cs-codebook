using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Drag_and_Drop_von_Dateien_und_Ordnern
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox fileList;
		private System.Windows.Forms.Label label1;
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
			this.fileList = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// fileList
			// 
			this.fileList.AllowDrop = true;
			this.fileList.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.fileList.Location = new System.Drawing.Point(8, 48);
			this.fileList.Name = "fileList";
			this.fileList.Size = new System.Drawing.Size(288, 186);
			this.fileList.TabIndex = 0;
			this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
			this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ziehen Sie die Dateien oder Ordner auf die ListBox. Ordner werden allerdings verw" +
				"orfen.";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 253);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.fileList});
			this.Name = "StartForm";
			this.Text = "Drag & Drop von Dateien und Ordnern";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void fileList_DragEnter(object sender, DragEventArgs e)
		{
			// Überprüfen, ob Dateien oder Ordner gezogen werden
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void fileList_DragDrop(object sender, DragEventArgs e)
		{
			// Dateien aus den gezogenen Daten auslesen
			string[] filesNames = (string[])e.Data.GetData(DataFormats.FileDrop,
				false);
			foreach (string fileName in filesNames)
			{
				// FileInfo-Objekt erzeugen
				FileInfo fi = new FileInfo(fileName);
				if (fi.Exists)
					// Wenn es sich nicht um einen Ordner handelt: FileInfo-Objekt der
					// Liste anfügen
					this.fileList.Items.Add(fi);
			} 
		}

	}
}
