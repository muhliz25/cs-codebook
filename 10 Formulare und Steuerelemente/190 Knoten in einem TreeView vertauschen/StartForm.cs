using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Controls;

namespace Knoten_in_einem_TreeView_vertauschen
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView bookTree;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox swapIndex1TextBox;
		private System.Windows.Forms.TextBox swapIndex2TextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button wrongSwapButton;
		private System.Windows.Forms.Button swapSubNodes;
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
			this.swapSubNodes = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.swapIndex1TextBox = new System.Windows.Forms.TextBox();
			this.swapIndex2TextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.wrongSwapButton = new System.Windows.Forms.Button();
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
			// swapSubNodes
			// 
			this.swapSubNodes.Location = new System.Drawing.Point(8, 224);
			this.swapSubNodes.Name = "swapSubNodes";
			this.swapSubNodes.Size = new System.Drawing.Size(128, 23);
			this.swapSubNodes.TabIndex = 1;
			this.swapSubNodes.Text = "Knoten vertauschen";
			this.swapSubNodes.Click += new System.EventHandler(this.swapSubNodes_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(144, 224);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Index 1:";
			// 
			// swapIndex1TextBox
			// 
			this.swapIndex1TextBox.Location = new System.Drawing.Point(192, 224);
			this.swapIndex1TextBox.Name = "swapIndex1TextBox";
			this.swapIndex1TextBox.Size = new System.Drawing.Size(32, 20);
			this.swapIndex1TextBox.TabIndex = 3;
			this.swapIndex1TextBox.Text = "0";
			// 
			// swapIndex2TextBox
			// 
			this.swapIndex2TextBox.Location = new System.Drawing.Point(192, 248);
			this.swapIndex2TextBox.Name = "swapIndex2TextBox";
			this.swapIndex2TextBox.Size = new System.Drawing.Size(32, 20);
			this.swapIndex2TextBox.TabIndex = 5;
			this.swapIndex2TextBox.Text = "1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 248);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Index 2:";
			// 
			// wrongSwapButton
			// 
			this.wrongSwapButton.Location = new System.Drawing.Point(256, 224);
			this.wrongSwapButton.Name = "wrongSwapButton";
			this.wrongSwapButton.Size = new System.Drawing.Size(136, 23);
			this.wrongSwapButton.TabIndex = 6;
			this.wrongSwapButton.Text = "Fehlerhafter Tausch";
			this.wrongSwapButton.Click += new System.EventHandler(this.wrongSwapButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.wrongSwapButton,
																		  this.swapIndex2TextBox,
																		  this.label2,
																		  this.swapIndex1TextBox,
																		  this.label1,
																		  this.swapSubNodes,
																		  this.bookTree});
			this.Name = "StartForm";
			this.Text = "Knoten eines TreeView-Steuerelements tauschen";
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
			// Füllen des TreeView
			this.bookTree.Nodes.Add(new TreeNode("Bücher", new TreeNode[] {
				new TreeNode("G.A.S. (GAS). Die Trilogie der Stadtwerke"),
				new TreeNode("Fool on the Hill"),
				new TreeNode("Set This House in Order"),
				new TreeNode("Per Anhalter durch die Galaxis"),
				new TreeNode("Der elektrische Mönch"),
				new TreeNode("Der lange dunkle Fünfuhrtee der Seele")}));
		}


		private void wrongSwapButton_Click(object sender, System.EventArgs e)
		{
			/* Unterknoten fehlerhaft vertauschen */
			TreeNode node = bookTree.Nodes[0].Nodes[0];
			bookTree.Nodes[0].Nodes[2] = bookTree.Nodes[0].Nodes[1];
			bookTree.Nodes[0].Nodes[1] = node;
		}

		private void swapSubNodes_Click(object sender, System.EventArgs e)
		{
			/* Unterknoten korrekt vertauschen */
			int index1 = Convert.ToInt32(this.swapIndex1TextBox.Text);
			int index2 = Convert.ToInt32(this.swapIndex2TextBox.Text);

			ControlUtils.SwapTreeViewNodes(this.bookTree.Nodes[0].Nodes, index1, index2);
		}

	}
}
