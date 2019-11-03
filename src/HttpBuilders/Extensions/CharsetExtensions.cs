using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class CharsetExtensions
    {
        public static string GetMemberValue(this Charset charset)
        {
            switch (charset)
            {
                case Charset.Big5:
                    return "big5";
                case Charset.Euc_jp:
                    return "euc-jp";
                case Charset.Euc_kr:
                    return "euc-kr";
                case Charset.Gb2312:
                    return "gb2312";
                case Charset.Gb18030:
                    return "gb18030";
                case Charset.Gbk:
                    return "gbk";
                case Charset.Iso_2022_jp:
                    return "iso-2022-jp";
                case Charset.Iso_8859_1:
                    return "iso-8859-1";
                case Charset.Iso_8859_2:
                    return "iso-8859-2";
                case Charset.Iso_8859_3:
                    return "iso-8859-3";
                case Charset.Iso_8859_4:
                    return "iso-8859-4";
                case Charset.Iso_8859_5:
                    return "iso-8859-5";
                case Charset.Iso_8859_6:
                    return "iso-8859-6";
                case Charset.Iso_8859_7:
                    return "iso-8859-7";
                case Charset.Iso_8859_8:
                    return "iso-8859-8";
                case Charset.Iso_8859_9:
                    return "iso-8859-9";
                case Charset.Iso_8859_10:
                    return "iso-8859-10";
                case Charset.Iso_8859_11:
                    return "iso-8859-11";
                case Charset.Iso_8859_15:
                    return "iso-8859-15";
                case Charset.Shift_jis:
                    return "shift_jis";
                case Charset.Tis_620:
                    return "tis-620";
                case Charset.Utf_7:
                    return "utf-7";
                case Charset.Utf_8:
                    return "utf-8";
                case Charset.Utf_16:
                    return "utf-16";
                case Charset.Utf_16be:
                    return "utf-16be";
                case Charset.Utf_16le:
                    return "utf-16le";
                case Charset.Utf_32:
                    return "utf-32";
                case Charset.Windows_874:
                    return "windows-874";
                case Charset.Windows_949:
                    return "windows-949";
                case Charset.Windows_1250:
                    return "windows-1250";
                case Charset.Windows_1251:
                    return "windows-1251";
                case Charset.Windows_1252:
                    return "windows-1252";
                case Charset.Windows_1253:
                    return "windows-1253";
                case Charset.Windows_1254:
                    return "windows-1254";
                case Charset.Windows_1255:
                    return "windows-1255";
                case Charset.Windows_1256:
                    return "windows-1256";
                case Charset.Windows_1257:
                    return "windows-1257";
                case Charset.Windows_1258:
                    return "windows-1258";
                default:
                    throw new ArgumentOutOfRangeException(nameof(charset), charset, null);
            }
        }
    }
}