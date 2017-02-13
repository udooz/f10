namespace F10
{
    using System;

    public static partial class Core
    {   
        public static Option<T> Some<T>(Option<T> value) => new Option<T>(value.Value, value.IsSome);
        public static Option<T> Some<T>(T value) => new Option<T>(value);
        public static readonly NoneObject None = NoneObject._;
        public static Option<T> Some<T>(NoneObject none) => new Option<T>(none);
    }
}
