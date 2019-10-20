using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class ContentEncodingTypeExtensions
    {
        public static string GetMemberValue(this ContentEncodingType type)
        {
            if (type == ContentEncodingType.Unknown)
                throw new ArgumentOutOfRangeException(nameof(type), type, null);

            return type.ToString().ToLowerInvariant();
        }
    }
}