using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace Xml2CSharp.Tests.Specs.Converter
{
    public class When_xml_has_empty_nodes
    {
        private readonly IEnumerable<Class> _classInfo;

        public When_xml_has_empty_nodes()
        {
            const string xml = @"<note>
	<to>Tove</to>
	<from>Jani</from>
	<heading>Reminder</heading>
	<body>Don't forget me this weekend!</body>
</note>
";
            _classInfo = new Xml2CSharpConverer().Convert(xml);
        }

        public void Then_class_count_is_one()
        {
            _classInfo.Should().HaveCount(1);
        }
        
        public void Then_class_name_is_note()
        {
            _classInfo.First().Name.Should().Be("note");
        }

        public void Then_class_has_fields_for_all_the_simple_nodes()
        {
            _classInfo.First().Fields.Should().HaveCount(4);
        }

    }
}