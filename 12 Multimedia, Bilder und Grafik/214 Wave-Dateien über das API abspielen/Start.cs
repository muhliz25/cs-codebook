using System;
using System.IO;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Multimedia;

namespace Wave_Dateien_abspielen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{	
			string fileName = Path.Combine(Application.StartupPath, "pavel_und_bronko.wav");
			try
			{
				SoundUtils.PlayWaveFile(fileName, true, false);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
			SoundUtils.PlayWaveFile(null, true, false);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
