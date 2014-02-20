using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_simple_xml_with_attribute
    {
        private readonly IEnumerable<Class> _classInfo;

        public When_simple_xml_with_attribute()
        {
            const string xml = @"<xml name=""hello""></xml>";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_class_count_is_one()
        {
            _classInfo.Should().HaveCount(1);
        }

        public void Then_class_name_is_xml()
        {
            _classInfo.First().Name.Should().Be("xml");
        }

        public void Then_class_has_one_field()
        {
            _classInfo.First().Fields.Should().HaveCount(1);
        }

        public void Then_class_has_one_field_named_hello()
        {
            _classInfo.First().Fields.First().Name.Should().Be("name");
        }

        public void Then_class_has_one_field_with_type_string()
        {
            _classInfo.First().Fields.First().Type.Should().Be("String");            
        }

        public void Then_class_has_one_field_with_xml_type_attribute()
        {
            _classInfo.First().Fields.First().XmlType.Should().Be(XmlType.Attribute);                        
        }

    }
}