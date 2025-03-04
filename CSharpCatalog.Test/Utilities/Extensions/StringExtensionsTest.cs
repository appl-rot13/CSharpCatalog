
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class StringExtensionsTest
{
    [TestMethod]
    public void SingleQuotedTest()
    {
        "test".SingleQuoted().ShouldBe("'test'");

        string.Empty.SingleQuoted().ShouldBe(string.Empty);
        ((string?)null).SingleQuoted().ShouldBeNull();
    }

    [TestMethod]
    public void DoubleQuotedTest()
    {
        "test".DoubleQuoted().ShouldBe("\"test\"");

        string.Empty.DoubleQuoted().ShouldBe(string.Empty);
        ((string?)null).DoubleQuoted().ShouldBeNull();
    }

    [TestMethod]
    public void ParenthesizedTest()
    {
        "test".Parenthesized().ShouldBe("(test)");

        string.Empty.Parenthesized().ShouldBe(string.Empty);
        ((string?)null).Parenthesized().ShouldBeNull();
    }

    [TestMethod]
    public void SquareBracketedTest()
    {
        "test".SquareBracketed().ShouldBe("[test]");

        string.Empty.SquareBracketed().ShouldBe(string.Empty);
        ((string?)null).SquareBracketed().ShouldBeNull();
    }

    [TestMethod]
    public void JoinWithCharSeparatorTest()
    {
        new[] { "a", "b", "c" }.Join(',').ShouldBe("a,b,c");
        new[] { "a", null, "c" }.Join(',').ShouldBe("a,,c");

        Enumerable.Empty<string>().Join(',').ShouldBe(string.Empty);
    }

    [TestMethod]
    public void JoinWithStringSeparatorTest()
    {
        new[] { "a", "b", "c" }.Join(",").ShouldBe("a,b,c");
        new[] { "a", null, "c" }.Join(",").ShouldBe("a,,c");

        Enumerable.Empty<string>().Join(",").ShouldBe(string.Empty);
    }

    [TestMethod]
    public void ContainsAnyTest()
    {
        "cdefg".ContainsAny(["abc", "def", "ghi"]).ShouldBeTrue();
        "CDEFG".ContainsAny(["abc", "def", "ghi"]).ShouldBeFalse();

        "cdefg".ContainsAny([]).ShouldBeFalse();
    }

    [TestMethod]
    public void ContainsAnyWithStringComparisonTest()
    {
        "cdefg".ContainsAny(["abc", "def", "ghi"], StringComparison.Ordinal).ShouldBeTrue();
        "CDEFG".ContainsAny(["abc", "def", "ghi"], StringComparison.Ordinal).ShouldBeFalse();
        "cdefg".ContainsAny(["abc", "def", "ghi"], StringComparison.OrdinalIgnoreCase).ShouldBeTrue();
        "CDEFG".ContainsAny(["abc", "def", "ghi"], StringComparison.OrdinalIgnoreCase).ShouldBeTrue();

        "cdefg".ContainsAny([], StringComparison.Ordinal).ShouldBeFalse();
    }
}
