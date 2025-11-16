
namespace CSharpCatalog.Utilities.Extensions;

using System.Diagnostics.CodeAnalysis;

public static class StringExtensions
{
    extension(string? value)
    {
        [return: NotNullIfNotNull(nameof(value))]
        public string? SingleQuoted()
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return $"'{value}'";
        }

        [return: NotNullIfNotNull(nameof(value))]
        public string? DoubleQuoted()
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return $"\"{value}\"";
        }

        [return: NotNullIfNotNull(nameof(value))]
        public string? Parenthesized()
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return $"({value})";
        }

        [return: NotNullIfNotNull(nameof(value))]
        public string? SquareBracketed()
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return $"[{value}]";
        }
    }

    extension<T>(IEnumerable<T?> values)
    {
        public string Join(char separator)
        {
            return string.Join(separator, values);
        }

        public string Join(string separator)
        {
            return string.Join(separator, values);
        }
    }

    extension(string value)
    {
        public bool ContainsAny(IEnumerable<string> source)
        {
            return source.Any(value.Contains);
        }

        public bool ContainsAny(IEnumerable<string> source, StringComparison comparisonType)
        {
            return source.Any(element => value.Contains(element, comparisonType));
        }
    }
}
