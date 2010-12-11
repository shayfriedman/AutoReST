using System;

namespace AutoReST.Infrastructure
{
    public class ActionParam
    {
        public string Name { get; set; }
        public bool IsComplexType { get; set; }

        public bool Equals(ActionParam other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && other.IsComplexType.Equals(IsComplexType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ActionParam)) return false;
            return Equals((ActionParam) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ IsComplexType.GetHashCode();
            }
        }
    }
}