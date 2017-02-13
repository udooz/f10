
namespace F10
{
    using System;
    using System.Collections.Generic;

    public static partial class Core
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> incolls,
            Func<T, R> f)
        {
            foreach (var t in incolls)
            {
                yield return f(t);
            }
        }

        public static Option<R> Map<T, R>(this Option<T> option,
            Func<T, R> f)
        {
            return option.Match(
                (t) => Some(f(t)),
                () => None);
        }
    }
}
