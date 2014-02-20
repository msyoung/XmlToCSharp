using System.Collections.Generic;
using FluentAssertions;

namespace Xml2CSharp.Tests.Specs.Pocos
{
    public class When_class_list
    {
        public void Should_return_true_when_using_matching_class_but_different_instance()
        {
            var class1 = new Class
            {
                Name = "Name",
                XmlName = "XmlName",
                Namespace = "Namespace",
                Fields = new[]
                {
                    new Field {Name = "Field1", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                    new Field {Name = "Field2", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                }
            };

            var list = new List<Class> { class1 };
            var class2 = new Class
            {
                Name = "Name",
                XmlName = "XmlName",
                Namespace = "Namespace",
                Fields = new[]
                {
                    new Field {Name = "Field1", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                    new Field {Name = "Field2", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                }
            };

            list.Contains(class2).Should().BeTrue();
        }

        public void Should_return_true_when_using_same_instance()
        {
            var class1 = new Class
            {
                Name = "Name",
                XmlName = "XmlName",
                Namespace = "Namespace",
                Fields = new[]
                {
                    new Field {Name = "Field1", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                    new Field {Name = "Field2", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                }
            };

            var list = new List<Class> { class1 };
           
            list.Contains(class1).Should().BeTrue();
        }

        public void Should_return_false_when_different_type_of_class()
        {
            var class1 = new Class
            {
                Name = "Name",
                XmlName = "XmlName",
                Namespace = "Namespace",
                Fields = new[]
                {
                    new Field {Name = "Field1", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                    new Field {Name = "Field2", Namespace = "Namespace", Type = "String", XmlType = XmlType.Element},
                }
            };

            var list = new List<Class> { class1 };

            list.Contains(new Class()).Should().BeFalse();
        }
    }
}