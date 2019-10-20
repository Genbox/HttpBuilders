using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class ContentDispositionTypeExtensions
    {
        public static string GetMemberValue(this ContentDispositionType type)
        {
            switch (type)
            {
                case ContentDispositionType.Inline:
                    return "inline";
                case ContentDispositionType.Attachment:
                    return "attachment";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}