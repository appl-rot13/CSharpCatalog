
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StringExtensionsTest
{
    [TestMethod]
    public void SingleQuotedTest()
    {
        "test".SingleQuoted().Is("'test'");

        string.Empty.SingleQuoted().Is(string.Empty);
        ((string?)null).SingleQuoted().IsNull();
    }

    [TestMethod]
    public void DoubleQuotedTest()
    {
        "test".DoubleQuoted().Is("\"test\"");

        string.Empty.DoubleQuoted().Is(string.Empty);
        ((string?)null).DoubleQuoted().IsNull();
    }

    [TestMethod]
    public void ParenthesizedTest()
    {
        "test".Parenthesized().Is("(test)");

        string.Empty.Parenthesized().Is(string.Empty);
        ((string?)null).Parenthesized().IsNull();
    }

    [TestMethod]
    public void SquareBracketedTest()
    {
        "test".SquareBracketed().Is("[test]");

        string.Empty.SquareBracketed().Is(string.Empty);
        ((string?)null).SquareBracketed().IsNull();
    }

    [TestMethod]
    public void JoinWithCharSeparatorTest()
    {
        new[] { "a", "b", "c" }.Join(',').Is("a,b,c");
        new[] { "a", null, "c" }.Join(',').Is("a,,c");

        Enumerable.Empty<string>().Join(',').Is(string.Empty);
    }

    [TestMethod]
    public void JoinWithStringSeparatorTest()
    {
        new[] { "a", "b", "c" }.Join(",").Is("a,b,c");
        new[] { "a", null, "c" }.Join(",").Is("a,,c");

        Enumerable.Empty<string>().Join(",").Is(string.Empty);
    }

    [TestMethod]
    public void ContainsAnyTest()
    {
        "cdefg".ContainsAny(["abc", "def", "ghi"]).IsTrue();
        "CDEFG".ContainsAny(["abc", "def", "ghi"]).IsFalse();

        "cdefg".ContainsAny([]).IsFalse();
    }

    [TestMethod]
    public void ContainsAnyWithStringComparisonTest()
    {
        "cdefg".ContainsAny(["abc", "def", "ghi"], StringComparison.Ordinal).IsTrue();
        "CDEFG".ContainsAny(["abc", "def", "ghi"], StringComparison.Ordinal).IsFalse();
        "cdefg".ContainsAny(["abc", "def", "ghi"], StringComparison.OrdinalIgnoreCase).IsTrue();
        "CDEFG".ContainsAny(["abc", "def", "ghi"], StringComparison.OrdinalIgnoreCase).IsTrue();

        "cdefg".ContainsAny([], StringComparison.Ordinal).IsFalse();
    }
}
