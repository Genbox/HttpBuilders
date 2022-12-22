using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions;

public static class ContentEncodingTypeExtensions
{
    public static string GetMemberValue(this ContentEncodingType type)
    {
        if (type == ContentEncodingType.Unknown)
            throw new ArgumentOutOfRangeException(nameof(type), type, null);

        if (type == ContentEncodingType.Brotli)
            return "br";

        return type.ToString().ToLowerInvariant();
    }
}