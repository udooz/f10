namespace F10
{
    using System;

    public static partial class Core
    {
        public static Option<Int32> ParseInt32(this string s)
        {
            int value;
            if(Int32.TryParse(s, out value))
            {
                return Some(value);
            }
            return None;
        }
    }
}
