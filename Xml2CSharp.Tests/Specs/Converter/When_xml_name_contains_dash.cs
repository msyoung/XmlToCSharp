using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_xml_name_contains_dash
    {
                private readonly IEnumerable<Class> _classInfo;

                public When_xml_name_contains_dash()
        {
            const string xml = @"
<root-node>
  <inner-node>Some text</inner-node>
</root-node>
";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_class_name_is_stripped_of_dash()
        {
            _classInfo.Single().Name.Should().Be("rootnode");
        }

        public void Then_class_xml_name_stays_true_of_xml()
        {
            _classInfo.Single().XmlName.Should().Be("root-node");
        }

        public void Then_field_name_is_stripped_of_dash()
        {
            _classInfo.Single().Fields.Single().Name.Should().Be("innernode");
        }

        public void Then_field_xml_name_stays_true_of_xml()
        {
            _classInfo.Single().Fields.Single().XmlName.Should().Be("inner-node");
        }
    }
}