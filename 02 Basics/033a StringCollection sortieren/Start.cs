using System;
using System.Collections.Specialized;
using Addison_Wesley.Codebook.Basics;

namespace StringCollection_sortieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// StringCollection erzeugen und füllen
			StringCollection col = new StringCollection();
			col.Add("Zaphod");
			col.Add("Trillian");
			col.Add("arthur");
			col.Add("ford");
			col.Add("Marvin");
			col.Add("Slartibartfaß");

			Console.WriteLine("Original-Reihenfolge:");
			for (int i = 0; i < col.Count; i++)
				Console.WriteLine(col[i]);

			// StringCollection über die eigene Sort-Methode sortieren
			SortUtils.Sort(col);
 
			Console.WriteLine();
			Console.WriteLine("Sortiert:");
			for (int i = 0; i < col.Count; i++)
				Console.WriteLine(col[i]);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
