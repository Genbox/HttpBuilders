﻿using System;
using Genbox.HttpBuilders.Enums;

namespace Genbox.HttpBuilders.Extensions
{
    public static class AcceptEncodingTypeExtensions
    {
        public static string GetMemberValue(this AcceptEncodingType type)
        {
            if (type == AcceptEncodingType.Unknown)
                throw new ArgumentOutOfRangeException(nameof(type), type, null);

            if (type == AcceptEncodingType.Star)
                return "*";

            return type.ToString().ToLowerInvariant();
        }
    }
}