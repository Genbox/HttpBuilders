using System.Text;
using Genbox.HttpBuilders.Abstracts;
using Genbox.HttpBuilders.Enums;
using Genbox.HttpBuilders.Extensions;
using Genbox.HttpBuilders.Internal.Collections;
using Genbox.HttpBuilders.Internal.Extensions;

namespace Genbox.HttpBuilders
{
    /// <summary>
    /// The Content-Language entity header is used to describe the language(s) intended for the audience, so that it allows a user to differentiate
    /// according to the users' own preferred language. For example, if "Content-Language: de-DE" is set, it says that the document is intended for German
    /// language speakers (however, it doesn't indicate the document is written in German. For example, it might be written in English as part of a language
    /// course for German speakers. If you want to indicate which language the document is written in, use the lang attribute instead). For more info, see
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Language
    /// </summary>
    public class ContentLanguageBuilder : IHttpHeaderBuilder
    {
        private ConstantGrowArray<string>? _languages;
        private StringBuilder? _sb;

        public string HeaderName => "Content-Language";

        public string? Build()
        {
            if (!HasData())
                return null;

            if (_sb == null)
                _sb = new StringBuilder(25);
            else
                _sb.Clear();

            _sb.AppendJoin(", ", _languages!);
            return _sb.ToString();
        }

        public void Reset()
        {
            _languages?.Clear();
        }

        public bool HasData()
        {
            return _languages != null && _languages.Count > 0;
        }

        public ContentLanguageBuilder Add(Language language)
        {
            return Add(language.GetMemberValue());
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