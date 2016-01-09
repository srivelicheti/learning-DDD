using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common
{
    public abstract class Entity
    {
        public Guid ID { get; protected set; }

        public TrackingState State { get; set; }

        public Entity(Guid entityId)
        {
            ID = entityId;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(compareTo, null))
                return false;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (this.GetType() != compareTo.GetType())
                return false;

            return false;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (this.GetType().FullName + ID).GetHashCode();
        }
    }
}
