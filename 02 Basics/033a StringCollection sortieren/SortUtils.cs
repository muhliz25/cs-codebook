using System;
using System.Collections.Specialized;

namespace Addison_Wesley.Codebook.Basics
{
	public class SortUtils
	{
		/* Methode zum Sortieren einer StringCollection */
		public static void Sort(StringCollection col)
		{
			// StringCollection in ein Array kopieren und dieses sortieren 
			string[] values = new string[col.Count];
			col.CopyTo(values, 0);
			Array.Sort(values);
   
			// Das Ergebnis wieder zurückkopieren
			for (int i = 0; i < values.Length; i++)
				col[i] = values[i];
		}
	}
}
