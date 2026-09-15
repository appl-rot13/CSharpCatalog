namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;
using Shouldly;

[TestClass]
public class TimeSpanExtensionsTest
{
    [TestMethod]
    [DataRow(0.999, 0)]
    [DataRow(1.000, 1)]
    [DataRow(1.999, 1)]
    [DataRow(2.000, 2)]
    public void TruncateToSeconds_ReturnsTruncatedValue(double inputSeconds, long expectedSeconds)
    {
        var actual = TimeSpan.FromSeconds(inputSeconds).TruncateToSeconds();
        actual.ShouldBe(TimeSpan.FromSeconds(expectedSeconds));
    }
}
