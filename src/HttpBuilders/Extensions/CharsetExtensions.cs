using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions;

public static class CharsetExtensions
{
    public static string GetMemberValue(this Charset charset)
    {
        return charset switch
        {
            Charset.Big5 => "big5",
            Charset.Euc_jp => "euc-jp",
            Charset.Euc_kr => "euc-kr",
            Charset.Gb2312 => "gb2312",
            Charset.Gb18030 => "gb18030",
            Charset.Gbk => "gbk",
            Charset.Iso_2022_jp => "iso-2022-jp",
            Charset.Iso_8859_1 => "iso-8859-1",
            Charset.Iso_8859_2 => "iso-8859-2",
            Charset.Iso_8859_3 => "iso-8859-3",
            Charset.Iso_8859_4 => "iso-8859-4",
            Charset.Iso_8859_5 => "iso-8859-5",
            Charset.Iso_8859_6 => "iso-8859-6",
            Charset.Iso_8859_7 => "iso-8859-7",
            Charset.Iso_8859_8 => "iso-8859-8",
            Charset.Iso_8859_9 => "iso-8859-9",
            Charset.Iso_8859_10 => "iso-8859-10",
            Charset.Iso_8859_11 => "iso-8859-11",
            Charset.Iso_8859_15 => "iso-8859-15",
            Charset.Shift_jis => "shift_jis",
            Charset.Tis_620 => "tis-620",
            Charset.Utf_7 => "utf-7",
            Charset.Utf_8 => "utf-8",
            Charset.Utf_16 => "utf-16",
            Charset.Utf_16be => "utf-16be",
            Charset.Utf_16le => "utf-16le",
            Charset.Utf_32 => "utf-32",
            Charset.Windows_874 => "windows-874",
            Charset.Windows_949 => "windows-949",
            Charset.Windows_1250 => "windows-1250",
            Charset.Windows_1251 => "windows-1251",
            Charset.Windows_1252 => "windows-1252",
            Charset.Windows_1253 => "windows-1253",
            Charset.Windows_1254 => "windows-1254",
            Charset.Windows_1255 => "windows-1255",
            Charset.Windows_1256 => "windows-1256",
            Charset.Windows_1257 => "windows-1257",
            Charset.Windows_1258 => "windows-1258",
            _ => throw new ArgumentOutOfRangeException(nameof(charset), charset, null)
        };
    }
}