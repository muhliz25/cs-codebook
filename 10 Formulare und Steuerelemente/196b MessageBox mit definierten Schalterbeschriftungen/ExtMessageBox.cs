using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Addison_Wesley.Codebook.Windows.Forms
{
	public class ExtMessageBox
	{
		/* Aufzählung für die Rückgabe der Show-Methode */
		public enum ExtDialogResult
		{
			FirstButton,
			SecondButton,
			ThirdButton
		}

		/* Eigenschaft für den Hook-Handle */
		private static IntPtr hHook;

		/* Eigenschaften, die die Beschriftungen der Schalter speichern und
		 * in der Hook-Funktion abgefragt werden */
		private static string button1Caption;
		private static string button2Caption;
		private static string button3Caption;

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

		/* Aufzählung für die Aktionen, bei denen ein CBT-Hook aufgerufen 
		 * werden kann */
		private enum CBTHookAction : int
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

		/* Aufzählung für die MessageBox-Schaltertypen */
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
		private delegate int HookProcDelegate(CBTHookAction nCode,
			IntPtr wParam, IntPtr lParam);

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

		/* Die Hook-Funktion */
		private static int HookProc(CBTHookAction code, IntPtr wParam,
			IntPtr lParam)
		{
			if (code < 0)
				// Wenn keine Hook-Aktion übergeben wurde, Windows 
				// direkt zum nächsten Hook verzweigen lassen
				return CallNextHookEx(hHook, code, wParam, lParam);
      
			if (code == CBTHookAction.HCBT_ACTIVATE)
			{
				// Wenn das Fenster gerade aktiviert wird:
				// Schalter neu beschriften
				if (button3Caption != null)
				{
					SetDlgItemText(wParam, (int)ButtonType.IDYES,
						button1Caption);
					SetDlgItemText(wParam, (int)ButtonType.IDNO,
						button2Caption);
					SetDlgItemText(wParam, (int)ButtonType.IDCANCEL,
						button3Caption);
				}
				else if (button2Caption != null) 
				{
					SetDlgItemText(wParam, (int)ButtonType.IDYES,
						button1Caption);
					SetDlgItemText(wParam, (int)ButtonType.IDNO,
						button2Caption);
				}
				else
				{
					SetDlgItemText(wParam, (int)ButtonType.IDOK,
						button1Caption);
				}
			}

			// Zum nächsten Hook in der Hook-Kette wechseln
			return CallNextHookEx(hHook, code, wParam, lParam);
		}
   
		/* Methode zum Aufruf der MessageBox */ 
		public static ExtDialogResult Show(string text, string
			caption, string button1Caption, string button2Caption,
			string button3Caption, MessageBoxIcon icon,
			MessageBoxDefaultButton defaultButton)
		{
			// Festlegen der als Basis verwendeten Schalter
			MessageBoxButtons buttons;
			if (button3Caption != null)
				buttons = MessageBoxButtons.YesNoCancel;
			else if (button2Caption != null) 
				buttons = MessageBoxButtons.YesNo;
			else
				buttons = MessageBoxButtons.OK;

			// Schalterbeschriftungen an die privaten Eigenschaften
			// übergeben, damit diese in der Hook-Funktion zur
			// Verfügung stehen
			ExtMessageBox.button1Caption = button1Caption;
			ExtMessageBox.button2Caption = button2Caption;
			ExtMessageBox.button3Caption = button3Caption;

			// CBT-Hook nur für den aktuellen Thread installieren
			hHook = SetWindowsHookEx(HookType.WH_CBT, 
				new HookProcDelegate(HookProc), IntPtr.Zero, 
				(int)AppDomain.GetCurrentThreadId());

			// Standard-MessageBox aufrufen
			ExtDialogResult returnValue;
			switch(MessageBox.Show(text, caption, buttons, icon,
				defaultButton))
			{
				case DialogResult.OK: 
					returnValue = ExtDialogResult.FirstButton;
					break;
				case DialogResult.Yes: 
					returnValue = ExtDialogResult.FirstButton;
					break;
				case DialogResult.No: 
					returnValue = ExtDialogResult.SecondButton;
					break;
				case DialogResult.Cancel: 
					returnValue = ExtDialogResult.ThirdButton;
					break;
				default:
					returnValue = ExtDialogResult.FirstButton;
					break;
			}

			// Hook wieder deinstallieren
			UnhookWindowsHookEx(hHook);

			// Ergebnis zurückgeben
			return returnValue;
		}
	}
}
