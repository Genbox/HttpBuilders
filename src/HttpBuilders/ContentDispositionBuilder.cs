using System;
using System.Text;
using EnumsNET;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Options;
using Microsoft.Extensions.Options;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The "Cache-Control" header field is used to specify directives for caches along the request/response chain.
    /// </summary>
    public class ContentDispositionBuilder : IHttpHeaderBuilder
    {
        private string _filename;
        private ContentDispositionType _type;

        public ContentDispositionBuilder()
        {
            Options = Microsoft.Extensions.Options.Options.Create(new ContentDispositionBuilderOptions());
        }

        public ContentDispositionBuilder(IOptions<ContentDispositionBuilderOptions> options)
        {
            Options = options;
        }

        public IOptions<ContentDispositionBuilderOptions> Options { get; }

        public string Build()
        {
            if (_type == ContentDispositionType.Unknown)
                return null;

            if (Options.Value.OmitDefaultDisposition && _type == ContentDispositionType.Inline)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.Append(_type.AsString(EnumFormat.DisplayName));

            if (_filename != null)
                sb.Append("; filename").Append(Options.Value.UseExtendedFilename ? "*" : null).Append("=\"").Append(_filename).Append('"');

            return sb.ToString();
        }

        public void Set(ContentDispositionType type, string filename = null)
        {
            if (type == ContentDispositionType.Attachment && filename == null)
                throw new ArgumentException("You have to supply a filename", nameof(filename));

            if (type == ContentDispositionType.Inline && filename != null)
                throw new ArgumentException("You supplied a filename to Inline. That is not permitted", nameof(filename));

            _type = type;
            _filename = filename;
        }
    }
}