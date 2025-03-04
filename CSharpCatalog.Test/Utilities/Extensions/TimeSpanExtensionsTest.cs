
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class TimeSpanExtensionsTest
{
    [TestMethod]
    public void TruncateToSecondsTest()
    {
        TimeSpan.FromSeconds(1.000).TruncateToSeconds().ShouldBe(TimeSpan.FromSeconds(1));
        TimeSpan.FromSeconds(1.234).TruncateToSeconds().ShouldBe(TimeSpan.FromSeconds(1));
    }
}
