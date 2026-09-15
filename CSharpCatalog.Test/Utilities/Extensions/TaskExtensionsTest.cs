namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;
using Shouldly;

[TestClass]
public class TaskExtensionsTest
{
    [TestMethod]
    public async Task WhenAll_CompletesWhenAllTasksComplete()
    {
        TaskCompletionSource[] sources = [new(), new(), new()];
        var task = sources.Select(source => source.Task).WhenAll();

        foreach (var source in sources)
        {
            task.IsCompleted.ShouldBeFalse();
            source.SetResult();
        }

        await task;
        task.IsCompleted.ShouldBeTrue();
    }

    [TestMethod]
    public async Task WhenAll_EmptyTasks_CompletesImmediately()
    {
        var task = Array.Empty<Task>().WhenAll();
        task.IsCompleted.ShouldBeTrue();
    }

    [TestMethod]
    [DataRow(new bool[] {  true, false,  true })]
    [DataRow(new bool[] { false,  true, false })]
    public async Task WhenAll_ReturnsResultsOfAllTasks(bool[] results)
    {
        TaskCompletionSource<bool>[] sources = [new(), new(), new()];
        var task = sources.Select(source => source.Task).WhenAll();

        foreach (var (source, result) in sources.Zip(results))
        {
            task.IsCompleted.ShouldBeFalse();
            source.SetResult(result);
        }

        (await task).ShouldBe(results);
        task.IsCompleted.ShouldBeTrue();
    }

    [TestMethod]
    public async Task WhenAll_EmptyTasks_ReturnsEmpty()
    {
        var task = Array.Empty<Task<bool>>().WhenAll();

        (await task).ShouldBe(Enumerable.Empty<bool>());
        task.IsCompleted.ShouldBeTrue();
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(2)]
    public async Task WhenAny_CompletesWhenAnyTaskCompletes(int index)
    {
        TaskCompletionSource[] sources = [new(), new(), new()];
        var task = sources.Select(source => source.Task).WhenAny();

        task.IsCompleted.ShouldBeFalse();
        sources[index].SetResult();
        task.IsCompleted.ShouldBeTrue();

        (await task).ShouldBe(sources[index].Task);
    }

    [TestMethod]
    public async Task WhenAny_EmptyTasks_ThrowsArgumentException()
    {
        await Should.ThrowAsync<ArgumentException>(() => Array.Empty<Task>().WhenAny());
    }

    [TestMethod]
    [DataRow(0, true)]
    [DataRow(2, false)]
    public async Task WhenAny_ReturnsFirstCompletedTask(int index, bool result)
    {
        TaskCompletionSource<bool>[] sources = [new(), new(), new()];
        var task = sources.Select(source => source.Task).WhenAny();

        task.IsCompleted.ShouldBeFalse();
        sources[index].SetResult(result);
        task.IsCompleted.ShouldBeTrue();

        (await task).ShouldBe(sources[index].Task);
        (await await task).ShouldBe(result);
    }

    [TestMethod]
    public async Task WhenAny_EmptyTasksOfT_ThrowsArgumentException()
    {
        await Should.ThrowAsync<ArgumentException>(() => Array.Empty<Task<bool>>().WhenAny());
    }
}
