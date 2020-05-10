using System;


namespace R5T.Amphipolis
{
    public class TypedExtensions
    {
        public static bool ValueEquals<T>(Typed<T> a, Typed<T> b)
        {
            var valueEquals = a.Value.Equals(b.Value);
            return valueEquals;
        }
    }
}
