using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Hooking
{
	class Hooking
	{
		/* Eigenschaft für den Hook-Handle */
		private static IntPtr hHook;

		/* Aufzählung für die verschiedenen Hook-Typen */
		public enum HookType: int
		{
			WH_JOURNALRECORD = 0,
			WH_JOURNALPLAYBACK = 1,
			WH_KEYBOARD = 2,
			WH_GETMESSAGE = 3,
			WH_CALLWNDPROC = 4,
			WH_CBT = 5,
			WH_SYSMSGFILTER = 6,
			WH_MOUSE = 7,
			WH_HARDWARE = 8,
			WH_DEBUG = 9,
			WH_SHELL = 10,
			WH_FOREGROUNDIDLE = 11,
			WH_CALLWNDPROCRET = 12,		
			WH_KEYBOARD_LL = 13,
			WH_MOUSE_LL = 14
		}

		/* Aufzählung für die Aktionen, bei denen ein CBT-Hook aufgerufen werden kann */
		private enum CBTHookAction: int
		{
			HCBT_MOVESIZE = 0,
			HCBT_MINMAX = 1,
			HCBT_QS = 2,
			HCBT_CREATEWND = 3,
			HCBT_DESTROYWND = 4,
			HCBT_ACTIVATE = 5,
			HCBT_CLICKSKIPPED = 6,
			HCBT_KEYSKIPPED = 7,
			HCBT_SYSCOMMAND = 8,
			HCBT_SETFOCUS = 9
		}

		/* Aufzählung für die Messagebox-Schaltertypen */
		private enum ButtonType
		{
			IDOK = 1,
			IDCANCEL = 2,
			IDABORT = 3,
			IDRETRY = 4,
			IDIGNORE = 5,
			IDYES = 6,
			IDNO = 7
		}

		/* Delegate für die Hook-Funktion */
		private delegate int HookProcDelegate(CBTHookAction nCode, IntPtr wParam, IntPtr lParam);

		/* Deklaration der benötigten API-Funktionen */
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SetWindowsHookEx(HookType idHook, 
			HookProcDelegate lpfn, IntPtr hMod, int dwThreadId);		

		[DllImport("user32.dll")]
		private static extern int CallNextHookEx(IntPtr hhook, 
			CBTHookAction code, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		private static extern int UnhookWindowsHookEx(IntPtr hhook); 

		[DllImport("User32")]
		static extern private bool SetDlgItemText(IntPtr hWnd,
			int nIDDlgItem, string lpString);

		/* Hook-Funktion */
		private static int HookProc(CBTHookAction code, IntPtr wParam, IntPtr lParam)
		{
			if (code == CBTHookAction.HCBT_ACTIVATE)
			{
				// Wenn das Fenster gerade aktiviert wird:
				// Schalter neu beschriften
				SetDlgItemText(wParam, (int)ButtonType.IDYES, "Jau");
				SetDlgItemText(wParam, (int)ButtonType.IDNO,  "Nö");
				SetDlgItemText(wParam, (int)ButtonType.IDCANCEL, "Vielleicht");
			}

			// Zum nächsten Hook in der Hook-Kette wechseln 
			return CallNextHookEx(hHook, code, wParam, lParam);
		}
	

		[STAThread]
		static void Main(string[] args)
		{
			// Hook installieren
			hHook = SetWindowsHookEx(HookType.WH_CBT, 
				new HookProcDelegate(HookProc), IntPtr.Zero, 
				(int)AppDomain.GetCurrentThreadId());

			// Standard-Messagebox aufrufen
			MessageBox.Show("C# ist doch cool, oder?", 
				Application.ProductName, MessageBoxButtons.YesNoCancel, 
				MessageBoxIcon.Question);

			// Hook wieder deinstallieren
			UnhookWindowsHookEx(hHook);

		}
	}
}
