﻿namespace Devdog.General
{
    public class LocalIdentifier : ILocalIdentifier
    {
        public string ID { get; protected set; }

        public LocalIdentifier(string ID)
        {
            this.ID = ID;
        }

        #region Equality comparers

        public static bool operator ==(LocalIdentifier a, LocalIdentifier b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(LocalIdentifier a, LocalIdentifier b)
        {
            return !(a == b);
        }

        public bool Equals(ILocalIdentifier other)
        {
            return ID == other.ID;
        }

        protected bool Equals(LocalIdentifier other)
        {
            return Equals(ID, other.ID);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((LocalIdentifier)obj);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return ID;
        }
    }
}
