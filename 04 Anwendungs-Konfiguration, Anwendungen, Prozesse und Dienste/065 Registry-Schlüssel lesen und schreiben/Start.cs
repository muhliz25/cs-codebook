using System;
using Addison_Wesley.Codebook.AppUtils;

namespace Registry_lesen_und_schreiben
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Wert des Eintrags HKEY_CURRENT_USER\Software\Microsoft\Office\
			// 10.0\Word\Options\DOC-PATH lesen
			object wordDocPath = RegUtils.ReadValue(RegistryRootKeys.HKEY_CURRENT_USER,
				@"Software\Microsoft\Office\10.0\Word\Options", "DOC-PATH", null);
			if (wordDocPath != null)
				Console.WriteLine(wordDocPath);
			else
				Console.WriteLine("Eintrag nicht gefunden");

			// Eintrag HKEY_CURRENT_USER\Software\Addison-Wesley\Codebook\Version so schreiben,
			// dass der Eintrag inklusive allen Schlüsseln automatisch angelegt wird, 
			// falls er noch nicht existiert
			RegUtils.WriteValue(RegistryRootKeys.HKEY_CURRENT_USER, 
				@"Software\Addison-Wesley\Codebook", "Version", "1.0", true);

			// Eintrag HKEY_CURRENT_USER\Software\Addison-Wesley\Codebook\Samples schreiben
			RegUtils.WriteValue(RegistryRootKeys.HKEY_CURRENT_USER, 
				@"Software\Addison-Wesley\Codebook\Samples", "Registry",
				"c:\\Samples\\Registry", true);

			// Schlüssel HKEY_CURRENT_USER\Software\Addison-Wesley\Codebook\Samples löschen
			RegUtils.DeleteKey(RegistryRootKeys.HKEY_CURRENT_USER, 
				@"Software\Addison-Wesley\Codebook\Samples");

			Console.WriteLine("Fertig");
			Console.ReadLine();
		}
	}
}
