using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using Addison_Wesley.Codebook.DateAndTime;
using Addison_Wesley.Codebook.Basics;

namespace Sortier_Performance_Test
{
	public class Start
	{
	
		public static void Main(string[] args)
		{
			HighResStopClock sc = new HighResStopClock();
			//StreamWriter sr = new StreamWriter("C:\\Performance.txt");
			
			Console.WriteLine("Performance-Messung ...");
			string name;

			StringCollection colDummy = new StringCollection();
			colDummy.Add("a");
			colDummy.Add("b");
			colDummy.Add("c");
				
			// Drei Duchläufe 
			StringCollection col1 = null;
			StringCollection col2 = null;
			StringCollection col3 = null;

			double time1 = 0, time2 = 0, time3 = 0;
			for (int i = 0; i < 3; i++)
			{
				col1 = new StringCollection();
				col2 = new StringCollection();
				col3 = new StringCollection();
				System.GC.WaitForPendingFinalizers();

				for (int j = 0; j < 1000; j++)
				{
					string s = StringUtils.RandomString(50);
					col1.Add(s);
					col2.Add(s);
					col3.Add(s);
				}

				SortUtils.Quicksort(colDummy);
				SortUtils.Heapsort(colDummy);
				SortUtils.Sort(colDummy);

				name = "Quicksort";
				sc.Start();
				SortUtils.Quicksort(col1);
				double seconds = sc.Stop();
				time1 += seconds;
				Console.WriteLine("{0}: {1}", name, seconds);
				//sr.WriteLine("{0}: {1}", name, seconds);

				name = "Heapsort";
				sc.Start();
				SortUtils.Heapsort(col2);
				seconds = sc.Stop();
				time2 += seconds;
				Console.WriteLine("{0}: {1}", name, seconds);
				//sr.WriteLine("{0}: {1}", name, seconds);

				name = "Sort";
				sc.Start();
				SortUtils.Sort(col3);
				seconds = sc.Stop();
				time3 += seconds;
				Console.WriteLine("{0}: {1}", name, seconds);
				//sr.WriteLine("{0}: {1}", name, seconds);
			}

			Console.WriteLine("Quicksort (mittel): {0}", time1 / 3);
			//sr.WriteLine("Quicksort (mittel): {0}", time1 / 3);
			Console.WriteLine("Heapsort (mittel): {0}", time2 / 3);
			//sr.WriteLine("Heapsort (mittel): {0}", time2 / 3);
			Console.WriteLine("Sort (mittel): {0}", time3 / 3);
			//sr.WriteLine("Sort (mittel): {0}", time3 / 3);
			
			//sr.Close();
			//Process.Start("notepad.exe", "c:\\Performance.txt");
			
			//for (int i = 0; i < col3.Count; i++)
			//	Console.WriteLine(col3[i]);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
