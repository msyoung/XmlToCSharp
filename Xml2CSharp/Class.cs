using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Xml2CSharp
{
    public class Class
    {
        protected bool Equals(Class other)
        {
            return string.Equals(XmlName, other.XmlName) &&  Fields.Matches(other.Fields);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Class) obj);
        }

        public override int GetHashCode()
        {
            return (XmlName != null ? XmlName.GetHashCode() : 0);
        }

        public string Name { get; set; }
        public IEnumerable<Field> Fields { get; set; }
        public string XmlName { get; set; }
        public string Namespace { get; set; }

        public bool IsRepeated(XElement element)
        {
            return element.ElementsAfterSelf(Name).Any();
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Fields: {1}, Namespace: {2}, XmlName: {3}", Name, Fields, Namespace, XmlName);
        }
    }

    public static class FieldsExtensions
    {
        public static bool Matches(this IEnumerable<Field> input, IEnumerable<Field> other)
        {
            return input.OrderBy(f => f.Name).SequenceEqual(other.OrderBy(f => f.Name));
        }
    }
}