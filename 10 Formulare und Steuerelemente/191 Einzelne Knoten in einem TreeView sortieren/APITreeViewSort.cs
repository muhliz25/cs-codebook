using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Controls
{
	public class APITreeViewSort
	{
		/* Delegate für den Vergeleichs-Callback */
		public delegate int CompareNodes(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);

		/* Vergeleichs-Callback */
		private static int CompareNodesHandler(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort)
		{
			if ((int)lParam1 > (int)lParam2)
				return 1;
			else if ((int)lParam1 < (int)lParam2)
				return -1;
			else
				return 0;

		}

		/* Deklaration benötigter API-Funktionen, -Konstanten und -Strukturen */
		[StructLayout(LayoutKind.Sequential)]
			public struct TVSORTCB
		{
			public IntPtr hParent;
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public CompareNodes lpfnCompare;
			public int lParam;
		}

		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr handle, int msg, int wparam,
			ref TVSORTCB lparam);

		private const int TV_FIRST = 0x1100 ;
		private const int TVM_SORTCHILDRENCB = TV_FIRST + 21 ;

		/* Methode zum definierten Sortieren aller Unterknoten eines TreeView-Knotens
		 * Erfordert, dass den zu sortierenden Knoten über eine TVITEM-Struktur
		 * ein benutzerdefinierter int-Wert im Feld lParam zugewiesen wurde,
		 * der dann der Callback-Methode übergeben wird.   */
		public static void SortTreeViewNodes(TreeView treeView, TreeNode parentNode)
		{
			TVSORTCB sort;
			sort.hParent = parentNode.Handle;
			sort.lpfnCompare = new CompareNodes(CompareNodesHandler);
			sort.lParam = 0;

			int result = SendMessage(treeView.Handle, TVM_SORTCHILDRENCB, 0, ref sort);
			;
		}
	}
}

