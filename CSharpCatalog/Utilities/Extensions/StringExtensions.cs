
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
}
