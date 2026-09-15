namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;
using Shouldly;

[TestClass]
public class ArrayExtensionsTest
{
    [TestMethod]
    [DataRow(new int[] { 1, 2, 3 }, false)]
    [DataRow(new int[] {         },  true)]
    [DataRow(null                 ,  true)]
    public void IsNullOrEmpty_ReturnsExpected(int[]? array, bool expected)
    {
        array.IsNullOrEmpty().ShouldBe(expected);
    }

    [TestMethod]
    [DataRow(new bool[] { false       }, false)]
    [DataRow(new bool[] {  true       },  true)]
    [DataRow(new bool[] { false, true }, false)]
    [DataRow(new bool[] {  true, true },  true)]
    [DataRow(new bool[] {             },  true)]
    public void IsAllTrue_ReturnsExpected(bool[] array, bool expected)
    {
        array.IsAllTrue().ShouldBe(expected);
    }
}
