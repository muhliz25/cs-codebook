using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Controls;
using Addison_Wesley.Codebook.DateAndTime;

namespace Einzelne_Knoten_in_einem_TreeView_sortieren
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView bookTree;
		private System.Windows.Forms.Button sortSubNodes;
		private System.Windows.Forms.Label infoLabel;
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
			this.bookTree = new System.Windows.Forms.TreeView();
			this.sortSubNodes = new System.Windows.Forms.Button();
			this.infoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bookTree
			// 
			this.bookTree.ImageIndex = -1;
			this.bookTree.Location = new System.Drawing.Point(8, 8);
			this.bookTree.Name = "bookTree";
			this.bookTree.SelectedImageIndex = -1;
			this.bookTree.Size = new System.Drawing.Size(392, 208);
			this.bookTree.TabIndex = 0;
			// 
			// sortSubNodes
			// 
			this.sortSubNodes.Location = new System.Drawing.Point(8, 224);
			this.sortSubNodes.Name = "sortSubNodes";
			this.sortSubNodes.Size = new System.Drawing.Size(128, 23);
			this.sortSubNodes.TabIndex = 1;
			this.sortSubNodes.Text = "Unterknoten sortieren";
			this.sortSubNodes.Click += new System.EventHandler(this.sortSubNodes_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(144, 224);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(208, 23);
			this.infoLabel.TabIndex = 2;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 261);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.infoLabel,
																		  this.sortSubNodes,
																		  this.bookTree});
			this.Name = "StartForm";
			this.Text = "Einzelne Knoten eines TreeView-Steuerelements sortieren";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		/* Methode zur Ermittlung eines Zufalls-Strings */
		Random r = new Random();
		private string getRandomString(int count)
		{
			string result = "";
			for (int i = 0; i < count; i++)
				result += (char)r.Next(97, 122);
			return result;
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Füllen des TreeView
			this.bookTree.Nodes.Add(new TreeNode("Matt Ruff", new TreeNode[] {
				new TreeNode("G.A.S. (GAS). Die Trilogie der Stadtwerke"),
				new TreeNode("Fool on the Hill"),
				new TreeNode("Set This House in Order")}));

			this.bookTree.Nodes.Add(new TreeNode("Douglas Adams", new TreeNode[] {
				new TreeNode("Per Anhalter durch die Galaxis"),
				new TreeNode("Der elektrische Mönch"),
				new TreeNode("Der lange dunkle Fünfuhrtee der Seele")}));

			TreeNode testNode = new TreeNode("TEST");
			for (int i = 0; i < 1000; i++)
				testNode.Nodes.Add(new TreeNode(getRandomString(10)));
			this.bookTree.Nodes.Add(testNode);
		}



		private void sortSubNodes_Click(object sender, System.EventArgs e)
		{
			// Alle Knoten der ersten Ebene durchgehen und deren
			// Unterknoten sortieren
			HighResStopClock sc = new HighResStopClock();
			sc.Start();
			for (int i = 0; i < bookTree.Nodes.Count; i++)
			{
				ControlUtils.SortTreeViewNodes(bookTree.Nodes[i].Nodes);
			}
			infoLabel.Text = sc.Stop().ToString() + " Sekunden";

		}

	}
}
