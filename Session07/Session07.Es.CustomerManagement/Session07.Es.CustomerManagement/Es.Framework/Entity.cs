using System;
using System.Collections.Generic;

namespace Es.Framework
{
    public abstract class Entity 
    {

        public  Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return EqualityComparer<Guid>.Default.Equals(Id, ((Entity)obj).Id);
        }

        public static bool operator ==(Entity lhs, Entity rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Entity lhs, Entity rhs) => !(lhs == rhs);

        public override int GetHashCode()
        {
            if (Id.Equals(default(Guid)))
            {
                return base.GetHashCode();
            }

            return GetType().GetHashCode() ^ Id.GetHashCode();
        }
    }
}
