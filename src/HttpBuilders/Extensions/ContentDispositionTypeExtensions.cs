using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions;

public static class ContentDispositionTypeExtensions
{
    public static string GetMemberValue(this ContentDispositionType type)
    {
        return type switch
        {
            ContentDispositionType.Inline => "inline",
            ContentDispositionType.Attachment => "attachment",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}