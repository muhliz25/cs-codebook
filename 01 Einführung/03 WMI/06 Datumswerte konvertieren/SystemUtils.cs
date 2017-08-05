using System;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Methode zum Konvertieren eines WMI-Datums in einen DateTime-Wert */
		public static DateTime WMIDateToDateTime(string wmiDate)
		{
			int year = DateTime.Now.Year;
			int month = 1, day = 1, hour = 0, minute = 0;
			int second = 0, millisec = 0;
			string tempString = "";
   
			if ((wmiDate == "") || (wmiDate == null)) 
				return DateTime.MinValue;
			if (wmiDate.Length != 25) 
				return DateTime.MinValue;
			tempString = wmiDate.Substring(0, 4);
			if (tempString != "****") 
				year = Int32.Parse(tempString);
			tempString = wmiDate.Substring(4, 2);
			if (tempString != "**") 
				month = Int32.Parse(tempString);
			tempString = wmiDate.Substring(6, 2);
			if (tempString != "**") 
				day = Int32.Parse(tempString);
			tempString = wmiDate.Substring(8, 2);
			if (tempString != "**") 
				hour = Int32.Parse(tempString);
			tempString = wmiDate.Substring(10, 2);
			if (tempString != "**") 
				minute = Int32.Parse(tempString);
			tempString = wmiDate.Substring(12, 2);
			if (tempString != "**") 
				second = Int32.Parse(tempString);
			tempString = wmiDate.Substring(15, 3);
			if (tempString != "**") 
				millisec = Int32.Parse(tempString);
   
			return new DateTime(year, month, day, hour, minute, 
				second, millisec);
		}
	}
}
