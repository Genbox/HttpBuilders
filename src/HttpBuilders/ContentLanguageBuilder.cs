using System.Text;
using EnumsNET;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Internal.Collections;
using Genbox.HttpBuilders.Internal.Extensions;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The Content-Language entity header is used to describe the language(s) intended for the audience, so that it allows a
    /// user to differentiate according to the users' own preferred language.
    /// See https://tools.ietf.org/html/rfc7231#section-3.1.3.2
    /// </summary>
    public class ContentLanguageBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<string> _languages;

        public string Build()
        {
            if (_languages == null)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(", ", _languages);
            return sb.ToString();
        }

        public ContentLanguageBuilder Add(Language language)
        {
            return Add(language.AsString(EnumFormat.DisplayName));
        }

        public ContentLanguageBuilder Add(string language)
        {
            if (_languages == null)
                _languages = new ConstantGrowArray<string>(1);

            _languages.Add(language);

            return this;
        }
    }
}