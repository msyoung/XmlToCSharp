using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_xml_has_namespaces
    {
        private readonly IEnumerable<Class> _classInfo;

        public When_xml_has_namespaces()
        {
            const string xml = @"<root xmlns:h=""http://www.w3.org/TR/html4/""
xmlns:f=""http://www.w3schools.com/furniture"">

<h:table>
  <h:tr>
    <h:td>Apples</h:td>
    <h:td>Bananas</h:td>
  </h:tr>
</h:table>

<f:table>
  <f:name>African Coffee Table</f:name>
  <f:width>80</f:width>
  <f:length>120</f:length>
</f:table>

</root>
";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_classes_are_created_for_each_of_the_complex_nodes()
        {
            _classInfo.Single(x => x.Name == "root");
            _classInfo.Single(x => x.Name == "table");
            _classInfo.Single(x => x.Name == "table2");
            _classInfo.Single(x => x.Name == "tr");
        }

        public void Then_different_class_names_are_created_for_different_tables()
        {
            _classInfo.Single(x => x.Name == "table" && x.XmlName == "table");
            _classInfo.Single(x => x.Name == "table2" && x.XmlName == "table");
        }

        public void Then_root_node_has_element_attribute_with_correct_namespace_and_element_name_for_different_tables()
        {
            _classInfo.Single(x => x.Name == "root").Fields.Single(f => f.Name == "table" && f.XmlName == "table" && f.Namespace == "http://www.w3.org/TR/html4/");
            _classInfo.Single(x => x.Name == "root").Fields.Single(f => f.Name == "table2" && f.XmlName == "table" && f.Namespace == "http://www.w3schools.com/furniture");
        }

        public void Then_second_table_has_correct_element_types()
        {
            _classInfo.Single(x => x.Name == "table2").Fields.Single(f => f.Name == "name" && f.XmlType == XmlType.Element);
            _classInfo.Single(x => x.Name == "table2").Fields.Single(f => f.Name == "width" && f.XmlType == XmlType.Element);
            _classInfo.Single(x => x.Name == "table2").Fields.Single(f => f.Name == "length" && f.XmlType == XmlType.Element);
        }

        public void Then_root_class_has_both_table_types_as_fields()
        {
            _classInfo.Single(x => x.Name == "root").Fields.Single(f => f.Name == "table");
            _classInfo.Single(x => x.Name == "root").Fields.Single(f => f.Name == "table2");
        }

        public void Then_root_node_has_no_namespace()
        {
            _classInfo.Single(x => x.Name == "root").Namespace.Should().Be("");
        }

        public void Then_table_node_has_namespace_h()
        {
            _classInfo.Single(x => x.Name == "table").Namespace.Should().Be("http://www.w3.org/TR/html4/");
        }

        public void Then_table2_node_has_namespace_f()
        {
            _classInfo.Single(x => x.Name == "table2").Namespace.Should().Be("http://www.w3schools.com/furniture");
        }

        public void Then_field_tr_has_namespace_h()
        {
            _classInfo.Single(x => x.Name == "table").Fields.First(f => f.Name == "tr").Namespace.Should().Be("http://www.w3.org/TR/html4/");
        }

        public void Then_field_name_has_namespace_f()
        {
            _classInfo.Single(x => x.Name == "table2").Fields.First(f => f.Name == "name").Namespace.Should().Be("http://www.w3schools.com/furniture");            
        }
    }
}