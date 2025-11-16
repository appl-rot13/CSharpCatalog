
namespace CSharpCatalog.Utilities.Extensions;

public static class EnumerableExtensions
{
    extension<T>(IEnumerable<T?> source)
        where T : struct
    {
        public IEnumerable<T> ExcludeNull()
        {
            return source.Where(element => element.HasValue).Select(element => element!.Value);
        }
    }

    extension<T>(IEnumerable<T?> source)
        where T : class
    {
        public IEnumerable<T> ExcludeNull()
        {
            return source.Where(element => element != null)!;
        }
    }
}
