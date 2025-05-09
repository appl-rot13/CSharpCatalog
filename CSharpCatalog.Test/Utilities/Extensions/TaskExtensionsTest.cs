﻿
namespace CSharpCatalog.Test.Utilities.Extensions;

using CSharpCatalog.Utilities.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

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
            task.IsCompleted.ShouldBeFalse();
            source.SetResult();
        }

        await task;
        task.IsCompleted.ShouldBeTrue();
    }

    [TestMethod]
    public async Task WhenAllGenericTest()
    {
        TaskCompletionSource<bool>[] sources = [new(), new(), new()];
        bool[] results = [true, false, false];

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
    public async Task WhenAnyTest()
    {
        TaskCompletionSource[] sources = [new(), new(), new()];

        var task = sources.Select(source => source.Task).WhenAny();
        task.IsCompleted.ShouldBeFalse();

        foreach (var source in sources)
        {
            source.SetResult();
            task.IsCompleted.ShouldBeTrue();
        }

        (await task).ShouldBe(sources.First().Task);
    }

    [TestMethod]
    public async Task WhenAnyGenericTest()
    {
        TaskCompletionSource<bool>[] sources = [new(), new(), new()];
        bool[] results = [true, false, false];

        var task = sources.Select(source => source.Task).WhenAny();
        task.IsCompleted.ShouldBeFalse();

        foreach (var (source, result) in sources.Zip(results))
        {
            source.SetResult(result);
            task.IsCompleted.ShouldBeTrue();
        }

        (await task).ShouldBe(sources.First().Task);
        (await await task).ShouldBe(results.First());
    }
}
