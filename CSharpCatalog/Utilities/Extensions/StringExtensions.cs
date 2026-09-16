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

    extension(IEnumerable<string?> values)
    {
        public IEnumerable<string> ExcludeNullOrEmpty()
        {
            return values.Where(value => !string.IsNullOrEmpty(value))!;
        }

        public IEnumerable<string> ExcludeNullOrWhiteSpace()
        {
            return values.Where(value => !string.IsNullOrWhiteSpace(value))!;
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

    extension(string text)
    {
        public bool ContainsAny(IEnumerable<string> keywords)
        {
            return keywords.Any(text.Contains);
        }

        public bool ContainsAny(IEnumerable<string> keywords, StringComparison comparisonType)
        {
            return keywords.Any(keyword => text.Contains(keyword, comparisonType));
        }
    }
}
