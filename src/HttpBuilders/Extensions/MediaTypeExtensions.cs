using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class MediaTypeExtensions
    {
        public static string GetMemberValue(this MediaType type)
        {
            switch (type)
            {
                case MediaType.Application_gzip:
                    return "application/gzip";
                case MediaType.Application_json:
                    return "application/json";
                case MediaType.Application_msword:
                    return "application/msword";
                case MediaType.Application_octetstream:
                    return "application/octet-stream";
                case MediaType.Application_pdf:
                    return "application/pdf";
                case MediaType.Application_php:
                    return "application/php";
                case MediaType.Application_rtf:
                    return "application/rtf";
                case MediaType.Application_xml:
                    return "application/xml";
                case MediaType.Application_zip:
                    return "application/zip";
                case MediaType.Audio_3gpp:
                    return "audio/3gpp";
                case MediaType.Audio_3gpp2:
                    return "audio/3gpp2";
                case MediaType.Audio_aac:
                    return "audio/aac";
                case MediaType.Audio_midi:
                    return "audio/midi";
                case MediaType.Audio_mpeg:
                    return "audio/mpeg";
                case MediaType.Audio_ogg:
                    return "audio/ogg";
                case MediaType.Audio_wav:
                    return "audio/wav";
                case MediaType.Audio_webm:
                    return "audio/webm";
                case MediaType.Font_otf:
                    return "font/otf";
                case MediaType.Font_ttf:
                    return "font/ttf";
                case MediaType.Font_woff:
                    return "font/woff";
                case MediaType.Font_woff2:
                    return "font/woff2";
                case MediaType.Image_bmp:
                    return "image/bmp";
                case MediaType.Image_gif:
                    return "image/gif";
                case MediaType.Image_jpeg:
                    return "image/jpeg";
                case MediaType.Image_png:
                    return "image/png";
                case MediaType.Image_tiff:
                    return "image/tiff";
                case MediaType.Image_webp:
                    return "image/webp";
                case MediaType.Text_css:
                    return "text/css";
                case MediaType.Text_csv:
                    return "text/csv";
                case MediaType.Text_html:
                    return "text/html";
                case MediaType.Text_javascript:
                    return "text/javascript";
                case MediaType.Text_plain:
                    return "text/plain";
                case MediaType.Text_xml:
                    return "text/xml";
                case MediaType.Video_3gpp:
                    return "video/3gpp";
                case MediaType.Video_3gpp2:
                    return "video/3gpp2";
                case MediaType.Video_mpeg:
                    return "video/mpeg";
                case MediaType.Video_ogg:
                    return "video/ogg";
                case MediaType.Video_webm:
                    return "video/webm";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}