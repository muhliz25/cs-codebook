using System;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Controls
{
	public class ControlUtils
	{
		/* Methode für einen Quicksort. Zum Test gegen den Bubblesort. 
		 * Wird zurzeit nicht benutzt */
		private static void quicksort(TreeNodeCollection nodes, int start, int end)
		{
			int left = start;
			int right = end;
			
			if (end > start)
			{
				int pivotIndex = (start + end) / 2;
				while (left <= right)
				{
					for (; left < end; left++)
					{
						if (nodes[left].Text.CompareTo(nodes[pivotIndex].Text) >= 0)
							break;
					}
					for (; right > start; right--)
					{
						if (nodes[right].Text.CompareTo(nodes[pivotIndex].Text) <= 0)
							break;
					}
					if (left <= right)
					{
						if (left < right)
						{
							// Tauschen
							TreeNode node1 = nodes[left];
							TreeNode node2 = nodes[right];
							nodes.RemoveAt(left);
							nodes.RemoveAt(right-1);
							nodes.Insert(left, node2);
							nodes.Insert(right, node1);
						}

						left++;
						right--;
					}
					if (right > start)
						quicksort(nodes, start, right);
					if (left < end)
						quicksort(nodes, left, end);
				}
			}
		}

		/* Methode zum Sortieren einer TreeNodeCollection */
		public static void SortTreeViewNodes(TreeNodeCollection nodes)
		{
			// Quicksort
			// quicksort(nodes, 0, nodes.Count - 1);

			// Sortieren der Unterknoten über einen einfachen BubbleSort
			// (bei 100 Elementen recht schnell,
			// bei 1000 super langsam; gilt aber auch für den 
			// Quicksort)
			for (int i = 0; i < nodes.Count; i++)
			{
				for (int j = nodes.Count - 1; j > i; j--)
				{
					if (String.Compare(nodes[i].Text, nodes[j].Text, true) > 0)
					{
						// Tauschen
						TreeNode node1 = nodes[i];
						TreeNode node2 = nodes[j];
						nodes.RemoveAt(i);
						nodes.RemoveAt(j-1);
						nodes.Insert(i, node2);
						nodes.Insert(j, node1);
					}
				}
			}
		}
	}		
}
