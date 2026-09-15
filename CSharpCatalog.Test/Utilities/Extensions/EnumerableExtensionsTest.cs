namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;
using Shouldly;

[TestClass]
public class EnumerableExtensionsTest
{
    public static IEnumerable<(int?[], int[])> ExcludeNullValueTypeTestCases()
    {
        return
        [
            ([                ], []),
            ([null, null, null], []),
            ([1,       2,       3], [1, 2, 3]),
            ([1, null, 2, null, 3], [1, 2, 3]),
        ];
    }

    [TestMethod]
    [DynamicData(nameof(ExcludeNullValueTypeTestCases))]
    public void ExcludeNull_ValueType_ReturnsNonNullValues(IEnumerable<int?> source, IEnumerable<int> expected)
    {
        source.ExcludeNull().ShouldBe(expected);
    }

    public static IEnumerable<(string?[], string[])> ExcludeNullReferenceTypeTestCases()
    {
        return
        [
            ([                ], []),
            ([null, null, null], []),
            (["a",       "b",       "c"], ["a", "b", "c"]),
            (["a", null, "b", null, "c"], ["a", "b", "c"]),
        ];
    }

    [TestMethod]
    [DynamicData(nameof(ExcludeNullReferenceTypeTestCases))]
    public void ExcludeNull_ReferenceType_ReturnsNonNullValues(IEnumerable<string?> source, IEnumerable<string> expected)
    {
        source.ExcludeNull().ShouldBe(expected);
    }
}
