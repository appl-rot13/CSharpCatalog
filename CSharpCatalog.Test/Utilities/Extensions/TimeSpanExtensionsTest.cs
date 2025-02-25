
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TimeSpanExtensionsTest
{
    [TestMethod]
    public void TruncateToSecondsTest()
    {
        TimeSpan.FromSeconds(1.000).TruncateToSeconds().Is(TimeSpan.FromSeconds(1));
        TimeSpan.FromSeconds(1.234).TruncateToSeconds().Is(TimeSpan.FromSeconds(1));
    }
}
