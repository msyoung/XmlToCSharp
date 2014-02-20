using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_nested_list_xml
    {
        private readonly IEnumerable<Class> _classInfo;
        private readonly Class _nestedClass;
        private readonly Class _xmlClass;

        public When_nested_list_xml()
        {
            const string xml = @"<xml><nested title=""bob""></nested><nested title=""bob2""></nested></xml>";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
            _nestedClass = _classInfo.Single(x => x.Name == "nested");
            _xmlClass = _classInfo.Single(x => x.Name == "xml");
        }

        public void Then_class_count_is_two()
        {
            _classInfo.Should().HaveCount(2);
        }

        public void Then_xml_class_has_one_field()
        {
            _xmlClass.Fields.Should().HaveCount(1);
        }

        public void Then_nested_class_has_one_field()
        {
            _nestedClass.Fields.Should().HaveCount(1);
        }

        public void Then_xml_class_has_one_field_with_type_List_Of_nested_class()
        {
            _xmlClass.Fields.Single().Type.Should().Be("List<nested>");
        }

        public void Then_xml_class_has_one_field_with_xml_type_element()
        {
            _xmlClass.Fields.Single().XmlType.Should().Be(XmlType.Element);
        }

        public void Then_xml_class_has_one_field_with_xml_name_nested()
        {
            _xmlClass.Fields.Single().XmlName.Should().Be("nested");
        }

        public void Then_nested_class_has_one_field_named_title()
        {
            _nestedClass.Fields.First().Name.Should().Be("title");
        }

        public void Then_nested_class_has_one_field_with_type_string()
        {
            _nestedClass.Fields.First().Type.Should().Be("String");
        }

        public void Then_nested_class_has_one_field_with_xml_type_attribute()
        {
            _nestedClass.Fields.First().XmlType.Should().Be(XmlType.Attribute);
        }

    }
}