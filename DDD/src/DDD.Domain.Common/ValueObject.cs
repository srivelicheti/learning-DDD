using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime;

namespace DDD.Domain.Common
{
    /// <summary>
    /// Implementation of Value object for DDD taken from https://lostechies.com/jimmybogard/2007/06/25/generic-value-object-equality/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> : IEquatable<T>
    where T : ValueObject<T>
    {
        private TrackingState _trackingState;
        public TrackingState TrackingState { get {
                return _trackingState;
            } set {
                if (value == TrackingState.Modified)
                    throw new ArgumentException("Value objects can't be modified, they can only be in one of the other three states");
                _trackingState = value;
            } }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            T other = obj as T;
            return Equals(other);
        }
        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();
            int startValue = 17;
            int multiplier = 59;
            int hashCode = startValue;
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);
                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }
            return hashCode;
        }
        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;
            Type t = GetType();
            Type otherType = other.GetType();
            if (t != otherType)
                return false;
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);
                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }
            return true;
        }
        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();
            List<FieldInfo> fields = new List<FieldInfo>();
            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
#if net46
                t = t.BaseType;
#else 
                throw new NotImplementedException("Imlemetaion required for dotnet core framework ");
#endif
            }
            return fields;
        }
        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return ( ReferenceEquals(x, null) && ReferenceEquals(y,null)) || ( !(ReferenceEquals(x, null)) && x.Equals(y));
        }
        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }
    }
}
