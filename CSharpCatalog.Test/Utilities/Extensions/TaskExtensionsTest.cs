
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TaskExtensionsTest
{
    [TestMethod]
    public async Task WhenAllTest()
    {
        TaskCompletionSource[] sources = [new(), new(), new()];

        var task = sources.Select(source => source.Task).WhenAll();
        foreach (var source in sources)
        {
            task.IsCompleted.IsFalse();
            source.SetResult();
        }

        await task;
        task.IsCompleted.IsTrue();
    }

    [TestMethod]
    public async Task WhenAllGenericTest()
    {
        TaskCompletionSource<bool>[] sources = [new(), new(), new()];
        bool[] results = [true, false, false];

        var task = sources.Select(source => source.Task).WhenAll();
        foreach (var (source, result) in sources.Zip(results))
        {
            task.IsCompleted.IsFalse();
            source.SetResult(result);
        }

        (await task).IsStructuralEqual(results);
        task.IsCompleted.IsTrue();
    }

    [TestMethod]
    public async Task WhenAnyTest()
    {
        TaskCompletionSource[] sources = [new(), new(), new()];

        var task = sources.Select(source => source.Task).WhenAny();
        task.IsCompleted.IsFalse();

        foreach (var source in sources)
        {
            source.SetResult();
            task.IsCompleted.IsTrue();
        }

        (await task).Is(sources.First().Task);
    }

    [TestMethod]
    public async Task WhenAnyGenericTest()
    {
        TaskCompletionSource<bool>[] sources = [new(), new(), new()];
        bool[] results = [true, false, false];

        var task = sources.Select(source => source.Task).WhenAny();
        task.IsCompleted.IsFalse();

        foreach (var (source, result) in sources.Zip(results))
        {
            source.SetResult(result);
            task.IsCompleted.IsTrue();
        }

        (await task).Is(sources.First().Task);
        (await await task).Is(results.First());
    }
}
