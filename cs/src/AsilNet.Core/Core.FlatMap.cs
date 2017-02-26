namespace F10
{
	using System;

    public static partial class Core
    {
        public static Option<R> FlatMap<T, R>(this Option<T> option, 
			Func<T, Option<R>> f)
            => option.Match(
                (t) => f(t),
                () => None);
    }
}
