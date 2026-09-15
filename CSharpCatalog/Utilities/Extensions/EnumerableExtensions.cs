namespace CSharpCatalog.Utilities.Extensions;

public static class EnumerableExtensions
{
    extension<T>(IEnumerable<T?> source)
        where T : struct
    {
        public IEnumerable<T> ExcludeNull()
        {
            return source.OfType<T>();
        }
    }

    extension<T>(IEnumerable<T?> source)
        where T : class
    {
        public IEnumerable<T> ExcludeNull()
        {
            return source.OfType<T>();
        }
    }
}
