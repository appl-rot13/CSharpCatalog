
namespace CSharpCatalog.Utilities.Extensions;

using System.Diagnostics.CodeAnalysis;

public static class ArrayExtensions
{
    extension<T>([NotNullWhen(false)] T[]? array)
    {
        public bool IsNullOrEmpty()
        {
            return array == null || array.Length == 0;
        }
    }

    extension(bool[] array)
    {
        public bool IsAllTrue()
        {
            //return array.All(element => element);
            foreach (var element in array.AsSpan())
            {
                if (!element)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
