
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class EnumerableExtensionsTest
{
    [TestMethod]
    public void ExcludeNullStructTest()
    {
        new int?[] { 1, null, 2, null, 3 }.ExcludeNull().ShouldBe([ 1, 2, 3 ]);
    }

    [TestMethod]
    public void ExcludeNullClassTest()
    {
        new[] { "1", null, "2", null, "3" }.ExcludeNull().ShouldBe([ "1", "2", "3" ]);
    }
}
