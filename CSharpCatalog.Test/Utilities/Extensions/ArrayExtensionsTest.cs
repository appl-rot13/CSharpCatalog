
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class ArrayExtensionsTest
{
    [TestMethod]
    public void IsNullOrEmptyTest()
    {
        new[] { 1, 2, 3 }.IsNullOrEmpty().ShouldBeFalse();

        Array.Empty<int>().IsNullOrEmpty().ShouldBeTrue();
        ((int[]?)null).IsNullOrEmpty().ShouldBeTrue();
    }

    [TestMethod]
    public void IsAllTrueTest()
    {
        new[] { true, false }.IsAllTrue().ShouldBeFalse();
        new[] { true, true  }.IsAllTrue().ShouldBeTrue();

        Array.Empty<bool>().IsAllTrue().ShouldBeTrue();
    }
}
