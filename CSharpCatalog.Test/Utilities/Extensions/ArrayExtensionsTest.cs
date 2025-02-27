
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ArrayExtensionsTest
{
    [TestMethod]
    public void IsNullOrEmptyTest()
    {
        new[] { 1, 2, 3 }.IsNullOrEmpty().IsFalse();

        Array.Empty<int>().IsNullOrEmpty().IsTrue();
        ((int[]?)null).IsNullOrEmpty().IsTrue();
    }

    [TestMethod]
    public void IsAllTrueTest()
    {
        new[] { true, false }.IsAllTrue().IsFalse();
        new[] { true, true  }.IsAllTrue().IsTrue();

        Array.Empty<bool>().IsAllTrue().IsTrue();
    }
}
