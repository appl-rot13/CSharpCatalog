
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
}
