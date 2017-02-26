namespace F10
{
    using System;
    using System.Collections.Generic;

    public static partial class Core
    {
        public static R Match<T, R>(this Option<T> option,
            Func<T, R> Some, Func<R> None) =>
                option.IsSome ? Some(option.Value) : None();
        public static R Match<S, F, R>(this Try<S, F> @try,
            Func<S, R> Success, Func<F, R> Failed) =>
                @try.IsSuccess ? Success(@try.Success) : Failed(@try.Failed);
        public static Option<T> Filter<T>(this Option<T> opt, Func<T, bool> predicate)
        {
            return opt.Match((t) => predicate(t) ? opt : None, () => None);
        }
    }
}
