namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;
using Shouldly;

[TestClass]
public class StringExtensionsTest
{
    [TestMethod]
    [DataRow("test", "'test'")]
    [DataRow(" ", "' '")]
    [DataRow("", "")]
    [DataRow(null, null)]
    public void SingleQuoted_ReturnsExpected(string? input, string? expected)
    {
        input.SingleQuoted().ShouldBe(expected);
    }

    [TestMethod]
    [DataRow("test", "\"test\"")]
    [DataRow(" ", "\" \"")]
    [DataRow("", "")]
    [DataRow(null, null)]
    public void DoubleQuoted_ReturnsExpected(string? input, string? expected)
    {
        input.DoubleQuoted().ShouldBe(expected);
    }

    [TestMethod]
    [DataRow("test", "(test)")]
    [DataRow(" ", "( )")]
    [DataRow("", "")]
    [DataRow(null, null)]
    public void Parenthesized_ReturnsExpected(string? input, string? expected)
    {
        input.Parenthesized().ShouldBe(expected);
    }

    [TestMethod]
    [DataRow("test", "[test]")]
    [DataRow(" ", "[ ]")]
    [DataRow("", "")]
    [DataRow(null, null)]
    public void SquareBracketed_ReturnsExpected(string? input, string? expected)
    {
        input.SquareBracketed().ShouldBe(expected);
    }

    public static IEnumerable<(string?[], char, string)> JoinWithCharSeparatorTestCases()
    {
        return
        [
            (["a", "b" , "c"], ',', "a,b,c"     ),
            (["a", null, "c"], ',', "a,,c"      ),
            ([              ], ',', string.Empty),
        ];
    }

    [TestMethod]
    [DynamicData(nameof(JoinWithCharSeparatorTestCases))]
    public void Join_WithCharSeparator_ReturnsExpected(IEnumerable<string?> source, char separator, string expected)
    {
        source.Join(separator).ShouldBe(expected);
    }

    public static IEnumerable<(string?[], string, string)> JoinWithStringSeparatorTestCases()
    {
        return
        [
            (["a", "b" , "c"], ",", "a,b,c"     ),
            (["a", null, "c"], ",", "a,,c"      ),
            ([              ], ",", string.Empty),
        ];
    }

    [TestMethod]
    [DynamicData(nameof(JoinWithStringSeparatorTestCases))]
    public void Join_WithStringSeparator_ReturnsExpected(IEnumerable<string?> source, string separator, string expected)
    {
        source.Join(separator).ShouldBe(expected);
    }

    [TestMethod]
    [DataRow("cdefg", new string[] { "abc", "def", "ghi" },  true)]
    [DataRow("CDEFG", new string[] { "abc", "def", "ghi" }, false)]
    [DataRow("cdefg", new string[] {                     }, false)]
    public void ContainsAny_ReturnsExpected(string text, IEnumerable<string> keywords, bool expected)
    {
        text.ContainsAny(keywords).ShouldBe(expected);
    }

    [TestMethod]
    [DataRow("cdefg", new string[] { "abc", "def", "ghi" }, StringComparison.Ordinal          ,  true)]
    [DataRow("CDEFG", new string[] { "abc", "def", "ghi" }, StringComparison.Ordinal          , false)]
    [DataRow("cdefg", new string[] { "abc", "def", "ghi" }, StringComparison.OrdinalIgnoreCase,  true)]
    [DataRow("CDEFG", new string[] { "abc", "def", "ghi" }, StringComparison.OrdinalIgnoreCase,  true)]
    [DataRow("cdefg", new string[] {                     }, StringComparison.Ordinal          , false)]
    public void ContainsAny_WithStringComparison_ReturnsExpected(string text, IEnumerable<string> keywords, StringComparison comparisonType, bool expected)
    {
        text.ContainsAny(keywords, comparisonType).ShouldBe(expected);
    }
}
