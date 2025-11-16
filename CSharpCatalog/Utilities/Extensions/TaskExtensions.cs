
namespace CSharpCatalog.Utilities.Extensions;

public static class TaskExtensions
{
    extension(IEnumerable<Task> tasks)
    {
        public Task WhenAll()
        {
            return Task.WhenAll(tasks);
        }

        public Task<Task> WhenAny()
        {
            return Task.WhenAny(tasks);
        }
    }

    extension<T>(IEnumerable<Task<T>> tasks)
    {
        public Task<T[]> WhenAll()
        {
            return Task.WhenAll(tasks);
        }

        public Task<Task<T>> WhenAny()
        {
            return Task.WhenAny(tasks);
        }
    }
}
