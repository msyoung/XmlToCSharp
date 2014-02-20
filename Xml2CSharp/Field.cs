namespace Xml2CSharp
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public XmlType XmlType { get; set; }
        public string Namespace { get; set; }
        public string XmlName { get; set; }

        protected bool Equals(Field other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Type, other.Type) && XmlType == other.XmlType && string.Equals(Namespace, other.Namespace) && string.Equals(XmlName, other.XmlName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Field) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) XmlType;
                hashCode = (hashCode*397) ^ (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (XmlName != null ? XmlName.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Type: {1}, XmlType: {2}, Namespace: {3}, XmlName: {4}", Name, Type, XmlType, Namespace, XmlName);
        }
    }
}