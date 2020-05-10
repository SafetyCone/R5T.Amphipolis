using System;


namespace R5T.Amphipolis
{
    /// <summary>
    /// Allows wrapping a type <typeparamref name="T"/> in another type.
    /// </summary>
    public class Typed<T> : IEquatable<Typed<T>>
    {
        #region Static

        public static bool operator ==(Typed<T> a, Typed<T> b)
        {
            if (a is null)
            {
                var output = b is null;
                return output;
            }
            else
            {
                var output = a.Equals(b);
                return output;
            }
        }

        public static bool operator !=(Typed<T> a, Typed<T> b)
        {
            var output = !(a == b);
            return output;
        }

        #endregion


        public T Value { get; }


        public Typed(T value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            // No type-check required since (obj as TypedString).GetType() will still return the actual type.

            var objAsTyped = obj as Typed<T>;

            var isEqual = this.Equals(objAsTyped);
            return isEqual;
        }

        protected virtual bool Equals_Value(Typed<T> other)
        {
            var isEqual = this.Value.Equals(other.Value);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public bool Equals(Typed<T> other)
        {
            // Required type-check for derived classes using the base class TypedString.Equals(TypedString).
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Value(other);
            return isEqual;
        }
    }
}
