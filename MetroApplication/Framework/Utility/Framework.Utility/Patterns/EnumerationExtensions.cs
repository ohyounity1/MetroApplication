using System;
using System.Collections.Generic;

namespace Framework.Utility.Patterns
{
    public static class EnumerationExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> container, Action<T> action)
        {
            foreach (var item in container)
                action(item);
        }
    }
}
