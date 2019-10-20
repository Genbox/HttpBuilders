﻿using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class LanguageExtensions
    {
        public static string GetMemberValue(this Language language)
        {
            switch (language)
            {
                case Language.Afar:
                    return "aa";
                case Language.Abkhazian:
                    return "ab";
                case Language.Avestan:
                    return "ae";
                case Language.Afrikaans:
                    return "af";
                case Language.Akan:
                    return "ak";
                case Language.Amharic:
                    return "am";
                case Language.Aragonese:
                    return "an";
                case Language.Arabic:
                    return "ar";
                case Language.Assamese:
                    return "as";
                case Language.Avaric:
                    return "av";
                case Language.Aymara:
                    return "ay";
                case Language.Azerbaijani:
                    return "az";
                case Language.Bashkir:
                    return "ba";
                case Language.Belarusian:
                    return "be";
                case Language.Bulgarian:
                    return "bg";
                case Language.Bihari:
                    return "bh";
                case Language.Bislama:
                    return "bi";
                case Language.Bambara:
                    return "bm";
                case Language.Bengali:
                    return "bn";
                case Language.Tibetan:
                    return "bo";
                case Language.Breton:
                    return "br";
                case Language.Bosnian:
                    return "bs";
                case Language.Catalan:
                    return "ca";
                case Language.Chechen:
                    return "ce";
                case Language.Chamorro:
                    return "ch";
                case Language.Corsican:
                    return "co";
                case Language.Cree:
                    return "cr";
                case Language.Czech:
                    return "cs";
                case Language.ChurchSlavic:
                    return "cu";
                case Language.Chuvash:
                    return "cv";
                case Language.Welsh:
                    return "cy";
                case Language.Danish:
                    return "da";
                case Language.German:
                    return "de";
                case Language.Divehi:
                    return "dv";
                case Language.Dzongkha:
                    return "dz";
                case Language.Ewe:
                    return "ee";
                case Language.GreekModern:
                    return "el";
                case Language.English:
                    return "en";
                case Language.Esperanto:
                    return "eo";
                case Language.Spanish:
                    return "es";
                case Language.Estonian:
                    return "et";
                case Language.Basque:
                    return "eu";
                case Language.Persian:
                    return "fa";
                case Language.Fulah:
                    return "ff";
                case Language.Finnish:
                    return "fi";
                case Language.Fijian:
                    return "fj";
                case Language.Faroese:
                    return "fo";
                case Language.French:
                    return "fr";
                case Language.Frisian:
                    return "fy";
                case Language.Irish:
                    return "ga";
                case Language.Gaelic:
                    return "gd";
                case Language.Galician:
                    return "gl";
                case Language.Guarani:
                    return "gn";
                case Language.Gujarati:
                    return "gu";
                case Language.Manx:
                    return "gv";
                case Language.Hausa:
                    return "ha";
                case Language.Hebrew:
                    return "he";
                case Language.Hindi:
                    return "hi";
                case Language.HiriMotu:
                    return "ho";
                case Language.Croatian:
                    return "hr";
                case Language.Haitian:
                    return "ht";
                case Language.Hungarian:
                    return "hu";
                case Language.Armenian:
                    return "hy";
                case Language.Herero:
                    return "hz";
                case Language.Indonesian:
                    return "id";
                case Language.Igbo:
                    return "ig";
                case Language.SichuanYi:
                    return "ii";
                case Language.Inupiaq:
                    return "ik";
                case Language.Ido:
                    return "io";
                case Language.Icelandic:
                    return "is";
                case Language.Italian:
                    return "it";
                case Language.Inuktitut:
                    return "iu";
                case Language.Japanese:
                    return "ja";
                case Language.Javanese:
                    return "jv";
                case Language.Georgian:
                    return "ka";
                case Language.Kongo:
                    return "kg";
                case Language.Kikuyu:
                    return "ki";
                case Language.Kuanyama:
                    return "kj";
                case Language.Kazakh:
                    return "kk";
                case Language.Kalaallisut:
                    return "kl";
                case Language.CentralKhmer:
                    return "km";
                case Language.Kannada:
                    return "kn";
                case Language.Korean:
                    return "ko";
                case Language.Kanuri:
                    return "kr";
                case Language.Kashmiri:
                    return "ks";
                case Language.Kurdish:
                    return "ku";
                case Language.Komi:
                    return "kv";
                case Language.Cornish:
                    return "kw";
                case Language.Kirghiz:
                    return "ky";
                case Language.Latin:
                    return "la";
                case Language.Luxembourgish:
                    return "lb";
                case Language.Ganda:
                    return "lg";
                case Language.Limburgan:
                    return "li";
                case Language.Lingala:
                    return "ln";
                case Language.Lao:
                    return "lo";
                case Language.Lithuanian:
                    return "lt";
                case Language.LubaKatanga:
                    return "lu";
                case Language.Latvian:
                    return "lv";
                case Language.Malagasy:
                    return "mg";
                case Language.Marshallese:
                    return "mh";
                case Language.Maori:
                    return "mi";
                case Language.Macedonian:
                    return "mk";
                case Language.Malayalam:
                    return "ml";
                case Language.Mongolian:
                    return "mn";
                case Language.Marathi:
                    return "mr";
                case Language.Malay:
                    return "ms";
                case Language.Maltese:
                    return "mt";
                case Language.Burmese:
                    return "my";
                case Language.Nauru:
                    return "na";
                case Language.NorwegianBokmål:
                    return "nb";
                case Language.NdebeleNorth:
                    return "nd";
                case Language.Nepali:
                    return "ne";
                case Language.Ndonga:
                    return "ng";
                case Language.DutchFlemish:
                    return "nl";
                case Language.NorwegianNynorsk:
                    return "nn";
                case Language.Norwegian:
                    return "no";
                case Language.NdebeleSouth:
                    return "nr";
                case Language.Navajo:
                    return "nv";
                case Language.Chichewa:
                    return "ny";
                case Language.Occitan:
                    return "oc";
                case Language.Ojibwa:
                    return "oj";
                case Language.Oromo:
                    return "om";
                case Language.Oriya:
                    return "or";
                case Language.Ossetian:
                    return "os";
                case Language.Panjabi:
                    return "pa";
                case Language.Pali:
                    return "pi";
                case Language.Polish:
                    return "pl";
                case Language.Pushto:
                    return "ps";
                case Language.Portuguese:
                    return "pt";
                case Language.Quechua:
                    return "qu";
                case Language.Romansh:
                    return "rm";
                case Language.Rundi:
                    return "rn";
                case Language.Romanian:
                    return "ro";
                case Language.Russian:
                    return "ru";
                case Language.Kinyarwanda:
                    return "rw";
                case Language.Sanskrit:
                    return "sa";
                case Language.Sardinian:
                    return "sc";
                case Language.Sindhi:
                    return "sd";
                case Language.Sami:
                    return "se";
                case Language.Sango:
                    return "sg";
                case Language.Sinhala:
                    return "si";
                case Language.Slovak:
                    return "sk";
                case Language.Slovenian:
                    return "sl";
                case Language.Samoan:
                    return "sm";
                case Language.Shona:
                    return "sn";
                case Language.Somali:
                    return "so";
                case Language.Albanian:
                    return "sq";
                case Language.Serbian:
                    return "sr";
                case Language.Swati:
                    return "ss";
                case Language.Sotho:
                    return "st";
                case Language.Sundanese:
                    return "su";
                case Language.Swedish:
                    return "sv";
                case Language.Swahili:
                    return "sw";
                case Language.Tamil:
                    return "ta";
                case Language.Telugu:
                    return "te";
                case Language.Tajik:
                    return "tg";
                case Language.Thai:
                    return "th";
                case Language.Tigrinya:
                    return "ti";
                case Language.Turkmen:
                    return "tk";
                case Language.Tagalog:
                    return "tl";
                case Language.Tswana:
                    return "tn";
                case Language.Tonga:
                    return "to";
                case Language.Turkish:
                    return "tr";
                case Language.Tsonga:
                    return "ts";
                case Language.Tatar:
                    return "tt";
                case Language.Twi:
                    return "tw";
                case Language.Tahitian:
                    return "ty";
                case Language.Uighur:
                    return "ug";
                case Language.Ukrainian:
                    return "uk";
                case Language.Urdu:
                    return "ur";
                case Language.Uzbek:
                    return "uz";
                case Language.Venda:
                    return "ve";
                case Language.Vietnamese:
                    return "vi";
                case Language.Volapük:
                    return "vo";
                case Language.Walloon:
                    return "wa";
                case Language.Wolof:
                    return "wo";
                case Language.Xhosa:
                    return "xh";
                case Language.Yiddish:
                    return "yi";
                case Language.Yoruba:
                    return "yo";
                case Language.Zhuang:
                    return "za";
                case Language.Chinese:
                    return "zh";
                case Language.Zulu:
                    return "zu";
                default:
                    throw new ArgumentOutOfRangeException(nameof(language), language, null);
            }
        }
    }
}