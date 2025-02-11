
namespace CSharpCatalog.Utilities.Extensions;

using System.Diagnostics.CodeAnalysis;

public static class StringExtensions
{
    [return: NotNullIfNotNull(nameof(value))]
    public static string? SingleQuoted(this string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return $"'{value}'";
    }

    [return: NotNullIfNotNull(nameof(value))]
    public static string? DoubleQuoted(this string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return $"\"{value}\"";
    }

    [return: NotNullIfNotNull(nameof(value))]
    public static string? Parenthesized(this string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return $"({value})";
    }

    [return: NotNullIfNotNull(nameof(value))]
    public static string? SquareBracketed(this string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return $"[{value}]";
    }

    public static string Join<T>(this IEnumerable<T?> values, char separator)
    {
        return string.Join(separator, values);
    }

    public static string Join<T>(this IEnumerable<T?> values, string separator)
    {
        return string.Join(separator, values);
    }

    public static bool ContainsAny(this string value, IEnumerable<string> source)
    {
        return source.Any(value.Contains);
    }

    public static bool ContainsAny(this string value, IEnumerable<string> source, StringComparison comparisonType)
    {
        return source.Any(element => value.Contains(element, comparisonType));
    }
}
