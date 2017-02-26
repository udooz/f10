namespace F10
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class Core
    {
        public static IEnumerable<T> List<T>(params T[] items) => items.ToList();
        
    }
}
