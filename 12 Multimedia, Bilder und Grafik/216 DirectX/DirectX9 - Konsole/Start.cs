using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace DirectX9_Konsole
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Videodatei abspielen
			Console.WriteLine("Video-Datei wird abgespielt ...");
			string videoFileName = Path.Combine(Application.StartupPath, "Tuborg.mpeg");						
			Video video = new Video(videoFileName, false);
			Console.WriteLine("Lautstärke: {0}", video.Audio.Volume);

			video.Play();
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
			video.Stop();
			video.Dispose();

			// Audiodatei abspielen
			Console.WriteLine("Audio-Datei wird abgespielt ...");
			string audioFileName = Path.Combine(Application.StartupPath, "DoubleN - Moon Child.mp3");						
			Audio audio = new Audio(audioFileName, false);
			audio.Play();
			Console.WriteLine("Lautstärke: {0}", audio.Volume);
			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
			audio.Stop();
			audio.Dispose();

			Console.ReadLine();
		}
	}
}
