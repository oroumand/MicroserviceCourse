using System.Collections.Generic;
using System.Linq;

namespace Es.Framework
{
    public abstract class ValueObject
    {

        private const int HighPrime = 557927;

        protected abstract IEnumerable<object> GetAtomicValues();

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select((x, i) => (x != null ? x.GetHashCode() : 0) + (HighPrime * i))
                .Aggregate((x, y) => x ^ y);
        }

        public ValueObject GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }

        public bool Equals(ValueObject obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            return GetHashCode() == obj.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((ValueObject)obj);
        }

        public static bool operator ==(ValueObject lhs, ValueObject rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(ValueObject lhs, ValueObject rhs) => !(lhs == rhs);
    }
}
