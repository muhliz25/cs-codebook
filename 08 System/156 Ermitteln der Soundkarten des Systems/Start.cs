using System;
using System.Collections;
using System.Windows.Forms;
using Addison_Wesley.Codebook.System;

namespace Soundkarte_abfragen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			/* Auflisten der installierten Soundkarten */
			Hashtable soundcards = SystemUtils.EnumSoundcards();

			if (soundcards.Count > 0)
			{
				Console.WriteLine("Soundkarte(n) gefunden:");
				foreach (string key in soundcards.Keys)
				{
					Console.WriteLine("DeviceId: {0}, ProductName: {1}",
						key, soundcards[soundcards]);
				}
			}
			else
			{
				MessageBox.Show("Auf Ihrem System wurde keine Soundkarte gefunden",
					Application.ProductName, MessageBoxButtons.OK, 
					MessageBoxIcon.Exclamation);
			}

			Console.WriteLine("Taste ...");
			Console.ReadLine();
		}
	}
}
