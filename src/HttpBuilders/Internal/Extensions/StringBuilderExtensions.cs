using System.Collections.Generic;
using System.Text;

namespace Genbox.HttpBuilders.Internal.Extensions
{
    internal static class StringBuilderExtensions
    {
        public static StringBuilder AppendJoin<T>(this StringBuilder sb, string separator, IEnumerable<T> values)
        {
            sb.Append(string.Join(separator, values));
            return sb;
        }
    }
}