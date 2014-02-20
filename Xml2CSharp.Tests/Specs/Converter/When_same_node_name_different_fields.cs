using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_same_node_name_different_fields
    {
        private readonly IEnumerable<Class> _classInfo;
        private readonly Class _nestedClass;
        private Class _xmlClass;

        public When_same_node_name_different_fields()
        {
            const string xml = @"<xml><node field1=""bob""></node><node field2=""bob2""/></xml>";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_classes_are_created_for_each_node()
        {
            _classInfo.Single(x => x.Name == "node");
            _classInfo.Single(x => x.Name == "node2");
        }

        public void Then_node_has_xml_name_of_node()
        {
            _classInfo.Single(x => x.Name == "node").XmlName.Should().Be("node");

        }

        public void Then_node2_has_xml_name_of_node()
        {
            _classInfo.Single(x => x.Name == "node2").XmlName.Should().Be("node");
        }

    }
}