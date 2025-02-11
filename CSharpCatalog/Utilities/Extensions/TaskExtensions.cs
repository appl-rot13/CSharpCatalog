
namespace CSharpCatalog.Utilities.Extensions;

public static class TaskExtensions
{
    public static Task WhenAll(this IEnumerable<Task> tasks)
    {
        return Task.WhenAll(tasks);
    }

    public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
    {
        return Task.WhenAll(tasks);
    }

    public static Task<Task> WhenAny(this IEnumerable<Task> tasks)
    {
        return Task.WhenAny(tasks);
    }

    public static Task<Task<T>> WhenAny<T>(this IEnumerable<Task<T>> tasks)
    {
        return Task.WhenAny(tasks);
    }
}
