using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions;

public static class MediaTypeExtensions
{
    public static string GetMemberValue(this MediaType type)
    {
        return type switch
        {
            MediaType.Application_gzip => "application/gzip",
            MediaType.Application_json => "application/json",
            MediaType.Application_msword => "application/msword",
            MediaType.Application_octetstream => "application/octet-stream",
            MediaType.Application_pdf => "application/pdf",
            MediaType.Application_php => "application/php",
            MediaType.Application_rtf => "application/rtf",
            MediaType.Application_xml => "application/xml",
            MediaType.Application_zip => "application/zip",
            MediaType.Audio_3gpp => "audio/3gpp",
            MediaType.Audio_3gpp2 => "audio/3gpp2",
            MediaType.Audio_aac => "audio/aac",
            MediaType.Audio_midi => "audio/midi",
            MediaType.Audio_mpeg => "audio/mpeg",
            MediaType.Audio_ogg => "audio/ogg",
            MediaType.Audio_wav => "audio/wav",
            MediaType.Audio_webm => "audio/webm",
            MediaType.Font_otf => "font/otf",
            MediaType.Font_ttf => "font/ttf",
            MediaType.Font_woff => "font/woff",
            MediaType.Font_woff2 => "font/woff2",
            MediaType.Image_bmp => "image/bmp",
            MediaType.Image_gif => "image/gif",
            MediaType.Image_jpeg => "image/jpeg",
            MediaType.Image_png => "image/png",
            MediaType.Image_tiff => "image/tiff",
            MediaType.Image_webp => "image/webp",
            MediaType.Text_css => "text/css",
            MediaType.Text_csv => "text/csv",
            MediaType.Text_html => "text/html",
            MediaType.Text_javascript => "text/javascript",
            MediaType.Text_plain => "text/plain",
            MediaType.Text_xml => "text/xml",
            MediaType.Video_3gpp => "video/3gpp",
            MediaType.Video_3gpp2 => "video/3gpp2",
            MediaType.Video_mpeg => "video/mpeg",
            MediaType.Video_ogg => "video/ogg",
            MediaType.Video_webm => "video/webm",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}