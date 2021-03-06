using System;
using System.Text.RegularExpressions;

namespace Addison_Wesley.Codebook.Basics
{
	public class StringUtils
	{
		/* Sichere Methode zur Ermittlung der Anzahl der W�rter in einem String */
		public static long WordCount1(string source)
		{
			return Regex.Matches(source, @"\w{1,}").Count;  
		}

		/* Schnelle und speichersparende Methode zur Ermittlung der Anzahl 
		 * der W�rter in einem String. Funktioniert nur f�r lateinische Zeichen.
		 * Funktioniert nicht, wenn der Unicode-String Zeichen der Teiltabellen 
		 * ab der griechischen (ab Zeichen 0x0370) enth�lt */
		public static long WordCount2(string source)
		{
			bool newWord = false;
			long count = 0;
			// Alle Zeichen des String durchgehen
			for (int i = 0; i < source.Length; i++)
			{
				char c = source[i];
				// �berpr�fen, ob es kein Wort-Zeichen ist 
				// (nach den Informationen zu alfabetischen Unicode-Zeichen bei
				// www.unicode.org/Public/UNIDATA/DerivedCoreProperties.txt;
				// Zahlbereich 0x0030 bis 0x0039 hinzugef�gt)
				if ((c >= '\x0030' && c <= '\x0039')
					(c >= '\x0041' && c <= '\x005A') || 
					(c >= '\x0061' && c <= '\x007A') || 
					(c >= '\x00AA') || 
					(c >= '\x00B5') || 
					(c >= '\x00BA') || 
					(c >= '\x00C0' && c <= '\x00D6') || 
					(c >= '\x00D8' && c <= '\x00F6') || 
					(c >= '\x00F8' && c <= '\x01BA') || 
					(c >= '\x01BB') || 
					(c >= '\x01BC' && c <= '\x01BF') || 
					(c >= '\x01C0' && c <= '\x01C3') || 
					(c >= '\x01C4' && c <= '\x0236') || 
					(c >= '\x0250' && c <= '\x02AF') || 
					(c >= '\x02B0' && c <= '\x02C1') || 
					(c >= '\x02C6' && c <= '\x02D1') || 
					(c >= '\x02E0' && c <= '\x02E4') || 
					(c >= '\x02EE') || 
					(c >= '\x0345') || 
					(c >= '\x037A') || 
					(c >= '\x0386') || 
					(c >= '\x0388' && c <= '\x038A') || 
					(c >= '\x038C') || 
					(c >= '\x038E' && c <= '\x03A1') || 
					(c >= '\x03A3' && c <= '\x03CE') || 
					(c >= '\x03D0' && c <= '\x03F5') || 
					(c >= '\x03F7' && c <= '\x03FB') || 
					(c >= '\x0400' && c <= '\x0481') || 
					(c >= '\x048A' && c <= '\x04CE') || 
					(c >= '\x04D0' && c <= '\x04F5') || 
					(c >= '\x04F8' && c <= '\x04F9') || 
					(c >= '\x0500' && c <= '\x050F') || 
					(c >= '\x0531' && c <= '\x0556') || 
					(c >= '\x0559') || 
					(c >= '\x0561' && c <= '\x0587') || 
					(c >= '\x05B0' && c <= '\x05B9') || 
					(c >= '\x05BB' && c <= '\x05BD') || 
					(c >= '\x05BF') || 
					(c >= '\x05C1' && c <= '\x05C2') || 
					(c >= '\x05C4') || 
					(c >= '\x05D0' && c <= '\x05EA') || 
					(c >= '\x05F0' && c <= '\x05F2') || 
					(c >= '\x0610' && c <= '\x0615') || 
					(c >= '\x0621' && c <= '\x063A') || 
					(c >= '\x0640') || 
					(c >= '\x0641' && c <= '\x064A') || 
					(c >= '\x064B' && c <= '\x0657') || 
					(c >= '\x066E' && c <= '\x066F') || 
					(c >= '\x0670') || 
					(c >= '\x0671' && c <= '\x06D3') || 
					(c >= '\x06D5') || 
					(c >= '\x06D6' && c <= '\x06DC') || 
					(c >= '\x06E1' && c <= '\x06E4') || 
					(c >= '\x06E5' && c <= '\x06E6') || 
					(c >= '\x06E7' && c <= '\x06E8') || 
					(c >= '\x06ED') || 
					(c >= '\x06EE' && c <= '\x06EF') || 
					(c >= '\x06FA' && c <= '\x06FC') || 
					(c >= '\x06FF') || 
					(c >= '\x0710') || 
					(c >= '\x0711') || 
					(c >= '\x0712' && c <= '\x072F') || 
					(c >= '\x0730' && c <= '\x073F') || 
					(c >= '\x074D' && c <= '\x074F') || 
					(c >= '\x0780' && c <= '\x07A5') || 
					(c >= '\x07A6' && c <= '\x07B0') || 
					(c >= '\x07B1') || 
					(c >= '\x0901' && c <= '\x0902') || 
					(c >= '\x0903') || 
					(c >= '\x0904' && c <= '\x0939') || 
					(c >= '\x093D') || 
					(c >= '\x093E' && c <= '\x0940') || 
					(c >= '\x0941' && c <= '\x0948') || 
					(c >= '\x0949' && c <= '\x094C') || 
					(c >= '\x0950') || 
					(c >= '\x0958' && c <= '\x0961') || 
					(c >= '\x0962' && c <= '\x0963') || 
					(c >= '\x0981') || 
					(c >= '\x0982' && c <= '\x0983') || 
					(c >= '\x0985' && c <= '\x098C') || 
					(c >= '\x098F' && c <= '\x0990') || 
					(c >= '\x0993' && c <= '\x09A8') || 
					(c >= '\x09AA' && c <= '\x09B0') || 
					(c >= '\x09B2') || 
					(c >= '\x09B6' && c <= '\x09B9') || 
					(c >= '\x09BD') || 
					(c >= '\x09BE' && c <= '\x09C0') || 
					(c >= '\x09C1' && c <= '\x09C4') || 
					(c >= '\x09C7' && c <= '\x09C8') || 
					(c >= '\x09CB' && c <= '\x09CC') || 
					(c >= '\x09D7') || 
					(c >= '\x09DC' && c <= '\x09DD') || 
					(c >= '\x09DF' && c <= '\x09E1') || 
					(c >= '\x09E2' && c <= '\x09E3') || 
					(c >= '\x09F0' && c <= '\x09F1') || 
					(c >= '\x0A01' && c <= '\x0A02') || 
					(c >= '\x0A03') || 
					(c >= '\x0A05' && c <= '\x0A0A') || 
					(c >= '\x0A0F' && c <= '\x0A10') || 
					(c >= '\x0A13' && c <= '\x0A28') || 
					(c >= '\x0A2A' && c <= '\x0A30') || 
					(c >= '\x0A32' && c <= '\x0A33') || 
					(c >= '\x0A35' && c <= '\x0A36') || 
					(c >= '\x0A38' && c <= '\x0A39') || 
					(c >= '\x0A3E' && c <= '\x0A40') || 
					(c >= '\x0A41' && c <= '\x0A42') || 
					(c >= '\x0A47' && c <= '\x0A48') || 
					(c >= '\x0A4B' && c <= '\x0A4C') || 
					(c >= '\x0A59' && c <= '\x0A5C') || 
					(c >= '\x0A5E') || 
					(c >= '\x0A70' && c <= '\x0A71') || 
					(c >= '\x0A72' && c <= '\x0A74') || 
					(c >= '\x0A81' && c <= '\x0A82') || 
					(c >= '\x0A83') || 
					(c >= '\x0A85' && c <= '\x0A8D') || 
					(c >= '\x0A8F' && c <= '\x0A91') || 
					(c >= '\x0A93' && c <= '\x0AA8') || 
					(c >= '\x0AAA' && c <= '\x0AB0') || 
					(c >= '\x0AB2' && c <= '\x0AB3') || 
					(c >= '\x0AB5' && c <= '\x0AB9') || 
					(c >= '\x0ABD') || 
					(c >= '\x0ABE' && c <= '\x0AC0') || 
					(c >= '\x0AC1' && c <= '\x0AC5') || 
					(c >= '\x0AC7' && c <= '\x0AC8') || 
					(c >= '\x0AC9') || 
					(c >= '\x0ACB' && c <= '\x0ACC') || 
					(c >= '\x0AD0') || 
					(c >= '\x0AE0' && c <= '\x0AE1') || 
					(c >= '\x0AE2' && c <= '\x0AE3') || 
					(c >= '\x0B01') || 
					(c >= '\x0B02' && c <= '\x0B03') || 
					(c >= '\x0B05' && c <= '\x0B0C') || 
					(c >= '\x0B0F' && c <= '\x0B10') || 
					(c >= '\x0B13' && c <= '\x0B28') || 
					(c >= '\x0B2A' && c <= '\x0B30') || 
					(c >= '\x0B32' && c <= '\x0B33') || 
					(c >= '\x0B35' && c <= '\x0B39') || 
					(c >= '\x0B3D') || 
					(c >= '\x0B3E') || 
					(c >= '\x0B3F') || 
					(c >= '\x0B40') || 
					(c >= '\x0B41' && c <= '\x0B43') || 
					(c >= '\x0B47' && c <= '\x0B48') || 
					(c >= '\x0B4B' && c <= '\x0B4C') || 
					(c >= '\x0B56') || 
					(c >= '\x0B57') || 
					(c >= '\x0B5C' && c <= '\x0B5D') || 
					(c >= '\x0B5F' && c <= '\x0B61') || 
					(c >= '\x0B71') || 
					(c >= '\x0B82') || 
					(c >= '\x0B83') || 
					(c >= '\x0B85' && c <= '\x0B8A') || 
					(c >= '\x0B8E' && c <= '\x0B90') || 
					(c >= '\x0B92' && c <= '\x0B95') || 
					(c >= '\x0B99' && c <= '\x0B9A') || 
					(c >= '\x0B9C') || 
					(c >= '\x0B9E' && c <= '\x0B9F') || 
					(c >= '\x0BA3' && c <= '\x0BA4') || 
					(c >= '\x0BA8' && c <= '\x0BAA') || 
					(c >= '\x0BAE' && c <= '\x0BB5') || 
					(c >= '\x0BB7' && c <= '\x0BB9') || 
					(c >= '\x0BBE' && c <= '\x0BBF') || 
					(c >= '\x0BC0') || 
					(c >= '\x0BC1' && c <= '\x0BC2') || 
					(c >= '\x0BC6' && c <= '\x0BC8') || 
					(c >= '\x0BCA' && c <= '\x0BCC') || 
					(c >= '\x0BD7') || 
					(c >= '\x0C01' && c <= '\x0C03') || 
					(c >= '\x0C05' && c <= '\x0C0C') || 
					(c >= '\x0C0E' && c <= '\x0C10') || 
					(c >= '\x0C12' && c <= '\x0C28') || 
					(c >= '\x0C2A' && c <= '\x0C33') || 
					(c >= '\x0C35' && c <= '\x0C39') || 
					(c >= '\x0C3E' && c <= '\x0C40') || 
					(c >= '\x0C41' && c <= '\x0C44') || 
					(c >= '\x0C46' && c <= '\x0C48') || 
					(c >= '\x0C4A' && c <= '\x0C4C') || 
					(c >= '\x0C55' && c <= '\x0C56') || 
					(c >= '\x0C60' && c <= '\x0C61') || 
					(c >= '\x0C82' && c <= '\x0C83') || 
					(c >= '\x0C85' && c <= '\x0C8C') || 
					(c >= '\x0C8E' && c <= '\x0C90') || 
					(c >= '\x0C92' && c <= '\x0CA8') || 
					(c >= '\x0CAA' && c <= '\x0CB3') || 
					(c >= '\x0CB5' && c <= '\x0CB9') || 
					(c >= '\x0CBD') || 
					(c >= '\x0CBE') || 
					(c >= '\x0CBF') || 
					(c >= '\x0CC0' && c <= '\x0CC4') || 
					(c >= '\x0CC6') || 
					(c >= '\x0CC7' && c <= '\x0CC8') || 
					(c >= '\x0CCA' && c <= '\x0CCB') || 
					(c >= '\x0CCC') || 
					(c >= '\x0CD5' && c <= '\x0CD6') || 
					(c >= '\x0CDE') || 
					(c >= '\x0CE0' && c <= '\x0CE1') || 
					(c >= '\x0D02' && c <= '\x0D03') || 
					(c >= '\x0D05' && c <= '\x0D0C') || 
					(c >= '\x0D0E' && c <= '\x0D10') || 
					(c >= '\x0D12' && c <= '\x0D28') || 
					(c >= '\x0D2A' && c <= '\x0D39') || 
					(c >= '\x0D3E' && c <= '\x0D40') || 
					(c >= '\x0D41' && c <= '\x0D43') || 
					(c >= '\x0D46' && c <= '\x0D48') || 
					(c >= '\x0D4A' && c <= '\x0D4C') || 
					(c >= '\x0D57') || 
					(c >= '\x0D60' && c <= '\x0D61') || 
					(c >= '\x0D82' && c <= '\x0D83') || 
					(c >= '\x0D85' && c <= '\x0D96') || 
					(c >= '\x0D9A' && c <= '\x0DB1') || 
					(c >= '\x0DB3' && c <= '\x0DBB') || 
					(c >= '\x0DBD') || 
					(c >= '\x0DC0' && c <= '\x0DC6') || 
					(c >= '\x0DCF' && c <= '\x0DD1') || 
					(c >= '\x0DD2' && c <= '\x0DD4') || 
					(c >= '\x0DD6') || 
					(c >= '\x0DD8' && c <= '\x0DDF') || 
					(c >= '\x0DF2' && c <= '\x0DF3') || 
					(c >= '\x0E01' && c <= '\x0E30') || 
					(c >= '\x0E31') || 
					(c >= '\x0E32' && c <= '\x0E33') || 
					(c >= '\x0E34' && c <= '\x0E3A') || 
					(c >= '\x0E40' && c <= '\x0E45') || 
					(c >= '\x0E46') || 
					(c >= '\x0E4D') || 
					(c >= '\x0E81' && c <= '\x0E82') || 
					(c >= '\x0E84') || 
					(c >= '\x0E87' && c <= '\x0E88') || 
					(c >= '\x0E8A') || 
					(c >= '\x0E8D') || 
					(c >= '\x0E94' && c <= '\x0E97') || 
					(c >= '\x0E99' && c <= '\x0E9F') || 
					(c >= '\x0EA1' && c <= '\x0EA3') || 
					(c >= '\x0EA5') || 
					(c >= '\x0EA7') || 
					(c >= '\x0EAA' && c <= '\x0EAB') || 
					(c >= '\x0EAD' && c <= '\x0EB0') || 
					(c >= '\x0EB1') || 
					(c >= '\x0EB2' && c <= '\x0EB3') || 
					(c >= '\x0EB4' && c <= '\x0EB9') || 
					(c >= '\x0EBB' && c <= '\x0EBC') || 
					(c >= '\x0EBD') || 
					(c >= '\x0EC0' && c <= '\x0EC4') || 
					(c >= '\x0EC6') || 
					(c >= '\x0ECD') || 
					(c >= '\x0EDC' && c <= '\x0EDD') || 
					(c >= '\x0F00') || 
					(c >= '\x0F40' && c <= '\x0F47') || 
					(c >= '\x0F49' && c <= '\x0F6A') || 
					(c >= '\x0F71' && c <= '\x0F7E') || 
					(c >= '\x0F7F') || 
					(c >= '\x0F80' && c <= '\x0F81') || 
					(c >= '\x0F88' && c <= '\x0F8B') || 
					(c >= '\x0F90' && c <= '\x0F97') || 
					(c >= '\x0F99' && c <= '\x0FBC') || 
					(c >= '\x1000' && c <= '\x1021') || 
					(c >= '\x1023' && c <= '\x1027') || 
					(c >= '\x1029' && c <= '\x102A') || 
					(c >= '\x102C') || 
					(c >= '\x102D' && c <= '\x1030') || 
					(c >= '\x1031') || 
					(c >= '\x1032') || 
					(c >= '\x1036') || 
					(c >= '\x1038') || 
					(c >= '\x1050' && c <= '\x1055') || 
					(c >= '\x1056' && c <= '\x1057') || 
					(c >= '\x1058' && c <= '\x1059') || 
					(c >= '\x10A0' && c <= '\x10C5') || 
					(c >= '\x10D0' && c <= '\x10F8') || 
					(c >= '\x1100' && c <= '\x1159') || 
					(c >= '\x115F' && c <= '\x11A2') || 
					(c >= '\x11A8' && c <= '\x11F9') || 
					(c >= '\x1200' && c <= '\x1206') || 
					(c >= '\x1208' && c <= '\x1246') || 
					(c >= '\x1248') || 
					(c >= '\x124A' && c <= '\x124D') || 
					(c >= '\x1250' && c <= '\x1256') || 
					(c >= '\x1258') || 
					(c >= '\x125A' && c <= '\x125D') || 
					(c >= '\x1260' && c <= '\x1286') || 
					(c >= '\x1288') || 
					(c >= '\x128A' && c <= '\x128D') || 
					(c >= '\x1290' && c <= '\x12AE') || 
					(c >= '\x12B0') || 
					(c >= '\x12B2' && c <= '\x12B5') || 
					(c >= '\x12B8' && c <= '\x12BE') || 
					(c >= '\x12C0') || 
					(c >= '\x12C2' && c <= '\x12C5') || 
					(c >= '\x12C8' && c <= '\x12CE') || 
					(c >= '\x12D0' && c <= '\x12D6') || 
					(c >= '\x12D8' && c <= '\x12EE') || 
					(c >= '\x12F0' && c <= '\x130E') || 
					(c >= '\x1310') || 
					(c >= '\x1312' && c <= '\x1315') || 
					(c >= '\x1318' && c <= '\x131E') || 
					(c >= '\x1320' && c <= '\x1346') || 
					(c >= '\x1348' && c <= '\x135A') || 
					(c >= '\x13A0' && c <= '\x13F4') || 
					(c >= '\x1401' && c <= '\x166C') || 
					(c >= '\x166F' && c <= '\x1676') || 
					(c >= '\x1681' && c <= '\x169A') || 
					(c >= '\x16A0' && c <= '\x16EA') || 
					(c >= '\x16EE' && c <= '\x16F0') || 
					(c >= '\x1700' && c <= '\x170C') || 
					(c >= '\x170E' && c <= '\x1711') || 
					(c >= '\x1712' && c <= '\x1713') || 
					(c >= '\x1720' && c <= '\x1731') || 
					(c >= '\x1732' && c <= '\x1733') || 
					(c >= '\x1740' && c <= '\x1751') || 
					(c >= '\x1752' && c <= '\x1753') || 
					(c >= '\x1760' && c <= '\x176C') || 
					(c >= '\x176E' && c <= '\x1770') || 
					(c >= '\x1772' && c <= '\x1773') || 
					(c >= '\x1780' && c <= '\x17B3') || 
					(c >= '\x17B6') || 
					(c >= '\x17B7' && c <= '\x17BD') || 
					(c >= '\x17BE' && c <= '\x17C5') || 
					(c >= '\x17C6') || 
					(c >= '\x17C7' && c <= '\x17C8') || 
					(c >= '\x17D7') || 
					(c >= '\x17DC') || 
					(c >= '\x1820' && c <= '\x1842') || 
					(c >= '\x1843') || 
					(c >= '\x1844' && c <= '\x1877') || 
					(c >= '\x1880' && c <= '\x18A8') || 
					(c >= '\x18A9') || 
					(c >= '\x1900' && c <= '\x191C') || 
					(c >= '\x1920' && c <= '\x1922') || 
					(c >= '\x1923' && c <= '\x1926') || 
					(c >= '\x1927' && c <= '\x1928') || 
					(c >= '\x1929' && c <= '\x192B') || 
					(c >= '\x1930' && c <= '\x1931') || 
					(c >= '\x1932') || 
					(c >= '\x1933' && c <= '\x1938') || 
					(c >= '\x1950' && c <= '\x196D') || 
					(c >= '\x1970' && c <= '\x1974') || 
					(c >= '\x1D00' && c <= '\x1D2B') || 
					(c >= '\x1D2C' && c <= '\x1D61') || 
					(c >= '\x1D62' && c <= '\x1D6B') || 
					(c >= '\x1E00' && c <= '\x1E9B') || 
					(c >= '\x1EA0' && c <= '\x1EF9') || 
					(c >= '\x1F00' && c <= '\x1F15') || 
					(c >= '\x1F18' && c <= '\x1F1D') || 
					(c >= '\x1F20' && c <= '\x1F45') || 
					(c >= '\x1F48' && c <= '\x1F4D') || 
					(c >= '\x1F50' && c <= '\x1F57') || 
					(c >= '\x1F59') || 
					(c >= '\x1F5B') || 
					(c >= '\x1F5D') || 
					(c >= '\x1F5F' && c <= '\x1F7D') || 
					(c >= '\x1F80' && c <= '\x1FB4') || 
					(c >= '\x1FB6' && c <= '\x1FBC') || 
					(c >= '\x1FBE') || 
					(c >= '\x1FC2' && c <= '\x1FC4') || 
					(c >= '\x1FC6' && c <= '\x1FCC') || 
					(c >= '\x1FD0' && c <= '\x1FD3') || 
					(c >= '\x1FD6' && c <= '\x1FDB') || 
					(c >= '\x1FE0' && c <= '\x1FEC') || 
					(c >= '\x1FF2' && c <= '\x1FF4') || 
					(c >= '\x1FF6' && c <= '\x1FFC') || 
					(c >= '\x2071') || 
					(c >= '\x207F') || 
					(c >= '\x2102') || 
					(c >= '\x2107') || 
					(c >= '\x210A' && c <= '\x2113') || 
					(c >= '\x2115') || 
					(c >= '\x2119' && c <= '\x211D') || 
					(c >= '\x2124') || 
					(c >= '\x2126') || 
					(c >= '\x2128') || 
					(c >= '\x212A' && c <= '\x212D') || 
					(c >= '\x212F' && c <= '\x2131') || 
					(c >= '\x2133' && c <= '\x2134') || 
					(c >= '\x2135' && c <= '\x2138') || 
					(c >= '\x2139') || 
					(c >= '\x213D' && c <= '\x213F') || 
					(c >= '\x2145' && c <= '\x2149') || 
					(c >= '\x2160' && c <= '\x2183') || 
					(c >= '\x3005') || 
					(c >= '\x3006') || 
					(c >= '\x3007') || 
					(c >= '\x3021' && c <= '\x3029') || 
					(c >= '\x3031' && c <= '\x3035') || 
					(c >= '\x3038' && c <= '\x303A') || 
					(c >= '\x303B') || 
					(c >= '\x303C') || 
					(c >= '\x3041' && c <= '\x3096') || 
					(c >= '\x309D' && c <= '\x309E') || 
					(c >= '\x309F') || 
					(c >= '\x30A1' && c <= '\x30FA') || 
					(c >= '\x30FC' && c <= '\x30FE') || 
					(c >= '\x30FF') || 
					(c >= '\x3105' && c <= '\x312C') || 
					(c >= '\x3131' && c <= '\x318E') || 
					(c >= '\x31A0' && c <= '\x31B7') || 
					(c >= '\x31F0' && c <= '\x31FF') || 
					(c >= '\x3400' && c <= '\x4DB5') || 
					(c >= '\x4E00' && c <= '\x9FA5') || 
					(c >= '\xA000' && c <= '\xA48C') || 
					(c >= '\xAC00' && c <= '\xD7A3') || 
					(c >= '\xF900' && c <= '\xFA2D') || 
					(c >= '\xFA30' && c <= '\xFA6A') || 
					(c >= '\xFB00' && c <= '\xFB06') || 
					(c >= '\xFB13' && c <= '\xFB17') || 
					(c >= '\xFB1D') || 
					(c >= '\xFB1E') || 
					(c >= '\xFB1F' && c <= '\xFB28') || 
					(c >= '\xFB2A' && c <= '\xFB36') || 
					(c >= '\xFB38' && c <= '\xFB3C') || 
					(c >= '\xFB3E') || 
					(c >= '\xFB40' && c <= '\xFB41') || 
					(c >= '\xFB43' && c <= '\xFB44') || 
					(c >= '\xFB46' && c <= '\xFBB1') || 
					(c >= '\xFBD3' && c <= '\xFD3D') || 
					(c >= '\xFD50' && c <= '\xFD8F') || 
					(c >= '\xFD92' && c <= '\xFDC7') || 
					(c >= '\xFDF0' && c <= '\xFDFB') || 
					(c >= '\xFE70' && c <= '\xFE74') || 
					(c >= '\xFE76' && c <= '\xFEFC') || 
					(c >= '\xFF21' && c <= '\xFF3A') || 
					(c >= '\xFF41' && c <= '\xFF5A') || 
					(c >= '\xFF66' && c <= '\xFF6F') || 
					(c >= '\xFF70') || 
					(c >= '\xFF71' && c <= '\xFF9D') || 
					(c >= '\xFF9E' && c <= '\xFF9F') || 
					(c >= '\xFFA0' && c <= '\xFFBE') || 
					(c >= '\xFFC2' && c <= '\xFFC7') || 
					(c >= '\xFFCA' && c <= '\xFFCF') || 
					(c >= '\xFFD2' && c <= '\xFFD7') || 
					(c >= '\xFFDA' && c <= '\xFFDC') == false)
				{
					// Kein Wort-Zeichen
					newWord = false;
				}
				else
				{
					// Wort-Zeichen
					if (newWord == false) 
						count++;
					newWord = true;
				}
			}
			
			return count;
		}
	}
}
