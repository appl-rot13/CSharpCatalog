
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class EnumerableExtensionsTest
{
    [TestMethod]
    public void ExcludeNullStructTest()
    {
        new int?[] { 1, null, 2, null, 3 }.ExcludeNull().ToArray().IsStructuralEqual(new[] { 1, 2, 3 });
    }

    [TestMethod]
    public void ExcludeNullClassTest()
    {
        new[] { "1", null, "2", null, "3" }.ExcludeNull().ToArray().IsStructuralEqual(new[] { "1", "2", "3" });
    }
}
